using System.Text;

namespace Sort
{
	public class SelectionSortWithDescription : ISort
	{
		public string Title => "=== Selection Sort Representation ===";

		public string Description { get; private set; }

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
			string sortRuleName = isAscending ? "ASCENDING" : "DESCENDING";

			Description = $@"
=======================================
|   {sortRuleName,10} sort with description  |
=============================================================
| 1. Find value which most applicable to sorting direction. |
| 2. Change this value with first position value in array.  |
| 3. Repeat for not sorted part of array.                   |
=============================================================
| Complexity is: O(n^2)               |
=======================================
";
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
