using System;
using System.Linq;

namespace BinarySearch
{
	static class SearchEngin
	{	
		public static bool Step(ref string[] data, string searched)
		{
			if (data.Count() == 1)
			{
				bool result = data.FirstOrDefault().Equals(searched, StringComparison.InvariantCultureIgnoreCase);
				data = new string[0];
				return result;
			}
			
			int middleIndex = data.Length / 2;

			string middleElement = data[middleIndex];

			int compare = middleElement.ToLower().CompareTo(searched.ToLower());

			if (compare == 0)
			{
				data = new string[0];
				return true;
			} 
			else if (compare < 0 )
			{
				data = data.CopyDataFrom(middleIndex);
			}
			else
			{
				data = data.CopyDataTill(middleIndex);
			}

			return false;
		}


	}
}
