using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
	public float thresholdLimit;

	// Use this for initialization
	void Start () {
		//GetComponent<Transform> ().eulerAngles = new Vector3(0, 0, 5f);
		Debug.Log(name + isStanding());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool isStanding() {
		Vector3 eulerAngles = GetComponent<Transform> ().eulerAngles;
		float xAngle = getAngleDifference (eulerAngles.x);
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
