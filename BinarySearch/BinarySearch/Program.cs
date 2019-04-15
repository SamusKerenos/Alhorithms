using System;
using System.Linq;

namespace BinarySearch
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("===Binary Search Representation===");
			var repository = new Repository();

			Console.WriteLine("Data for search:");
			Console.WriteLine("|| Name:     || Number: || Letter: ||");
			Console.WriteLine("=====================================");
			for (int i = 0; i < repository.Data.Length; i++)
			{
				int number = i + 1;
				Console.WriteLine($"|| {repository.Data[i], -10}||{number, 8} ||{repository.Data[i].FirstOrDefault(), 8} ||");
			}
			Console.WriteLine("=====================================");

			Console.WriteLine($"In summary we have: {repository.Data.Count()} names, \n which sort by first letters, \n starter from: {repository.Data.FirstOrDefault().FirstOrDefault()} and end at: {repository.Data.Last().FirstOrDefault()}");
			Console.WriteLine("=====================================");

			Console.WriteLine("Now enter the name which you want to search:");

			string data = Console.ReadLine();
			while (string.IsNullOrWhiteSpace(data) || !Char.IsLetter(data.FirstOrDefault()))
			{
				Console.WriteLine("You should enter name, try again:");
				data = Console.ReadLine();
			}

			string[] source = repository.Data.CopyData();
			bool searchComplete = false;
			bool success = false;
			int stepNumber = 1;

			do
			{
				Console.Write($"Step {stepNumber}, we enter:");
				foreach (string item in source)
				{
					Console.Write($"{item} ");
				}
				Console.WriteLine();

				success = SearchEngin.Step(ref source, data);

				searchComplete = success || !source.Any();
				
				stepNumber++;
			} while (!searchComplete);

			if (success)
			{
				Console.WriteLine($"In data sequence we found: {data} on step {stepNumber}");
			}
			else
			{
				Console.WriteLine($"We don't found {data} in curent sequence, search complete on {stepNumber}");
			}

			Console.ReadKey();
		}
	}
}
