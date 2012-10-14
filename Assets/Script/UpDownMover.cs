using UnityEngine;
using System.Collections;

public class UpDownMover : MonoBehaviour 
{
	public float Speed = -4.0f;
	public float upDownMove = 0.02f;
	
	private float curTime;
	private float upDown = 0.0f;
	
	void Update () 
	{
		// カメラに向いて近づく .
		float move = Speed * Time.deltaTime;
		
		// upDown.
		curTime += Time.deltaTime;
		upDown = (int)curTime % 2 == 0 ? upDownMove: upDownMove * -1.0f;

		transform.Translate(0.0f, upDown, move);
	}
}
