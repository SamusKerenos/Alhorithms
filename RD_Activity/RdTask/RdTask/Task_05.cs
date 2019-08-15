using Source.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RdTask
{
	public class Task_05
	{
		#region Part01
		// select customers having orders with Quantity > 5 
		// в данном методе необходимо написать LINQ запрос в любом удобном для вас синтаксисе, 
		// который будет отбирать среди покупателей тех, которые имеют более 5 единиц 
		public IEnumerable<Customer> GetCustomersWithMoreThenFiveOrders()
		{
			//throw new NotImplementedException();
			return Source.LINQ.Customers.Where(c => c.Orders.Any(o => o.Quantity > 5));
		}
		#endregion

		#region Part02
		// for each customer select his name and the names of the products he bought
		// в данном методе необходимо написать LINQ запрос в любом удобном для вас синтаксисе,
		// который пробежит по всем покупателям и создаст выборку из имени клиента и наименований
		// всех продуктов, которые купил данный клиент.
		public IEnumerable<CustomerWithProduct> GetCustomersWithProducts()
		{
			//throw new NotImplementedException();
			return Source.LINQ.Customers.Select(i => i.Orders.Select(o => new CustomerWithProduct
			{
				Product = o.Product.Name,
				Name = i.Name
			})).SelectMany(i => i);
		}
		#endregion
	}
}
