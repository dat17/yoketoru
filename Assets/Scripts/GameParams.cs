using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameParams : MonoBehaviour {
	// 自分のインスタンス
	private static GameParams _instance;
	// スコアテキスト
	public Text scoreText;
	// スコア
	private static int _score;

	void Awake() {
		_instance = this;
	}

	public static void AddScore(int add) {
		_score += add;
		if (_score > 999999) {
			_score = 999999;
		}
		DrawScore ();
	}

	public static void SetScore(int sc) {
		_score = sc;
		DrawScore ();
	}

	public static void DrawScore() {
		_instance.scoreText.text = "Score " + _score.ToString ("D6");
	}

}
