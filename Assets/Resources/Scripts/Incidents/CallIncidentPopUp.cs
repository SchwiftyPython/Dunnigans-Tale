using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallIncidentPopUp {

	private  UnityAction okAction;
	private  IncidentPopUp incidentPopUp;

	public CallIncidentPopUp(){
		incidentPopUp = IncidentPopUp.Instance ();
		okAction = new UnityAction (okPressed); 
	}

	public void callPopUp(Incident i){
		incidentPopUp.PopUp (i.name, i.description, okAction);
	}

	void okPressed(){
		incidentPopUp.ClosePopUp ();
	}

}
