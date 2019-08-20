using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionSort
{
	public interface ISort
	{
		string Title { get; }
		StringBuilder Description { get; }
		int[] Descending(int[] source);
		int[] Ascending(int[] source);
	}
}
