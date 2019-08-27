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

		private void Sort(int[] source, int start, int end, Func<int, int, bool> shouldMovElementToRight)
		{
			int newStart = 0;
			for (int i = end; i > start; i--)
			{
				if (shouldMovElementToRight(source[i - 1], source[i]))
				{
					int mem = source[i - 1];
					source[i - 1] = source[i];
					source[i] = mem;

					newStart = i;
				}
			}
			// new start index set an position of last exchange


			if (newStart < end)
			{
				int newEnd = 0;
				for (int i = start; i < end; i++)
				{
					if (shouldMovElementToRight(source[i], source[i + 1]))
					{
						int mem = source[i + 1];
						source[i + 1] = source[i];
						source[i] = mem;

						newEnd = i;
					}
				}
			
				Sort(source, newStart, newEnd, shouldMovElementToRight);
			}
		}
	}
}
