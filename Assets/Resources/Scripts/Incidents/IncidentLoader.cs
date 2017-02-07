using System.Collections;
using UnityEngine;

public class IncidentLoader : MonoBehaviour {

	public const string path = "incidents";
	private static string[] icNames;
	private static IncidentContainer ic;

	void Start(){
		ic = IncidentContainer.Load (path);

		icNames = new string[ic.incidents.Count];

		int index = 0;

		foreach (Incident i  in ic.incidents) {
			icNames [index] = i.name;
			index ++;
		}

		// DEBUG
		/*
		for (int i = 0; i < icNames.Length; i++) {
			Debug.Log (icNames [i]);
		}
        */

		// DEBUG
		/*
		foreach(Incident i in ic.incidents){
			Debug.Log(i.name);
			Debug.Log(i.effect);
			Debug.Log(i.duration);
			Debug.Log(i.description);
		}
		*/
	}

	public static string[] getIncidentNames(){
		return icNames;
	}

	public static string getIncidentNameAt(int index){
		return icNames [index];
	}

	public static int getICLength(){
		return icNames.Length;
	}

	public static Incident getIncident(string incidentName){
		int index = ic.incidents.FindIndex(item => item.name.Equals(incidentName.ToLower()));
		Incident i = ic.incidents [index];

		// DEBUG
		/*
		Debug.Log (i.name);
		Debug.Log (i.effect);
		Debug.Log (i.duration);
		Debug.Log (i.description);
        */

		return i;
	}


}
