using System.Text;

namespace BinarySearch
{
	public class BinarySearchWithDescription
	{
		public StringBuilder Description { get; } = new StringBuilder();

		public DataNode Search(DataNode[] source, string searchedName)
		{
			DataNode result = new DataNode();

			bool searchComplete = false;

			do
			{
				int middleIndex = source.Length / 2;
				int comparer = source[middleIndex].Name.ToLower().CompareTo(searchedName.ToLower());

				Description.Append($@"
======================================
| We enter: {source.NameStringRepresent()}
| We define the index of middle element: {middleIndex}
| We compare middle element name: {source[middleIndex].Name} 
| with element which we want to find: {searchedName}
======================================
");

				if (comparer == 0)
				{
					Description.AppendLine("Search complete: ELEMENT FINDED");
					searchComplete = true;
					result = source[middleIndex];
				}
				else if (source.Length == 1)
				{
					Description.AppendLine("Search complete: ELEMENT NOT FOUND");
					searchComplete = true;
				}
				else if (comparer < 0)
				{
					source = source.CopyDataFrom(middleIndex);
					Description.AppendLine("Comparer value less then zero that meat that middle element less then searched, we get elements affter middle element for next iteration");
				}
				else if (comparer > 0)
				{
					source = source.CopyDataTill(middleIndex);
					Description.AppendLine("Comparer value greater then zero that meat that middle element higher then searched, we get elements before middle element (include it) for next iteration");
				}

				Description.AppendLine(@"-------------------------------------------------------
");

			} while (!searchComplete);

			return result;
		}
	}
}
