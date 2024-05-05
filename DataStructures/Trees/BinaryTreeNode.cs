namespace Trees
{
	/// <summary>
	/// Represents a node in a binary tree.
	/// </summary>
	/// <typeparam name="T">The type of value stored in the node, which must implement the IComparable interface.</typeparam>
	public class BinaryTreeNode<T>
		where T : IComparable<T>
	{
		/// <summary>
		/// Gets the value stored in the node.
		/// </summary>
		public T Value { get; private set; }

		/// <summary>
		/// Gets the parent node of the current node.
		/// </summary>
		public BinaryTreeNode<T> ParentNode { get; private set; }

		/// <summary>
		/// Gets the left child node of the current node.
		/// </summary>
		public BinaryTreeNode<T> LeftNode { get; private set; }

		/// <summary>
		/// Gets the right child node of the current node.
		/// </summary>
		public BinaryTreeNode<T> RightNode { get; private set; }

		/// <summary>
		/// Initializes a new instance of the BinaryTreeNode&lt;T&gt; class with the specified value.
		/// </summary>
		/// <param name="data">The value to be stored in the node.</param>
		public BinaryTreeNode(T data)
		{
			Value = data;
		}

		/// <summary>
		/// Sets the parent node of the current node.
		/// </summary>
		/// <param name="parent">The parent node to be set.</param>
		public void SetParentNode(BinaryTreeNode<T> parent)
		{
			ParentNode = parent;
		}

		/// <summary>
		/// Sets the left child node of the current node.
		/// </summary>
		/// <param name="left">The left child node to be set.</param>
		public void SetLeftNode(BinaryTreeNode<T> left)
		{
			LeftNode = left;
		}

		/// <summary>
		/// Sets the right child node of the current node.
		/// </summary>
		/// <param name="right">The right child node to be set.</param>
		public void SetRightNode(BinaryTreeNode<T> right)
		{
			RightNode = right;
		}

		/// <summary>
		/// Sets the value stored in the node.
		/// </summary>
		/// <param name="value">The value to be set.</param>
		public void SetValue(T value)
		{
			Value = value;
		}

		/// <summary>
		/// Returns a string representation of the node's value.
		/// </summary>
		/// <returns>A string representing the value stored in the node.</returns>
		public override string ToString()
		{
			return Value.ToString();
		}
	}
}