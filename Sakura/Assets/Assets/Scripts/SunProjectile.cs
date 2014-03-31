using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SunProjectile : MonoBehaviour {

	private List<GameObject> hitList = new List<GameObject>();
	public List<GameObject> HitList
	{
		set { 
			hitList = value;
			Debug.Log(value);
			gameObject.rigidbody.velocity 
				= (hitList[0].transform.position - gameObject.transform.position).normalized * speed;
		}	
	}
	
	
	public float speed = 2;

	void OnTriggerEnter(Collider col) {
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
	
	void sunlight(GameObject obj) {}	
}
