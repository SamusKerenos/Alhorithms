using System.Text;

namespace System
{
	public static class ConsoleExtensions
	{
		public static int GetIntNumber(int max, int min)
		{
			Console.Write($"Enter some number which not bigger then {max} or less then {min}: ");
			string strNumber = Console.ReadLine();

			bool sucessful = false;
			int number = 0;

			do
			{
				sucessful = int.TryParse(strNumber, out number);
				if (!sucessful)
				{
					Console.Write("Entered data is not a number, try again: ");
					strNumber = Console.ReadLine();
				}
				else if (number > max)
				{
					sucessful = false;
					Console.Write($"Entered number is bigger then {max}, try again: ");
					strNumber = Console.ReadLine();
				}
				else if (number < min)
				{
					sucessful = false;
					Console.Write($"Entered number is less then {min}, try again: ");
					strNumber = Console.ReadLine();
				}
			} while (!sucessful);

			return number;
		}

		public static string Represent(this int[] source)
		{
			StringBuilder result = new StringBuilder();

			foreach (int item in source)
			{
				result.Append($" {item}");
			}

			return result.ToString();
		}
	}
}
