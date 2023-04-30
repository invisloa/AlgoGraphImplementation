using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoGraphImplementation
{
	public class GraphNode
	{
		public int Value { get; set; }
		public List<GraphNode> Neighbors { get; set; }

		public GraphNode(int value)
		{
			Value = value;
			Neighbors = new List<GraphNode>();
		}
	}
}
