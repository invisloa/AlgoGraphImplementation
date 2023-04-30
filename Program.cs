using System;
using System.Collections.Generic;

public class Graph
{
	public List<int> Nodes { get; private set; }
	public List<List<int>> AdjacencyList { get; private set; }

	public Graph()
	{
		Nodes = new List<int>();
		AdjacencyList = new List<List<int>>();
	}

	public int GetIndex(int node)
	{
		return Nodes.IndexOf(node);
	}

	public void AddNode(int node)
	{
		if (!Nodes.Contains(node))
		{
			Nodes.Add(node);
			AdjacencyList.Add(new List<int>());
		}
	}

	public void RemoveNode(int node)
	{
		int index = GetIndex(node);
		if (index != -1)
		{
			Nodes.RemoveAt(index);
			AdjacencyList.RemoveAt(index);

			foreach (var neighbors in AdjacencyList)
			{
				neighbors.Remove(node);
			}
		}
	}

	public void AddEdge(int from, int to)
	{
		AddNode(from);
		AddNode(to);
		int indexFrom = GetIndex(from);
		int indexTo = GetIndex(to);
		AdjacencyList[indexFrom].Add(to);
		AdjacencyList[indexTo].Add(from); // Add the reverse edge for an undirected graph
	}

	public void RemoveEdge(int from, int to)
	{
		int indexFrom = GetIndex(from);
		int indexTo = GetIndex(to);
		if (indexFrom != -1)
		{
			AdjacencyList[indexFrom].Remove(to);
		}
		if (indexTo != -1)
		{
			AdjacencyList[indexTo].Remove(from); // Remove the reverse edge for an undirected graph
		}
	}

	public List<int> BFS(int start)
	{
		var visited = new HashSet<int>();
		var queue = new Queue<int>();
		var bfsTraversal = new List<int>();

		queue.Enqueue(start);

		while (queue.Count > 0)
		{
			int node = queue.Dequeue();

			if (!visited.Contains(node))
			{
				visited.Add(node);
				bfsTraversal.Add(node);

				int index = GetIndex(node);
				foreach (var neighbor in AdjacencyList[index])
				{
					if (!visited.Contains(neighbor))
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
		var visited = new HashSet<int>();
		var stack = new Stack<int>();
		var dfsTraversal = new List<int>();

		stack.Push(start);

		while (stack.Count > 0)
		{
			int node = stack.Pop();

			if (!visited.Contains(node))
			{
				visited.Add(node);
				dfsTraversal.Add(node);

				int index = GetIndex(node);
				foreach (var neighbor in AdjacencyList[index])
				{
					if (!visited.Contains(neighbor))
					{
						stack.Push(neighbor);
					}
				}
			}
		}

		return dfsTraversal;
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
		graph.AddEdge(6, 10);
		graph.RemoveEdge(2, 4);



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