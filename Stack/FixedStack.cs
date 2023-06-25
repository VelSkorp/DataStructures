using System;

namespace Stack
{
	/*  
	 * Disadvantages:
	 * The need to reallocate memory when adding or deleting data
	 * Increasing the complexity of the computational algorithm
	*/
	public class FixedStack<T>
	{
		public bool IsEmpty => Count == 0;
		public int Count { get; private set; }

		private const int DefaultDepth = 10;
		private readonly T[] items;

		public FixedStack()
		{
			items = new T[DefaultDepth];
		}

		public FixedStack(int depth)
		{
			items = new T[depth];
		}

		public void Push(T item)
		{
			if (Count == items.Length)
			{
				throw new InvalidOperationException("The stack is overflowing"); 
			}
			items[Count++] = item;
		}

		public T Pop()
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("Stack is empty"); 
			}
			var item = items[--Count];
			items[Count] = default;
			return item;
		}

		public T Peek()
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("Stack is empty");
			}
			return items[Count - 1];
		}
	}
}