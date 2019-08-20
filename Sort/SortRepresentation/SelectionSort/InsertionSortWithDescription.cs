namespace Sort
{
	public class InsertionSortWithDescription : ISort
	{
		private string _sortRuleName;

		public string Title => "=== Insertion Sort Representation ===";

		public string Description => $@"
=======================================
|   {_sortRuleName,10} sort with description  |
=============================================================================
| 1. Sequence devided at two parts: sorted, at first step it contein        |
     only one element and unsorted which contain all other part of sequence |
| 2. Then take first element of unsorted sequence and find place in sorted  |
|    part where it should be                                                |
| 3. Move all elements of sorted sequence which should                      |
|    (we need place to new element) move at one position to the right       |
| 2. Take next element of unsorted sequence                                 |
=============================================================================
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
				for (int j = 0; j < i; j++)
				{
					bool match = isAscending
						? source[i] < source[j]
						: source[i] > source[j];

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
