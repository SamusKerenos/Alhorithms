using Sort;
using SourceAndExtensions;
using System;

namespace SortRepresentation
{
	class Program
	{
		static void Main()
		{
			int choise = 0;
			do
			{
				Console.WriteLine($@"
=========================================
| Available Representations:            |
| 1. Selection Sort                     |
| 2. Insertion Sort                     |
| 3. Exit                               |
=========================================
");
				choise = ConsoleExtensions.GetIntNumber(3, 1);

				switch (choise)
				{
					case 1:
						SortConsoleRepresentator.Represent(new SelectionSortWithDescription());
						break;
					case 2:
						SortConsoleRepresentator.Represent(new InsertionSortWithDescription());
						break;
					default:
						break;
				}
			} while (choise != 3);
		}
	}
}
