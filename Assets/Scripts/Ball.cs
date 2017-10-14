using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Vector3 velocity;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody>().velocity = velocity;
		this.GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
