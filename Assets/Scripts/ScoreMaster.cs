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

		int cumulative = 0;

		for (int i = 1; i < rolls.Count; i+=2) {
			if (scores.Count == 10) {
				break;
			}
				
			if (rolls [i-1] + rolls [i] < 10) {
				scores.Add (cumulative += rolls [i-1] + rolls [i]);
			}
				
			// Not enough for a spare or strike, just get out early
			if (rolls.Count - 1 <= i) {
				break;
			}

			// Strike
			if (rolls[i-1] == 10 && rolls.Count >= i + 2) {
				i--;
				cumulative += 10;
				cumulative += rolls[i+1];
				scores.Add (cumulative += rolls[i+2]);
			} else if (rolls[i-1] + rolls[i] == 10) {
				cumulative += 10;
				scores.Add (cumulative += rolls[i+1]);
			
			} 
		}

		return scores;
	}
}
