using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanMove : MonoBehaviour {
	float curPos;

	void Start () {
		curPos = transform.position.x;
		QualitySettings.vSyncCount = 0;
	}
	

	void Update () {
		if (Time.timeScale != 0) {
			transform.Translate (-CaravanController.instance.wagonSpeed * Time.deltaTime, 0, 0);
		}
	}
}
