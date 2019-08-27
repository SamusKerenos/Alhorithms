using System;
using System.Collections.Generic;
using System.Text;

namespace RdTask
{
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
			//throw new NotImplementedException();
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
}
