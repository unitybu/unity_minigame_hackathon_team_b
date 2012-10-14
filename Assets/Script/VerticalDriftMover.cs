using UnityEngine;
using System.Collections;

public class VerticalDriftMover : MonoBehaviour {

	public float Speed = -4.0f;
	private float totalDelta = 0.0f;

	void Update () 
	{
		// カメラに向いて近づく .
		float move = Speed * Time.deltaTime;
		totalDelta += Time.deltaTime;
		bool isEven = (int)totalDelta % 2 == 0;
		float dx = isEven ? +0.1F : -0.1F;
		transform.Translate(dx, 0.0f, move);
	}

}
