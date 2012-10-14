using UnityEngine;
using System.Collections;

public class SpiralMover : MonoBehaviour {
	
	public float Radius = 2.5F;
	public float Speed = -4.0F;
	private float totalDelta = 0.0F;
	
	void Start ()
	{
		transform.localPosition = new Vector3(0.0F, 0.0F, 40.0F);
	}
		
	void Update () 
	{
		// カメラに向いて近づく .
		float move = Speed * Time.deltaTime;
		totalDelta += Time.deltaTime;
		float theta = totalDelta / 2.0F * Mathf.PI;
		float x = Radius * Mathf.Cos(theta);
		float y = Radius * Mathf.Sin(theta);
		float z = transform.position.z;
		transform.localPosition = new Vector3(x, y, z);
		transform.Translate(0, 0, move);
	}
}
