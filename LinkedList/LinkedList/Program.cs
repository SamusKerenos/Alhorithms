using System;

namespace LinkedList
{
	class Program
	{
		static void Main(string[] args)
		{
			LinkedList<string> source = new LinkedList<string>();

			source.Add(" the");
			source.Add(" quick");
			source.Add(" brown");
			source.Add(" fox");
			source.Add(" jumps");
			source.Add(" over");
			source.Add(" the");
			source.Add(" lazy");
			source.Add(" dog");

			Console.WriteLine("Default order");	
			Represent<string>(source, ConsoleColor.Cyan);

			source.Reverse();

			Console.WriteLine("Reverse order");
			Represent<string>(source, ConsoleColor.DarkMagenta);
		}

		private static void Represent<T>(LinkedList<T> source, ConsoleColor color)
			where T : IComparable<T>
		{
			Console.ForegroundColor = color;
			foreach (var item in source)
			{
				Console.Write(item);
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine();
		}
	}
}
