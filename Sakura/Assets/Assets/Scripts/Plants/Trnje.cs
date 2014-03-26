using System.Collections;
using UnityEngine;

public class Trnje : Plant {
	
	PlantType plantType = PlantType.trnje;	
	static Material material = Resources.Load("Materials/Trnje") as Material;
	public float cooldown = 3.0f;
	public float prosli ;
	
	void Start () {
		isBuilt = false;
		
		maxHealth = 10f; health = 0f;
		maxAttack = 0f;  attack = 0f;
		maxSun = 1f; sunProduction = 0.2f; sun = 0f;
		maxWater = 1f; waterProduction = 0.1f; water = 0f;
		
		GetComponent<MeshRenderer>().material = material;	
		prosli = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Time.time > ( prosli + cooldown ) )
		{
			Debug.Log("Ruzin interval");
			if (( AssemblyCSharp.HexMath.neighbours ( (int)transform.position.x, (int)transform.position.y , 1) ) )!= null)
			{
//				GameObject token = Instantiate(thorn, transform.position, transform.parent.rotation) as GameObject;
				prosli = Time.time;
				break;
			}
		}
		
	}
}
