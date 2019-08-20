using Sort;
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
				sorter.Descending(source);
			}

			if (choice == 2)
			{
				sorter.Ascending(source);
			}

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(sorter.Description);
			Console.ResetColor();

			Console.WriteLine($@"
========================================
|     Result is: {source.Represent()}
========================================");
		}
	}
}
