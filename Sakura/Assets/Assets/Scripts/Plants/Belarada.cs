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
		maxAttack = 0f;  attack = 0f;
		maxSun = 5f; sunProduction = 0.2f; sun = 0f;
		maxWater = 1f; waterProduction = 0.1f; water = 0f;
		
		GetComponent<MeshRenderer>().material = material;	
		createSunToken();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void createSunToken() {
		GameObject token = Instantiate(sunToken, transform.position, transform.parent.rotation) as GameObject;
//		List<GameObject> hitList = new List<GameObject>();
//		hitList.Add(HexMap.Instance.map[new Vector2(5,5)]);
//		hitList.Add(HexMap.Instance.map[new Vector2(1,7)]);
//		hitList.Add(HexMap.Instance.map[new Vector2(4,2)]);
//		token.GetComponent<SunProjectile>().HitList = hitList;
//		Console.WriteLine(hitList.ToString());
	}
}
