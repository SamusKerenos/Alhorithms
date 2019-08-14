using System.Collections.Generic;

namespace Source.Entities
{
	public class Customer
	{
		public string Name { get; set; }
		public List<Order> Orders { get; set; }
	}
}
