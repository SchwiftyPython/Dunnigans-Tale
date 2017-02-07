using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CaravanController : MonoBehaviour {

	public int day { get; set; }
	public int distanceTravelled { get; set; }
	public int crewSize { get; set; }
	public int amountOfFood { get; set; }
	public int numOxen { get; set; }
	public int money { get; set; }
	public int attackPower { get; set; }
	public double capacity { get; set; }
	public double weight { get; set; }
	public int wagonSpeed { get; set; }

	public List<Effect> activeEffects; 

	private int nextDistanceUpdate  = 1;   // In seconds
	private int nextDayUpdate = 60;        //

	public static CaravanController instance = null;

	// Use this for initialization
	void Start () {

		if (instance == null) {
			
			instance = this;
			this.day = 1;
			this.distanceTravelled = 0;
			this.crewSize = 4;
			this.amountOfFood = 1000;
			this.numOxen = 4;
			this.money = 1000;
			this.attackPower = this.crewSize * 3;
			this.wagonSpeed = 2;

			this.updateWeight ();
			this.activeEffects = new List<Effect> ();

		}else if(instance != this){
			// Destroy the current object, so there is just one 
			Destroy(gameObject);
		}

		// Don't destroy this object when loading scenes
		DontDestroyOnLoad(gameObject);

		    
	}

	void Update(){

		if (Time.time >= this.nextDistanceUpdate) {
			this.nextDistanceUpdate = Mathf.FloorToInt (Time.time) + 1;
			this.updateDistanceTravelled ();

			if (this.activeEffects.Count > 0) {
				Debug.Log ("Checking active effects...");
				this.checkActiveEffects ();
			}

			// DEBUG
			//Debug.Log ("Distance travelled: " + this.distanceTravelled);
		}

		if (Time.time >= this.nextDayUpdate) {
			this.nextDayUpdate = Mathf.FloorToInt (Time.time) + 60;
			this.day ++;

			this.consumeFood ();

			// DEBUG
			//Debug.Log ("Day updated to: " + this.day);
		}


	}
	

	void updateWeight () {
		this.capacity = this.numOxen * GameController.instance.weightPerOx * this.crewSize * GameController.instance.weightPerPerson;
		this.weight = this.amountOfFood * GameController.instance.foodWeight;

		// DEBUG
		//print ("Capacity: " + capacity);
		//print ("Weight : " + weight);
	}

	void updateDistanceTravelled (){
		if (effectIsActive ("immobile")) {
			this.distanceTravelled += 0;
		} else if (effectIsActive ("half speed")) { 
			this.distanceTravelled += this.wagonSpeed / 2;
		} else {
			this.distanceTravelled += this.wagonSpeed;
		}
	}

	void consumeFood(){
		this.amountOfFood -= this.crewSize * GameController.instance.foodPerPerson;

		if (this.amountOfFood < 0) {
			this.amountOfFood = 0;
		}
	}

	void checkActiveEffects(){
		foreach (Effect effect in this.activeEffects.ToList()) {
			if (effect.duration == -1) {  //if no duration for effect, skip
				break;
			} else if (effect.duration == 0) {
				removeActiveEffect (effect);
			} else {
				effect.duration--;
			}
		}
	}

	void removeActiveEffect(Effect effect){
		this.activeEffects.Remove (effect);

		// DEBUG
		Debug.Log ("Removed " + effect + " num effects active: " + this.activeEffects.Count);
	}

	public bool effectIsActive(string name){
		foreach (Effect effect in this.activeEffects.ToList()) {
			if (effect.name.Equals (name)) {
				return true;
			}
		}
		return false;
	}


}
