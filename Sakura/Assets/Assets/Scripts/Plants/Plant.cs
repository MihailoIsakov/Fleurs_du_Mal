using UnityEngine;
using System.Collections;

public abstract class Plant : MonoBehaviour {

	public enum PlantType {leaf, belarada, lokvanj, maslacak, pecurka, ruza, trnje, vockica};

	protected bool isBuilt;

	protected float maxHealth, health;
	protected float maxAttack, attack;
	protected float maxSun, sunProduction, sun;
	protected float maxWater, waterProduction, water;

	PlantType plantType;
	static Material material;
	
	void Awake() {
	
	
	}
	
	void Start() {	
	}

}
