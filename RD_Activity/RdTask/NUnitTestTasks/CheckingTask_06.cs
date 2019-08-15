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
}
