using UnityEngine;
using System.Collections;

public class BgSpiral : MonoBehaviour {
	
	public float Speed = 4.0f;
	
	// Update is called once per frame
	void Update () {
		float spiral = Time.deltaTime * Speed;
		transform.Rotate(0, 0, spiral);
	}
}
