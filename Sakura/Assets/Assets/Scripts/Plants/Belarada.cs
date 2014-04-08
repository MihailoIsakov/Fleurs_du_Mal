using System.Collections;
using UnityEngine;

public class Belarada : Plant {
	
	PlantType plantType = PlantType.belarada;	

	void Awake () {
		isBuilt = false;
		sunNeeded = 10;
		
		maxHealth = 15f; health = 0f;
		attack = 0f;
		maxSun = 1f; sunProduction = 0.2f; Sun = 0f;
		maxWater = 0f; waterProduction = 0f; Water = 0f;

	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		ProjectileUtility.tryToCreateSun(this);
	}

}
