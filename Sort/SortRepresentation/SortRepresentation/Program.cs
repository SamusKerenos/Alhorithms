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
==============================
| Available Representations: |
| 1. Selection Sort          |
| 2. Insertion Sort          |
| 3. Merdge Sort             |
| 4. Bubble Sort             |
| 5. Quick Sort              |
|----------------------------|
| 6. Clear Console           |
| 7. Exit                    |
==============================
");
				choise = ConsoleExtensions.GetIntNumber(7, 1);

				switch (choise)
				{
					case 1:
						SortConsoleRepresentator.Represent(new SelectionSort());
						break;
					case 2:
						SortConsoleRepresentator.Represent(new InsertionSort());
						break;
					case 3:
						SortConsoleRepresentator.Represent(new MerdgeSort());
						break;
					case 4:
						SortConsoleRepresentator.Represent(new BubbleSort());
						break;
					case 5:
						SortConsoleRepresentator.Represent(new QuickSort());
						break;
					case 6:
						Console.Clear();
						break;
					default:
						break;
				}
			} while (choise != 7);
		}
	}
}
