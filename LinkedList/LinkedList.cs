using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node (T data)
        {
            Data = data;
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public bool IsEmpty => count == 0;

        private Node<T> head;
        private Node<T> tail;
        private int count;

        public void Add(T data)
        {
            var node = new Node<T>(data);
            if (head == null)
            {
                head = node; 
            }
            else
            {
                tail.Next = node; 
            }
            tail = node;
            count++;
        }

        public bool Remove(T data)
        {
            var current = head;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            tail = previous; 
                        }
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                        {
                            tail = null; 
                        }
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            var current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true; 
                }
                current = current.Next;
            }
            return false;
        }

        public void AppendFirst(T data)
        {
            var node = new Node<T>(data)
            {
                Next = head
            };
            head = node;
            if (count == 0)
            {
                tail = head; 
            }
            count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}