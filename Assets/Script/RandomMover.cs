
using UnityEngine;
using System.Collections;

public class RandomMover : MonoBehaviour 
{
//	public float SpeedX = -0.01f;
//	public float SpeedY = -0.01f;
	public float SpeedZ = -4.0f;
	private float total=0.0f;
	
	void Update () 
	{
		total=total+Time.deltaTime;
		if(total>=2.0f)
		{
			total=0.0f;
			SpeedZ=SpeedZ*-1.0f;
		}
		
		// カメラに向いて近づく .
//		float moveX = SpeedX * Time.deltaTime;
//		float moveY = SpeedY * Time.deltaTime;
		float moveZ = SpeedZ * Time.deltaTime;
		transform.Translate(0.0f, 0.0f, moveZ);
	}
}
