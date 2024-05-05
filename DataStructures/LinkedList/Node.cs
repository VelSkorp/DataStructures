namespace LinkedList
{
	/// <summary>
	/// Represents a node in a singly linked list.
	/// </summary>
	/// <typeparam name="T">The type of data stored in the node.</typeparam>
	public class Node<T>
	{
		/// <summary>
		/// Gets the value stored in the node.
		/// </summary>
		public T Value { get; private set; }

		/// <summary>
		/// Gets the next node in the linked list.
		/// </summary>
		public Node<T> Next { get; private set; }

		/// <summary>
		/// Initializes a new instance of the Node class with the specified value.
		/// </summary>
		/// <param name="value">The value to store in the node.</param>
		public Node(T value)
		{
			Value = value;
		}

		/// <summary>
		/// Sets the next node in the linked list.
		/// </summary>
		/// <param name="next">The next node in the linked list.</param>
		public void SetNext(Node<T> next)
		{
			Next = next;
		}

		/// <summary>
		/// Returns a string representation of the value.
		/// </summary>
		/// <returns>A string representing the value.</returns>
		public override string ToString()
		{
			return Value.ToString();
		}
	}
}