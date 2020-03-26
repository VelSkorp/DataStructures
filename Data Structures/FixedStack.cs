using System;

namespace Data_Structures
{    
    /*  
     * Недостатки:
     * необходимости перераспределения памяти при добавлении или удалении данных
     * увеличение сложности вычислительного алгоритма
    */
    class FixedStack<T>
    {
        private T[] items; //элементы стека
        private int count; //количество элементов
        const int n = 10; //количество элементов по умолчанию
        public FixedStack()
        {
            items = new T[n];
        }
        public FixedStack(int length)
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
                throw new InvalidOperationException("Стек переполнен");
            items[count++] = item;
        }
        public T Pop()
        {
            if (isEmpty)
                throw new InvalidOperationException("Стек пуст");
            T item = items[--count];
            items[count] = default(T); //сбрасываем ссылку
            return item;
        }
        public T Peek()
        {
            return items[count - 1];
        }
    }
}