using UnityEngine;
using System.Collections.Generic;

public class TouchChecker : MonoBehaviour
{	
	protected virtual void CheckTouch()
	{
        // タッチ入力が無い場合は,終了する.
		if ( Input.touchCount <= 0 )
		{
			return;	
		}
		
        // 入力を獲得する.
		Touch touch = Input.GetTouch(0);

        // 入力し始めの時のみ処理をする.		
		if ( touch.phase == TouchPhase.Began ) 
		{
            // タッチ位置の獲得.
            Vector2 point = touch.position;

            // タッチ位置から,レイを飛ばす.
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay( point );
			
			if ( Camera.main == null )
			{
				ray = Camera.current.ScreenPointToRay( point );
			}
			
            // もしレイがゲームオブジェクトに当たったら.
			if ( Physics.Raycast( ray, out hit ) ) 
			{
				// 当たったオブジェクトのOnMouseDown() メソッドを呼ぶ.
				hit.transform.gameObject.SendMessage( "OnMouseDown" );
			}
   		}
	}
	
    void Update () 
	{
        CheckTouch();
	}
}
