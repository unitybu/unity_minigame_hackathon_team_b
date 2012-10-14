using UnityEngine;
using System.Collections;

public class GameoverScoreText : MonoBehaviour 
{
	void Start () 
	{
		// スコア表示 .
		TextMesh text = GetComponent<TextMesh>();
		text.text = "Your Score is..." + GameManager.LastScore;
	}
}
