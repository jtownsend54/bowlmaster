using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	/**
	 * Given a list of rolls, return the actions for each
	 */
	public static Action NextAction(List<int> rolls) {
		Action lastAction = new Action();
		int[] bowls = new int[21];
		int bowlCount = 1;

		foreach (int roll in rolls) {
			if (roll > 10 || roll < 0) {
				throw new UnityException ("Pins is out of bounds. Got " + roll);
			}

			bowls [bowlCount - 1] = roll;

			// If the player scores a strike on the first or second throw of the last frame
			if (bowlCount == 19 && roll == 10) {
				bowlCount++;
				lastAction = Action.Reset;
				continue;
			}

			if (bowlCount == 20) {
				// Last frame, no strike or spare
				if ((bowls [bowlCount - 2] + roll) < 10) {
					lastAction = Action.EndGame;
					continue;
				}

				// Strike, then partial pins
				if ((bowls [bowlCount - 2]) == 10 && roll < 10) {
					bowlCount++;
					lastAction = Action.Tidy;
					continue;
				}

				// Picked up the spare using 19 and 20
				if ((bowls [bowlCount - 2]) + roll >= 10) {
					bowlCount++;
					lastAction = Action.Reset;
					continue;
				}
			}


			// Player made spare or two strikes to get to last possbile throw
			if (bowlCount == 21) {
				lastAction = Action.EndGame;
				continue;
			}

			// End frame and there are no pins left. -2 is finding the previous score in the frame
			if (bowlCount % 2 == 0) {
				bowlCount ++;
				lastAction = Action.EndTurn;
				continue;
			}

			// Strike
			if (roll == 10) {
				bowlCount += 2;
				lastAction = Action.EndTurn;
				continue;
			}

			// Mid Frame
			if (bowlCount % 2 != 0) {
				bowlCount++;
				lastAction = Action.Tidy;
				continue;
			}

			throw new UnityException ("Ran out of actions, not sure what to do");
		}

		return lastAction;
	}

//	/**
//	 * Determine what action is needed based on a single roll
//	 */
//	private static Action Bowl(int pins) {
//		// If the player scores a strike on the first or second throw of the last frame
//		if (bowlCount == 19 && pins == 10) {
//			bowlCount++;
//			return Action.Reset;
//		}
//
//		if (bowlCount == 20) {
//			// Last frame, no strike or spare
//			if ((bowls [bowlCount - 2] + pins) < 10) {
//				return Action.EndGame;
//			}
//
//			// Strike, then partial pins
//			if ((bowls [bowlCount - 2]) == 10 && pins < 10) {
//				bowlCount++;
//				return Action.Tidy;
//			}
//
//			// Picked up the spare using 19 and 20
//			if ((bowls [bowlCount - 2]) + pins >= 10) {
//				bowlCount++;
//				return Action.Reset;
//			}
//		}
//
//
//		// Player made spare or two strikes to get to last possbile throw
//		if (bowlCount == 21) {
//			return Action.EndGame;
//		}
//
//		// End frame and there are no pins left. -2 is finding the previous score in the frame
//		if (bowlCount % 2 == 0) {
//			bowlCount ++;
//			return Action.EndTurn;
//		}
//			
//		// Strike
//		if (pins == 10) {
//			bowlCount += 2;
//			return Action.EndTurn;
//		}
//
//		// Mid Frame
//		if (bowlCount % 2 != 0) {
//			bowlCount++;
//			return Action.Tidy;
//		}
//
//		throw new UnityException ("Ran out of actions, not sure what to do");
//	}
}
