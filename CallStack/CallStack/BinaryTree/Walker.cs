using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallStack.BinaryTree
{
	public class WalkerWithDescription
	{
		public StringBuilder Description { get; } = new StringBuilder();
		public int Step { get; private set; } = 1;

		public List<int> RecurentWalk(Node root)
		{
			List<int> result = new List<int>();

			if (Step == 1)
			{
				Description.AppendLine($@"
======================================================
| We show walking throw random generated binary tree |
======================================================
");
			}

			if (root.Left != null)
			{
				Step++;
				var left = RecurentWalk(root.Left);
				Step--;
				Description.AppendLine($"{ConsoleExtensions.MakeLeftPadding(Step)} values returned from left is: {left.RepresentList()}");
				result.AddRange(left);
			}
			
			if (root.Right != null)
			{
				Step++;
				var right = RecurentWalk(root.Right);
				Step--;
				Description.AppendLine($"{ConsoleExtensions.MakeLeftPadding(Step)} value returned from right is: {right.RepresentList()}");
				result.AddRange(right);
			}

			result.Add(root.Data);

			if (Step == 1)
			{
				Description.AppendLine($@"
============================================================
| All items: {result.RepresentList()}
============================================================
");
			}

			return result;
		}
	}
}
