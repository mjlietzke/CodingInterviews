using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter8 {
	class Chapter8Problem1 : ICodingProblem {
		public void Run() {
			int stairs = 3;
			System.Console.Out.WriteLine($"For {stairs} number of stairs, there are {CountingStairs(stairs)} ways to climb them");

		}

		//child is running up the N stairs either by 1 2 ir 3
		//imlpement a method that counts all possible ways that a child can climb the stairs

		//basic premise:
		//we can take the remaining number of stairs at any given level and count the invocation of the funciton when taking 1 2 or 3 steps and repeat

		public int CountingStairs(int numberOfStairsLeft) {
			int count = 0;
			if(0 == numberOfStairsLeft) {
				return 0;
			}
			if (numberOfStairsLeft >= 3) {
				//numberOfStairsLeft = numberOfStairsLeft - 3;
				count += 1 + CountingStairs(numberOfStairsLeft - 3);
			}
			if (numberOfStairsLeft >= 2) {
				//numberOfStairsLeft = numberOfStairsLeft - 2;
				count += 1 + CountingStairs(numberOfStairsLeft - 2);
			}
			if (numberOfStairsLeft >= 1) {
				//numberOfStairsLeft = numberOfStairsLeft - 1;
				count += 1 + CountingStairs(numberOfStairsLeft - 1);
			}

			return count;
		}
	
	}
}
