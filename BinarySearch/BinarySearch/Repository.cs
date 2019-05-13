using System.Linq;
using System.Text;

namespace BinarySearch
{
	class Repository
	{
		public DataNode[] Data => new DataNode[]
		{
			new DataNode() { Name = "Amely", Number = 1 },
			new DataNode() { Name = "Alan", Number = 2 },
			new DataNode() { Name = "Brain", Number = 3 },
			new DataNode() { Name = "Betany", Number = 4 },
			new DataNode() { Name = "Clar", Number = 5 },
			new DataNode() { Name = "Clark", Number = 6 },
			new DataNode() { Name = "David", Number = 7 },
			new DataNode() { Name = "Diana", Number = 8 },
			new DataNode() { Name = "Erica", Number = 9 },
			new DataNode() { Name = "Ethan", Number = 10 },
			new DataNode() { Name = "Fedora", Number = 11 },
			new DataNode() { Name = "Frank", Number = 12 },
			new DataNode() { Name = "Gracy", Number = 13 },
			new DataNode() { Name = "Gregor", Number = 14 }
		};

		public string Represent()
		{
			StringBuilder result = new StringBuilder();

			result.Append(@"
=====================================
|| Number: || Letter: || Name:
=====================================
");
			foreach (var item in Data)
			{
				result.AppendLine(item.Represent());
			}
			
			char firstLetter = Data.FirstOrDefault().FirstLetter;
			char lastLetter = Data.Last().FirstLetter;

			result.Append($@"=====================================
|| In summary we have: {Data.Length, 3} names,  ||
|| which sort by first letters,    ||
|| starter from: {firstLetter} and end at: {lastLetter}   ||
=====================================
");

			return result.ToString();
		}
	}
}

