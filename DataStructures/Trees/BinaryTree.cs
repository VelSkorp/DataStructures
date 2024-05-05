namespace Trees
{
	/// <summary>
	/// Represents a binary tree data structure.
	/// </summary>
	/// <typeparam name="T">The type of elements in the binary tree, which must implement the IComparable interface.</typeparam>
	public class BinaryTree<T>
		where T : IComparable<T>
	{
		/// <summary>
		/// Gets the root node of the binary tree.
		/// </summary>
		public BinaryTreeNode<T> Root { get; private set; }

		/// <summary>
		/// Adds a new element to the binary tree.
		/// </summary>
		/// <param name="data">The data to be added to the binary tree.</param>
		/// <returns>True if the element is added successfully; otherwise, false.</returns>
		public bool Add(T data)
		{
			var newNode = new BinaryTreeNode<T>(data);

			if (Root is not null)
			{
				return Add(newNode, Root);
			}

			Root = newNode;
			return true;
		}

		/// <summary>
		/// Finds a node with the specified value in the binary tree.
		/// </summary>
		/// <param name="value">The value to search for in the binary tree.</param>
		/// <returns>The node with the specified value if found; otherwise, null.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the Binary tree is empty.</exception>
		public BinaryTreeNode<T> FindNode(T value)
		{
			if (Root is null)
			{
				throw new InvalidOperationException("Binary tree is empty");
			}

			return FindNode(value, Root);
		}

		/// <summary>
		/// Removes a node with the specified value from the binary tree.
		/// </summary>
		/// <param name="value">The value of the node to be removed.</param>
		/// <returns>True if the node is removed successfully; otherwise, false.</returns>
		/// <exception cref="InvalidOperationException">Thrown when the Binary tree is empty.</exception>
		public bool Remove(T value)
		{
			var foundNode = FindNode(value);
			return Remove(foundNode);
		}

		/// <summary>
		/// Recursively adds a new node to the binary tree starting from the given current node.
		/// </summary>
		/// <param name="newNode">The node to be added.</param>
		/// <param name="currentNode">The current node being evaluated during insertion.</param>
		/// <returns>True if the node is added successfully; otherwise, false.</returns>
		private bool Add(BinaryTreeNode<T> newNode, BinaryTreeNode<T> currentNode)
		{
			if (newNode.Value.CompareTo(currentNode.Value) == 0)
			{
				return false;
			}

			if (newNode.Value.CompareTo(currentNode.Value) < 0)
			{
				if (currentNode.LeftNode is not null)
				{
					return Add(newNode, currentNode.LeftNode);
				}
				currentNode.SetLeftNode(newNode);
				return true;
			}

			if (currentNode.RightNode is not null)
			{
				return Add(newNode, currentNode.RightNode);
			}
			currentNode.SetRightNode(newNode);
			return true;
		}

		/// <summary>
		/// Recursively searches for a node with the specified value starting from the given current node.
		/// </summary>
		/// <param name="value">The value to search for.</param>
		/// <param name="currentNode">The current node being evaluated during the search.</param>
		/// <returns>The node with the specified value if found; otherwise, null.</returns>
		private BinaryTreeNode<T> FindNode(T value, BinaryTreeNode<T> currentNode)
		{
			if (currentNode is null)
			{
				return null;
			}

			if (value.CompareTo(currentNode.Value) == 0)
			{
				return currentNode;
			}

			if (value.CompareTo(currentNode.Value) < 0)
			{
				return FindNode(value, currentNode.LeftNode);
			}

			return FindNode(value, currentNode.RightNode);
		}

		/// <summary>
		/// Removes the specified node from the binary tree.
		/// </summary>
		/// <param name="node">The node to be removed.</param>
		/// <returns>True if the node is removed successfully; otherwise, false.</returns>
		private bool Remove(BinaryTreeNode<T> node)
		{
			if (node is null)
			{
				return false;
			}

			if (node.LeftNode is null && node.RightNode is null)
			{
				if (node == Root)
				{
					Root = null;
				}
				else
				{
					ParentSetChildNode(node, null);
				}
				return true;
			}

			if (node.LeftNode is null || node.RightNode is null)
			{
				var newChild = node.LeftNode ?? node.RightNode;
				newChild.SetParentNode(node.ParentNode);
				ParentSetChildNode(node, newChild);

				if (node == Root)
				{
					Root = newChild;
				}

				return true;
			}

			var successor = FindSuccessor(node);
			node.SetValue(successor.Value);
			return Remove(successor);
		}

		/// <summary>
		/// Sets the child node of a parent node to the specified child node.
		/// </summary>
		/// <param name="node">The parent node whose child node will be set.</param>
		/// <param name="childNode">The child node to be set.</param>
		private void ParentSetChildNode(BinaryTreeNode<T> node, BinaryTreeNode<T> childNode)
		{
			if (node.ParentNode.LeftNode == node)
			{
				node.ParentNode.SetLeftNode(childNode);
			}
			else
			{
				node.ParentNode.SetRightNode(childNode);
			}
		}

		/// <summary>
		/// Finds the successor node of the specified node in the binary tree.
		/// </summary>
		/// <param name="node">The node for which to find the successor.</param>
		/// <returns>The successor node of the specified node.</returns>
		private BinaryTreeNode<T> FindSuccessor(BinaryTreeNode<T> node)
		{
			if (node.RightNode == null)
			{
				return null;
			}

			node = node.RightNode;
			while (node.LeftNode != null)
			{
				node = node.LeftNode;
			}
			return node;
		}
	}
}