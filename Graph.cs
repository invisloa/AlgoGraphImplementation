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
}
