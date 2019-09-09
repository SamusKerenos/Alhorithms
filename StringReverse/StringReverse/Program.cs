using System;

namespace StringReverse
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=== String revers alhorithm ===");

			Console.WriteLine("Enter the some sting to revers it:");
			string source = Console.ReadLine();

			Console.WriteLine($"The result is: {source.Revert()}");
		 }
	}
}
