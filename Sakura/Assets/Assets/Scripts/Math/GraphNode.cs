using System;
using System.Collections.Generic;
using UnityEngine;


public class GraphNode {

	public Vector2 position;
	private GameObject parent = null;
	public GameObject Parent {
		get {
			if (parent != null)
				return parent;
			else { //parent is null
				try {
					parent = HexMap.Instance.map[position];
					return parent;
				}
				catch (KeyNotFoundException) {
					return null;
				}
			}
		}
	}

	List<GraphNode> connections = new List<GraphNode>();
	public List<GraphNode> Connections {
		get { return connections; }
	}
	
	public GraphNode (Vector2 pos) {
		position = pos; //The parent will be SAFELY initialised when its called.
	} 
	
	public void OnDestroy() {
		foreach (GraphNode node in connections) //for all my connections
			foreach (GraphNode nodeConnection in node.connections) //remove me from theirs
				nodeConnection.removeConnection(this);
	}
	
	public GraphNode addConnection(GraphNode newKid) {
		connections.Add(newKid);
		return this;
	}
	public GraphNode addMutualConnection(GraphNode newKid) {
		addConnection(newKid);
		newKid.addConnection(this);
		return this;
	}
	public GraphNode removeConnection(GraphNode deadKid) {
		connections.Remove(deadKid);
		return this;
	}
	
	public void findConnections() {
		connections = new List<GraphNode>();
		
		List<GameObject> neighbours = HexMath.neighbours(Parent, HexMath.RANGE); //see who's around
		foreach (GameObject obj in neighbours)
			if (obj.GetComponent<Plant>() != null) // any plants?
			{
				GraphNode neighbourNode = obj.GetComponent<Plant>().Node; 
				addMutualConnection(neighbourNode); //add him to my connections, and me to his.
			}
	}
	
	public bool Equals(GraphNode node) {
		if (position.x == node.position.x && position.y == node.position.y)
			return true;
		else return false;	
	}
}


