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
	
	public void OnDestroy() {
		foreach (GraphNode node in connections) //for all my connections
			foreach (GraphNode nodeConnection in node.connections) //remove me from theirs
				nodeConnection.removeConnection(this);
	}
	
	public void addConnection(GraphNode newKid) {
		connections.Add(newKid);
	}
	
	public void removeConnection(GraphNode deadKid) {
		connections.Remove(deadKid);
	}
	
	public void findConnections(GameObject go) {
		connections = new List<GraphNode>();
		
		List<GameObject> neighbours = HexMath.neighbours(go, HexMath.RANGE); //see who's around
		foreach (GameObject obj in neighbours)
			if (obj.GetComponent<Plant>() != null)
			{
				GraphNode neighbourNode = obj.GetComponent<Plant>().Node;
				connections.Add(neighbourNode);	//if its a plant, add him to my connections
				neighbourNode.addConnection(this); //and add me to his connections. If I can see him, he can see me.
			}
	}
	
	
}


