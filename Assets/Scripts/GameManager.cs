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
	// 次のシーンを指定する変数。空文字の時は何もしない
	public static string NextScene = "";

	// Use this for initialization
	void Start () {
		GameParams.SetScore (0);
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
