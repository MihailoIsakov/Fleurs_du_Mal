using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;

public class Belarada : Plant {
	
	PlantType plantType = PlantType.belarada;	
	static Material material = Resources.Load("Materials/Belarada") as Material;
	private static GameObject sunToken = Resources.Load("Prefabs/SunToken") as GameObject;
	
	void Awake () {
		isBuilt = false;
		
		maxHealth = 15f; health = 0f;
		attack = 0f;
		maxSun = 1f; sunProduction = 0.2f; Sun = 0f;
		maxWater = 1f; waterProduction = 0f; Water = 0f;
		
		GetComponent<MeshRenderer>().material = material;	
		createSunToken();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		Debug.Log(Sun);
		if (Sun >= maxSun)
		{
			Sun -= 1;
			createSunToken();
		}	
	}
	
	void createSunToken() {
		GameObject token = Instantiate(sunToken, transform.position, transform.parent.rotation) as GameObject;
	}
}
