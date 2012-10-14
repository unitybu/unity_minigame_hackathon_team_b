using UnityEngine;
using System.Collections;

public class StraightMover : MonoBehaviour 
{
	public float Speed = -4.0f;
	
	void Update () 
	{
		// カメラに向いて近づく .
		float move = Speed * Time.deltaTime;
		transform.Translate(0.0f, 0.0f, move);
	}
}
