using System;
using UnityEngine;
using System.Collections.Generic;

public static class HexMath	{
	
	static Vector2[] neighbour1, neighbour3, neighbour5, neighbour7;
	public const int RANGE = 5;
	
	public delegate bool testFunction(GameObject go);
	
	public static void readNeighbourLists() {
		string[] n1 = System.IO.File.ReadAllLines(Application.dataPath + "/Assets/Scripts/neighbours1.txt.txt");
		string[] n3 = System.IO.File.ReadAllLines(Application.dataPath + "/Assets/Scripts/neighbours3.txt.txt");
		string[] n5 = System.IO.File.ReadAllLines(Application.dataPath + "/Assets/Scripts/neighbours5.txt.txt");
		string[] n7 = System.IO.File.ReadAllLines(Application.dataPath + "/Assets/Scripts/neighbours7.txt.txt");
		
		neighbour1 = new Vector2[n1.Length];
		neighbour3 = new Vector2[n3.Length];
		neighbour5 = new Vector2[n5.Length];
		neighbour7 = new Vector2[n7.Length];
		for (int i = 0; i < n1.Length; i++)
		{
			String[] data = n1[i].Replace("(", "").Replace(")","").Split(',');
			neighbour1[i] = new Vector2(float.Parse(data[0]), float.Parse(data[1]));			
		}				
		for (int i = 0; i < n3.Length; i++)
		{
			String[] data = n3[i].Replace("(", "").Replace(")","").Split(',');
			neighbour3[i] = new Vector2(float.Parse(data[0]), float.Parse(data[1]));			
		}	
		for (int i = 0; i < n5.Length; i++)
		{
			String[] data = n5[i].Replace("(", "").Replace(")","").Split(',');
			neighbour5[i] = new Vector2(float.Parse(data[0]), float.Parse(data[1]));			
		}				
		for (int i = 0; i < n7.Length; i++)
		{
			String[] data = n7[i].Replace("(", "").Replace(")","").Split(',');
			neighbour7[i] = new Vector2(float.Parse(data[0]), float.Parse(data[1]));			
		}						
	}
	
	//tested. Passed
	public static int hexDistance(float x1, float y1, float x2, float y2) { //returns the distance between two hexes
		return Mathf.RoundToInt((Mathf.Abs(x1 - x2) + Mathf.Abs(y1 - y2) + Mathf.Abs(x2 + y2 - x1 - y1)) / 2);		
	}
	public static int hexDistance(Vector2 v1, Vector2 v2) {
		return hexDistance(v1.x, v1.y, v2.x, v2.y);
	}
	public static int hexDistance(Tile t1, Tile t2) {
		return hexDistance(t1.position, t2.position);
	}
	public static int hexDistance(GameObject t1, GameObject t2) {
		return hexDistance(t1.GetComponent<Tile>(), t2.GetComponent<Tile>());
	}
	public static float euclidDistance(GameObject t1, GameObject t2) 
	{
		Vector3 vec = t1.transform.position - t2.transform.position;
		return vec.magnitude;		
	}
	
	// Tested. Passed.
	// Gets the neighbouring tiles of the field at pos
	public static List<Vector2> neighbourVectors(Vector2 pos, int range) { 
		
		//Return a precreated list
		if (range == 1) {
			List<Vector2> list = new List<Vector2>();
			foreach (Vector2 vector in neighbour1)
				list.Add(vector + pos);
			return list;
		}
		else if (range == 3) {
			List<Vector2> list = new List<Vector2>();
			foreach (Vector2 vector in neighbour3)
				list.Add(vector+ pos);
			return list;
		}
		else if (range == 5) {
			List<Vector2> list = new List<Vector2>();
			foreach (Vector2 vector in neighbour5)
				list.Add(vector+ pos);
			return list;
		}
		else if (range == 7) {
			List<Vector2> list = new List<Vector2>();
			foreach (Vector2 vector in neighbour7)
				list.Add(vector+ pos);
			return list;
		}
		
		//If the range is not covered by a pre-prepared list:		
		List<Vector2> neighbourList = new List<Vector2>();
		for (float x = pos.x - range; x <= pos.x + range; x++)
			for (float y = Mathf.Max(-range, -x-range); y <= Mathf.Min(range, -x + range); y++)
				neighbourList.Add(new Vector2(x, y));
				
		return neighbourList;
	}
		
	// Tested. Passed.
	public static List<GameObject> neighbours(Vector2 pos, int range) {
		List<Vector2> list = neighbourVectors(pos, range);
		List<GameObject> neighbourList = new List<GameObject>();
		foreach (Vector2 vec in list)
		try {
			neighbourList.Add(HexMap.Instance.map[vec]);
		}
		catch (KeyNotFoundException) {
			Debug.Log("Key not found exception in HexMath.neighbours: " + vec.ToString());
		}
		return neighbourList;
	}
	public static List<GameObject> neighbours(GameObject g, int range) {
		return neighbours (g.GetComponent<Tile>().position, range);
	}
	
//	//Iterative depth first search. Should be an A*
//	public static List<GameObject> badPathfind(GameObject start, GameObject end) {
//		//TODO implement A*
//		//TODO implement graph logic
//		
//		foreach (GameObject tile in neighbours (start, 5)
//			if (tile.getComponent<Plant>() != null) // a neighbour is a plant
//				
//	
//	}
		
	
//	//TODO implement better list sorting
//	//TODO implement Theseus algorithm. Test performance in number of steps and in processing time.
//	public static List<GameObject> AStarSearch(GraphNode start, GraphNode end) {
//		List<State> open = new List<State>(); //list of States to be processed
//		HashSet<GraphNode> closed = new HashSet<GraphNode>(); //set of processed nodes
//		
//		
//		//Make a new state from the start node.
//		State startState = new State();
//		startState.node = start;
//		startState.parent = null;
//		startState.g = 0;
//		open.Add(startState);
//		
//		State currentState = open[0];
//		
//		while (open.Count > 0) { //run until open empties or it finds a path
//		
//			open.Remove(currentState);
//			closed.Add(currentState);
//			
//			if (currentState.node == end) //check if path found
//				return getPathFromState(currentState);
//				
//			List<GraphNode> newNodes = currentState.node.Connections; //get connections of the current state
//			foreach (GraphNode node in newNodes) {
//				State nextState = new State();
//				nextState.node = node;
//				nextState.parent = currentState;
//				nextState.g = currentState.g + (currentState.node.parent.GetComponent<Tile>().position - nextState.node.parent.GetComponent<Tile>().position).magnitude;
//				
//				if (!open.Contains(nextState) && !closed.Contains(nextState.node))  //if the node has not yet been processed
//					nextState.f = nextState.g + nextState.Heuristic(end);
//					for (int i = 0; i < open.Count; i++)
//						if (nextState.f < open[i].f)
//							open.Insert(i, nextState); //insert it into open, sorted.
//				else 
//					if (open.Contains(nextState)) {
//					}
//				
//				
//			
//			}
//			
//		
//		}
//		return null; //couldnt find a path
//	}
//	
//	private static List<GraphNode> getPathFromState(State state) {
//		List<GraphNode> path = new List<GraphNode>();
//		while (state.parent != null) {
//			path.Insert(0, state.node);
//		}
//		return path;
//	}
//	
//	private class State {
//		public float f = 0;
//		public float g = 0;
//		public State parent;
//		public GraphNode node;	
//		public float Heuristic (GraphNode end) {
//			return (node.parent.GetComponent<Tile>().position - end.parent.GetComponent<Tile>().position).magnitude; 
//		}
//	}
	
	//gadja trnje
	public static bool testFunction1 (GameObject go) {
		if (go.GetComponent<Plant>().Type == Plant.PlantType.trnje) {
			go.GetComponent<MeshRenderer>().material = null;
			return true;
		}
		return false;
	} 
}
			                                      
			                                      
			                                      
			                                      