using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SunProjectile : AbstractProjectile {
	
	protected override bool candidate(GraphNode node) {
		Plant plant = node.Parent.GetComponent<Plant>();
		if (plant.Sun < plant.maxSun && plant.sunProduction == 0) //if the plant needs sun, and is not producing any
			return true;
		return false;
	}
	
	protected override void effect(GameObject obj) {
		obj.GetComponent<Plant>().Sun += resource;
		Destroy(gameObject);
	}	
}
