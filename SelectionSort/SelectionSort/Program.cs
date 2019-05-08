using System;

namespace SelectionSort
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("=== Selection Sort Representation ===");

			int length = ConsoleExtensions.GetIntNumber(50, 5);
			int[] source = RandomGenerator.GetRandomIntArray(60, 0, length);
			var sorter = new SelectionSortWithDescription();
			int[] sorted = new int[length];
			
			Console.WriteLine($@"
Available Actions:
=========================================
| 1. Sort generated array by descending |
| 2. Sort generated array by ascending  |
=========================================
| Initial array: {source.Represent()}
=========================================
");
			int choice = ConsoleExtensions.GetIntNumber(2, 1);

			if (choice == 1)
			{
				Console.WriteLine("=== Descending Sort Selected ===");
				sorted = sorter.Descending(source);
			}

			if (choice == 2)
			{
				Console.WriteLine("=== Ascending Sort Selected ===");
				sorted = sorter.Ascending(source);
			}

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(sorter.Description);
			Console.ResetColor();

			Console.WriteLine($@"
========================================
| Result is: {sorted.Represent()}
========================================
");

			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}

	}
}
