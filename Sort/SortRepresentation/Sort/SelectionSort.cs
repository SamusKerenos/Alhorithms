namespace Sort
{
	public class SelectionSort : ISort
	{
		public string Title => "Selection Sort";

		public void Descending(int[] source)
		{
			Sort(source, false);
		}

		public void Ascending(int[] source)
		{
			Sort(source, true);
		}

		private void Sort(int[] source, bool isAscending)
		{
			for (int i = 0; i < source.Length; i++)
			{
				for (int j = i + 1; j < source.Length; j++)
				{
					bool match = isAscending
						? source[i] > source[j]
						: source[i] < source[j];

					if (match)
					{
						int mem = source[i];
						source[i] = source[j];
						source[j] = mem;
					}
				}
			}
		}
	}
}
