using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Supplies will vary from food to medicine
// Need to make a base class or xml file for different supplies
public class AddSupplies : Effect {

	public AddSupplies(){
		this.duration = -1;
		this.name = "add supplies";
	}

	public override void applyEffect ()	{
		//temp implementation for testing
		CaravanController.instance.amountOfFood += 50;
	}
}
