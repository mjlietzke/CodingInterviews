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

			public void appendToTail(T dataToAppend) {
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
			Node<int> behind = null;
			Node<int> cur = head;			
			
			while (cur != null) {
				//Console.Out.WriteLine("Data: cur.data" + cur.data);
				if (values.Add(cur.data)) {
					Console.Out.WriteLine(cur.data);
					if (null == behind) {
						behind = head;
					} else {
						behind.next = cur;
					}
					cur = cur.next;
				} else {
					cur = cur.next;
				}
				
			}
			
		}

		public void Run() {
			Node<int> myList = new Node<int>(1);
			myList.appendToTail(2);
			myList.appendToTail(3);
			myList.appendToTail(3);
			myList.appendToTail(4); myList.appendToTail(4);
			myList.Print();
			Console.Out.WriteLine();
			RemoveDuplicates(myList);
			myList.Print();
			Console.Out.WriteLine();
			Console.In.ReadLine();

		}
		
	}
}
