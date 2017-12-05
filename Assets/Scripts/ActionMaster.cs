﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	private int bowlCount = 1;
	private int[] bowls = new int[21];

	public Action Bowl(int pins) {
		if (pins > 10 || pins < 0) {
			throw new UnityException ("Pins is out of bounds. Got " + pins);
		}

		bowls [bowlCount - 1] = pins;

		// Last frame, no strike or spare
		if (bowlCount == 20 && (bowls [bowlCount - 2] + pins) < 10) {
			return Action.EndGame;
		}

		// Last frame, picked up the spare
		if (bowlCount == 20 && (bowls [bowlCount - 2] + pins) == 10) {
			bowlCount++;
			return Action.Reset;
		}

		// Player made spare or two strikes to get to last possbile throw
		if (bowlCount == 21) {
			return Action.EndGame;
		}
			
		// Strike
		if (pins == 10) {
			bowlCount += 2;
			return Action.EndTurn;
		}

		// End frame and there are no pins left. -2 is finding the previous score in the frame
		if (bowlCount % 2 == 0) {
			bowlCount ++;
			return Action.EndTurn;
		}

		// Mid Frame
		if (bowlCount % 2 != 0) {
			bowlCount++;
			return Action.Tidy;
		}

		throw new UnityException ("Ran out of actions, not sure what to do");
	}
}