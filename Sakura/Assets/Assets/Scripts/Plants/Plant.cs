using UnityEngine;
using System.Collections;

/// <summary>
/// Parent class for ALL the players plants.
///	At awake, initialize all the 
/// </summary>

public abstract class Plant : MonoBehaviour {

	public enum PlantType {leaf, belarada, lokvanj, maslacak, pecurka, ruza, trnje, vockica};

	public bool isBuilt {
		get;
		protected set;
	} //isBuilt with a public getter
	protected float sunNeeded; //sun needed to be built
	public float SunNeeded {
		get { return sunNeeded;}
		protected set {
			sunNeeded = value;
		}
	}
	
	protected float maxHealth;
	protected float health;
	public float Health {
		get {
			return health;
		}
		set {
			health  = Mathf.Clamp(value, 0, maxHealth);
			if (health == 0)
				Die();
		}
	}
	
	protected float attack;
	public float sunProduction, maxSun;
	protected float sun; //checks if the plant has been built first
	public float Sun {
		get {
			return sun;
		}
		set {
			if (isBuilt)
				sun = Mathf.Clamp(value, 0, maxSun);
			else {
				sun = value;
				if (sun >= SunNeeded) {
					sun = 0;
					isBuilt = true;
				}
				setMaterial();
			}
		}
	}
	public float waterProduction, maxWater;
	protected float water;
	public float Water {
		get { 
			return water;
		}
		set {
			water = Mathf.Clamp(value, 0, maxWater);
		}
	}
	
	protected GraphNode node;
	public GraphNode Node {
		get { return node; }
		set { node = value;}
	}

	PlantType plantType;
	public PlantType Type {
		get { return plantType; }
	}
	
	protected Material material;
	protected virtual void setMaterial() {
		if (isBuilt)
			gameObject.renderer.material = material;
		else {
			float t = 0.2f + Sun / SunNeeded * 0.6f; // _/-
			Debug.Log("TTTTTT: "+t);
			gameObject.renderer.material.Lerp(material, gameObject.GetComponent<Tile>().material, t);
		}
	}
	
	protected virtual void Start() {
		node = new GraphNode(gameObject.GetComponent<Tile>().position); //at start, create node
		node.findConnections(); // and find its connections
	}
	
	protected virtual void Update() {
		Sun += sunProduction * Time.deltaTime;
		Water += waterProduction * Time.deltaTime;	
	}
	
	protected virtual void OnDestroy() {
		node.OnDestroy();
		gameObject.renderer.material = gameObject.GetComponent<Tile>().material; //paint it as land
	}
	
	protected virtual void Die() {}
	
	
	
}
