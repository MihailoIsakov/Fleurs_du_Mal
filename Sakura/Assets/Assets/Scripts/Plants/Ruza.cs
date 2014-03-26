using System.Collections;
using UnityEngine;

public class Ruza : Plant {
	
	PlantType plantType = PlantType.belarada;	
	static Material material = Resources.Load("Materials/Belarada") as Material;
	private static GameObject thorn = Resources.Load("Prefabs/WannabeThorn") as GameObject;
	public float cooldown = 5.0f ;
	public int range = 5;
	private float prosli ;
	
	void Awake () {
		isBuilt = false;
		
		maxHealth = 15f; health = 0f;
		maxAttack = 0f;  attack = 0f;
		maxSun = 5f; sunProduction = 0.2f; sun = 0f;
		maxWater = 1f; waterProduction = 0.1f; water = 0f;
		
		GetComponent<MeshRenderer>().material = material;	
		prosli = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if ( Time.time > ( prosli + cooldown ) )
		{
			Debug.Log("Ruzin interval");
			foreach (GameObject g in ( AssemblyCSharp.HexMath.neighbours ( (int)transform.position.x, (int)transform.position.y , range) ) ){
			GameObject token = Instantiate(thorn, transform.position, transform.parent.rotation) as GameObject;
			token.GetComponent<ThornProjectile>().Goal =  new Vector3(0.0f,0.0f,0.0f) ;
			prosli = Time.time;
				break;
			}
		}
	}

}
