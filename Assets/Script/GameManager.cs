using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public static float OffScreenZ = -9.5f;	// 敵を破棄する位置 .
	public static float KillableZ = 8.0f;	// 敵を倒せる用になる位置 .
	public static int LastScore = 0;		// 前回のスコア .
	
	public int Life = 5;					// プレイヤーのライフ .
	public int Score = 0;					// ゲームのスコア .
	
	public GameObject LifeText;
	public GameObject ScoreText;
	GUIText m_lifeText;
	GUIText m_scoreText;
	
	void Start()
	{
		// 処理軽減の為に、コンポーネントを今獲得 .
		if (LifeText != null && ScoreText != null)
		{
			m_lifeText = LifeText.GetComponent<GUIText>();
			m_scoreText = ScoreText.GetComponent<GUIText>();
		}
	}
	
	void Update () 
	{
		// 戻るキーが押されたかを確認
		if (Input.GetKey(KeyCode.Escape))
		{
			// ゲーム終了
			Application.Quit();		
		}
	
		// UIを更新 .
		if (LifeText != null && ScoreText != null)
		{
			m_lifeText.text = "LIFE: " + Life.ToString();
			m_scoreText.text = "SCORE: " + Score.ToString();
		}
	}
	
	public void DamagePlayer(int damage)
	{		
		// ライフを減らす .
		Life -= damage;
		
		// カメラ移動.
		GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
		camera.SendMessage("Shake");
		
		// if player is dead
		if (Life <= 0)
		{
			// ゲームオーバー .スコアを保存し、シーン移動	
			LastScore = Score;
			Application.LoadLevel("GameOver");
		}
	}
	
	public void AddScore(int score)
	{
		Score += score;	
	}
	
	public void ResetGame()
	{
		Life = 5;
		Score = 0;
	}
}
