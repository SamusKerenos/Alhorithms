using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
	public interface ISort
	{
		string Title { get; }
		string Description { get; }
		void Descending(int[] source);
		void Ascending(int[] source);
	}
}
