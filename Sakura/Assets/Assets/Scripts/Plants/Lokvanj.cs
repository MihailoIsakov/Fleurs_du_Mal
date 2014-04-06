using System.Collections;
using UnityEngine;

public class Lokvanj : Plant {
	
	PlantType plantType = PlantType.lokvanj;	
	
	void Awake () {
		isBuilt = false;
		sunNeeded = 10;
		
		maxHealth = 10f; health = 0f;
		attack = 0f;
		maxSun = 1f; sunProduction = 0.2f; sun = 0f;
		maxWater = 1f; waterProduction = 0.1f; water = 0f;
		
		material = Resources.Load("Materials/Lokvanj") as Material;
		setMaterial();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		ProjectileUtility.tryToCreateWater(this);
	}
}
