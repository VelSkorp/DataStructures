using System;
using System.Collections.Generic;
using System.Collections;

namespace Data_Structures
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class NodeStack<T> : IEnumerable<T>
    {
        Node<T> head;
        int count;
        public bool isEmpty
        {
            get { return count == 0; }
        }
        public int Count
        {
            get { return count; }
        }
        public void Push(T item)
        {
            Node<T> node = new Node<T>(item);
            node.Next = head;
            head = node;
            count++;
        }
        public T Pop()
        {
            if (isEmpty)
                throw new InvalidOperationException("стек пуст");
            Node<T> temp = head;
            head = head.Next;
            count--;
            return temp.Data; 
        }
        public T Peek()
        {
            if (isEmpty)
                throw new InvalidOperationException("стек пуст");
            return head.Data;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}