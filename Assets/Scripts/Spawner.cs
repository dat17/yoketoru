using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject PrefSpawn;
    public int SpawnCount = 4;
    public float MinSpeed = 1f;
    public float MaxSpeed = 4f;
    public Bounds [] SpawnBounds;

    private void OnDrawGizmos()
    {
        foreach (Bounds pos in SpawnBounds)
        {
            Gizmos.DrawWireCube(pos.center, pos.size);
        }
    }

    // Use this for initialization
    void Start () {
        for (int i=0; i<SpawnCount;i++)
        {
            // 座標を求める
            int idx = Random.Range(0, SpawnBounds.Length);
            Vector3 pos = new Vector3(
                Random.Range(SpawnBounds[idx].min.x, SpawnBounds[idx].max.x),
                Random.Range(SpawnBounds[idx].min.y, SpawnBounds[idx].max.y),
                0
            );

            // 速度を求める
            float spd = Random.Range(MinSpeed, MaxSpeed);
            // 角度を求める
            float theta = Random.value * 2f * Mathf.PI;
            // 速度ベクトルを求める
            Vector3 vel = new Vector3(
                Mathf.Cos(theta),
                Mathf.Sin(theta),
                0f
            );

            // オブジェクトを生成する
            GameObject go = Instantiate<GameObject>(PrefSpawn, pos, Quaternion.identity);
            go.GetComponent<Rigidbody>().velocity = vel*spd;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
