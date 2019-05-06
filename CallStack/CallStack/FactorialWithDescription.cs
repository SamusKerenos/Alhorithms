using System;
using System.Collections.Generic;
using System.Text;

namespace CallStack
{
	public class FactorialWithDescription
	{
		public FactorialWithDescription()
		{
			Step = 1;
		}

		public StringBuilder Description { get; } = new StringBuilder();

		public int Step { get; private set; }
				
		public int RecurentFind(int source)
		{
			if (Step == 1)
			{
				Description.AppendLine($@"
=========================================================
We found factorial for {source} and show 
how calls of functions stack in memory.
Each function in call stack will be represetn by: -symbol
=========================================================
");
			}

			if (source != 1)
			{
				Description.AppendLine($"{MakeLeftPadding()} Recurent case step: {Step, 2} source: {source}");

				Step++;
				int result = source * RecurentFind(source - 1);
				Step--;

				Description.AppendLine($"{MakeLeftPadding()} Back to step: {Step, 2} result: {result}");

				if (Step == 1)
				{
					Description.AppendLine($@"
=========================================================
Factorial is: {result}
=========================================================
");
				}

				return result;
			}
			else
			{
				Description.AppendLine($"{MakeLeftPadding()} BASE CASE: recursion End, now function run back on call stack");
				return source;
			}
		}
		

		private string MakeLeftPadding()
		{
			StringBuilder result = new StringBuilder();

			for (int i = 0; i < Step; i++)
			{
				result.Append("-");
			}

			return result.ToString();
		}
	}
}
