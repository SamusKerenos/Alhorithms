using System;

namespace CallStack.BinaryTree
{
	public static class RandomGenerator
	{
		private static Random _engin = new Random(DateTime.Now.Millisecond);

		public static int[] GetRandomIntArray(int maxItem, int minItem, int count)
		{
			int[] result = new int[count];

			for (int i = 0; i < count; i++)
			{
				result[i] = _engin.Next(minItem, maxItem);
			}

			return result;
		}
	}
}
