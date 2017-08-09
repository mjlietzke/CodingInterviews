using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter2 {
	//Check a LL if it is a palendrome
	class Chapter2Problem6 : ICodingProblem{

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
		
		public bool Palendrome(Node<char> head) {
			Node<char> reverseList = ReverseList(head);
			while(reverseList != null && head != null) {
				if(reverseList.data != head.data) {
					return false;
				}
				reverseList = reverseList.next;
				head = head.next;
			}
			if(reverseList == null && head == null) {
				return true;
			} else {
				return false;
			}

		}
		public Node<char> ReverseList(Node<char> node) {
			Node<char> head = null;
			while (node != null) {
				Node<char> cur = new Node<char>(node.data);
				cur.next = head;
				head = cur;
				node = node.next;
			}
			return head;
		}
			
		public void Run() {
			Node<char> myList = new Node<char>('1');
			myList.appendToTail('2');
			myList.appendToTail('3');
			myList.appendToTail('3');
			myList.appendToTail('2');
			myList.appendToTail('1');
			myList.Print();
			Console.In.ReadLine();
			Console.Out.WriteLine($"They are a palendrome is:{Palendrome(myList)}");
			//Node<char> myListReversed = ReverseList(myList);
			//myListReversed.Print();
			//Console.Out.WriteLine();
			Console.In.ReadLine();
		}

	}
}
