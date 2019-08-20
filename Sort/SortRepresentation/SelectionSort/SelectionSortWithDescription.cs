using System.Text;

namespace SelectionSort
{
	public class SelectionSortWithDescription : ISort
	{
		public string Title => "=== Selection Sort Representation ===";

		public StringBuilder Description => new StringBuilder();

		public int[] Descending(int[] source)
		{
			return Sort(source, false);
		}

		public int[] Ascending(int[] source)
		{
			return Sort(source, true);
		}

		private int[] Sort(int[] source, bool isAscending)
		{
			string sortRuleName = isAscending ? "ASCENDING" : "DESCENDING";

			Description.Append($@"
=======================================
|   {sortRuleName,10} sort with description  |
=======================================
| We iterate over the result array.   |
| And for each result element         |
| we iterate over the source array    |
| to find value which which most      |
| applicable for our sort rule.       |
| When we find it, we change value    |
| in source array to value which was  |
| in current element of result array  |
| before. Every iteration over result |
| we reduse source array to one item. |
| =F mean that we find ellement       |
=======================================
");
			int[] result = new int[source.Length];

			for (int i = 0; i < result.Length; i++)
			{
				result[i] = source[i];
				Description.AppendLine($@"
First checked value is: {result[i]} sort rule is: {sortRuleName} source length is: {source.Length - (i + 1)}");

				for (int j = i + 1; j < source.Length; j++)
				{
					Description.Append($" -check: {j + 1}");
					bool match = false;
					if (isAscending)
					{
						match = result[i] > source[j];
					}
					else
					{
						match = result[i] < source[j];
					}

					if (match)
					{
						Description.Append(" =F");
						int mem = result[i];
						result[i] = source[j];
						source[j] = mem;
					}
				}
				Description.AppendLine(@"
------------------------------------------------------------------------------------");
			}

			return result;
		}
	}
}
