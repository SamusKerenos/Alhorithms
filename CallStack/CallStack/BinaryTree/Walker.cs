using System;
using System.Collections.Generic;
using System.Text;

namespace CallStack.BinaryTree
{
	public class WalkerWithDescription
	{
		public StringBuilder Description { get; } = new StringBuilder();
		public int Level { get; private set; } = 1;

		public List<int> RecurentWalk(Node root)
		{
			List<int> result = new List<int>();

			if (Level == 1)
			{
				Description.AppendLine($@"
================================================
| We show recurent walking through binary tree |
================================================
");
			}
			
			if (root.Left != null)
			{
				Level++;
				var left = RecurentWalk(root.Left);
				result.AddRange(left);
			}
			
			if (root.Right != null)
			{
				Level++;
				var right = RecurentWalk(root.Right);
				result.AddRange(right);
			}

			result.Add(root.Data);

			Description.AppendLine($"{ConsoleExtensions.MakeLeftPadding(Level)} Recurent level: {Level} | All values: {result.Represent()}");
			Level--;
			
			return result;
		}
	}
}
