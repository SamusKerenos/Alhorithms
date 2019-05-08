using System;

namespace CallStack
{
	public static class RandomGenerator
	{
		private static Random _engin = new Random(DateTime.Now.Millisecond);

		public static int[] GetRandomIntArray(int maxItem, int minItem, int length)
		{
			int[] result = new int[length];

			for (int i = 0; i < length; i++)
			{
				result[i] = _engin.Next(minItem, maxItem);
			}

			return result;
		}
	}
}
