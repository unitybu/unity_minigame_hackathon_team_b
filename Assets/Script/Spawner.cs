using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour 
{
	public List<GameObject> Enemies; // 生成する敵の種類を保存 .
	
	public float NearZ = 0.0f;		// 敵が生まれるもっとも近い位置 . 
	public float FarZ = 40.0f;		// 敵が生まれるもっとも遠い位置 .
	
	public float MinSpawnTime = 0.35f; // 次の敵が生まれる一番早い時間 .
	public float MaxSpawnTime = 1.5f;  // 次の敵が生まれる一番遅い時間 .
	
	float m_nextSpawnTime = 1.0f;		// 次に何時生成するか .
	float m_timer = 0.0f;
	
	void Start () 
	{
		// 次に何時生成するかを決める. 
		m_nextSpawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);
	}
	
	void Update () 
	{
		// もし次の敵を生成する時間になったら .
		m_timer += Time.deltaTime;
		if (m_timer >= m_nextSpawnTime)
		{
			// タイマーをリセットして、次に何時生成するかを決める. 
			m_timer = 0.0f;
			m_nextSpawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);
			
			// オブジェクトの配置箇所を獲得する .
			float middle = 4.0f;
			float x = Random.Range( -middle, middle );
			float y = Random.Range( -middle, middle );
			float z = Random.Range( NearZ, FarZ );;
			
			// 作るオブジェクトの種類を決める .
			int typeToCreat = Random.Range(0, Enemies.Count);

			// オブジェクトを作る .
			Instantiate( Enemies[typeToCreat], new Vector3(x, y, z), Quaternion.identity );
		}
	}
}
