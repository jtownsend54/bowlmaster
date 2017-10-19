using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {
	private Vector3 startPos;
	private Vector3 endPos;
	private float startTime;
	private float endTime;

	Ball ball;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball> ();
	}

	// Store position and time
	public void DragStart() {
		startPos = Input.mousePosition;
		startTime = Time.time;
	}

	public void DragEnd() {
		endPos = Input.mousePosition;
		endTime = Time.time;
		Vector3 change;

		change.x = endPos.x - startPos.x;
		change.y = endPos.z - startPos.z;
		change.z = endPos.y - startPos.y;

		//ball.GetComponent<Rigidbody> ().velocity = (endPos - startPos) / (endTime - startTime);
		ball.Launch (change / (endTime - startTime));
	}
}
