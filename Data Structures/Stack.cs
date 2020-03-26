using System;

namespace Data_Structures
{
    /*  
     * Недостатки:
     * необходимости перераспределения памяти при добавлении или удалении данных
     * увеличение сложности вычислительного алгоритма
    */
    class Stack<T>
    {
        private T[] items;
        private int count;
        const int n = 10;
        public Stack()
        {
            items = new T[n];
        }
        public Stack(int length)
        {
            items = new T[length];
        }
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
            if (count == items.Length)
                Resize(items.Length + 10);
            items[count++] = item;  
        }
        public T Pop()
        {
            if (count == 0)
                throw new InvalidOperationException("Стек пуст");
            T item = items[--count];
            items[count] = default(T);
            if (count > 0 && count < items.Length - 10)
                Resize(items.Length - 10);
            return item;
        }
        public T Peek()
        {
            return items[count - 1];
        }
        private void Resize(int max)
        {
            T[] tempItems = new T[max];
            for (int i = 0; i < count; i++)
                tempItems[i] = items[i];
            items = tempItems;
        }
    }
}