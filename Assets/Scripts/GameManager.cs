using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Game manager.
/// Oキーでゲームオーバー
/// Cキーでクリア
/// 両方のシーン切り替えが同時に発生しないようにする
/// </summary>

public class GameManager : MonoBehaviour {
	// 敵のプレハブ
	public GameObject prefTeki;
	// 敵を出現させる数
	public int TekiCount = 4;

	// 効果音
	public AudioClip [] SE;
	public AudioSource SEAudio;
	private static GameManager _instance;

	/// <summary>
	/// 効果音を鳴らす
	/// </summary>
	/// <param name="num">Number.</param>
	public static void PlaySE(int num) {
		_instance.SEAudio.PlayOneShot (_instance.SE [num]);
	}

	// アイテムのプレハブ
	public GameObject prefItem;
	// アイテムを出現させる数
	public int ItemCount = 10;

	// 次のシーンを記録する
	private static string _nextScene = "";
	// 次のシーンを指定する変数。空文字の時は何もしない
	public static string NextScene {
		get { return _nextScene; }
		set {
			// 現在Clearが設定されていないか、
			// あるいは、新しく空文字を設定したい時に設定を許可する
			if (	(_nextScene != "Clear") 
				||	(value == ""))
			{
				_nextScene = value;
				Time.timeScale = 0f;
			}
		}
	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;

		GameParams.SetScore (0);
		_nextScene = "";
		MoveBall.ClearBallCount ();

		_instance = this;

		/*
		// 敵を出現
		for (int i = 0; i < TekiCount; i++) {
			Instantiate (prefTeki);
		}
		// アイテムを出現
		for (int i = 0; i < ItemCount; i++) {
			Instantiate (prefItem);
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		// Oキー
		if (Input.GetKeyDown (KeyCode.O)) {
			NextScene = "GameOver";
		}
		// Cキー
		else if (Input.GetKeyDown (KeyCode.C)) {
			NextScene = "Clear";
			NextScene = "GameOver";
		}
		// Aキー
		else if (Input.GetKey (KeyCode.A)) {
			GameParams.AddScore (100);
		}

		// シーン切り替え処理
		if (NextScene.Length > 0) {
			SceneManager.LoadSceneAsync (NextScene, LoadSceneMode.Additive);
			NextScene = "";
			enabled = false;
		}
	}
}
