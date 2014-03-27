using System;
using System.Collections.Generic;
using UnityEngine;


public class GraphNode {
	public GameObject parent;
	List<GraphNode> connections;
	public List<GraphNode> Connections {
		get { return connections; }
	}

	public GraphNode (GameObject obj)
	{
		parent = obj; //TODO check if parent is needed at all.
		findConnections(parent);
	}
	
	public void addConnection(GraphNode newKid) {
		connections.Add(newKid);
	}
	
	public void removeConnection(GraphNode deadKid) {
		connections.Remove(deadKid);
	}
	
	public void findConnections(GameObject go) {
		connections = new List<GraphNode>();
		
		List<GameObject> neighbours = HexMath.neighbours(go, HexMath.RANGE);
		foreach (GameObject obj in neighbours)
			if (obj.GetComponent<Plant>() != null) //is plant
			{
				GraphNode neighbourNode = obj.GetComponent<Plant>().Node;
				connections.Add(neighbourNode);	
				neighbourNode.addConnection(this);
			}
	}
	
	
}


