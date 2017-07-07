using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		// Fire1キーが押されたら、Gameシーンに切り替え
		if (Input.GetButtonDown("Fire1")) {
			SceneManager.LoadSceneAsync ("Game");
		}
	}
}
