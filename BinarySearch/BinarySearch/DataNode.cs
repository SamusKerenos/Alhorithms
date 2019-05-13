using System.Linq;

namespace BinarySearch
{
	public class DataNode
	{
		public string Name { get; set; }
		public int Number { get; set; }
		public char FirstLetter => string.IsNullOrWhiteSpace(Name) 
			? '-'
			: Name.FirstOrDefault();
	}
}
