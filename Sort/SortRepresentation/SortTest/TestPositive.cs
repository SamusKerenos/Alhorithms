using NUnit.Framework;
using Sort;
using SourceAndExtensions;
using System.Collections;
using System.Linq;

namespace Tests
{
	[TestFixture]
	public class TestPositive
	{
		private int _max = 100;
		private int _min = 0;

		[Test]
		[TestCaseSource(typeof(Test_Data), nameof(Test_Data.Sorters))]
		public void TestAscending(ISort sorter, int length)
		{
			int[] data = RandomGenerator.GetRandomIntArray(_max, _min, length);
			int[] actual = data.Select(i => i).ToArray();
			int[] expected = data.OrderBy(i => i).ToArray();
			sorter.Ascending(actual);

			CollectionAssert.AreEqual(expected, actual);
		}

		[Test]
		[TestCaseSource(typeof(Test_Data), nameof(Test_Data.Sorters))]
		public void TestDescending(ISort sorter, int length)
		{
			int[] data = RandomGenerator.GetRandomIntArray(_max, _min, length);
			int[] actual = data.Select(i => i).ToArray();
			int[] expected = data.OrderByDescending(i => i).ToArray();
			sorter.Descending(actual);

			CollectionAssert.AreEqual(expected, actual);
		}
	}

	public static class Test_Data
	{
		public static IEnumerable Sorters
		{
			get
			{
				yield return new TestCaseData(new SelectionSort(), 6000);
				yield return new TestCaseData(new InsertionSort(), 6000);
				yield return new TestCaseData(new MerdgeSort(), 6000);
				yield return new TestCaseData(new BubbleSort(), 6000);
				yield return new TestCaseData(new QuickSort(), 6000);
				yield return new TestCaseData(new CocktailSort(), 6000);

				yield return new TestCaseData(new SelectionSort(), 60);
				yield return new TestCaseData(new InsertionSort(), 60);
				yield return new TestCaseData(new MerdgeSort(), 60);
				yield return new TestCaseData(new BubbleSort(), 60);
				yield return new TestCaseData(new QuickSort(), 60);
				yield return new TestCaseData(new CocktailSort(), 60);

				yield return new TestCaseData(new SelectionSort(), 6);
				yield return new TestCaseData(new InsertionSort(), 6);
				yield return new TestCaseData(new MerdgeSort(), 6);
				yield return new TestCaseData(new BubbleSort(), 6);
				yield return new TestCaseData(new QuickSort(), 6);
				yield return new TestCaseData(new CocktailSort(), 6);
			}
		}
	}
}