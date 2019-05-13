using CallStack.BinaryTree;
using System;
using System.Linq;

namespace CallStack
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("=== Call Stack In Recurent Algorithms ===");
			Console.WriteLine(@"
Available Actions:
============================================
| 1. Factorial call stack representation   |
| 2. Binary tree call stack representation |
============================================
");
			int choice = ConsoleExtensions.GetIntNumber(2, 1);

			if (choice == 1)
			{
				Console.WriteLine("=== Factorial Selected ===");
				int number = ConsoleExtensions.GetIntNumber(12, 5);

				var factorial = new FactorialWithDescription();
				int result = factorial.RecurentFind(number);

				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine(factorial.Description);
				Console.ResetColor();

				Console.WriteLine($@"
============================
| Factorial is: {result,10} |
============================
");
			}

			if (choice == 2)
			{
				Console.WriteLine("=== Binary Tree Selected ===");
				int length = ConsoleExtensions.GetIntNumber(30, 10);

				int[] source = new int[]
				{ 4, 4, 10, 3, 14, 7, 13, 5, 9, 8, 9, 9, 15, 8, 2, 5, 10, 4, 11, 10, 7, 9, 11, 15, 9 }; 
				//RandomGenerator.GetRandomIntArray(16, 1, length);
				Console.WriteLine($@"
===========================================================
| Initial array: {source.Represent()}
===========================================================
");
				var tree = new Node();
				foreach (var item in source)
				{
					tree.Data = item;
				}

				var treeWalker = new WalkerWithDescription();
				var result = treeWalker.RecurentWalk(tree).ToList();

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(treeWalker.Description);
				Console.ResetColor();

				Console.WriteLine($@"
===========================================================
| Result list: {result.Represent()}
===========================================================
");
			}

			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}
	}
}
