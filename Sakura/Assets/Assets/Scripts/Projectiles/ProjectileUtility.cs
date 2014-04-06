using System;
using UnityEngine;

public static class ProjectileUtility
{	
//	public delegate bool testFunction(GraphNode node);
	private static GameObject sunToken = Resources.Load("Prefabs/SunToken") as GameObject;
	private static GameObject waterToken = Resources.Load("Prefabs/WaterToken") as GameObject;
	
	
	//a function that checks if a plant can produce a sun projectile and acts accordingly
	public static bool tryToCreateSun(Plant plant) {
		if (plant.Sun >= plant.maxSun) //can make projectile
		{
			bool hasTarget = true;
			try { GraphSearch.horizonSearch(plant.Node, needsSun).path(); }
			catch (NullReferenceException n) { hasTarget = false; } //cant find a path
			
			if (hasTarget) {
				GameObject token = GameObject.Instantiate(sunToken, plant.transform.position, plant.transform.parent.rotation) as GameObject;
				plant.Sun -= token.GetComponent<SunProjectile>().resource;
				return true;
			}
		}
		return false;
	}
	
	public static bool tryToCreateWater(Plant plant) {
		if (plant.Water >= plant.maxWater) //can make projectile
		{
			bool hasTarget = true;
			try { GraphSearch.horizonSearch(plant.Node, needsWater).path(); }
			catch (NullReferenceException n) { hasTarget = false; } //cant find a path
			
			if (hasTarget) {
				GameObject token = GameObject.Instantiate(waterToken, plant.transform.position, plant.transform.parent.rotation) as GameObject;
				plant.Water -= token.GetComponent<WaterProjectile>().resource;
				return true;
			}
		}
		return false;
	}
	
	//A static function for checking if any accessible nodes need resource specified by the delegate function. 
	//The specific projectile chooses which node it will target, this function only determines if it should be 
	private static bool canFire (GraphNode node, GraphSearch.testFunction candidate) {
		try {
			GraphSearch.horizonSearch(node, candidate).path();
		}
		catch (NullReferenceException n) {
			return false; //cant find a candidate, so it cant fire
		}
		return true;
	}
	
	//Check if this specific node needs sun.
	private static bool needsSun(GraphNode node) {
		Plant plant = node.Parent.GetComponent<Plant>();
		if (plant.Sun < plant.maxSun && plant.sunProduction == 0) //if the plant needs sun, and is not producing any
			return true;
		return false;
	}
	
	//Check if this specific node needs water.
	private static bool needsWater(GraphNode node) {
		Plant plant = node.Parent.GetComponent<Plant>();
		if (plant.Water < plant.maxWater && plant.waterProduction == 0) //if the plant needs sun, and is not producing any
			return true;
		return false;
	}	
}


