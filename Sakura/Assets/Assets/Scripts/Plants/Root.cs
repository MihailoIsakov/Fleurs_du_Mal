using System.Collections;
using UnityEngine;

public class Root : Plant {
	
	PlantType plantType = PlantType.root;	
	
	private float cooldown = 1f;
	private float timeSinceFired = 0f;
	
	void Awake () {
		isBuilt = true;
		
		maxHealth = 50f; health = 50f;
		attack = 1f;
		maxSun = 1f; sunProduction = 0.2f; Sun = 0f;
		maxWater = 1f; waterProduction = 0.2f; Water = 0f;
	
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		
		timeSinceFired += Time.deltaTime;
		
		if (timeSinceFired > cooldown && ProjectileUtility.tryToCreateSun(this)) //if is cool and has created sun
			timeSinceFired = 0;
		else if (timeSinceFired > cooldown && ProjectileUtility.tryToCreateWater(this)) //is cool and has created water
			timeSinceFired = 0;
	}
}
