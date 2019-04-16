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

			string searched = Console.ReadLine();
			while (string.IsNullOrWhiteSpace(searched) || !Char.IsLetter(searched.FirstOrDefault()))
			{
				Console.WriteLine("You should enter name, try again:");
				searched = Console.ReadLine();
			}

			Console.WriteLine("=== Search Started ===");
			string[] source = repository.Data.CopyData();
			bool searchComplete = false;
			int stepNumber = 1;
			
			do
			{
				Console.Write($"\nStep {stepNumber}, we enter:");
				foreach (string item in source)
				{
					Console.Write($"{item} ");
				}
				Console.WriteLine();

				int middleIndex = source.Length / 2;
				Console.WriteLine($"\nWe define the index of middle element: {middleIndex} \nto do it we just devide on 2 length of entered data.");

				int comparer = source[middleIndex].ToLower().CompareTo(searched.ToLower());
				Console.WriteLine($"\nWe compare middle element: {source[middleIndex]} \nwith element which we want to find: {searched} \nBy using String.CompareTo() method and get: {comparer}");

				if (comparer == 0)
				{
					searchComplete = true;
					Console.WriteLine($"\nAnd we foud that it element is equals with searched! \nIn data sequence we found: {searched} on step {stepNumber}");
				}
				else if (source.Count() == 1)
				{
					searchComplete = true;
					Console.WriteLine($"\nData sequence don't contains searched element");
				}
				else if (comparer < 0)
				{
					source = source.CopyDataFrom(middleIndex);
					Console.WriteLine("\nIf comparer value less then zero, that meat that middle element less then searched \nAnd we get elements affter middle element for next step");
				}
				else
				{
					source = source.CopyDataTill(middleIndex);
					Console.WriteLine("\nIf comparer value greate then zero, that meat that middle element higher then searched \nAnd we get elements before middle element (include it) for next step");
				}

				Console.WriteLine("\nPress any key to continue");
				Console.WriteLine("=====================================");
				Console.ReadKey();
				stepNumber++;
			} while (!searchComplete);
		}
	}
}
