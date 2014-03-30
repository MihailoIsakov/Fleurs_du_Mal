using UnityEngine;
using System.Collections;

public abstract class Plant : MonoBehaviour {

	public enum PlantType {leaf, belarada, lokvanj, maslacak, pecurka, ruza, trnje, vockica};

	protected bool isBuilt;

	protected float maxHealth, health;
	protected float maxAttack, attack;
	protected float maxSun, sunProduction, sun;
	protected float maxWater, waterProduction, water;
	
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
		node = new GraphNode(gameObject);
	}
	
	protected virtual void OnDestroy() {
		node.OnDestroy();
	}
	
}
