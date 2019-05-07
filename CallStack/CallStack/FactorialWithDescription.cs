using System;
using System.Text;

namespace CallStack
{
	public class FactorialWithDescription
	{
		public StringBuilder Description { get; } = new StringBuilder();

		public int Level { get; private set; } = 1;

		public int RecurentFind(int source)
		{
			if (Level == 1)
			{
				Description.AppendLine($@"
==================================================
| We found factorial for {source, 2} and show             |
| how calls of functions stack in memory.        |
| Each function in call stack will be descripted |
==================================================
");
			}

			if (source != 1)
			{
				Description.AppendLine($"{ConsoleExtensions.MakeLeftPadding(Level)} Recurent level: {Level,2} source: {source}");

				Level++;
				int nextResult = RecurentFind(source - 1);
				int currentResult = source * nextResult;
				Level--;

				Description.AppendLine($"{ConsoleExtensions.MakeLeftPadding(Level)} Back to level: {Level,2} result: {currentResult} = {source} * {nextResult}");
				return currentResult;
			}
			else
			{
				Description.AppendLine($"{ConsoleExtensions.MakeLeftPadding(Level)} BASE CASE: recursion End, now function run back on call stack");
				return source;
			}
		}
	}
}
