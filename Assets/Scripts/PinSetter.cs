using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	public Text pinCount;
	public GameObject pins;
	public GameObject pinPrefab;

	// Use this for initialization
	void Start () {
		pinCount = GameObject.Find("PinCount").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
//		if (ballLeftBox) {
//			pinCount.text = CountStanding ().ToString ();
//			CheckStanding ();
//		}
	}

	void OnTriggerEnter(Collider collider) {
//		if (collider.gameObject.GetComponent<Ball>()) {
//			standingBeforeBallIsThrown = CountStanding ();
//			lastStandingCount = -1;
//			pinCount.color = Color.red;
//		}
	}

	/**
	 * Destroy any pins that leave the area
	 */
	void OnTriggerExit(Collider collider) {
		GameObject obj = collider.gameObject;

		if (obj.GetComponent<Pin>()) {
			Destroy (collider.gameObject);
		}
	}
		
	/**
	 * Called by GameMaster, the animator then calls RaisePins, LowerPins, or RenewPins
	 */
	public void doAnimation(ActionMaster.Action action) {
		if (action == ActionMaster.Action.Tidy) {
			gameObject.GetComponent<Animator> ().SetTrigger ("triggerTidy");
		} else {
			gameObject.GetComponent<Animator> ().SetTrigger ("triggerRenew");
		}
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


}

