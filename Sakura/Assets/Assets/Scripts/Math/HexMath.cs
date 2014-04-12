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
	public static int hexDistance(GameObject start, GameObject end) {
		return hexDistance(getParentTile(start), getParentTile(end));
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
	public static List<GameObject> neighbourTiles(Vector2 pos, int range) {
		List<Vector2> list = neighbourVectors(pos, range);
		List<GameObject> neighbourList = new List<GameObject>();
		foreach (Vector2 vec in list)
		try {
			neighbourList.Add(HexMap.Instance.map[vec]);
		}
		catch (KeyNotFoundException) {
		}
		return neighbourList;
	}
	
	public static List<GameObject> neighbourTiles(GameObject g, int range) {
		return neighbourTiles (getParentTile(g).position, range);
	}
	
	public static Tile getParentTile(GameObject start) {
		while (start.GetComponent<Tile>() == null) //if it isn't a tile
			if (start.transform.parent != null) //and it has a parent
				start = start.transform.parent.gameObject; // go one level up
			else {
				Debug.LogError("hexDistance called from an object not belonging to a tile object.");
				return null;
			}
		return start.GetComponent<Tile>();	
	} 
	
}
			                                      
			                                      
			                                      
			                                      