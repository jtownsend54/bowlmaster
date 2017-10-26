using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	GameObject pinCount;

	// Use this for initialization
	void Start () {
		pinCount = GameObject.Find("PinCount");
	}
	
	// Update is called once per frame
	void Update () {
		pinCount.GetComponent<Text> ().text = CountStanding ().ToString();
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
}
