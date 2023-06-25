using System;

namespace Stack
{
	/*  
	 * Disadvantages:
	 * The need to reallocate memory when adding or deleting data
	 * Increasing the complexity of the computational algorithm
	*/
	public class ResizableFixedStack<T>
	{
		public bool IsEmpty => Count == 0;
		public int Count { get; private set; }

		private const int DefaultDepth = 10;
		private T[] items;

		public ResizableFixedStack()
		{
			items = new T[DefaultDepth];
		}
		
		public ResizableFixedStack(int depth)
		{
			items = new T[depth];
		}

		public void Push(T item)
		{
			if (Count == items.Length)
			{
				Resize(items.Length + 10); 
			}
			items[Count++] = item;  
		}

		public T Pop()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("Stack is empty"); 
			}

			var item = items[--Count];
			items[Count] = default;

			if (Count > 0 && Count < items.Length - 10)
			{
				Resize(items.Length - 10); 
			}

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

		private void Resize(int max)
		{
			var tempItems = new T[max];
			for (var i = 0; i < Count; i++)
			{
				tempItems[i] = items[i]; 
			}
			items = tempItems;
		}
	}
}