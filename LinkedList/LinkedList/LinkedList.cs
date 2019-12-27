using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
	public class LinkedList<TItem> : IEnumerable<TItem> 
		where TItem : IComparable<TItem>
	{
		public ListItem<TItem> Head { get; private set; }
		
		/// <summary>
		/// Place for thinking
		/// </summary>
		public void Reverse()
		{
			ListItem<TItem> currentNode = Head;
			ListItem<TItem> newHead = null;
			ListItem<TItem> rawNode = null;

			while (currentNode != null)
			{
				rawNode = currentNode.Next;
				currentNode.Next = newHead;
				newHead = currentNode;
				currentNode = rawNode;
			}

			Head = newHead;
		}
		
		public void Add(IEnumerable<TItem> values)
		{
			foreach (TItem value in values)
			{
				Add(value);
			}
		}

		public void Add(TItem value)
		{
			var newItem = new ListItem<TItem>() { Value = value };
			if (Head == null)
			{
				Head = newItem;
				return;
			}

			var current = Head;
			while (current.Next != null)
			{
				current = current.Next;
			}

			current.Next = newItem;
		}

		public IEnumerator<TItem> GetEnumerator()
		{
			if (Head == null)
			{
				yield break;
			}

			var current = Head;
			while (current != null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}

		public override string ToString()
		{
			if (Head == null)
				return string.Empty;

			StringBuilder builder = new StringBuilder();
			bool isFirst = true;
			foreach (TItem item in this)
			{
				string format = isFirst ? "{0}" : ", {0}";
				builder.AppendFormat(format, item);
				isFirst = false;
			}

			return builder.ToString();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}

	public class ListItem<TValue>
	{
		public TValue Value { get; set; }

		public ListItem<TValue> Next { get; set; }

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
