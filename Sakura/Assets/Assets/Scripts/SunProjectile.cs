using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SunProjectile : MonoBehaviour {

	public delegate bool testFunction(GraphNode node);
	
	public bool candidate(GraphNode node) {
		Plant plant = node.Parent.GetComponent<Plant>();
		if (plant.Sun < plant.maxSun && plant.sunProduction == 0) //if the plant needs sun, and is not producing any
			return true;
		return false;
	}
	
	public float speed = 2;

	void OnTriggerEnter(Collider col) {
		Plant plant = col.gameObject.GetComponent<Plant>();
		if (plant != null) //has hit a plant and not an empty tile or a weed
		{
			List<GraphNode> list;
			try {
				list = GraphSearch.horizonSearch(plant.Node, candidate).path();
			}
			catch (NullReferenceException n) {
				list = new List<GraphNode>();
				Debug.Log ("Null reference exception at sunProjectile");
			}
			switch(list.Count) {
				case 0: //no target, destroy projectile.
					Destroy(gameObject, 0.5f); //destroy it after half a second
					break;
				case 1: // hit a plant that needs sun.
					sunlight(col.gameObject);
					break;
				default:
					gameObject.rigidbody.velocity = 
						(list[1].Parent.transform.position - list[0].Parent.transform.position).normalized * speed;
					break;
			}
		}
//		if (hitList.Count > 0 && col.gameObject == hitList[0]) { //hit the next in line
//			GameObject goal = HexMath.breadthFirstSearch(col.gameObject, HexMath.testFunction1);
//			List<GraphNode> newList = GraphMath.depthFirstSearch(col.gameObject.GetComponent<Plant>().Node, goal.GetComponent<Plant>().Node);
//			hitList.Clear();
//			foreach (GraphNode node in newList)
//				hitList.Add(node.Parent);
//			Debug.Log(hitList.Count);
//			hitList.RemoveAt(0);
//			if (hitList.Count == 0) { //hit the goal
//				sunlight(col.gameObject);
//				Destroy(gameObject);
//			}
//			else {
//				gameObject.rigidbody.velocity 
//					= (hitList[0].transform.position - gameObject.transform.position).normalized * speed;
//				
//			}
//		}	
	}

	void Start () {
		transform.position += new Vector3(0, 0.25f, 0);
		rigidbody.angularVelocity = UnityEngine.Random.onUnitSphere * 3;
	}
	
	void sunlight(GameObject obj) {
		obj.GetComponent<Plant>().Sun += 1;
		Destroy(gameObject);
	}	
}
