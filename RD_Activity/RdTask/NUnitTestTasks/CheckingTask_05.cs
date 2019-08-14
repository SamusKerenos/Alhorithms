using System.Linq;
using System;
using NUnit.Framework;
using RdTask;
using Source.Entities;

namespace NUnitTestTasks
{
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
			var expected = Source.LINQ.Customers.Select(i => i.Orders.Select(o => new CustomerWithProduct
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
