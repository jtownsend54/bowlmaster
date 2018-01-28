using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
	public PinSetter pinSetter;
	public Ball ball;
	public ScoreDisplay scoreDisplay;

	private List<int> rolls;
	private List<int> scores;

	// Use this for initialization
	void Start () {
		rolls = new List<int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BallThrown(int pins) {
		// Add the new roll to our list
		rolls.Add(pins);

		// Pass our action to the pinSetter/animator to reset, renew, or raise pins
		pinSetter.doAnimation (ActionMaster.NextAction (rolls));

		scores = ScoreMaster.scoreCumulative (rolls);

		scoreDisplay.AddFrameScores (scores);
		scoreDisplay.AddRoll (rolls);

		// Reset the ball
		ball.Reset();
	}
}
