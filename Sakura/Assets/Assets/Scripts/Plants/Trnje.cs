using System.Collections;
using UnityEngine;

public class Trnje : Plant {
	
	PlantType plantType = PlantType.trnje;	
	public float cooldown = 3.0f;
	public float prosli ;
	
	void Awake () {
		isBuilt = false;
		
		maxHealth = 10f; health = 0f;
		attack = 0f;
		maxSun = 1f; sunProduction = 0.2f; sun = 0f;
		maxWater = 1f; waterProduction = 0.1f; water = 0f;
		
		prosli = Time.time;
		
	}
}
