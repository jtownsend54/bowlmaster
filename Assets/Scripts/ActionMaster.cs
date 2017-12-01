using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	public Action Bowl(int pins) {
		if (pins > 10 || pins < 0) {
			throw new UnityException ("Pins is out of bounds. Got " + pins);
		}

		if (pins == 10) {
			return Action.EndTurn;
		}

		throw new UnityException ("Ran out of actions, not sure what to do");
	}
}
