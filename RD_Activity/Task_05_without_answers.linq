<Query Kind="Program">
  <NuGetReference Version="3.7.1">NUnit</NuGetReference>
  <NuGetReference>NUnitLite.Out</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

public class Runner
{
	public static int Main(string[] args)
	{
		return new AutoRun(Assembly.GetExecutingAssembly())
					   .Execute(new String[] { });
	}

	[TestFixture]
	public class CheckingTask_05
	{
		private Task_05 item = new Task_05();

		#region task_01_test
		[Test]
		public void Test_05_01_Implement()
		{
			Assert.DoesNotThrow(new TestDelegate(ExceptionerTask_05_01));
		}

		[Test]
		public void Test_05_01_HaveValue()
		{
			Assert.IsNotNull(item.GetCustomersWithMoreThenFiveOrders());
		}

		[Test]
		public void Test_05_01_ReturnAnyCustomers()
		{
			Assert.IsTrue(item.GetCustomersWithMoreThenFiveOrders().Any());
		}

		[Test]
		public void Test_05_01_AllCustomersHaveOrdersValue()
		{
			Assert.IsTrue(item.GetCustomersWithMoreThenFiveOrders().All(c => c.Orders != null));
		}

		[Test]
		public void Test_05_01_AllCustomersHaveAnyOrders()
		{
			Assert.IsTrue(item.GetCustomersWithMoreThenFiveOrders().All(c => c.Orders.Any()));
		}

		[Test]
		public void Test_05_01_Positive()
		{
			Assert.IsTrue(item.GetCustomersWithMoreThenFiveOrders().All(c => c.Orders.Any(o => o.Quantity > 5)));
		}

		private void ExceptionerTask_05_01()
		{
			item.GetCustomersWithMoreThenFiveOrders();
		}
		#endregion

		#region task_02_test
		[Test]
		public void Test_05_02_Implement()
		{
			Assert.DoesNotThrow(new TestDelegate(ExceptionerTask_05_02));
		}

		[Test]
		public void Test_05_02_HaveValue()
		{
			Assert.IsNotNull(item.GetCustomersWithProducts());
		}

		[Test]
		public void Test_05_02_ReturnAnyKeyValuePairs()
		{
			Assert.IsTrue(item.GetCustomersWithProducts().Any());
		}

		[Test]
		public void Test_05_02_AllKeyValuePairsHaveValues()
		{
			Assert.IsTrue(item.GetCustomersWithProducts().All(i => !String.IsNullOrWhiteSpace(i.Name) && !String.IsNullOrWhiteSpace(i.Product)));
		}

		[Test]
		public void Test_05_02_Positive()
		{
			var expected = LINQ.Customers.Select(i => i.Orders.Select(o => new CustomerWithProduct
			{
				Product = o.Product.Name,
				Name = i.Name
			})).SelectMany(i => i);

			var actual = item.GetCustomersWithProducts();

			CollectionAssert.AreEqual(expected, actual);
		}

		private void ExceptionerTask_05_02()
		{
			item.GetCustomersWithProducts();
		}
		#endregion
	}
}

public class Task_05
{
	#region Part01
	// select customers having orders with Quantity > 5 
	// в данном методе необходимо написать LINQ запрос в любом удобном для вас синтаксисе, 
	// который будет отбирать среди покупателей тех, которые имеют более 5 единиц 
	public IEnumerable<Customer> GetCustomersWithMoreThenFiveOrders()
	{
		throw new NotImplementedException();
	}
	#endregion

	#region Part02
	// for each customer select his name and the names of the products he bought
	// в данном методе необходимо написать LINQ запрос в любом удобном для вас синтаксисе,
	// который пробежит по всем покупателям и создаст выборку из имени клиента и наименований
	// всех продуктов, которые купил данный клиент.
	public IEnumerable<CustomerWithProduct> GetCustomersWithProducts()
	{
		throw new NotImplementedException();
	}
	#endregion
}

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

public class Customer
{
	public string Name { get; set; }
	public List<Order> Orders { get; set; }
}

public class CustomerWithProduct
{
	public string Name { get; set; }
	public string Product { get; set; }

	public override bool Equals(object obj)
	{
		if (obj == null || obj as CustomerWithProduct == null)
		{
			return false;
		}

		return Equals((CustomerWithProduct)obj);
	}

	public bool Equals(CustomerWithProduct obj)
	{
		return Name.Equals(obj.Name)
			&& Product.Equals(obj.Product);
	}

	public override int GetHashCode()
	{
		return Name.GetHashCode() + Product.GetHashCode();
	}
}

public class Order
{
	public Product Product { get; set; }
	public int Quantity { get; set; }
}

public class Product
{
	public string Name { get; set; }
}