using System;

namespace Sort
{
	public class CocktailSort : ISort
	{
		public string Title => "Cocktail Sort";

		public void Descending(int[] source)
		{
			Sort(source, 0, source.Length - 1, (first, second) => first < second);
		}

		public void Ascending(int[] source)
		{
			Sort(source, 0, source.Length - 1, (first, second) => first > second);
		}

		private void Sort(int[] source, int start, int end, Func<int, int, bool> shouldExchangeElements)
		{
			int newStart = end;
			for (int i = end; i > start; i--)
			{
				// in this iteration we move to the left direction
				// from end, to start and change places of the elements
				// according with sorting rule, as a result of this iteration
				// the fittest element move to the left side of array.
				if (shouldExchangeElements(source[i - 1], source[i]))
				{
					// we exchange left element with right
					int mem = source[i - 1];
					source[i - 1] = source[i];
					source[i] = mem;

					newStart = i;
					// memorize last exchange index
				}
			}
			// new start index set an position of last exchange
			
			if (newStart < end)
			{
				int newEnd = newStart;
				for (int i = newStart; i < end; i++)
				{
					// in this iteration we move to the right direction
					// from newStart, to end and change places of the elements
					// according with sorting rule, as a result of this iteration
					// the un fittest element move to the right side of array..
					if (shouldExchangeElements(source[i], source[i + 1]))
					{
						// we exchange right element with left
						int mem = source[i + 1];
						source[i + 1] = source[i];
						source[i] = mem;

						newEnd = i;
						// memorize last exchange index
					}
				}

				if (newStart < newEnd)
				{
					// we do it only if we still have some unsorted elemens
					Sort(source, newStart, newEnd, shouldExchangeElements);
				}
			}

		}
	}
}
