using UnityEngine;
using System.Collections;

public class Effect {
	public int duration { get; set; }
	public string name { get; set; }

	public Effect(){
		this.duration = 0;
		this.name = "";
	}

	public virtual void applyEffect(){}

}

