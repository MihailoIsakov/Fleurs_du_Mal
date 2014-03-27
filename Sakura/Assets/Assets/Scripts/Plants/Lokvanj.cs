using System.Collections;
using UnityEngine;

public class Lokvanj : Plant {
	
	PlantType plantType = PlantType.lokvanj;	
	static Material material = Resources.Load("Materials/Lokvanj") as Material;
	
	void Awake () {
		isBuilt = false;
		
		maxHealth = 10f; health = 0f;
		maxAttack = 0f;  attack = 0f;
		maxSun = 1f; sunProduction = 0.2f; sun = 0f;
		maxWater = 1f; waterProduction = 0.1f; water = 0f;
		
		GetComponent<MeshRenderer>().material = material;	
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
