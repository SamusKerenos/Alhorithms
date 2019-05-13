using System;
using System.Collections.Generic;
using System.Text;

namespace CallStack.BinaryTree
{
	public class WalkerWithDescription
	{
		public StringBuilder Description { get; } = new StringBuilder();
		public int Level { get; private set; } = 1;

		public List<int> RecurentWalk(Node root, string nodeType = "root")
		{
			List<int> result = new List<int>();

			if (Level == 1)
			{
				Description.AppendLine($@"
=================================================
| We show recurent walking through binary tree  |
| At first we look at left side and if we have  |
| left node we move there. Then we look at rght |
| and if we have right node - move there. Then  |
| we look at current node to take it value and  |
| move to the root                              |
=================================================
");
			}
			
			if (root.Left != null)
			{
				Level++;
				Description.Append($"|({nodeType}) -> Left |");
				var left = RecurentWalk(root.Left, "left");
				result.AddRange(left);
			}
			
			if (root.Right != null)
			{
				Level++;
				Description.Append($"|({nodeType})-> Right |");
				var right = RecurentWalk(root.Right, "right");
				result.AddRange(right);
			}

			result.Add(root.Data);
			Description.AppendLine($"|({nodeType})= Got: {root.Data}|");
			Description.AppendLine($@"{ConsoleExtensions.MakeLeftPadding(Level)} | Recurent level: {Level} | All values: {result.Represent()}
-------------------------------------------------------------------------------------------------------------------");
			Level--;
			
			return result;
		}
	}
}
