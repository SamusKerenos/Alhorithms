using System;

namespace Sort
{
	public class MerdgeSort : ISort
	{
		public string Title => "Merdge Sort";

		public void Descending(int[] source)
		{
			Sort(source, (leftElement, rightElement) => leftElement > rightElement);
		}

		public void Ascending(int[] source)
		{
			Sort(source, (leftElement, rightElement) => leftElement < rightElement);
		}

		private void Sort(int[] source, Func<int, int, bool> canAdd)
		{
			if (source.Length > 1)
			{
				// we need to do something only when source array 
				// have more then one element, because in other case
				// it is already sorted.
				
				int[] left = new int[source.Length / 2];
				int[] right = new int[source.Length - source.Length / 2];
				// we devide source array to left and right part
				
				for (int i = 0; i < left.Length; i++)
				{
					left[i] = source[i];
				}
				// we fill left part of initial array

				Sort(left, canAdd);
				// we sort left part

				for (int i = 0; i < right.Length; i++)
				{
					right[i] = source[i + left.Length];
				}
				// we fill left part of initial array

				Sort(right, canAdd);
				// we sort right part

				int leftAddingIndex = 0;
				int rightAddingIndex = 0;
				int sourceCount = 0;

				while (sourceCount < source.Length)
				{
					// we fill source array with elements from sorted left and right arrays
					if (leftAddingIndex < left.Length && rightAddingIndex < right.Length)
					{
						// if left and right arrays have elements to add
						// we should choose fittest element from both arrays
						if (canAdd(left[leftAddingIndex], right[rightAddingIndex]))
						{
							source[sourceCount] = left[leftAddingIndex];
							leftAddingIndex++;
						}
						else
						{
							source[sourceCount] = right[rightAddingIndex];
							rightAddingIndex++;
						}
					} 
					else if (leftAddingIndex < left.Length)
					{
						// if elements from right array already added
						// we add only left elemens
						source[sourceCount] = left[leftAddingIndex];
						leftAddingIndex++;
					}
					else if (rightAddingIndex < right.Length)
					{
						// if elements from left array already added
						// we add only right elemens
						source[sourceCount] = right[rightAddingIndex];
						rightAddingIndex++;
					}
					
					sourceCount++;
				}
			}
		}
	}
}
