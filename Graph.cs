using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoGraphImplementation
{
	public class Graph
	{
		public List<GraphNode> Nodes { get; private set; }
		public Graph()
		{
			Nodes = new List<GraphNode>();
		}

		public GraphNode GetNode(int value)
		{
			return Nodes.Find(node => node.Value == value);			// using linq find
		}
		public void AddNode(int value)
		{
			if (GetNode(value) == null)								// cannot add value if the falue already exists
			{
				Nodes.Add(new GraphNode(value));
			}
			else
			{
                Console.WriteLine($"Node {value} already exists");
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
			else
			{
				Console.WriteLine($"Node {value} doesn't exist");
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
			if (!fromNode.Neighbors.Contains(toNode))
			{
				fromNode.Neighbors.Add(toNode);
				toNode.Neighbors.Add(fromNode);
			}
			else
			{
                Console.WriteLine($"Edge from {from}, to {to} already exists.");
            }
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
		// BFS(Breadth-First Search)
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
		//DFS (Depth-First Search)
		public List<int> DFS(int start)
		{
			var startNode = GetNode(start);
			if (startNode == null)
			{
                Console.WriteLine("There is no Node of value {0}", start);
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
}
