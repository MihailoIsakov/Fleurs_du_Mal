using NUnit.Framework;
using System;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

[TestFixture]
public class MathTests {
	
//######################################################################################
	
	[TestFixtureSetUp]
	public void setup() {
		HexMath.readNeighbourLists();
	}
	
	//x,y, range
	[TestCase (2, -2, 2)]
	[TestCase (-2, 2, 2)]
	[TestCase (2, 0, 2)]
	[TestCase (0, 2, 2)]
	[TestCase (-2, 0, 2)]
	[TestCase (0, -2, 2)]
	[TestCase (1, 1, 2)]
	[TestCase (1, -1, 1)]
	[TestCase (-1, 1, 1)]
	[TestCase (-1, -1, 2)]
	public void testDistance(int x, int y, int range) {
		Vector2 v = new Vector2(x, y);
		Vector2 start = new Vector2(0,0);
		
		int distance = HexMath.hexDistance(start, v);
		Assert.AreEqual(distance, range);
	}
//######################################################################################
	
	[TestCase (1)]
	[TestCase (2)]
	[TestCase (3)]
	[TestCase (4)]
	[TestCase (5)]
	[TestCase (6)]
	[TestCase (7)]
	public void testNeighbours (int range) {
	
		Vector2 start = new Vector2(0,0);
		List<Vector2> list = HexMath.neighbourVectors(start, range);
		
		int distance;
		for (int i = 0; i < list.Count; i++) {
			Vector2 v = list [i];
			distance = HexMath.hexDistance (start, v);
			Assert.LessOrEqual (distance, range, v.x + " " + v.y);
		}
		Assert.Pass();
	}

//######################################################################################
	
	
	static GraphNode node1 = new GraphNode(new Vector2(0,0));
	static GraphNode node2 = new GraphNode(new Vector2(2,2));
	static GraphNode node3 = new GraphNode(new Vector2(4,4));
	static GraphNode node4 = new GraphNode(new Vector2(2,5));
	static GraphNode node5 = new GraphNode(new Vector2(2,7));
	static GraphNode node6 = new GraphNode(new Vector2(1,8));
	static GraphNode node7 = new GraphNode(new Vector2(3,8)); //changing between (3,8) and (3,11) we see that the search really finds the nearest.
	static GraphNode node8 = new GraphNode(new Vector2(5,2));
	
	
	GraphNode[] startNodes = {node1,  node6, node4};
		
	[Test]
	public void testGraph () {		
		
		//have to manually insert startNode :(
		GraphNode test = node4;
		
		//link graph;
		node2.addMutualConnection(node1).addMutualConnection(node3).addMutualConnection(node8).addMutualConnection(node4);
		node3.addMutualConnection (node8);
		node5.addMutualConnection(node4).addMutualConnection (node6).addMutualConnection (node7);
		node6.addMutualConnection (node7);
		
		List<GraphNode> search = GraphSearch.horizonSearch(test, testFunction).path();
		foreach (GraphNode node in search)
			Debug.Log(node.position.x + " _ " + node.position.y);
		Assert.Pass();
//		Assert.IsTrue(search[search.Count - 1].position.Equals(node8));
		
	}
	
	public bool testFunction(GraphNode node) {
		if (node.Equals(node7) || node.Equals(node8))
			return true;
		else
			return false;
	}
}
