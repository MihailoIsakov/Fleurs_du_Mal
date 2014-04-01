using UnityEngine;
using System.Collections;

/// <summary>
/// Parent class for ALL the players plants.
///	At awake, initialize all the 
/// </summary>

public abstract class Plant : MonoBehaviour {

	public enum PlantType {leaf, belarada, lokvanj, maslacak, pecurka, ruza, trnje, vockica};

	protected bool isBuilt;

	protected float maxHealth, health;
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
	protected float sun;
	public float Sun {
		get {
			return sun;
		}
		set {
			sun = Mathf.Clamp(value, 0, maxSun);
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
	static Material material;
	
	protected virtual void Start() {
		node = new GraphNode(gameObject.GetComponent<Tile>().position); //at start, create node
		node.findConnections(); // and find its connections
		Debug.Log("connections: "+node.Connections.Count);
		foreach (GraphNode connection in node.Connections)
			Debug.Log(connection.position.x+ "  "+connection.position.y);
	}
	
	protected virtual void Update() {
		Sun += sunProduction * Time.deltaTime;
		Water += waterProduction * Time.deltaTime;	
	}
	
	protected virtual void OnDestroy() {
		node.OnDestroy();
	}
	
	protected virtual void Die() {}
	
}
