using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject PrefSpawn;
	public int SpawnCount = 5;
	public float MinSpeed = 2f;
	public float MaxSpeed = 8f;
	public Bounds [] SpawnBounds;

	private void OnDrawGizmos() {
		foreach (Bounds pos in SpawnBounds) {
			Gizmos.DrawWireCube (pos.center, pos.size);
		}
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < SpawnCount; i++) {
			int idx = Random.Range (0, SpawnBounds.Length);
			Vector3 pos = new Vector3 (
				Random.Range(SpawnBounds[idx].min.x, SpawnBounds[idx].max.x),
				Random.Range(SpawnBounds[idx].min.y, SpawnBounds[idx].max.y),
				0
			);
			// Instantiate(プレハブ, 座標, 回転)
			// Quaternion.identity = 回転なしをあらわす
			GameObject go = Instantiate<GameObject> (PrefSpawn, pos, Quaternion.identity);

			// 0～360度にあたるラジアンの乱数を求める
			float theta = Random.Range(0f, Mathf.PI*2f);
			// 指定の範囲の長さを求める
			float len = Random.Range(MinSpeed, MaxSpeed);
			// 上記を速度にする
			Vector3 vel = new Vector3(
				Mathf.Cos(theta)*len,
				Mathf.Sin(theta)*len,
				0f
			);
			// 速度を設定
			go.GetComponent<Rigidbody>().velocity = vel;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
