using System;

namespace Workers
{
	public static class ConsoleWorkEvents
	{
		public static void OnWorkStart(int maxCounter)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($" work start, max count is {maxCounter}");
		}

		public static void OnWorkComplete(int counter)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($" work stoped at {counter} count");
		}

		public static void OnProgressChanged(string partialResult)
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write(partialResult);
		}

		public static void OnShowDelay(int delay)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($" delay: {delay}");
		}

		public static void OnDiceRoll(int dice)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($" roll dice: {dice}");
		}

		public static void OnWorkCanceled()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(" work successful canceled");
		}
	}
}
