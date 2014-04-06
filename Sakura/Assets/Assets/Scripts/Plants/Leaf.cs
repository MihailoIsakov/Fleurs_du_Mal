using System.Collections;
using UnityEngine;

public class Leaf : Plant {
	
	PlantType plantType = PlantType.leaf;	
	
	void Awake () {
		isBuilt = false;
		sunNeeded = 10;
	
		maxHealth = 10f; health = 0f;
		attack = 0f;
		maxSun = 0f; sunProduction = 0f; sun = 0f;
		maxWater = 1f; waterProduction = 0.1f; water = 0f;
		
		material = Resources.Load("Materials/List") as Material;
		setMaterial();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		ProjectileUtility.tryToCreateWater(this);
	}
}
