namespace Trees
{
	/// <summary>
	/// Represents a node in a B-tree data structure.
	/// </summary>
	/// <typeparam name="T">The type of data stored in the node.</typeparam>
	public class BTreeNode<T>
		where T : IComparable<T>
	{
		/// <summary>
		/// Gets the list of values stored in the node.
		/// </summary>
		public List<T> Values { get; private set; }

		/// <summary>
		/// Gets the parent node of the current node.
		/// </summary>
		public BTreeNode<T> ParentNode { get; private set; }

		/// <summary>
		/// Gets the list of child nodes of the current node.
		/// </summary>
		public List<BTreeNode<T>> ChildNodes { get; private set; }

		/// <summary>
		/// Indicates whether the current node is a leaf node (i.e., has no child nodes).
		/// </summary>
		public bool IsLeaf => ChildNodes.Count == 0;

		/// <summary>
		/// Initializes a new instance of the <see cref="BTreeNode{T}"/> class with a specified degree and a single value.
		/// </summary>
		/// <param name="degree">The degree of the B-tree.</param>
		/// <param name="value">The value to be stored in the node.</param>
		public BTreeNode(int degree, T value)
		{
			Values = new List<T>(degree) { value };
			ChildNodes = new List<BTreeNode<T>>(degree);
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="BTreeNode{T}"/> class with a specified degree and a collection of values.
		/// </summary>
		/// <param name="degree">The degree of the B-tree.</param>
		/// <param name="values">The collection of values to be stored in the node.</param>
		public BTreeNode(int degree, IEnumerable<T> values)
		{
			Values = new List<T>(values);
			ChildNodes = new List<BTreeNode<T>>(degree);
		}
	}
}