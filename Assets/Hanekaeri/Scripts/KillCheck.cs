using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCheck : MonoBehaviour {
	// 使わない場合、StartとUpdateは消してもよい

	// ぶつかった時の処理
	void OnTriggerEnter(Collider col) {
		Destroy (gameObject);
	}

	// マウスが重なった時の処理
	void OnMouseEnter() {
		// ぶつかったら消す
		// Destroy()が、ゲームオブジェクトを消す命令
		// gameObjectと書くと、自分のゲームオブジェクトのインスタンス（＝実体）が入っている

		//Destroy(gameObject);

		//gameObject.SetActive (false);

		// 物理エンジンの時間を止める(今回やりたいことではなかった・・・)
		//Time.timeScale = 0f;
	}
}
