using System.Collections;
using UnityEngine;

public class Ruza : Plant {
	
	PlantType plantType = PlantType.ruza;	
	private static GameObject thorn = Resources.Load("Prefabs/WannabeThorn") as GameObject;
	
	public float cooldown = 5.0f ;
	public int range = 5;
	private float prosli ;
	
	void Awake () {
	
		isBuilt = false;
		sunNeeded = 20;
		
		maxHealth = 15f; health = 0f;
		attack = 0f;
		maxSun = 5f; sunProduction = 0f; Sun = 0f;
		maxWater = 1f; waterProduction = 0f; Water = 0f;
		
		prosli = Time.time;
		
	}	

}
