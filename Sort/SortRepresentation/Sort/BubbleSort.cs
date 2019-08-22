using System;

namespace Sort
{
	public class BubbleSort : ISort
	{
		public string Title => "Bubble Sort";
		
		public void Descending(int[] source)
		{
			Sort(source, (first, second) => first < second);
		}

		public void Ascending(int[] source)
		{
			Sort(source, (first, second) => first > second);
		}

		private void Sort(int[] source, Func<int, int, bool> shouldMovElementToRight)
		{
			for (int i = 0; i < source.Length; i++)
			{
				// we iterate over source array this is main iteration
				for (int j = 1; j < source.Length - i; j++)
				{
					// we iterate unsorted part of array (it decrease on one
					// element on the end of source array at every step of main
					// iteration). And compare first element with the second to
					// find what elemen need to move right according with
					// sort direction
					if (shouldMovElementToRight(source[j - 1], source[j]))
					{
						int mem = source[j - 1];
						source[j - 1] = source[j];
						source[j] = mem;
					}

					// as a result of this iteration 
					// we increase sorted part (right part)
					// of our array to one element
				}
			}
		}
	}
}
