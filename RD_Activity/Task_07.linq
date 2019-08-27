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
	public class ConsoleUtilsTests
	{

		private const int _lenght = 30;
		private int[] _source;

		[SetUp]
		public void Setup()
		{
			Random _engin = new Random(DateTime.Now.Millisecond);

			_source = new int[_lenght];

			for (int i = 0; i < _lenght; i++)
			{
				_source[i] = _engin.Next(1, 50);
			}
		}

		[Test]
		public void Test_07_Ascending_Implement()
		{
			Assert.DoesNotThrow(new TestDelegate(ExceptionerTask_07_Ascending));
		}

		[Test]
		public void Test_07_Descending_Implement()
		{
			Assert.DoesNotThrow(new TestDelegate(ExceptionerTask_07_Descending));
		}

		[Test]
		public void Test_07_Ascending_HaveValue()
		{
			_source.Ascending();
			Assert.IsNotNull(_source);
		}

		[Test]
		public void Test_07_Descending_HaveValue()
		{
			_source.Descending();
			Assert.IsNotNull(_source);
		}

		[Test]
		public void Test_07_Ascending_ReturnAnyInt()
		{
			_source.Ascending();
			Assert.IsTrue(_source.Any());
		}

		[Test]
		public void Test_07_Descending_ReturnAnyInt()
		{
			_source.Descending();
			Assert.IsTrue(_source.Any());
		}

		[Test]
		public void Test_07_Ascending_ResultHasLengthOfSourceSequence()
		{
			var expected = _source.Count();
			_source.Ascending();
			var actual = _source.Count();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Test_07_Descending_ResultHasLengthOfSourceSequence()
		{
			var expected = _source.Count();
			_source.Descending();
			var actual = _source.Count();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Test_07_Ascending_Positive()
		{
			var expected = _source.OrderBy(i => i).ToArray();
			_source.Ascending();

			Assert.IsTrue(expected.SequenceEqual(_source));
		}

		[Test]
		public void Test_07_Descending_Positive()
		{
			var expected = _source.OrderByDescending(i => i).ToArray();
			_source.Descending();

			Assert.IsTrue(expected.SequenceEqual(_source));
		}

		private void ExceptionerTask_07_Ascending()
		{
			_source.Ascending();
		}

		private void ExceptionerTask_07_Descending()
		{
			_source.Descending();
		}
	}
}

public static class Task_07_Sorting
{
	// bubble sort
	public static void Ascending(this int[] source)
	{
		//Sort(source, (a, b) => true);
		Sort(source, (first, second) => first > second);
	}
	
	// bubble sort
	public static void Descending(this int[] source)
	{
		//Sort(source, (a, b) => true);
		Sort(source, (first, second) => first < second);
	}

	// необходимо написать реализацию указанного в задании алгоритма,
	// которая будет одинаково подходить как для возрастающей, так и для
	// убывающей сортировки. Так же необходимо переименовать переменную 
	// condition таким образом, что бы она отражала суть своего использования
	// в данном алгоритме

	//private static void Sort(int[] source, Func<int, int, bool> condition)
	private static void Sort(int[] source, Func<int, int, bool> shouldMovElementToRight)
	{
		for (int i = 0; i < source.Length; i++)
		{
			for (int j = 1; j < source.Length - i; j++)
			{
				if (shouldMovElementToRight(source[j - 1], source[j]))
				{
					int mem = source[j - 1];
					source[j - 1] = source[j];
					source[j] = mem;
				}
			}
		}
	}
}