using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutter : MonoBehaviour {
	private PinCounter pinCounter;

	// Use this for initialization
	void Start () {
		pinCounter = gameObject.GetComponentInParent<PinCounter> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.GetComponent<Ball> ()) {
			pinCounter.StartCounting ();
		}
	}
}
