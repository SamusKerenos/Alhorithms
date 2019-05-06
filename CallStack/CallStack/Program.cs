using System;

namespace CallStack
{
	internal class Program
	{
		private const int _max = 10;
		
		private static void Main(string[] args)
		{
			Console.WriteLine("===Call Stack Representation===");

			int number = ConsoleExtensions.GetIntNumber(15, 5);
			
			var factorial = new FactorialWithDescription();
			int result = factorial.RecurentFind(number);
			Console.WriteLine(factorial.Description);

			Console.WriteLine("Press any key to exit");
			Console.ReadLine();
		}
	}
}
