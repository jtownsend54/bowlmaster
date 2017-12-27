using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Vector3 defaultVelocity;
	public bool isLaunched = false;
	private Rigidbody ballBody;
	private Vector3 startingPosition;


	// Use this for initialization
	void Start () {
		ballBody = this.GetComponent<Rigidbody> ();
		ballBody.useGravity = false;
		startingPosition = gameObject.transform.position;
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

	public void Reset() {
		isLaunched 						= false;
		ballBody.useGravity 			= false;
		ballBody.velocity 				= new Vector3(0,0,0);
		ballBody.angularVelocity 		= new Vector3(0,0,0);
		gameObject.transform.position 	= startingPosition;
	}
}
