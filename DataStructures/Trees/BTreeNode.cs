using System.Collections.Generic;

namespace Trees
{
    public class BTreeNode<T>
    {
        public List<T> Values { get; private set; }
        public BTreeNode<T> ParentNode { get; set; }
        public List<BTreeNode<T>> ChildNodes { get; set; }

        public BTreeNode(int degree, T value)
        {
            Values = new List<T>(degree) { value };
            ChildNodes = new List<BTreeNode<T>>(degree);
        }

        public BTreeNode(int degree, IEnumerable<T> values)
        {
            Values = new List<T>(values);
            ChildNodes = new List<BTreeNode<T>>(degree);
        }
    }
}