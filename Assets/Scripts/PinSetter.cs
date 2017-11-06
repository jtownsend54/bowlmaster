﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	public Text pinCount;
	public int lastStandingCount = -1;
	public float distanceToRaise = 50f;
	public GameObject pins;

	private float lastChangeTime;
	private bool ballEnteredBox = false;
	private Ball ball;
	private Vector3 raiseLowerAmount;

	// Use this for initialization
	void Start () {
		pinCount = GameObject.Find("PinCount").GetComponent<Text> ();
		ball = GameObject.FindObjectOfType<Ball> ();
		raiseLowerAmount = new Vector3 (0, distanceToRaise, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (ballEnteredBox) {
			pinCount.text = CountStanding ().ToString ();
			CheckStanding ();
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.GetComponent<Ball>()) {
			pinCount.color = Color.red;
			ballEnteredBox = true;
		}
	}

	void OnTriggerExit(Collider collider) {
		GameObject obj = collider.gameObject;

		if (obj.GetComponent<Pin>()) {
			Destroy (collider.gameObject);
		}
	}

	int CountStanding() {
		int count = 0;

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			if (pin.isStanding ()) {
				count++;
			}
		}

		return count;
	}

	void CheckStanding() {
		int count = CountStanding ();

		if (lastStandingCount != count) {
			lastStandingCount = count;
			lastChangeTime = Time.time;
			return;
		}
			
		// If pin count has remained the same for at least 3 seconds
		if (Time.time - lastChangeTime >= 3) {
			PinsHaveSettled ();
		}
	}

	void PinsHaveSettled() {
		ball.Reset ();
		pinCount.color = Color.green;
		ballEnteredBox = false;
		lastStandingCount = -1;
	}

	public void RaisePins() {
		Debug.Log ("Raise Pins");

		foreach (Pin pin in pins.GetComponentsInChildren<Pin>()) {
			if (pin.isStanding ()) {
				pin.GetComponent<Rigidbody> ().useGravity = false;
				pin.GetComponent<Transform> ().position += raiseLowerAmount;
			}

		}
	}

	public void LowerPins() {
		Debug.Log ("Lower Pins");

		foreach (Pin pin in pins.GetComponentsInChildren<Pin>()) {
			pin.GetComponent<Rigidbody> ().useGravity = true;
			pin.GetComponent<Transform> ().position -= raiseLowerAmount;
		}
	}

	public void RenewPins() {
		Debug.Log ("Renew Pins");
	}
}

