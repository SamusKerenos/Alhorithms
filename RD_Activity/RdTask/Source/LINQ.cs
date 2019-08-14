using Source.Entities;
using System.Collections.Generic;

namespace Source
{
	public static class LINQ
	{
		private static readonly Product _apple = new Product { Name = "Apple" };
		private static readonly Product _orange = new Product { Name = "Orange" };
		private static readonly Product _bread = new Product { Name = "Bread" };

		public static List<Customer> Customers => new List<Customer>()
		{
			new Customer
			{
				Name = "Peter",
				Orders = new List<Order>()
				{
					new Order
					{
						Product = _apple,
						Quantity = 10
					},
					new Order
					{
						Product = _orange,
						Quantity = 5
					}
				}
			},
			new Customer
			{
				Name = "John",
				Orders = new List<Order>()
				{
					new Order
					{
						Product = _bread,
						Quantity = 5
					},
					new Order
					{
						Product = _orange,
						Quantity = 2
					}
				}
			},
			new Customer
			{
				Name = "Mary",
				Orders = new List<Order>()
				{
					new Order
					{
						Product = _apple,
						Quantity = 10
					}
				}
			}
		};
	}
}
