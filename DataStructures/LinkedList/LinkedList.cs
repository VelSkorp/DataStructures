using System.Collections;

namespace LinkedList
{
	/// <summary>
	/// Represents a singly linked list data structure.
	/// </summary>
	/// <typeparam name="T">The type of elements stored in the linked list.</typeparam>
	public class LinkedList<T> : IEnumerable<T>
	{
		/// <summary>
		/// Gets the number of elements contained in the linked list.
		/// </summary>
		public int Count { get; private set; }

		/// <summary>
		/// Indicates whether the linked list is empty.
		/// </summary>
		public bool IsEmpty => Count == 0;

		/// <summary>
		/// Represents the first node in the linked list.
		/// </summary>
		private Node<T> _head;


		/// <summary>
		/// Represents the last node in the linked list.
		/// </summary>
		private Node<T> _tail;

		/// <summary>
		///     <para>
		///         Appends a new node containing the specified data at the beginning of the linked list.
		///     </para>
		///     <para>
		///         Time Complexity: O(1), since inserting a node at the beginning of a linked list is a simple pointer assignment operation.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <param name="data">The data to add to the beginning of the linked list.</param>
		public void AppendFirst(T data)
		{
			var newNode = new Node<T>(data);
			AppendFirst(newNode);
		}

		/// <summary>
		///     <para>
		///         Appends the specified node at the beginning of the linked list.
		///     </para>
		///     <para>
		///         Time Complexity: O(1), since inserting a node at the beginning of a linked list is a simple pointer assignment operation.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <param name="node">The node to append to the beginning of the linked list.</param>
		public void AppendFirst(Node<T> node)
		{
			node.SetNext(_head);
			_head = node;
			if (Count == 0)
			{
				_tail = _head;
			}
			Count++;
		}

		/// <summary>
		///     <para>
		///         Adds a new node containing the specified data at the end of the linked list.
		///     </para>
		///     <para>
		///         Time Complexity: O(1), since inserting a node at the end of a linked list is a simple pointer assignment operation.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <param name="data">The data to add to the end of the linked list.</param>
		public void Add(T data)
		{
			var newNode = new Node<T>(data);
			Add(newNode);
		}

		/// <summary>
		///     <para>
		///         Adds the specified node at the end of the linked list.
		///     </para>
		///     <para>
		///         Time Complexity: O(1), since inserting a node at the end of a linked list is a simple pointer assignment operation.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <param name="node">The node to add to the end of the linked list.</param>
		public void Add(Node<T> node)
		{
			if (_head is null)
			{
				_head = node;
			}
			else
			{
				_tail.SetNext(node);
			}
			_tail = node;
			Count++;
		}

		/// <summary>
		///     <para>
		///         Removes the first occurrence of the specified data from the linked list.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the number of elements in the list.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <param name="data">The data to remove from the linked list.</param>
		/// <returns>True if the data was successfully removed; otherwise, false.</returns>
		public bool Remove(T data)
		{
			if (Count == 0 || _head is null)
			{
				return false;
			}

			if (_head.Value.Equals(data))
			{
				_head = _head.Next;
				if (_head is null)
				{
					_tail = null;
				}
				Count--;
				return true;
			}

			return Remove(_head, _head.Next, data);
		}

		/// <summary>
		///     <para>
		///         Removes all elements from the linked list.
		///     </para>
		///     <para>
		///         Time Complexity: O(1), сlearing the linked list by setting the _head and _tail pointers to null and resetting the Count counter to zero takes constant time.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		public void Clear()
		{
			_head = null;
			_tail = null;
			Count = 0;
		}

		/// <summary>
		///     <para>
		///         Determines whether the linked list contains the specified data.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the number of elements in the list.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <param name="data">The data to locate in the linked list.</param>
		/// <returns>True if the data is found in the linked list; otherwise, false.</returns>
		public bool Contains(T data)
		{
			var current = _head;
			while (current is not null)
			{
				if (current.Value.Equals(data))
				{
					return true;
				}
				current = current.Next;
			}
			return false;
		}

		/// <summary>
		///     <para>
		///         Returns an enumerator that iterates through the linked list.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the number of elements in the linked list.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the linked list.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}

		/// <summary>
		///     <para>
		///         Returns an enumerator that iterates through the linked list.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the number of elements in the linked list.
		///     </para>
		///     <para>
		///         Space Complexity: O(1), doesn't create any new data structures.
		///     </para>
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the linked list.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			var current = _head;
			while (current is not null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}

		/// <summary>
		///     <para>
		///         Recursively removes a node from the linked list.
		///     </para>
		///     <para>
		///         Time Complexity: O(n), where n is the number of elements in the list.
		///     </para>
		///     <para>
		///         Space Complexity: O(n), where n is the number of elements in the list.
		///     </para>
		/// </summary>
		/// <param name="previous">The node before the current node.</param>
		/// <param name="current">The current node being evaluated.</param>
		/// <param name="data">The data to be removed.</param>
		/// <returns>True if the data was successfully removed; otherwise, false.</returns>
		private bool Remove(Node<T> previous, Node<T> current, T data)
		{
			if (current is null)
			{
				return false;
			}

			if (current.Value.Equals(data))
			{
				previous.SetNext(current.Next);
				if (current.Next is null)
				{
					_tail = previous;
				}
				Count--;
				return true;
			}

			return Remove(current, current.Next, data);
		}
	}
}