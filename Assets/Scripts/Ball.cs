using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Vector3 defaultVelocity;
	private Rigidbody ballBody;
	public bool isLaunched = false;

	// Use this for initialization
	void Start () {
		ballBody = this.GetComponent<Rigidbody> ();
		ballBody.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Launch(Vector3 velocity) {
		isLaunched = true;
		ballBody.useGravity = true;
		ballBody.velocity = velocity;
		this.GetComponent<AudioSource> ().Play ();
	}
}
