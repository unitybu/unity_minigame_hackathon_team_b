using UnityEngine;
using System.Collections;

public class KillableObject : MonoBehaviour 
{
	public int Score = 1; // 破壊時に追加する得点 .
	public int Power = 1; // プレイヤーに与えるダメージ .
	public Color OriginalColour = Color.white; 	 // 初期状態の色
	public Color KillableColour = Color.magenta; // 倒せる状態の色
	
	float m_timer = 0.0f;
	bool m_isDead = false;
	ParticleSystem m_deathEffect = null;
	
	void Start()
	{
		// 処理負担を減らすため、ここでエフェクトへの参照を得る .
		Transform child = transform.GetChild(0);
		m_deathEffect = child.GetComponent<ParticleSystem>();
		
		// 色を変化 .
		renderer.materials[0].color = OriginalColour;		
	}
	
	void Update () 
	{				
		if (!m_isDead)
		{			
			// もし殺せる場所になったら
			if (transform.position.z < GameManager.KillableZ)
			{
				// 色を変更 .				
				renderer.materials[0].color = KillableColour;
			}
			
			// 画面外に移動した場合
			if (transform.position.z < GameManager.OffScreenZ)
			{
				// マネージャーを獲得し。ライフを減少させる .
				GameObject go = GameObject.Find("GameManager");
				GameManager manager = go.GetComponent<GameManager>();
				manager.DamagePlayer(Power);
				
				// 破棄する .
				Destroy(this.gameObject);	
			}			
		}
		else
		{
			// 死んでいる場合、エフェクト再生時間の分生きる .			
			m_timer += Time.deltaTime;
			if (m_timer >= 2.0f)
			{
				// 破棄 .
				Destroy(this.gameObject);	
			}
		}
	}
	
	void OnMouseDown()
	{
		// 一定以上地がづいている場合のみ .
		if (transform.position.z < GameManager.KillableZ)
		{
			// オブジェクトを破棄扱いする .
			m_isDead = true;
			
			// 描画止める .
			renderer.enabled = false;
			
			// エフェクト再生 .
			m_deathEffect.Play();
						
			// ゲームマネージャを獲得する
			GameObject go = GameObject.Find("GameManager");
			GameManager manager = go.GetComponent<GameManager>();
			
			// スコアを足す .
			manager.AddScore(Score);
		}
	}
}
