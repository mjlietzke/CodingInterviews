using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions {
	class Chapter2Problem1 : ICodingProblem {
		public class Node<T> {
			public Node<T> next;
			public T data;
			public Node(T newData) {
				next = null;
				data = newData;
			}

			public void AppendToTail(T dataToAppend) {
				Node<T> node = this;
				while (node.next != null) {
					node = node.next;
				}
				var newNode = new Node<T>(dataToAppend);
				node.next = newNode;
			}
			public void Print() {
				Node<T> cur = this;
				do {
					Console.Out.Write($"{cur.data}->");
					cur = cur.next;
				} while (cur != null);
			}
		}
		public void RemoveDuplicates(Node<int> head) {
			var values = new HashSet<int>();
			Node<int> previous = head;
			values.Add(head.data);
			Node<int> cur = head.next;

			while (cur != null) {
				//Console.Out.WriteLine("Data: cur.data" + cur.data);
				if (values.Contains(cur.data)) {
					previous.next = cur.next;
				} else {
					values.Add(cur.data);
					//Console.Out.WriteLine(cur.data);
					previous = cur;
				}
				cur = cur.next;
			}

		}
		public void RemoveDuplicatesNoBuffer(Node<int> head) {
			
			Node<int> outer = head;
			Node<int> runner = head.next;
			Node<int> prev = head;

			while ( outer != null) {
				runner = outer;
				while(null != runner) {
					if(outer.data == runner.data) {
						prev.next = runner.next;
					}
					prev = runner;
					runner = runner.next;
				}
				//Console.Out.WriteLine("Data: cur.data" + cur.data);
				prev = outer;
				outer = outer.next;
			}

		}

		public void Run() {
			Node<int> myList = new Node<int>(1);
			myList.AppendToTail(2);
			myList.AppendToTail(3);
			myList.AppendToTail(4);
			myList.AppendToTail(4);
			myList.AppendToTail(3);
			myList.Print();
			Console.Out.WriteLine();
			//RemoveDuplicates(myList);
			RemoveDuplicatesNoBuffer(myList);
			myList.Print();
			Console.Out.WriteLine();
			Console.In.ReadLine();

		}
		
	}
}
