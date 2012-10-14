using UnityEngine;
using System.Collections;

public class CameraShaker : MonoBehaviour 
{
	public float ShakeDuration = 0.2f;	// 演出の期間 .
	public float Strngth = 0.5f;		// 演出の強度 .
	
	Vector3 m_startPosition;	// 初期の位置 .
	float m_timer = 0.0f;		// タイマー .
	bool m_isShaking = false;	// 現在演出中か .
	
	void Start()
	{
		// 初期位置保存 .
		m_startPosition = transform.position;	
	}
	
	void Update () 
	{
		if (m_isShaking)
		{
			m_timer += Time.deltaTime;
			if (m_timer >= ShakeDuration)
			{
				// リセット .
				m_timer = 0.0f;
				m_isShaking = false;
				
				// 初期位置に移動 .
				transform.position = m_startPosition;
				return;
			}

			// 移動向きをランダムに獲得 .
			float x = Random.Range(-Strngth, Strngth);
			float y = Random.Range(-Strngth, Strngth);
			float z = Random.Range(-Strngth, Strngth);
			Vector3 move = new Vector3(x, y, z);
			
			// 移動 .
			transform.Translate(move);
		}
	}
	
	void Shake()
	{
		m_isShaking = true;	
	}
}
