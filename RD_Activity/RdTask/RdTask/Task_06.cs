using System;
using System.Collections.Generic;

namespace RdTask
{
	public static class Task_06
	{
		#region Part01
		// необходимо написать реализацию новой LINQ операции которя будет объединять две 
		// отсортированных коллекции одинакового типа в новую коллекцию того же типа,
		// которя так же будет отсортировнна.
		// Готовые методы LINQ исопользовать запрещено.
		public static IEnumerable<T> UnionSort<T>(this IEnumerable<T> main, IEnumerable<T> second)
			where T: IComparable<T>
		{
			//throw new NotImplementedException();

			if (main == null || second == null)
			{
				throw new ArgumentNullException();
			}

			List<T> result = new List<T>();
			var mainIterator = main.GetEnumerator();
			var secondIterator = second.GetEnumerator();

			mainIterator.Reset();
			secondIterator.Reset();

			bool mainMovedNext = mainIterator.MoveNext();
			bool secondMovedNext = secondIterator.MoveNext();

			while (mainMovedNext || secondMovedNext)
			{
				if (mainMovedNext && secondMovedNext)
				{
					if (mainIterator.Current.CompareTo(secondIterator.Current) == 1)
					{
						result.Add(secondIterator.Current);
						secondMovedNext = secondIterator.MoveNext();
					}
					else
					{
						result.Add(mainIterator.Current);
						mainMovedNext = mainIterator.MoveNext();
					}
				}
				else if (mainMovedNext)
				{
					result.Add(mainIterator.Current);
					mainMovedNext = mainIterator.MoveNext();
				}
				else if (secondMovedNext)
				{
					result.Add(secondIterator.Current);
					secondMovedNext = secondIterator.MoveNext();
				}
			}

			return result;
		}
		#endregion

		#region Part02
		// необходимо написать новую LINQ операцию которя будет объединять две 
		// отсортированных коллекции разного типа в новую коллекцию итогового типа,
		// которя так же будет отсортировнна.
		// Готовые методы LINQ исопользовать запрещено.
		public static IEnumerable<R> UnionSort<T, H, R>(this IEnumerable<T> main, IEnumerable<H> second, Func<T, R> selectorMain, Func<H, R> selectorSecond)
			where R: IComparable<R>
		{
			//throw new NotImplementedException();

			if (main == null || second == null || selectorMain == null || selectorSecond == null)
			{
				throw new ArgumentNullException();
			}

			List<R> result = new List<R>();
			var mainIterator = main.GetEnumerator();
			var secondIterator = second.GetEnumerator();

			mainIterator.Reset();
			secondIterator.Reset();

			bool mainMovedNext = mainIterator.MoveNext();
			bool secondMovedNext = secondIterator.MoveNext();

			while (mainMovedNext || secondMovedNext)
			{
				if (mainMovedNext && secondMovedNext)
				{
					var resultMain = selectorMain(mainIterator.Current);
					var resultSecond = selectorSecond(secondIterator.Current);

					if (resultMain.CompareTo(resultSecond) == 1)
					{
						result.Add(resultSecond);
						secondMovedNext = secondIterator.MoveNext();
					}
					else
					{
						result.Add(resultMain);
						mainMovedNext = mainIterator.MoveNext();
					}
				}
				else if (mainMovedNext)
				{
					result.Add(selectorMain(mainIterator.Current));
					mainMovedNext = mainIterator.MoveNext();
				}
				else if (secondMovedNext)
				{
					result.Add(selectorSecond(secondIterator.Current));
					secondMovedNext = secondIterator.MoveNext();
				}
			}

			return result;
		}
		#endregion
	}
}
