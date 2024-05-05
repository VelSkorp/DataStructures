using System.Collections;

namespace Stack
{
	/// <summary>
	/// Represents a fixed-size stack data structure.
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
	public class FixedStack<T> : IEnumerable<T>
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
		private readonly T[] _items;

		/// <summary>
		/// Initializes a new instance of the FixedStack&lt;T&gt; class with a default depth of 10.
		/// </summary>
		public FixedStack()
		{
			_items = new T[DefaultDepth];
		}

		/// <summary>
		/// Initializes a new instance of the FixedStack&lt;T&gt; class with the specified depth.
		/// </summary>
		/// <param name="depth">The maximum number of elements the stack can hold.</param>
		public FixedStack(int depth)
		{
			_items = new T[depth];
		}

		/// <summary>
		///     <para>
		///         Adds an item to the top of the stack.
		///     </para>
		///     <para>
		///         Time Complexity: O(1), since the element is added to the end.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <param name="item">The item to push onto the stack.</param>
		/// <exception cref="StackOverflowException">Thrown when the stack is full.</exception>
		public void Push(T item)
		{
			if (Count == _items.Length)
			{
				throw new StackOverflowException();
			}
			_items[Count++] = item;
		}

		/// <summary>
		///     <para>
		///         Removes and returns the item at the top of the stack.
		///     </para>
		///     <para>
		///         Time Complexity: O(1), since the element is removed from the end.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
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
		///         Returns an enumerator that iterates through the stack.
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
		///         Returns an enumerator that iterates through the stack.
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
	}
}