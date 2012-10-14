using UnityEngine;
using System.Collections;

public class GameoverScene : MonoBehaviour 
{
	public string SceneToLoad = "Test"; // 読み込むシーン .
	
	void Update () 
	{
		bool isChangeScene = false;
		
		// タップ入力 .
		if (Input.touchCount > 0 )
		{
			Touch touch = Input.GetTouch(0);
			if ( touch.phase == TouchPhase.Began)
			{
				isChangeScene = true;	
			}
		}
		
		// キーボード入力 .
		if (Input.anyKeyDown)
		{
			isChangeScene = true;	
		}
		
		// 入力確認時 .
		if (isChangeScene)
		{
			// シーン読み込み .
			Application.LoadLevel(SceneToLoad);	
		}
	}
}
