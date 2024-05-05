namespace Trees
{
	/// <summary>
	/// Represents a B-tree data structure.
	/// </summary>
	/// <typeparam name="T">The type of data stored in the tree.</typeparam>
	public class BTree<T>
		where T : IComparable<T>
	{
		/// <summary>
		/// The root node of the B-tree.
		/// </summary>
		public BTreeNode<T> Root { get; private set; }

		/// <summary>
		/// The degree of the B-tree, which determines the minimum and maximum number of keys per node.
		/// </summary>
		public int Degree { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="BTree{T}"/> class with the specified degree.
		/// </summary>
		/// <param name="degree">The degree of the B-tree.</param>
		public BTree(int degree)
		{
			Degree = degree;
		}

		/// <summary>
		/// Inserts a value into the B-tree.
		/// </summary>
		/// <param name="value">The value to insert.</param>
		/// <returns><c>true</c> if the insertion was successful; otherwise, <c>false</c>.</returns>
		public bool Insert(T value)
		{
			if (Root is null)
			{
				Root = new BTreeNode<T>(Degree, value);
				return true;
			}

			if (Root.Values.Count == (2 * Degree - 1))
			{
				var newRoot = new BTreeNode<T>(Degree, default(T));
				newRoot.ChildNodes.Add(Root);
				SplitChild(newRoot, 0);
				Root = newRoot;
			}

			return Insert(value, Root);
		}

		/// <summary>
		/// Deletes a value from the B-tree.
		/// </summary>
		/// <param name="item">The value to delete.</param>
		/// <returns><c>true</c> if the deletion was successful; otherwise, <c>false</c>.</returns>
		public bool Delete(T item)
		{
			return Delete(item, Root);
		}

		/// <summary>
		/// Searches for a value in the B-tree.
		/// </summary>
		/// <param name="value">The value to search for.</param>
		/// <returns>The node containing the value if found; otherwise, <c>null</c>.</returns>
		public BTreeNode<T> Search(T value)
		{
			return Search(value, Root);
		}

		/// <summary>
		/// Inserts a value into the specified node of the B-tree.
		/// </summary>
		/// <param name="value">The value to insert.</param>
		/// <param name="node">The node where the value will be inserted.</param>
		/// <returns><c>true</c> if the insertion was successful; otherwise, <c>false</c>.</returns>
		private bool Insert(T value, BTreeNode<T> node)
		{
			if (node.Values.Contains(value))
			{
				return false;
			}

			var index = node.Values.FindLastIndex(item => item.CompareTo(value) < 0);

			if (node.IsLeaf)
			{
				node.Values.Insert(index + 1, value);
				return true;
			}

			if (node.ChildNodes.ElementAt(index + 1) is not null && node.ChildNodes.ElementAt(index + 1).Values.Count == (2 * Degree - 1))
			{
				SplitChild(node, index + 1);
				if (value.CompareTo(node.Values.ElementAt(index + 1)) > 0)
				{
					index++;
				}
			}

			return Insert(value, node.ChildNodes.ElementAt(index + 1));
		}


		/// <summary>
		/// Deletes a value from the specified node of the B-tree.
		/// </summary>
		/// <param name="item">The value to delete.</param>
		/// <param name="node">The node from which the value will be deleted.</param>
		/// <returns><c>true</c> if the deletion was successful; otherwise, <c>false</c>.</returns>
		private bool Delete(T item, BTreeNode<T> node)
		{
			var index = node.Values.IndexOf(item);

			if (index != -1)
			{
				if (node.IsLeaf)
				{
					node.Values.RemoveAt(index);
					return true;
				}

				if (node.ChildNodes.ElementAt(index).Values.Count >= Degree)
				{
					var predecessor = GetPredecessor(node, index);
					node.Values[index] = predecessor;
					return Delete(predecessor, node.ChildNodes.ElementAt(index));
				}
				else if (node.ChildNodes.ElementAt(index + 1).Values.Count >= Degree)
				{
					var successor = GetSuccessor(node, index);
					node.Values[index] = successor;
					return Delete(successor, node.ChildNodes.ElementAt(index + 1));
				}

				MergeChild(node, index);
				return Delete(item, node.ChildNodes.ElementAt(index));
			}

			var childIndex = 0;
			while (childIndex < node.Values.Count && item.CompareTo(node.Values.ElementAt(childIndex)) > 0)
			{
				childIndex++;
			}

			if (node.ChildNodes.ElementAt(childIndex).Values.Count == Degree - 1)
			{
				if (childIndex > 0 && node.ChildNodes.ElementAt(childIndex - 1).Values.Count >= Degree)
				{
					BorrowFromLeftSibling(node, childIndex);
				}
				else if (childIndex < node.Values.Count && node.ChildNodes.ElementAt(childIndex + 1).Values.Count >= Degree)
				{
					BorrowFromRightSibling(node, childIndex);
				}
				else
				{
					if (childIndex < node.Values.Count)
					{
						MergeChild(node, childIndex);
					}
					else
					{
						MergeChild(node, childIndex - 1);
					}
				}
			}
			return Delete(item, node.ChildNodes.ElementAt(childIndex));
		}

		/// <summary>
		/// Searches for a value in the specified node of the B-tree.
		/// </summary>
		/// <param name="value">The value to search for.</param>
		/// <param name="node">The node where the search will be performed.</param>
		/// <returns>The node containing the value if found; otherwise, <c>null</c>.</returns>
		private BTreeNode<T> Search(T value, BTreeNode<T> node)
		{
			if (node.Values.Contains(value))
			{
				return node;
			}

			if (node.IsLeaf)
			{
				return null;
			}

			var childIndex = 0;
			while (childIndex < node.Values.Count && value.CompareTo(node.Values.ElementAt(childIndex)) > 0)
			{
				childIndex++;
			}

			return Search(value, node.ChildNodes.ElementAt(childIndex));
		}

		/// <summary>
		/// Splits a child node of the specified parent node at the specified index.
		/// </summary>
		/// <param name="parentNode">The parent node whose child will be split.</param>
		/// <param name="childIndex">The index of the child node to split.</param>
		private void SplitChild(BTreeNode<T> parentNode, int childIndex)
		{
			var childToSplit = parentNode.ChildNodes.ElementAt(childIndex);
			var newChild = new BTreeNode<T>(Degree, default(T));

			parentNode.Values.Insert(childIndex, childToSplit.Values.ElementAt(Degree - 1));

			for (var i = 0; i < Degree - 1; i++)
			{
				newChild.Values.Add(childToSplit.Values.ElementAt(i + Degree));
			}

			if (!childToSplit.IsLeaf)
			{
				for (var i = 0; i < Degree; i++)
				{
					newChild.ChildNodes.Add(childToSplit.ChildNodes.ElementAt(i + Degree));
				}
			}

			parentNode.ChildNodes.Insert(childIndex + 1, newChild);
		}

		/// <summary>
		/// Retrieves the predecessor of the value at the specified index in the specified node.
		/// </summary>
		/// <param name="node">The node containing the value.</param>
		/// <param name="index">The index of the value in the node.</param>
		/// <returns>The predecessor value.</returns>
		private T GetPredecessor(BTreeNode<T> node, int index)
		{
			var currentNode = node.ChildNodes.ElementAt(index);
			while (!currentNode.IsLeaf)
			{
				currentNode = currentNode.ChildNodes.ElementAt(currentNode.Values.Count);
			}
			return currentNode.Values.Last();
		}

		/// <summary>
		/// Retrieves the successor of the value at the specified index in the specified node.
		/// </summary>
		/// <param name="node">The node containing the value.</param>
		/// <param name="index">The index of the value in the node.</param>
		/// <returns>The successor value.</returns>
		private T GetSuccessor(BTreeNode<T> node, int index)
		{
			var currentNode = node.ChildNodes.ElementAt(index + 1);
			while (!currentNode.IsLeaf)
			{
				currentNode = currentNode.ChildNodes.First();
			}
			return currentNode.Values.First();
		}

		/// <summary>
		/// Borrows a value from the left sibling node of the specified child node in the specified parent node.
		/// </summary>
		/// <param name="parentNode">The parent node containing the child node.</param>
		/// <param name="childIndex">The index of the child node.</param>
		private void BorrowFromLeftSibling(BTreeNode<T> parentNode, int childIndex)
		{
			var childNode = parentNode.ChildNodes.ElementAt(childIndex);
			var leftSibling = parentNode.ChildNodes.ElementAt(childIndex - 1);

			childNode.Values.Insert(0, parentNode.Values.ElementAt(childIndex - 1));
			parentNode.Values[childIndex - 1] = leftSibling.Values.Last();

			if (!leftSibling.IsLeaf)
			{
				childNode.ChildNodes.Insert(0, leftSibling.ChildNodes.Last());
				leftSibling.ChildNodes.RemoveAt(leftSibling.ChildNodes.Count - 1);
			}

			leftSibling.Values.RemoveAt(leftSibling.Values.Count - 1);
		}

		/// <summary>
		/// Borrows a value from the right sibling node of the specified child node in the specified parent node.
		/// </summary>
		/// <param name="parentNode">The parent node containing the child node.</param>
		/// <param name="childIndex">The index of the child node.</param>
		private void BorrowFromRightSibling(BTreeNode<T> parentNode, int childIndex)
		{
			var childNode = parentNode.ChildNodes.ElementAt(childIndex);
			var rightSibling = parentNode.ChildNodes.ElementAt(childIndex + 1);

			childNode.Values.Add(parentNode.Values.ElementAt(childIndex));
			parentNode.Values[childIndex] = rightSibling.Values.First();

			if (!rightSibling.IsLeaf)
			{
				childNode.ChildNodes.Add(rightSibling.ChildNodes.First());
				rightSibling.ChildNodes.RemoveAt(0);
			}

			rightSibling.Values.RemoveAt(0);
		}

		/// <summary>
		/// Merges the specified child node with its sibling node at the specified index in the specified parent node.
		/// </summary>
		/// <param name="parentNode">The parent node containing the child nodes.</param>
		/// <param name="childIndex">The index of the child node to merge.</param>
		private void MergeChild(BTreeNode<T> parentNode, int childIndex)
		{
			var childNode = parentNode.ChildNodes.ElementAt(childIndex);
			var siblingNode = parentNode.ChildNodes.ElementAt(childIndex + 1);

			childNode.Values.Add(parentNode.Values.ElementAt(childIndex));

			childNode.Values.AddRange(siblingNode.Values);
			childNode.ChildNodes.AddRange(siblingNode.ChildNodes);

			parentNode.Values.RemoveAt(childIndex);
			parentNode.ChildNodes.RemoveAt(childIndex + 1);

			if (parentNode.Values.Count == 0 && parentNode == Root)
			{
				Root = childNode;
			}
		}
	}
}