using System;
using System.Text;

namespace CallStack
{
	public class FactorialWithDescription
	{
		public StringBuilder Description { get; } = new StringBuilder();

		public int Step { get; private set; } = 1;

		public int RecurentFind(int source)
		{
			if (Step == 1)
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
				Description.AppendLine($"{ConsoleExtensions.MakeLeftPadding(Step)} Recurent case step: {Step,2} source: {source}");

				Step++;
				int nextResult = RecurentFind(source - 1);
				int currentResult = source * nextResult;
				Step--;

				Description.AppendLine($"{ConsoleExtensions.MakeLeftPadding(Step)} Back to step: {Step,2} result: {currentResult} = {source} * {nextResult}");

				if (Step == 1)
				{
					Description.AppendLine($@"
============================
| Factorial is: {currentResult, 10} |
============================
");
				}

				return currentResult;
			}
			else
			{
				Description.AppendLine($"{ConsoleExtensions.MakeLeftPadding(Step)} BASE CASE: recursion End, now function run back on call stack");
				return source;
			}
		}
	}
}
