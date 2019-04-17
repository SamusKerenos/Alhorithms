using System;

namespace SelectionSort
{
	internal class Program
	{
		private const int min = 1;
		private const int max = 2;

		private static void Main(string[] args)
		{
			Console.WriteLine("===Selection Sort Representation===");

			Console.Write("\nEnter length for source array: ");
			string strLength = Console.ReadLine();
			int length = 0;

			while (!int.TryParse(strLength, out length))
			{
				Console.Write("Entered data is not a number, try again: ");
				strLength = Console.ReadLine();
			}

			int[] source = new int[length];
			Random random = new Random(DateTime.Now.Millisecond);

			Console.WriteLine("=====================================");
			Console.WriteLine($"We sort array by descending,\nmin value is: {min} \nmax value is: {max}");

			Console.WriteLine("=====================================");
			Console.WriteLine("Data for sort:");
			for (int i = 0; i < source.Length; i++)
			{
				source[i] = random.Next(1, 100);
				Console.Write($"{source[i]} ");
			}
			Console.WriteLine();
			Console.WriteLine("=====================================");

			int[] sorted = new int[length];
			int step = 1;

			for (int j = 0; j < sorted.Length; j++)
			{
				Console.Write($"Step {step} we enter: ");
				ShowSequence(source);

				sorted[j] = source[0];
				for (int i = 0; i < source.Length; i++)
				{
					if (sorted[j] < source[i])
					{
						sorted[j] = source[i];
					}
				}
				Console.WriteLine($"We find the greatest element in source sequince. And put in on {j + 1} position in result sequence");

				Console.WriteLine($"\nNow we create new source sequence without element {sorted[j]}");
				source = source.CopyInsteadOf(sorted[j]);
		
				Console.WriteLine("\nPress any key to continue");
				Console.WriteLine("=====================================");
				Console.ReadKey();
				step++;
			}

			Console.Write("Sorted sequence: ");
			ShowSequence(sorted);
			Console.WriteLine("=====================================");
			
			Console.ReadKey();
		}

		private static void ShowSequence(int[] sequence)
		{
			foreach (int item in sequence)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
		}
	}
}
