using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int weightPerOx { get; set; }
	public int weightPerPerson { get; set; }
	public double foodWeight { get; set; }
	public int foodPerPerson { get; set; }
	public int gameSpeed { get; set; }
	public double dayPerSecond { get; set; }
	public int distanceToGoal { get; set; }
	public double incidentProbability { get; set; }
	public int nextIncidentCheck { get; set; }

	public static GameController instance = null;


	// Called when the object is initialized
	void Awake()
	{
		// if it doesn't exist
		if(instance == null)
		{
			// Set the instance to the current object (this)
			instance = this;
			this.weightPerOx = 20;
			this.weightPerPerson = 2;
			this.foodWeight = 0.6;
			this.foodPerPerson = 2;
			this.gameSpeed = 2;
			this.dayPerSecond = 0.016;
			this.distanceToGoal = 1000;
			this.incidentProbability = 0.15;
			this.nextIncidentCheck = 0;
			IncidentManager.setNextIncidentCheck();   

		}

		// There can only be a single instance of the game manager
		else if(instance != this)
		{
			// Destroy the current object, so there is just one manager
			Destroy(gameObject);
		}

		// Don't destroy this object when loading scenes
		DontDestroyOnLoad(gameObject);
	}

	void Update(){

		// Try to generate an incident
		if (Time.time >= this.nextIncidentCheck) {
			Debug.Log ("Checking incident...");
			IncidentManager.incidentCheck ();
		}
	}

	public void onPause(){
		if (Time.timeScale > 0) {
			Time.timeScale = 0;

			// DEBUG
			//Debug.Log ("Paused");
		}
	}

	public void onPlay(){
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
	}

}
