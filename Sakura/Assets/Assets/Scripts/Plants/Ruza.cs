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
	
	// Update is called once per frame
	void Update () { //TODO resi picvajz
		
				
		
//		if ( Time.time > ( prosli + cooldown ) )
//		{
//			Debug.Log("Ruzin interval");
//			foreach (GameObject g in ( HexMath.neighbours ( gameObject.GetComponent<Tile>().position , range) ) ){
//			GameObject token = Instantiate(thorn, transform.position, transform.parent.rotation) as GameObject;
//			token.GetComponent<ThornProjectile>().Goal =  new Vector3(0.0f,0.0f,0.0f) ;
//			prosli = Time.time;
//				break;
//			}
//		}
	}

}
