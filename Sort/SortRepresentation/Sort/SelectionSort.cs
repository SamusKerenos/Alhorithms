using System;

namespace Sort
{
	public class SelectionSort : ISort
	{
		public string Title => "Selection Sort";

		public void Descending(int[] source)
		{
			Sort(source, (first, second) => first < second);
		}

		public void Ascending(int[] source)
		{
			Sort(source, (first, second) => first > second);
		}

		private void Sort(int[] source, Func<int, int, bool> shouldChange)
		{
			for (int i = 0; i < source.Length; i++)
			{
				// we take element from i position of source array
				for (int j = i + 1; j < source.Length; j++)
				{
					// we iterate over the source array 
					// to find fittest element to i position
					// according with sort direction
					// start from next position after i
					if (shouldChange(source[i], source[j]))
					{
						// we change value of element at i position
						// with value of element at j position
						int mem = source[i];
						source[i] = source[j];
						source[j] = mem;
					}
				}
			}
		}
	}
}
