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
		private int[] _source;

		[SetUp]
		public void Setup()
		{
			_source = RandomGenerator.GetRandomIntArray(60, 0, 60);
		}

		[Test]
		[TestCaseSource(typeof(Test_Data), nameof(Test_Data.Sorters))]
		public void TestAscending(ISort sorter)
		{
			int[] actual = _source.Select(i => i).ToArray();
			int[] expected = _source.OrderBy(i => i).ToArray();
			sorter.Ascending(actual);

			CollectionAssert.AreEqual(expected, actual);
		}

		[Test]
		[TestCaseSource(typeof(Test_Data), nameof(Test_Data.Sorters))]
		public void TestDescending(ISort sorter)
		{

			int[] actual = _source.Select(i => i).ToArray();
			int[] expected = _source.OrderByDescending(i => i).ToArray();
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
				yield return new TestCaseData(new SelectionSortWithDescription());
				yield return new TestCaseData(new InsertionSortWithDescription());
			}
		}
	}
}