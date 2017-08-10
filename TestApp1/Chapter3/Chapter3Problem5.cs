using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter3 {
	class Chapter3Problem5 : ICodingProblem {
		Stack<int> unsortedStack = new Stack<int>();
		public void SortUsingStack(Stack<int> unsorted) {
			Stack<int> sorted = new Stack<int>();
			int temp;
			int counter;
			while(unsorted.Count >= 1) {
				temp = unsorted.Pop();
				counter = 0;
				if (sorted.Count == 0) {
					sorted.Push(temp);
				} else {
					while (sorted.Count > 0 && temp > sorted.Peek()) {
						counter++;
						unsorted.Push(sorted.Pop());
					}
					sorted.Push(temp);
					while (counter > 0) {
						sorted.Push(unsorted.Pop());
						counter--;
					}
				}
			}
			foreach (int x in sorted) {
				Console.Out.Write($"{x}->");
			}
		}
		public void Run() {
			unsortedStack.Push(9);
			unsortedStack.Push(10);
			unsortedStack.Push(6);
			unsortedStack.Push(7);
			unsortedStack.Push(8);
			Console.Out.WriteLine($"The stack looks like:");
			foreach (int x in unsortedStack) {
				Console.Out.Write($"{x}->");
			}
			Console.In.ReadLine();
			SortUsingStack(unsortedStack);
			Console.In.ReadLine();
		}
	}
}
