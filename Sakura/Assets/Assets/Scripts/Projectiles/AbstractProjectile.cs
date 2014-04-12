using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractProjectile : MonoBehaviour {
	
	protected float speed = 2;
	public float resource = 1;
	
	protected delegate bool testFunction(GraphNode node);
	protected abstract bool candidate(GraphNode node); //to be implemented
	protected abstract void effect(GameObject obj);	   //this too
	
	protected virtual void OnTriggerEnter(Collider col) {
		Plant plant = col.gameObject.GetComponent<Plant>();
		if (plant != null) //has hit a plant and not an empty tile or a weed
		{
			List<GraphNode> list;
			try {
				list = GraphSearch.horizonSearch(plant.Node, candidate).path();
			}
			catch (NullReferenceException) {
				list = new List<GraphNode>();
			}
			switch(list.Count) {
			case 0: //no target, destroy projectile.
				Destroy(gameObject, 0.5f); //destroy it after half a second
				break;
			case 1: // hit a plant that needs water.
				effect(col.gameObject);
				break;
			default:
				gameObject.rigidbody.velocity = 
					(list[1].ParentTile.transform.position - list[0].ParentTile.transform.position).normalized * speed;
				break;
			}
		}
	}
	
	protected virtual void Start () {
		transform.position += new Vector3(0, 0.25f, 0);
		rigidbody.angularVelocity = UnityEngine.Random.onUnitSphere * 3;
	}
	
	
}
