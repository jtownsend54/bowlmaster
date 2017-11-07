using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
	public float thresholdLimit;
	public float distanceToRaise = 50f;

	private Vector3 raiseLowerAmount;

	// Use this for initialization
	void Start () {
		raiseLowerAmount = new Vector3 (0, distanceToRaise, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Raise() {
		if (isStanding ()) {
			gameObject.GetComponent<Rigidbody> ().useGravity = false;
			gameObject.GetComponent<Transform> ().position += raiseLowerAmount;
		}
	}

	public void Lower() {
		gameObject.GetComponent<Rigidbody> ().useGravity = true;
		gameObject.GetComponent<Transform> ().position -= raiseLowerAmount;
	}

	public bool isStanding() {
		Vector3 eulerAngles = GetComponent<Transform> ().eulerAngles;
		float xAngle = getAngleDifference (eulerAngles.x + 90);
		float zAngle = getAngleDifference (eulerAngles.z);

		return zAngle <= thresholdLimit && xAngle <= thresholdLimit;
	}

	/**
	 * Calculate the angle diference from 0. Angle may be positive or negative, 
	 * and relative to 0 or 360. This will normalize everything to be relative to
	 * 0 and return a positive value.
	 */
	float getAngleDifference(float angle) {
		float difference = 0f;
		float absAngle = Mathf.Abs (angle);

		if (absAngle >= 180) {
			difference = 360 - absAngle;
		}

		if (absAngle < 180) {
			difference = absAngle;
		}

		return difference;
	}
}
