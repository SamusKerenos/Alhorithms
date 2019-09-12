using System;

namespace Sort
{
	public interface ISort
	{
		string Title { get; }
		void Descending(int[] source);
		void Ascending(int[] source);
	}
	
	public class AnySort : ISort
	{
		public string Title => "Any Sort";

		public void Descending(int[] source)
		{
			Sort(source, (a, b) => true);
		}

		public void Ascending(int[] source)
		{
			Sort(source, (a, b) => true);
		}

		private void Sort(int[] source, Func<int, int, bool> condition)
		{

		}
	}
}
