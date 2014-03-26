﻿using System.Collections;
using UnityEngine;

public class Leaf : Plant {
	
	PlantType plantType = PlantType.leaf;	
	static Material material = Resources.Load("Materials/List") as Material;
	
	void Start () {
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
