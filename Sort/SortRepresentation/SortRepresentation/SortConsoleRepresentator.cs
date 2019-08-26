using Sort;
using SourceAndExtensions;
using System;

namespace SortRepresentation
{
	public static class SortConsoleRepresentator
	{
		public static void Represent(ISort sorter)
		{
			string _sortRuleName = string.Empty;
			int length = ConsoleExtensions.GetIntNumber(30, 5);
			int[] source = RandomGenerator.GetRandomIntArray(100, 0, length);

			Console.WriteLine($@"
=========================================
| Alhorithm: {sorter.Title}
| Initial array: {source.Represent()}
=========================================
| Available Actions:                    |
| 1. Sort generated array by descending |
| 2. Sort generated array by ascending  |
=========================================
");
			switch (ConsoleExtensions.GetIntNumber(2, 1))
			{
				case 1:
					_sortRuleName = "DESCENDING";
					sorter.Descending(source);
					break;
				case 2:
					_sortRuleName = "ASCENDING";
					sorter.Ascending(source);
					break;
				default:
					break;
			}

			Console.WriteLine($@"
========================================
|  {_sortRuleName,10} sort with description    |
========================================
|     Result is: {source.Represent()}
========================================");
		}
	}
}
