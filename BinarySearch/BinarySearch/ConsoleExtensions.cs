using System;
using System.Linq;
using System.Text;

namespace BinarySearch
{
	public static class ConsoleExtensions
	{
		public static string GetName()
		{
			Console.Write("Enter the name: ");
			string searched = Console.ReadLine();

			while (string.IsNullOrWhiteSpace(searched) || searched.Any(c => !Char.IsLetter(c)))
			{
				Console.Write("You should enter name, try again:");
				searched = Console.ReadLine();
			}

			return searched;
		}

		public static string Represent(this DataNode node)
		{
			return $"|| {node.Number,7} || {node.FirstLetter,7} || {node.Name}";
		}

		public static string NameStringRepresent(this DataNode[] data)
		{
			StringBuilder result = new StringBuilder();

			foreach (var item in data)
			{
				result.Append($"{item.Name} ");
			}

			return result.ToString();
		}
	}
}
