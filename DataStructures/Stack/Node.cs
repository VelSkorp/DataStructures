namespace Stack
{
	/// <summary>
	/// Represents a node in a node stack.
	/// </summary>
	/// <typeparam name="T">The type of data stored in the node.</typeparam>
	public class Node<T>
	{
		/// <summary>
		/// Gets the data stored in the node.
		/// </summary>
		public T Data { get; private set; }

		/// <summary>
		/// Gets the reference to the next node in the stack.
		/// </summary>
		public Node<T> Next { get; private set; }

		/// <summary>
		/// Initializes a new instance of the Node&lt;T&gt; class with the specified data.
		/// </summary>
		/// <param name="data">The data to be stored in the node.</param>
		public Node(T data)
		{
			Data = data;
		}

		/// <summary>
		/// Sets the reference to the next node in the stack.
		/// </summary>
		/// <param name="next">The next node to be referenced.</param>
		public void SetNext(Node<T> next)
		{
			Next = next;
		}
	}
}