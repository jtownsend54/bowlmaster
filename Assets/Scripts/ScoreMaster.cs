using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Generate the scores for individual frames given a list of roles
 */
public class ScoreMaster {
	public static List<int> scoreCumulative(List<int> rolls) {
		List<int> scores = new List<int> ();
//		ScoreMaster scoreMaster = new ScoreMaster ();
		int bowlCount = 0;
		int totalRolls = 0;
		int cumulative = 0;

		foreach (int roll in rolls) {
			bowlCount++;
			totalRolls++;
			//scores.Add(scoreMaster.generateCumulative (scores, roll));
			// Strike
			if (bowlCount == 1 && roll == 10) {
				// Bring this check inside the outer if so all strikes land here. If our last bowl
				// or second to last bowl is a strike, we do not want to update the score yet
				// because we do not have enough information
				if (rolls.Count >= totalRolls + 2) {
					cumulative += roll;
					cumulative += rolls [totalRolls];
					cumulative += rolls [totalRolls + 1];
				}

				// Set this to two so it gets reset to 0 later
				bowlCount = 2;
			} else if (bowlCount == 2 && roll + rolls[totalRolls - 2] == 10) {
				// Same as strike logic above, if we do not have a next bowl, we do not
				// have enough information to score after a spare
				if (rolls.Count >= totalRolls + 1) {
					cumulative += roll;
					cumulative += rolls [totalRolls];
				}
			} else {
				cumulative += roll;
			}

			scores.Add (cumulative);

			if (bowlCount == 2) {
				bowlCount = 0;
			}
		}

		Debug.Log (scores);

		return scores;
	}

	public static List<int> scoreFrames(List<int> rolls) {
		List<int> frameScores = new List<int> ();

		return frameScores;
	}

//	private int generateCumulative(List<int> scores, int roll) {
//
//	}

//	public void UpdateScore(int pinsStanding) {
//		
//		frameThrows++;
//		int score = previousPinsStanding - pinsStanding;
//
//		// If this is the second throw and pins standing is the same as the last throw, nothing was hit
//		if (frameThrows == 2 && (previousPinsStanding).ToString() == throwsHistory [throwsHistory.Count - 1]) {
//			throwsHistory.Add ("0");
////			pinSetter.GetComponent<Animator> ().SetTrigger ("triggerRenew");
//		} else if (pinsStanding == 0 && frameThrows == 1) {
//			throwsHistory.Add ("X");
//			frameThrows = 0;
////			pinSetter.GetComponent<Animator> ().SetTrigger ("triggerRenew");
//		} else if (pinsStanding == 0 && frameThrows == 2) {
//			throwsHistory.Add ("S");
////			pinSetter.GetComponent<Animator> ().SetTrigger ("triggerRenew");
//		} else {
//			throwsHistory.Add ((previousPinsStanding - pinsStanding).ToString());
////			pinSetter.GetComponent<Animator> ().SetTrigger ("triggerTidy");
//		}
//
////		throwsHistory.Add ("X");
////		throwsHistory.Add ("X");
////		throwsHistory.Add ("2");
////		throwsHistory.Add ("S");
//
//		previousPinsStanding -= score;
//
//		if (frameThrows == 1 && score != 10) {
//			pinSetter.GetComponent<Animator> ().SetTrigger ("triggerTidy");
//		} else {
//			pinSetter.GetComponent<Animator> ().SetTrigger ("triggerRenew");
//		}
//
//		if (frameThrows == 2 || score == 10) {
//			frameThrows = 0;
//			previousPinsStanding = 10;
//		}
//
//
//
//		int scoreToDisplay = 0;
//
//		string scoreList = "";
//		foreach (string temp in throwsHistory) {
//			scoreList += "::" + temp;
//		}
//		Debug.Log (scoreList);
//
//		for (int i = 0; i < throwsHistory.Count; i++) {
//			string frameScore = throwsHistory [i];
//
//			if (frameScore == "S") {
//				continue;
//			}
//
//			if (frameScore == "X" && i + 2 < throwsHistory.Count) {
//				// nextScore will never be a spare
//
//				// Add 10 for the current frame
//				scoreToDisplay += 10;
//
//				string nextScore = throwsHistory [i + 1];
//				string afterScore = throwsHistory [i + 2];
//
//				if (nextScore == "X" || afterScore == "S") {
//					scoreToDisplay += 10;
//				} 
//
//				// Only occurs if nextScore is a X
//				if (afterScore == "X") {
//					scoreToDisplay += 10;
//				}
//
//				if (nextScore != "X" && afterScore != "X" && afterScore != "S") {
//					scoreToDisplay += Int32.Parse (nextScore) + Int32.Parse (afterScore);
//				}
//
//			} else if (i + 2 < throwsHistory.Count && throwsHistory [i + 1] == "S") {
//				scoreToDisplay += 10;
//
//				string nextScore = throwsHistory [i + 2];
//
//				if (nextScore == "X") {
//					scoreToDisplay += 10;
//				} else {
//					scoreToDisplay += Int32.Parse (nextScore);
//				}
//			} else if (frameScore != "S" && frameScore != "X") {
//				scoreToDisplay += Int32.Parse (frameScore);
//			}
//		}
//
//		scoreText.text = scoreToDisplay.ToString ();
//	}
}
