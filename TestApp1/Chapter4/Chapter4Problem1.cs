using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter4 {
	class Chapter4Problem1 : ICodingProblem {
		public void Run() {
			//grabbed input example from github
			//         b
			//       / |
			//     a - c
			//       \ |
			//         e - d


			Node a = new Node("a");
			Node b = new Node("b");
			Node c = new Node("c");
			Node d = new Node("d");
			Node e = new Node("e");

			a.AdjecentNodes = new Node[] { b, c, e };
			b.AdjecentNodes = new Node[] { a, c };
			c.AdjecentNodes = new Node[] { a, b, e };
			d.AdjecentNodes = new Node[] { e };
			e.AdjecentNodes = new Node[] { a, c, d };
			//BFS(a);
			Console.Out.WriteLine("list of vertices");
			//BFS(a);
			Console.Out.WriteLine("Type in a vertice to search for");
			string vertice = Console.In.ReadLine();
			//Console.Out.WriteLine($"A path exists:{BFS(a, vertice)}"); 
			Console.Out.WriteLine($"A path exists:{BidirectionalSearch(a, d)}");
			Console.In.ReadLine();
		}

		public class Node {
			public string Data { get; set; }
			public bool Visited { get; set; }
			public Node[] AdjecentNodes;
			public Node(string data) {
				this.Data = data;
				Visited = false;
			}
		}

		public void BFS(Node root) {
			Queue<Node> nodeList = new Queue<Node>();
			root.Visited = true;
			nodeList.Enqueue(root);
			while (nodeList.Count > 0) {
				Node r = nodeList.Dequeue();
				foreach (Node n in r.AdjecentNodes) {
					if (n.Visited == false) {
						Visit(n);
						nodeList.Enqueue(n);
					}
				}
			}
		}
		public bool BFS(Node root, string searchData) {
			Queue<Node> nodeList = new Queue<Node>();
			root.Visited = true;
			nodeList.Enqueue(root);
			int iterations = 0;
			if (root.Data == searchData) {
				Console.Out.WriteLine($"It took:{iterations} iterations");
				return true;
			}
			while (nodeList.Count > 0) {
				iterations++;
				Node r = nodeList.Dequeue();
				foreach (Node n in r.AdjecentNodes) {
					Console.Out.WriteLine($"We are examining node{n.Data}");
					if (n.Data == searchData) {
						Console.Out.WriteLine($"It took:{iterations} iterations");
						return true;
					}
					if (n.Visited == false) {
						Console.Out.WriteLine($"{n.Data} has not been visited ");
						Visit(n);
						nodeList.Enqueue(n);
					}
				}
			}
			Console.Out.WriteLine($"It took:{iterations} iterations");
			return false;
		}

		public bool BidirectionalSearch(Node startNode, Node endNode) {
			Queue<Node> startNodeList = new Queue<Node>();
			Queue<Node> endNodeList = new Queue<Node>();
			startNode.Visited = true;
			startNodeList.Enqueue(startNode);
			endNode.Visited = true;
			endNodeList.Enqueue(endNode);
			int iterations = 0;
			while (startNodeList.Count > 0 && endNodeList.Count > 0) {
				Node startAdj = startNodeList.Dequeue();
				Node endAdj = endNodeList.Dequeue();
				foreach (Node n in startAdj.AdjecentNodes) {
					if (endAdj.AdjecentNodes.Contains(n)) {
						Console.Out.WriteLine($"It took:{iterations} iterations");
						return true;
					}
					if (n.Visited == false) {
						Visit(n);
						startNodeList.Enqueue(n);
					}
				}
				foreach (Node n in endAdj.AdjecentNodes) {
					if (startAdj.AdjecentNodes.Contains(n)) {
						Console.Out.WriteLine($"It took:{iterations} iterations");
						return true;
					}
					if (n.Visited == false) {
						Visit(n);
						endNodeList.Enqueue(n);
					}
				}
			}
			Console.Out.WriteLine($"It took:{iterations} iterations");
			return false;
		}
		private void Visit(Node n) {
			n.Visited = true;
			Console.Out.WriteLine("Visiting: " + n.Data);
		}

	}
}
