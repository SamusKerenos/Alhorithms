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
		public static IEnumerable<T> UnionSort<T>(this IEnumerable<T> main, IEnumerable<T> second, Func<T, T, bool> comporator)
		{
			//throw new NotImplementedException();

			if (main == null || second == null || comporator == null)
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
					if (comporator(mainIterator.Current, secondIterator.Current))
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
		#endregion
	}
}
