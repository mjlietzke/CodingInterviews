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

			a.adjecentNode = new Node[] { b, c, e };
			b.adjecentNode = new Node[] { a, c };
			c.adjecentNode = new Node[] { a, b, e };
			d.adjecentNode = new Node[] { e };
			e.adjecentNode = new Node[] { a, c, d };
			BFS(a);
			Console.In.ReadLine();
		}

		public class Node {
			public string data { get; set; }
			public bool visited { get; set; }
			public Node[] adjecentNode;
			public Node(string data) {
				this.data = data;
			}
		}

		public bool BFS(Node root) {
			Queue<Node> nodeList = new Queue<Node>();
			root.visited = true;
			nodeList.Enqueue(root);
			while (nodeList.Count > 0) {
				Node r = nodeList.Dequeue();
				foreach (Node n in r.adjecentNode) {
					if (n.visited == false) {
						Visit(n);
						nodeList.Enqueue(n);
					}
				}
			}

			return false;
		}
		private void Visit(Node n) {
			n.visited = true;
			Console.Out.WriteLine("Visiting: " + n.data);
		}

	}
}
