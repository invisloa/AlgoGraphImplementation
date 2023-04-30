using AlgoGraphImplementation;
using System;
using System.Collections.Generic;

public class Graph
{
	public List<GraphNode> Nodes { get; private set; }

	public Graph()
	{
		Nodes = new List<GraphNode>();
	}

	public GraphNode GetNode(int value)
	{
		return Nodes.Find(node => node.Value == value);
	}

	public void AddNode(int value)
	{
		if (GetNode(value) == null)
		{
			Nodes.Add(new GraphNode(value));
		}
	}

	public void RemoveNode(int value)
	{
		GraphNode nodeToRemove = GetNode(value);
		if (nodeToRemove != null)
		{
			Nodes.Remove(nodeToRemove);
			foreach (var node in Nodes)
			{
				node.Neighbors.Remove(nodeToRemove);
			}
		}
	}

	public void AddEdge(int from, int to)
	{
		GraphNode fromNode = GetNode(from);
		if (fromNode == null)
		{
			fromNode = new GraphNode(from);
			Nodes.Add(fromNode);
		}

		GraphNode toNode = GetNode(to);
		if (toNode == null)
		{
			toNode = new GraphNode(to);
			Nodes.Add(toNode);
		}

		fromNode.Neighbors.Add(toNode);
		toNode.Neighbors.Add(fromNode);
	}

	public void RemoveEdge(int from, int to)
	{
		GraphNode fromNode = GetNode(from);
		GraphNode toNode = GetNode(to);

		if (fromNode != null && toNode != null)
		{
			fromNode.Neighbors.Remove(toNode);
			toNode.Neighbors.Remove(fromNode);
		}
	}

	public List<int> BFS(int start)
	{
		var startNode = GetNode(start);
		if (startNode == null)
		{
			return new List<int>(); // Return an empty list if the start node is not in the graph
		}

		var visited = new HashSet<int>();
		var queue = new Queue<GraphNode>();
		var bfsTraversal = new List<int>();

		queue.Enqueue(startNode);

		while (queue.Count > 0)
		{
			GraphNode node = queue.Dequeue();

			if (!visited.Contains(node.Value))
			{
				visited.Add(node.Value);
				bfsTraversal.Add(node.Value);

				foreach (var neighbor in node.Neighbors)
				{
					if (!visited.Contains(neighbor.Value))
					{
						queue.Enqueue(neighbor);
					}
				}
			}
		}
		return bfsTraversal;
	}

	public List<int> DFS(int start)
	{
		var startNode = GetNode(start);
		if (startNode == null)
		{
			return new List<int>(); // Return an empty list if the start node is not in the graph
		}

		var visited = new HashSet<int>();
		var stack = new Stack<GraphNode>();
		var dfsTraversal = new List<int>();

		stack.Push(startNode);

		while (stack.Count > 0)
		{
			GraphNode node = stack.Pop();

			if (!visited.Contains(node.Value))
			{
				visited.Add(node.Value);
				dfsTraversal.Add(node.Value);

				foreach (var neighbor in node.Neighbors)
				{
					if (!visited.Contains(neighbor.Value))
					{
						stack.Push(neighbor);
					}
				}
			}
		}

		return dfsTraversal;
	}
	public void PrintAllNodes()
	{
		Console.WriteLine("All nodes in the graph:");
		foreach (var node in Nodes)
		{
			Console.Write(node.Value + " ");
		}
		Console.WriteLine();
	}
}
// Klasa Program zawierająca metodę Main() do testowania klasy Graph
public class Program
{
	public static void Main()
	{
		// Tworzenie nowego grafu
		var graph = new Graph();
		// Dodanie krawędzi do grafu
		graph.AddEdge(1, 2);
		graph.AddEdge(1, 3);
		graph.AddEdge(2, 4);
	//	graph.AddEdge(2, 6);
		graph.AddEdge(3, 5);
		graph.AddEdge(6, 5);
		graph.AddEdge(4, 8);
		graph.AddEdge(4, 9);
		graph.AddEdge(6, 11);
		graph.RemoveEdge(2, 4);
		graph.PrintAllNodes();



		// Wykonanie przeszukiwania wszerz grafu od wierzchołka 1
		Console.WriteLine("BFS traversal:");
		var bfs = graph.BFS(4);
		foreach (var node in bfs)
		{
			Console.Write(node + " ");
		}
		Console.WriteLine();

		// Wykonanie przeszukiwania w głąb grafu od wierzchołka 1
		Console.WriteLine("DFS traversal:");
		var dfs = graph.DFS(3);
		foreach (var node in dfs)
		{
			Console.Write(node + " ");
		}
		// Zakończenie programu
		Console.WriteLine();
	}
}