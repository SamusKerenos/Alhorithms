using System;

namespace CallStack.BinaryTree
{
	public static class RandomGenerator
	{
		private static Random _engin = new Random(DateTime.Now.Millisecond);

		public static Node GetRandomIntThree(int maxItem, int minItem, int count)
		{
			Node result = new Node();

			while (count > 0)
			{
				result.Data = _engin.Next(minItem, maxItem);
				count--;
			}

			return result;
		}
	}
}
