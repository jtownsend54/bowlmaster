using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
	public PinSetter pinSetter;
	public Ball ball;

	private ScoreMaster scoreMaster;
	private List<int> rolls;

	// Use this for initialization
	void Start () {
		scoreMaster = new ScoreMaster ();
		rolls = new List<int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BallThrown(int pins) {
		// Add the new roll to our list
		rolls.Add(pins);

//		// Determine the action we need to take
//		List<ActionMaster.Action> actions = ActionMaster.NextAction (rolls);

		// Pass our action to the pinSetter/animator to reset, renew, or raise pins
		pinSetter.doAnimation (ActionMaster.NextAction (rolls));

		// Reset the ball
		ball.Reset();
	}
}
