using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	public Text pinCount;
	public int lastStandingCount = -1;
	public GameObject pins;
	public GameObject pinPrefab;
	public ScoreMaster scoreMaster;

	private ActionMaster actionMaster;
	private float lastChangeTime;
	private bool ballEnteredBox = false;
	private int standingBeforeBallIsThrown;
	private Ball ball;

	// Use this for initialization
	void Start () {
		pinCount = GameObject.Find("PinCount").GetComponent<Text> ();
		ball = GameObject.FindObjectOfType<Ball> ();
		actionMaster = new ActionMaster ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ballEnteredBox) {
			pinCount.text = CountStanding ().ToString ();
			CheckStanding ();
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.GetComponent<Ball>()) {
			standingBeforeBallIsThrown = CountStanding ();
			lastStandingCount = -1;
			pinCount.color = Color.red;
			ballEnteredBox = true;
		}
	}

	void OnTriggerExit(Collider collider) {
		GameObject obj = collider.gameObject;

		if (obj.GetComponent<Pin>()) {
			Destroy (collider.gameObject);
		}
	}

	int CountStanding() {
		int count = 0;

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin> ()) {
			if (pin.isStanding ()) {
				count++;
			}
		}

		return count;
	}

	void CheckStanding() {
		int count = CountStanding ();
		int pinsKnockedOver = standingBeforeBallIsThrown - count;

		if (lastStandingCount != count) {
			lastStandingCount = count;
			lastChangeTime = Time.time;
			return;
		}
			
		// If pin count has remained the same for at least 3 seconds
		if (Time.time - lastChangeTime >= 3) {
			//scoreMaster.UpdateScore (lastStandingCount);
			PinsHaveSettled ();
			ActionMaster.Action action = actionMaster.Bowl (pinsKnockedOver);
			doAnimation (action);
		}
	}

	void PinsHaveSettled() {
		ball.Reset ();
		pinCount.color = Color.green;
		ballEnteredBox = false;

	}

	public void RaisePins() {
		foreach (Pin pin in pins.GetComponentsInChildren<Pin>()) {
			pin.Raise ();
		}
	}

	public void LowerPins() {
		foreach (Pin pin in pins.GetComponentsInChildren<Pin>()) {
			pin.Lower ();
		}
	}

	public void RenewPins() {
		Destroy(GameObject.Find("Pins"));

		pins = Instantiate (pinPrefab, new Vector3 (0, 30, 1829), Quaternion.identity);
	}

	private void doAnimation(ActionMaster.Action action) {
		if (action == ActionMaster.Action.Tidy) {
			gameObject.GetComponent<Animator> ().SetTrigger ("triggerTidy");
		} else {
			lastStandingCount = 10;
			gameObject.GetComponent<Animator> ().SetTrigger ("triggerRenew");
		}
	}
}

