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
						
			var factorial = new FactorialWithDescription();
			int result = factorial.RecurentFind(number);
			Console.WriteLine(factorial.Description);

			Console.WriteLine("Press any key to exit");
			Console.ReadLine();
		}
	}
}
