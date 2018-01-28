using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCounter : MonoBehaviour {
	public GameObject pins;

	private bool ballLeftBox = false;
	private int lastStandingCount = -1;
	private int standingBeforeBallIsThrown;
	private float lastChangeTime;
	
	// Update is called once per frame
	void Update () {
		if (ballLeftBox) {
			//pinCount.text = CountStanding ().ToString ();
			CheckStanding ();
		}
	}

	public void StartCounting() {
		ballLeftBox = true;
		standingBeforeBallIsThrown = CountStanding ();
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
			StopCounting ();
		}
	}

	// The pins have settled after a throw and we need to pass of the score to GameMaster
	void StopCounting() {
		ballLeftBox = false;
		GameMaster gameMaster = GameObject.Find ("GameMaster").GetComponent<GameMaster> ();
		gameMaster.BallThrown(standingBeforeBallIsThrown - lastStandingCount);
		lastStandingCount = -1;
	}
}
