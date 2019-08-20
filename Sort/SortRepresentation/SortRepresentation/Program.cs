using SelectionSort;
using SourceAndExtensions;
using System;

namespace SortRepresentation
{
	class Program
	{
		static void Main()
		{
			int[] available = new int[] { 1, 2 };
			int choise = 0;

			do
			{
				Console.WriteLine($@"
=========================================
| Available Representations:            |
| 1. Selection Sort                     |
| 2. Exit                               |
=========================================
");
				choise = ConsoleExtensions.GetIntNumber(2, 1);

				if (choise == 1)
				{
					SortConsoleRepresentator.Represent(new SelectionSortWithDescription());
				}
			} while (choise != 2);
		}
	}
}
