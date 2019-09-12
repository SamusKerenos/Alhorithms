using System;

namespace SourceAndExtensions
{
	public static class ConsoleExtensions
	{
		public static int GetIntNumber(int max, int min)
		{
			string strNumber;
			bool sucessful;
			int number;

			Console.Write($"Enter some number which not bigger then {max} or less then {min}: ");

			do
			{
				strNumber = Console.ReadLine();
				sucessful = int.TryParse(strNumber, out number);
				if (!sucessful)
				{
					Console.Write("Entered data is not a number, try again: ");
				}
				else if (number > max)
				{
					sucessful = false;
					Console.Write($"Entered number is bigger then {max}, try again: ");
				}
				else if (number < min)
				{
					sucessful = false;
					Console.Write($"Entered number is less then {min}, try again: ");
				}
			} while (!sucessful);

			return number;
		}
	}
}
