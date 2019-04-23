using System;

namespace SelectionSort
{
	internal class Program
	{
		private const int min = 1;
		private const int max = 50;

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
			Console.WriteLine($@"We sort array by descending,
where min value is: {min} 
and max value is: {max}");
			Console.WriteLine("=====================================");
			Console.Write("Data for sort:");
			for (int i = 0; i < source.Length; i++)
			{
				source[i] = random.Next(min, max);
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
				Console.WriteLine("-------------------------------------");
				Console.WriteLine($@"We try to found the bigest element in source array. 
We put the first element of source array at {j} position in sorted array 
Then we compare each element in source array with this element
And change it if we found a bigger element");
				Console.WriteLine("-------------------------------------");

				sorted[j] = source[0];
				for (int i = 0; i < source.Length; i++)
				{
					Console.Write($" -check: {i + 1}");
					if (sorted[j] < source[i])
					{
						Console.Write(" ==Finded!");
						sorted[j] = source[i];
						step++;
					}
					step++;
				}
				Console.WriteLine();
				Console.WriteLine("-------------------------------------");
				Console.WriteLine($@"We find the greatest element in source sequince.
And put it on {j} position in result sequence.
Now we change element: {sorted[j]} in source sequence to {min}");
				Console.WriteLine("-------------------------------------");

				for (int i = 0; i < source.Length; i++)
				{
					step++;
					if (source[i] == sorted[j])
					{
						Console.Write(" ==Change!");
						source[i] = min;
						step++;
						break;
					}
					else
					{
						Console.Write($" -don't: {i}");
					}
				}

				Console.WriteLine();
				Console.WriteLine("-------------------------------------");
				Console.WriteLine("Press any key to continue");
				Console.WriteLine("=====================================");
				Console.ReadKey();
				step++;
			}

			Console.Write("Sorted sequence: ");
			ShowSequence(sorted);
			Console.WriteLine($"We make {step} steps to do it for array with length: {length}");
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
