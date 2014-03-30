using NUnit.Framework;
using System;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

[TestFixture]
public class MathTests {
	
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
}
