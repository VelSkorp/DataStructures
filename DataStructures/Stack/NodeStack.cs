using System.Collections;

namespace Stack
{
	/// <summary>
	/// Represents a stack implemented using nodes.
	/// </summary>
	/// <typeparam name="T">The type of data stored in the stack.</typeparam>
	public class NodeStack<T> : IEnumerable<T>
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
		/// Reference to the head node of the stack.
		/// </summary>
		private Node<T> _head;

		/// <summary>
		/// Adds an item to the top of the stack.
		/// </summary>
		/// <param name="item">The item to push onto the stack.</param>
		public void Push(T item)
		{
			var node = new Node<T>(item);
			node.SetNext(_head);
			_head = node;
			Count++;
		}

		/// <summary>
		/// Removes and returns the item at the top of the stack.
		/// </summary>
		/// <returns>The item removed from the top of the stack.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
		public T Pop()
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("Stack is empty"); 
			}
			var temp = _head;
			_head = _head.Next;
			Count--;
			return temp.Data; 
		}

		/// <summary>
		/// Returns the item at the top of the stack without removing it.
		/// </summary>
		/// <returns>The item at the top of the stack.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
		public T Peek()
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("Stack is empty"); 
			}
			return _head.Data;
		}

		/// <summary>
		/// Returns an enumerator that iterates through the items in the stack.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the stack.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through the items in the stack.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the stack.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			var current = _head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}
	}
}