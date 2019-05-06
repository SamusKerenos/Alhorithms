using CallStack.BinaryTree;
using System;
using System.Linq;

namespace CallStack
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("=== Call Stack Representation ===");
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
			}

			if (choice == 2)
			{
				Console.WriteLine("=== Binary Tree Selected ===");
				
				var tree = RandomGenerator.GetRandomIntThree(16, 1, 25);
				var treeWalker = new WalkerWithDescription();
				var result = treeWalker.RecurentWalk(tree).ToList();

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(treeWalker.Description);
				Console.ResetColor();
			}

			Console.WriteLine("Press any key to exit");
			 Console.ReadKey();
		}
	}
}
