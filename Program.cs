using AlgoGraphImplementation;
using System;
using System.Collections.Generic;

var graph = new Graph();
/*graph.AddEdge(1, 2);
graph.AddEdge(1, 3);
graph.AddEdge(2, 4);
graph.AddEdge(3, 5);
graph.AddEdge(6, 5);
graph.AddEdge(4, 8);
graph.AddEdge(4, 9);
graph.AddEdge(6, 11);
graph.RemoveEdge(2, 4);
*/
graph.AddEdge(1, 3);
graph.AddEdge(1, 3);
graph.AddEdge(1, 3);
graph.PrintAllNodes();

//Breadth-First Search (BFS)
// Wykonanie przeszukiwania wszerz grafu od wierzchołka X
Console.WriteLine("BFS traversal:");
var bfs = graph.BFS(1);
foreach (var node in bfs)
	{
		Console.Write(node + " ");
	}
Console.WriteLine();

//Depth-First Search (DFS) 
// Wykonanie przeszukiwania w głąb grafu od wierzchołka X
Console.WriteLine("DFS traversal:");
var dfs = graph.DFS(3);
foreach (var node in dfs)
	{
		Console.Write(node + " ");
	}
