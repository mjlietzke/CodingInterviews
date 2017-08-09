using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
	public class Chapter2Problem4 : ICodingProblem
	{
		public class Node
		{
			public Node next;
			public int data;
			public Node(int newData)
			{
				next = null;
				data = newData;
			}
			
			public void appendToTail(int dataToAppend)
			{
				Node node = this;
				while (node.next != null) {
					node = node.next;
				}
				var newNode = new Node(dataToAppend);
				node.next = newNode;
			}
			public void Print() {
				Node cur = this;
				do {
					Console.Out.Write($"{cur.data}->");
					cur = cur.next;
				} while (cur != null);
			}
		}
		public static void Partition(Node head, int pivot)
		{
			Node leftPartition = null;
			Node rightPartition = null;
			Node cur = head;

			while (cur != null) {
				if (cur.data < pivot) {
					if (leftPartition != null) {
						leftPartition.appendToTail(cur.data);
					} else {
						leftPartition = new Node(cur.data);
					}
				} else {
					if (rightPartition != null) {
						rightPartition.appendToTail(cur.data);
					} else {
						rightPartition = new Node(cur.data);
					}
				}
				cur = cur.next;
			}
			cur = leftPartition;
			while (cur != null) {
				Console.Out.Write($"{cur.data}->");
				cur = cur.next;
			}
			cur = rightPartition;
			while (cur != null) {
				Console.Out.Write($"{cur.data}->");
				cur = cur.next;
			}
		}

		

		public void Run() {
			Node myList = new Node(3);
			myList.appendToTail(5);
			myList.appendToTail(8);
			myList.appendToTail(5);
			myList.appendToTail(10);
			myList.appendToTail(2);
			myList.appendToTail(1);
			myList.Print();
			Console.Out.WriteLine();
			Partition(myList, 5);
			myList.Print();
			Console.Out.WriteLine();
			Console.In.ReadLine();
			
		}
	}
}