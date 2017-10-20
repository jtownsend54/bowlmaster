using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallPosition : MonoBehaviour {
	public float direction;
	public float distance;
	Ball ball;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball> ();
	}
	
	// Update is called once per frame
	public void MoveStart (float xNudge) {
		// Prevent ball from being nudged after it has been launched
		if (ball.isLaunched) {
			return;
		}

		Vector3 position = ball.transform.position;
		position.x += xNudge;

		// Prevent the ball from being moved outside of the lane
		if (position.x > 50 || position.x < -50) {
			return;
		}

		ball.transform.position = position;
		Debug.Log (ball.transform.position.x);
	}
}
