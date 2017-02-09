using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class IncidentPopUp : MonoBehaviour {

	public Text title;
	public Text description;
	public Image iconImage;
	public Button okButton;
	public GameObject modalPanelObject;

	private static IncidentPopUp incidentPopUp;

	void Awake(){
		modalPanelObject.SetActive(false);
	}

	public static IncidentPopUp Instance(){
		if (!incidentPopUp) {
			incidentPopUp = FindObjectOfType (typeof(IncidentPopUp)) as IncidentPopUp;
			if (!incidentPopUp) {
				Debug.LogError ("Need an active pop up script.");
			}
		}
		return incidentPopUp;

	}


	public void PopUp(string ti, string desc, UnityAction okEvent){
		Debug.Log ("In the popUp method");
		GameController.instance.onPause ();
		modalPanelObject.SetActive (true);

		okButton.onClick.RemoveAllListeners();
		okButton.onClick.AddListener (okEvent);
		okButton.onClick.AddListener (ClosePopUp);

		this.title.text = ti;
		this.description.text = desc;

		okButton.gameObject.SetActive (true);
	}

	public void ClosePopUp(){
		modalPanelObject.SetActive (false);
		GameController.instance.onPlay ();
	}
}
