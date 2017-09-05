using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter8 {
	class Chapter8Problem1 : ICodingProblem {
		public void Run() {
			int stairs = 3;
			System.Console.Out.WriteLine($"For {stairs} number of stairs, there are {CountingStairs(stairs)} ways to climb them. Press any key to continue");
			Console.In.ReadLine();
		}

		//child is running up the N stairs either by 1 2 ir 3
		//imlpement a method that counts all possible ways that a child can climb the stairs

		//basic premise:
		//we can take the remaining number of stairs at any given level and count the invocation of the funciton when taking 1 2 or 3 steps and repeat

		public int CountingStairs(int numberOfStairsLeft) {
			if(numberOfStairsLeft < 0) {
				return 0;
			} else if (numberOfStairsLeft == 0) {
				return 1;
			} else {
				return CountingStairs(numberOfStairsLeft - 3) + CountingStairs(numberOfStairsLeft - 2) + CountingStairs(numberOfStairsLeft - 1);
			}
			
		}
	
	}
}
