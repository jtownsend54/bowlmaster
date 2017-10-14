using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody>().velocity = new Vector3 (0f, 0f, 200f);
		this.GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
