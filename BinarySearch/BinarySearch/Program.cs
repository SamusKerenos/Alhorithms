using System;

namespace BinarySearch
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("=== Binary Search Representation ===");
			var repository = new Repository();
			var searcher = new BinarySearchWithDescription();

			Console.WriteLine("Data for search:");
			Console.WriteLine(repository.Represent());

			string searchedName = ConsoleExtensions.GetName();

			Console.WriteLine("=== Search Started ===");
			DataNode searched = searcher.Search(repository.Data, searchedName);

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(searcher.Description);
			Console.ResetColor();

			Console.WriteLine($@"
======================================
|| Searched node is: 
{searched.Represent()}
======================================
");

			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}
	}
}
