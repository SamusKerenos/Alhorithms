using System.Text;

namespace Sort
{
	public class InsertionSortWithDescription : ISort
	{
		public string Title => "=== Insertion Sort Representation ===";

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
=======================================
|                                     |
=======================================
";

		}

	}
}
