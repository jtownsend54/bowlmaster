using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	public Text[] frameScores;
	public Text[] rollScores;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddRoll(List<int> rolls) {
		string[] rollsToDisplay = ExpandRolls (rolls).ToArray ();

		for (int i = 0; i < rollsToDisplay.Length; i++) {
			rollScores [i].text = rollsToDisplay [i];
		}
	}

	public void AddFrameScores(List<int> scores) {
		Debug.Log (scores.ToArray ());
		for (int i = 0; i < scores.Count; i++) {
			frameScores [i].text = scores [i].ToString ();
		}
	}

	// Take a list of int rolls and expand them into string we can use to display
	private List<string> ExpandRolls(List<int> rolls) {
		List<string> displayScores = new List<string> ();

		for (int i = 0; i < rolls.Count; i++) {
			if (rolls [i] == 10 && displayScores.Count % 2 == 0) {
				displayScores.Add ("X");
				displayScores.Add (" ");
			} else if (displayScores.Count % 2 == 1 && rolls [i] + rolls[i-1] == 10) {
				displayScores.Add ("/");
			} else {
				displayScores.Add (rolls [i].ToString());
			}
		}

		return displayScores;
	}
}
