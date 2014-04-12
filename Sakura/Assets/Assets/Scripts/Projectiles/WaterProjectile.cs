using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WaterProjectile : AbstractProjectile {
	
	protected override bool candidate(GraphNode node) {
	
		Plant[] plants = node.ParentTile.GetComponentsInChildren<Plant>();
		foreach (Plant plant in plants )
			if (plant.Sun < plant.maxWater && plant.waterProduction == 0) //if the plant needs sun, and is not producing any
				return true;
		return false;
	}
	
	protected override void effect(GameObject obj) {
		obj.GetComponent<Plant>().Water += resource;
		Destroy(gameObject);
	}	
}
