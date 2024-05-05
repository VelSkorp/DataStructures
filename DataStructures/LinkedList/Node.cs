namespace LinkedList
{
	/// <summary>
	/// Represents a node in a singly linked list.
	/// </summary>
	/// <typeparam name="T">The type of data stored in the node.</typeparam>
	public class Node<T>
	{
		/// <summary>
		/// Gets the data stored in the node.
		/// </summary>
		public T Data { get; private set; }

		/// <summary>
		/// Gets the next node in the linked list.
		/// </summary>
		public Node<T> Next { get; private set; }

		/// <summary>
		/// Initializes a new instance of the Node class with the specified data.
		/// </summary>
		/// <param name="data">The data to store in the node.</param>
		public Node(T data)
		{
			Data = data;
		}

		/// <summary>
		/// Sets the next node in the linked list.
		/// </summary>
		/// <param name="next">The next node in the linked list.</param>
		public void SetNext(Node<T> next)
		{
			Next = next;
		}
	}
}