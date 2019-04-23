using System;

namespace CallStack
{
	internal class Program
	{
		private const int _max = 10;
		
		private static void Main(string[] args)
		{
			Console.WriteLine("===Call Stack Representation===");

			Console.Write("Enter some number (not too big, we use recursion): ");
			string strNumber = Console.ReadLine();
			int number = 0;
			while (!int.TryParse(strNumber, out number) || number > _max)
			{
				Console.Write($"Entered data is not a number or value bigger then: {_max}, try again: ");
				strNumber = Console.ReadLine();
			}

			Console.WriteLine("=================================");
			Console.WriteLine($@"Now we found factorial of {number} 
and show how calls of functions stack in memory.
Each function in call stack will be represetn by: - symbol ");
			Console.WriteLine("=================================");

			int step = 1;
			int result = RecurentFactorialWitDescription(number, step);

			Console.WriteLine("=================================");
			Console.WriteLine($"Factorial for: {number} is: {result}");
			Console.WriteLine("=================================");
			Console.WriteLine("Press any key to exit");
			Console.ReadLine();
		}

		private static int RecurentFactorialWitDescription(int source, int step)
		{
			if (source != 1)
			{
				MakeLeftPadding(step);
				Console.WriteLine($"Recurent case step: {step} source: {source}");
				
				step++;
				int result = source * RecurentFactorialWitDescription(source - 1, step);
				step--;
				
				MakeLeftPadding(step);
				Console.WriteLine($"Back to step: {step} result: {result}");
				return result;
			}
			else
			{
				MakeLeftPadding(step);

				Console.WriteLine("BASE CASE: recursion End, now function run back on call stack");
				return source;
			}
		}

		private static void MakeLeftPadding(int count)
		{
			for (int i = 0; i < count; i++)
			{
				Console.Write("-");
			}
		}
	}
}
