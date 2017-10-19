using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Vector3 defaultVelocity;
	private Rigidbody ballBody;

	// Use this for initialization
	void Start () {
		ballBody = this.GetComponent<Rigidbody> ();
		ballBody.useGravity = false;

		//Launch (defaultVelocity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Launch(Vector3 velocity) {
		ballBody.useGravity = true;
		ballBody.velocity = velocity;
		this.GetComponent<AudioSource> ().Play ();
	}
}
