using System.Linq;
using System;
using NUnit.Framework;
using RdTask;
using Source.Entities;
using Source;
using System.Collections.Generic;
using System.Collections;

namespace NUnitTestTasks
{
	[TestFixture]
	public class CheckingTask_06
	{
		#region task_01_test
		[Test]
		public void Test_06_01_Implement()
		{
			Assert.DoesNotThrow(new TestDelegate(ExceptionerTask_06_01));
		}

		[Test]
		[TestCaseSource(typeof(Test_06_01_Data), nameof(Test_06_01_Data.TestData))]
		public void Test_06_01_HaveValue(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			Assert.IsNotNull(first.UnionSort(second));
		}

		[Test]
		[TestCaseSource(typeof(Test_06_01_Data), nameof(Test_06_01_Data.TestData))]
		public void Test_06_01_ReturnAnyEmployee(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			Assert.IsTrue(first.UnionSort(second).Any());
		}
		
		[Test]
		[TestCaseSource(typeof(Test_06_01_Data), nameof(Test_06_01_Data.TestData))]
		public void Test_06_01_ResultBouthMaleAndFemale(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			var actual = first.UnionSort(second);
			
			Assert.IsTrue(actual.Any(e => e.Gender == Gender.Male) && actual.Any(e => e.Gender == Gender.Female));
		}

		[Test]
		[TestCaseSource(typeof(Test_06_01_Data), nameof(Test_06_01_Data.TestData))]
		public void Test_06_01_ResultHasLengthOfBothSequence(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			var expected = first.Count() + second.Count();
			var actual = first.UnionSort(second).Count();
			
			Assert.AreEqual(expected, actual);
		}

		[Test]
		[TestCaseSource(typeof(Test_06_01_Data), nameof(Test_06_01_Data.TestData))]
		public void Test_06_01_ResultContainBothSequence(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			var actual = first.UnionSort(second);

			Assert.IsTrue(actual.All(ae => first.Any(fe => fe.Equals(ae)) || second.Any(se => se.Equals(ae))));
		}

		[Test]
		[TestCaseSource(typeof(Test_06_01_Data), nameof(Test_06_01_Data.TestData))]
		public void Test_06_01_Positive(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			var expected = first.Union(second).OrderBy(e => e.MonyPerHour).ToList();
			var actual = first.UnionSort(second);

			Assert.IsTrue(expected.SequenceEqual(actual));
		}

		private void ExceptionerTask_06_01()
		{
			CustomLINQ.FemaleEmployeeSortedByMoney.UnionSort<Employee>(CustomLINQ.MaleEmployeeSortedByMoney);
		}
		#endregion
		
		#region task_02_test
		[Test]
		public void Test_06_02_Implement()
		{
			Assert.DoesNotThrow(new TestDelegate(ExceptionerTask_06_02));
		}

		[Test]
		public void Test_06_02_EmployeeFirst_HaveValue()
		{
			var result = CustomLINQ.EmployeesSortedByMoney.UnionSort(CustomLINQ.FrilancersSortedByMoney, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeFreelancerComporator);
			
			Assert.IsTrue(result != null);
		}

		[Test]
		public void Test_06_02_FreelancerFirst_HaveValue()
		{
			var result = CustomLINQ.FrilancersSortedByMoney.UnionSort(CustomLINQ.EmployeesSortedByMoney, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerEmployeeComporator);
			
			Assert.IsTrue(result != null);
		}

		[Test]
		public void Test_06_02_EmployeeFirst_ReturnAny()
		{
			var result = CustomLINQ.EmployeesSortedByMoney.UnionSort(CustomLINQ.FrilancersSortedByMoney, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeFreelancerComporator);
			
			Assert.IsTrue(result.Any());
		}

		[Test]
		public void Test_06_02_FreelancerFirst_ReturnAny()
		{
			var result = CustomLINQ.FrilancersSortedByMoney.UnionSort(CustomLINQ.EmployeesSortedByMoney, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerEmployeeComporator);
			
			Assert.IsTrue(result.Any());
		}

		[Test]
		public void Test_06_02_EmployeeFirst_ResultHasLengthOfBothSequence()
		{
			var expected = CustomLINQ.EmployeesSortedByMoney.Count() + CustomLINQ.FrilancersSortedByMoney.Count();
			var actual = CustomLINQ.EmployeesSortedByMoney.UnionSort(CustomLINQ.FrilancersSortedByMoney, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeFreelancerComporator).Count();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Test_06_02_FreelancerFirst_ResultHasLengthOfBothSequence()
		{
			var expected = CustomLINQ.EmployeesSortedByMoney.Count() + CustomLINQ.FrilancersSortedByMoney.Count();
			var actual = CustomLINQ.FrilancersSortedByMoney.UnionSort(CustomLINQ.EmployeesSortedByMoney, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerEmployeeComporator).Count();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Test_06_02_EmployeeFirst_ResultContainBothSequence()
		{
			var actual = CustomLINQ.EmployeesSortedByMoney.UnionSort(CustomLINQ.FrilancersSortedByMoney, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeFreelancerComporator);

			Assert.IsTrue(actual.All(r => CustomLINQ.EmployeesSortedByMoney.Any(e => e.MonyPerHour == r.MonyPerHour) || CustomLINQ.FrilancersSortedByMoney.Any(f => f.MonyPerHour == r.MonyPerHour)));
		}

		[Test]
		public void Test_06_02_FreelancerFirst_ResultContainBothSequence()
		{
			var actual = CustomLINQ.FrilancersSortedByMoney.UnionSort(CustomLINQ.EmployeesSortedByMoney, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerEmployeeComporator);

			Assert.IsTrue(actual.All(r => CustomLINQ.EmployeesSortedByMoney.Any(e => e.MonyPerHour == r.MonyPerHour) || CustomLINQ.FrilancersSortedByMoney.Any(f => f.MonyPerHour == r.MonyPerHour)));
		}

		[Test]
		public void Test_06_02_EmployeeFirst_Positive()
		{
			var expected = CustomLINQ.EmployeesSortedByMoney.Select(e => new MonyAnaliticalUnit()
			{
				WorkerType = WorkerType.Employee,
				MonyPerHour = e.MonyPerHour
			}).ToList();

			expected.AddRange(CustomLINQ.FrilancersSortedByMoney.Select(f => new MonyAnaliticalUnit()
			{
				WorkerType = WorkerType.Freelancer,
				MonyPerHour = f.MonyPerHour
			}));

			expected = expected.OrderBy(a => a.MonyPerHour).ToList();

			var actual = CustomLINQ.EmployeesSortedByMoney.UnionSort(CustomLINQ.FrilancersSortedByMoney, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeFreelancerComporator);

			Assert.IsTrue(expected.SequenceEqual(actual));
		}

		[Test]
		public void Test_06_02_FreelancerFirst_Positive()
		{
			var expected = CustomLINQ.FrilancersSortedByMoney.Select(e => new MonyAnaliticalUnit()
			{
				WorkerType = WorkerType.Freelancer,
				MonyPerHour = e.MonyPerHour
			}).ToList();

			expected.AddRange(CustomLINQ.EmployeesSortedByMoney.Select(f => new MonyAnaliticalUnit()
			{
				WorkerType = WorkerType.Employee,
				MonyPerHour = f.MonyPerHour
			}));

			expected = expected.OrderBy(a => a.MonyPerHour).ToList();

			var actual = CustomLINQ.FrilancersSortedByMoney.UnionSort(CustomLINQ.EmployeesSortedByMoney, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerEmployeeComporator);

			Assert.IsTrue(expected.SequenceEqual(actual));
		}

		private void ExceptionerTask_06_02()
		{
			CustomLINQ.EmployeesSortedByMoney.UnionSort(CustomLINQ.FrilancersSortedByMoney, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeFreelancerComporator);
		}
		#endregion
	}

	public static class Test_06_01_Data
	{
		public static IEnumerable TestData
		{
			get
			{
				yield return new TestCaseData(CustomLINQ.FemaleEmployeeSortedByMoney, CustomLINQ.MaleEmployeeSortedByMoney);
				yield return new TestCaseData(CustomLINQ.MaleEmployeeSortedByMoney, CustomLINQ.FemaleEmployeeSortedByMoney);
			}
		}
	}

	public static class Test_06_02_Data
	{
		public static Func<Employee, MonyAnaliticalUnit> EmployeeSelector = e => new MonyAnaliticalUnit()
		{
			MonyPerHour = e.MonyPerHour,
			WorkerType = WorkerType.Employee
		};

		public static Func<Freelancer, MonyAnaliticalUnit> FreelancerSelector = e => new MonyAnaliticalUnit()
		{
			MonyPerHour = e.MonyPerHour,
			WorkerType = WorkerType.Freelancer
		};

		public static Func<Employee, Freelancer, bool> EmployeeFreelancerComporator = (e, f) => e.MonyPerHour > f.MonyPerHour;

		public static Func<Freelancer, Employee, bool> FreelancerEmployeeComporator = (f, e) => f.MonyPerHour > e.MonyPerHour;
	}
}
