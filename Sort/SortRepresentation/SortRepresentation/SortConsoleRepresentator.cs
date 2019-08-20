using SelectionSort;
using SourceAndExtensions;
using System;

namespace SortRepresentation
{
	public static class SortConsoleRepresentator
	{
		public static void Represent(ISort sorter)
		{
			Console.WriteLine(sorter.Title);

			int length = ConsoleExtensions.GetIntNumber(50, 5);
			int[] source = RandomGenerator.GetRandomIntArray(60, 0, length);
			int[] sorted = new int[length];

			Console.WriteLine($@"
=========================================
| Initial array: {source.Represent()}
=========================================
| Available Actions:                    |
| 1. Sort generated array by descending |
| 2. Sort generated array by ascending  |
=========================================
");
			int choice = ConsoleExtensions.GetIntNumber(2, 1);

			if (choice == 1)
			{
				Console.WriteLine($@"
========================================
| Descending Sort Selected             |
========================================");
				sorted = sorter.Descending(source);
			}

			if (choice == 2)
			{
				Console.WriteLine($@"
========================================
| Ascending Sort Selected              |
========================================");
				sorted = sorter.Ascending(source);
			}

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(sorter.Description);
			Console.ResetColor();

			Console.WriteLine($@"
========================================
|     Result is: {sorted.Represent()}
========================================");
		}
	}
}
