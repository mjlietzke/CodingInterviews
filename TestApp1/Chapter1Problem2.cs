using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
	class Chapter1Problem2 : ICodingProblem
	{
		public static bool Permutation(string first, string second)
		{
			if (first.Length == second.Length) {
				foreach (var element in first.ToCharArray()) {
					if (second.Contains(element)) {
						second = second.Remove(second.IndexOf(element));
					} else {   //does not contain letter, not permutation
						return false;
					}
				}
				//same size and contained all letters, it's a permutation
				return true;
			} else {
				//strings not same size, cannot be permutation
				return false;
			}
		}
		public void Run()
		{

			Console.Out.WriteLine("Please enter 2 words to see if they are permutations");
			string input = Console.In.ReadLine();
			Console.Out.WriteLine("Are they a permutation?" + Permutation(input.Split(' ')[0], input.Split(' ')[1]));
			input = Console.In.ReadLine();
		}
	}
}
