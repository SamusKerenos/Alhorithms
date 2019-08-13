using System.Collections.Generic;

namespace LINQSource.Entities
{
	public class Customer
	{
		public string Name { get; set; }
		public List<Order> Orders { get; set; }
	}
}
