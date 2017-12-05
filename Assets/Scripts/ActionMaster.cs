using System.Collections;
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
