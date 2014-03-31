using System;
using System.Collections.Generic;


public class State
{
	public State Parent { get; set; }
	public GraphNode Node { get; set; }
	public double Cost { get; set; }
	public int Level { get; set; }
	
	public List<State> getChildren() {
		List<State> children = new List<State>();
		foreach (GraphNode child in Node.Connections)
			children.Add(nextState(child));
			
		return children;
	}
	
	public State(GraphNode node)
	{
		this.Parent = null;
		this.Node = node;
		this.Level = 1;
		this.Cost = 0;	
	}
	
	public State nextState(GraphNode nextNode) 
	{	
		State next = new State(nextNode);
		next.Node = nextNode;
		next.Parent = this;
		next.Level = Level + 1;
		next.Cost = Cost + (Node.position - nextNode.position).magnitude; //the added path
		return next;	
	}
	
	public List<GraphNode> path () {
		List<GraphNode> pathList = new List<GraphNode>();
		
		State current = this;
		while (current != null) {
			pathList.Insert(0, current.Node);
			current = current.Parent;
		}
		
		return pathList;
	}
}



