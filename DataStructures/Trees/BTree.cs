using System.Linq;

namespace Trees
{
	public class BTree
	{
		private BTreeNode<int> root;
		private readonly int degree;

		public BTree(int t)
		{
			degree = t;
		}

		public bool Find(int item)
		{
			return Find(item, root) != null;
		}

		public void Insert(int item)
		{
			if (root == null)
			{
				root = new BTreeNode<int>(degree, item);
				return;
			}

			Insert(item, root);
		}

		public void Delete(int item)
		{

		}

		private BTreeNode<int> Find(int item, BTreeNode<int> node)
		{
			if (node.Values.Contains(item))
			{
				return node;
			}

			for (var i = 0; i < node.Values.Count; i++)
			{
				if (item < node.Values[i])
				{
					Find(item, node.ChildNodes[i]);
				}
			}

			return null;
		}

		public void Insert(int data, BTreeNode<int> node)
		{
			if (node.Values.Contains(data))
			{
				return;
			}

			var index = node.Values.FindLastIndex(item => item < data);

			if (node.Values.Count < degree - 1 && node.ChildNodes.Count == 0)
			{
				node.Values.Add(data);
				return;
			}

			if (node.Values.Count == degree - 1)
			{

			}

			if (node.ChildNodes.Count != 0 && node.ChildNodes[index + 1] != null)
			{
				Insert(data, node.ChildNodes[index + 1]);
				return;
			}

			BTreeNode<int> rightNode;

			if (node.ParentNode == null)
			{
				var root = new BTreeNode<int>(degree, data);
				rightNode = new BTreeNode<int>(degree, node.Values.Where(item => item > data)) { ParentNode = root };
				var leftNode = new BTreeNode<int>(degree, node.Values.Where(item => item < data)) { ParentNode = root };
				root.ChildNodes.Add(leftNode);
				root.ChildNodes.Add(rightNode);
				this.root = root;
				return;
			}

			rightNode = new BTreeNode<int>(degree, data);
			node.ParentNode.ChildNodes.Add(rightNode);
			Insert(node.Values[index], node.ParentNode);
			node.Values.RemoveRange(index, node.Values.Count - index);
		}
	}
}