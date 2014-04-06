using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WaterProjectile : AbstractProjectile {
	
	protected override bool candidate(GraphNode node) {
		Plant plant = node.Parent.GetComponent<Plant>();
		if (plant.Water < plant.maxWater && plant.waterProduction == 0) //if the plant needs water, and is not producing any
			return true;
		return false;
	}
	
	protected override void effect(GameObject obj) {
		obj.GetComponent<Plant>().Water += resource;
		Destroy(gameObject);
	}	
}
