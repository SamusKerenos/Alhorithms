namespace Sort
{
	public class SelectionSortWithDescription : ISort
	{
		private string _sortRuleName;

		public string Title => "=== Selection Sort Representation ===";

		public string Description => $@"
=======================================
|   {_sortRuleName,10} sort with description  |
=============================================================
| 1. Find value which most applicable to sorting direction. |
| 2. Change this value with first position value in array.  |
| 3. Repeat for not sorted part of array.                   |
=============================================================
| Complexity is: O(n^2) |
=========================
";

		public void Descending(int[] source)
		{
			_sortRuleName = "DESCENDING";
			Sort(source, false);
		}

		public void Ascending(int[] source)
		{
			_sortRuleName = "ASCENDING";
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
