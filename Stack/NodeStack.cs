using System;
using System.Collections.Generic;
using System.Collections;

namespace Stack
{
	public class Node<T>
	{
		public T Data { get; set; }
		public Node<T> Next { get; set; }

		public Node(T data)
		{
			Data = data;
		}
	}

	public class NodeStack<T> : IEnumerable<T>
	{
		public bool IsEmpty => Count == 0;
		public int Count { get; private set; }

		private Node<T> head;

		public void Push(T item)
		{
			var node = new Node<T>(item)
			{
				Next = head
			};
			head = node;
			Count++;
		}

		public T Pop()
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("Stack is empty"); 
			}
			var temp = head;
			head = head.Next;
			Count--;
			return temp.Data; 
		}

		public T Peek()
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("Stack is empty"); 
			}
			return head.Data;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this).GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			var current = head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}
	}
}