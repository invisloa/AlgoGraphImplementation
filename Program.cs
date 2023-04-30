using AlgoGraphImplementation;
using System;
using System.Collections.Generic;

var graph = new Graph();
graph.AddEdge(1, 2);
graph.AddEdge(1, 3);
graph.AddEdge(2, 4);
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
