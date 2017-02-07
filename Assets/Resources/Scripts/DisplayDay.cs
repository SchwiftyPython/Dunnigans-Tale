using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDay : MonoBehaviour {

	UnityEngine.UI.Text text;

	void Awake () {
		text = GetComponent<UnityEngine.UI.Text> ();
	}


	void Update () {
		text.text = "Day " + CaravanController.instance.day;
	}
}
