using UnityEngine;
using System.Collections;

public class HalfSpeed : Effect {

	public HalfSpeed(){		
		this.name = "half speed";
		this.duration = Random.Range (30, 60);
	}
}

