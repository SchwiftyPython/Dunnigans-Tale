using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IncidentManager : MonoBehaviour {	
	

	public static void setNextIncidentCheck(){
		GameController.instance.nextIncidentCheck += Random.Range (30, 60);  // between half-day to full day
		Debug.Log("Next check: " + GameController.instance.nextIncidentCheck * 2);
	}

	public static void incidentCheck(){
		float roll = Random.Range (0.0f, 1.0f);
		if (roll <= GameController.instance.incidentProbability) {
			Incident i = generateIncident ();

			CallIncidentPopUp callPopUp = new CallIncidentPopUp();
			callPopUp.callPopUp (i);

			applyEffect (i);

			GameController.instance.incidentProbability = 0.15;

			Debug.Log ("Incident success");
		} else {
			GameController.instance.incidentProbability += 0.85; // CHANGE BACK TO 0.05
		}
		setNextIncidentCheck ();
	}

	public static Incident generateIncident(){
		int index = Random.Range (0, IncidentLoader.getICLength());
		string name = IncidentLoader.getIncidentNameAt (index);
		Incident i = IncidentLoader.getIncident (name);

		// DEBUG

		Debug.Log (i.name);
		Debug.Log (i.effect);
		Debug.Log (i.duration);
		Debug.Log (i.description);

		return i;

	}

	public static void applyEffect(Incident incident){
		string effect = incident.effect;
		Debug.Log ("Applying incident " + effect);

		switch (effect){
		case "immobile": 
			if (!CaravanController.instance.effectIsActive (effect)) {
				Immobile i = new Immobile ();
				CaravanController.instance.activeEffects.Add (i);
			}
			break;
		case "add supplies":
			AddSupplies addSupply = new AddSupplies ();
			addSupply.applyEffect ();
		    break;
		case "half speed":
			if (!CaravanController.instance.effectIsActive (effect)) {
				HalfSpeed hs = new HalfSpeed ();
				CaravanController.instance.activeEffects.Add (hs);
			}
		    break;
		}
       
	}

}
