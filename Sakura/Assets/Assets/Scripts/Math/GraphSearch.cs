using System;
using UnityEngine;
using System.Collections.Generic;

public static class GraphSearch {
	public delegate bool testFunction(GraphNode node);
	
	private static List<KeyValuePair<double,State>> open = new List<KeyValuePair<double,State>>();
	private static HashSet<GraphNode> closed = new HashSet<GraphNode>();

	public static State horizonSearch(GraphNode startNode, testFunction isFinal) {

		open = new List<KeyValuePair<double,State>>();
		closed = new HashSet<GraphNode>();
		
		open.Add(new KeyValuePair<double,State>(0, new State(startNode)));
		
		while (open.Count > 0)
		{
			KeyValuePair<double,State> pair = open[0];
			State currentState = pair.Value;
			
			if (isFinal(currentState.Node)) //end
				return currentState;
			
			if (!closed.Contains(currentState.Node)) { //has not yet visited
				closed.Add(currentState.Node);
				foreach (State st in currentState.getChildren())
					insertByCost(st, st.Cost);
			}
			open.Remove(pair);
		}
		
		return null;
	}
	
	private static void insertByCost(State nextState, double cost) {
		for (int i=0; i<open.Count; i++)
			if (cost < open[i].Key) {
				open.Insert(i, new KeyValuePair<double,State>(cost, nextState));
				return;
			}
		open.Add(new KeyValuePair<double,State>(cost, nextState));	
	}
	
	
	
}


