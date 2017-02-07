using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaravanInfoManager : MonoBehaviour {

	UnityEngine.UI.Text text;

	void Awake () {
		text = GetComponent<UnityEngine.UI.Text> ();
	}
	

	void Update () {
		text.text = "Crew: " + CaravanController.instance.crewSize + "\n" +
		"Food: " + CaravanController.instance.amountOfFood + "\n" +
		"Miles Travelled: " + CaravanController.instance.distanceTravelled + "\n" +
		"Oxen: " + CaravanController.instance.numOxen + "\n" +
		"Money: " + CaravanController.instance.money;

	}
}
