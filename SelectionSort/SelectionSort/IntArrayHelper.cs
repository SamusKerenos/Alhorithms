using System.Collections.Generic;

namespace SelectionSort
{
	internal static class IntArrayHelper
	{
		public static int[] CopyInsteadOf(this int[] source, int value)
		{
			Stack<int> result = new Stack<int>();
			bool finded = false;

			for (int i = 0; i < source.Length; i++)
			{
				if (source[i] != value || finded)
				{
					result.Push(source[i]);
				}
				else
				{
					finded = true;
				}

			}

			return result.ToArray();
		}
	}
}
