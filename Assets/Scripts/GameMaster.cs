using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
	public PinSetter pinSetter;
	public Ball ball;

	private ActionMaster actionMaster;

	// Use this for initialization
	void Start () {
		actionMaster = new ActionMaster ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BallThrown(int pins) {
		// Determine the action we need to take
		ActionMaster.Action action = actionMaster.Bowl (pins);

		// Pass our action to the pinSetter/animator to reset, renew, or raise pins
		pinSetter.doAnimation (action);

		// Reset the ball
		ball.Reset();
	}
}
