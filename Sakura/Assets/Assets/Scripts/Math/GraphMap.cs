using System;
using System.Collections.Generic;
using UnityEngine;

//The point of GraphMap is to have a class that keeps GraphNodes separate from gameobjects.
public class GraphMap
{
	private static GraphMap instance;
	public static GraphMap Instance {
		get {
			if (instance == null)
				instance = new GraphMap();
				return instance;
		}	
	}
	
	//TODO find a better data structure for keeping and searching graphs
	Dictionary<Vector2, GraphNode> map = new Dictionary<Vector2, GraphNode>();
	
//	public List<GraphNode> getNeighbours(GraphNode node, int range) {
//		List<Vector2> neighbours = HexMath.neighbourVectors(node.position, HexMath.RANGE); // get neighbour vectors
//		foreach (Vector2 vector in neighbours)
//			if (map.) 
//	
//	}
//	
}

