using System;

namespace Sort
{
	public class InsertionSort : ISort
	{
		public string Title => "Insertion Sort";

		public void Descending(int[] source)
		{
			Sort(source, (notSortedElement, alreadySortedElement) => notSortedElement > alreadySortedElement);
		}

		public void Ascending(int[] source)
		{
			Sort(source, (notSortedElement, alreadySortedElement) => notSortedElement < alreadySortedElement);
		}

		private void Sort(int[] source, Func<int, int, bool> shouldMoveSortedElementToRight)
		{
			for (int i = 0; i < source.Length; i++)
			{
				// we take element from i position of source array
				for (int j = 0; j < i; j++)
				{
					// we assume that all elements before i position
					// we iterate over sorted part of source array 
					// add move sorted element to right to insert 
					// element from i position of source array
					if (shouldMoveSortedElementToRight(source[i], source[j]))
					{
						int mem = source[i];
						source[i] = source[j];
						source[j] = mem;
					}

					// as a result of this iteration 
					// we increase sorted part (left part)
					// of our array to one element
				}
			}
		}
	}
}
