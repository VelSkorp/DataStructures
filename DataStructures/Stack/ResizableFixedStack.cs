using System.Collections;

namespace Stack
{
	/// <summary>
	/// A resizable stack implementation that dynamically adjusts its capacity as items are added or removed.
	/// </summary>
	/// <typeparam name="T">The type of data stored in the stack.</typeparam>
	/// <remarks>
	/// Disadvantages:
	///     <para>
	///         - The need to reallocate memory when adding or deleting data.
	///     </para>
	///     <para>
	///         - Increasing the complexity of the computational algorithm.
	///     </para>
	/// </remarks>
	public class ResizableFixedStack<T> : IEnumerable<T>
	{
		/// <summary>
		/// Indicates whether the stack is empty.
		/// </summary>
		public bool IsEmpty => Count == 0;

		/// <summary>
		/// Gets the number of elements contained in the stack.
		/// </summary>
		public int Count { get; private set; }

		/// <summary>
		/// Default depth of the stack
		/// </summary>
		private const int DefaultDepth = 10;

		/// <summary>
		/// Array to hold the elements of the stack
		/// </summary>
		private T[] _items;

		/// <summary>
		/// Initializes a new instance of the ResizableFixedStack&lt;T&gt; class with a default depth of 10.
		/// </summary>
		public ResizableFixedStack()
		{
			_items = new T[DefaultDepth];
		}

		/// <summary>
		/// Initializes a new instance of the ResizableFixedStack&lt;T&gt; class with the specified depth.
		/// </summary>
		/// <param name="depth">The maximum number of elements the stack can hold.</param>
		public ResizableFixedStack(int depth)
		{
			_items = new T[depth];
		}

		/// <summary>
		///     <para>
		///         Adds an item to the top of the stack.
		///     </para>
		///     <para>
		///         Time Complexity: O(n) depends on the Resize call, where n is the number of elements in the stack.
		///     </para>
		///     <para>
		///         Space Complexity: O(n) depends on the Resize call, where n is the new maximum capacity of the stack.
		///     </para>
		/// </summary>
		/// <param name="item">The item to push onto the stack.</param>
		public void Push(T item)
		{
			if (Count == _items.Length)
			{
				Resize(_items.Length + 10); 
			}
			_items[Count++] = item;  
		}

		/// <summary>
		///     <para>
		///         Removes and returns the item at the top of the stack.
		///     </para>
		///     <para>
		///         Time Complexity: O(n) depends on the Resize call, where n is the number of elements in the stack.
		///     </para>
		///     <para>
		///         Space Complexity: O(n) depends on the Resize call, where n is the new maximum capacity of the stack.
		///     </para>
		/// </summary>
		/// <returns>The item removed from the top of the stack.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
		public T Pop()
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("Stack is empty"); 
			}

			var item = _items[--Count];
			_items[Count] = default;

			if (Count > 0 && Count < _items.Length - 10)
			{
				Resize(_items.Length - 10); 
			}

			return item;
		}

		/// <summary>
		///     <para>
		///         Returns the item at the top of the stack without removing it.
		///     </para>
		///     <para>
		///         Time Complexity: O(1), since it simply returns the value of the element at the end.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <returns>The item at the top of the stack.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
		public T Peek()
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("Stack is empty");
			}
			return _items[Count - 1];
		}

		/// <summary>
		///     <para>
		///         Returns an enumerator that iterates through the items in the stack.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the number of elements in the linked list.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the stack.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)_items).GetEnumerator();
		}

		/// <summary>
		///     <para>
		///         Returns an enumerator that iterates through the items in the stack.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the number of elements in the linked list.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the stack.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		/// <summary>
		///     <para>
		///         Resizes the internal array to the specified maximum capacity.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the number of elements in the stack.
		///     </para>
		///     <para>
		///         Space Complexity: O(n) additional memory, where n is the new maximum stack capacity.
		///     </para>
		/// </summary>
		/// <param name="max">The new maximum capacity of the stack.</param>
		private void Resize(int max)
		{
			var tempItems = new T[max];
			for (var i = 0; i < Count; i++)
			{
				tempItems[i] = _items[i];
			}
			_items = tempItems;
		}
	}
}