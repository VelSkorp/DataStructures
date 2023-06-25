using System;

namespace Stack
{
    public class Program
    {
        public static void Main()
        {
            var stack = new NodeStack<int>();
            for (var i = 0; i < 6; i++)
            {
                stack.Push(i); 
            }
            for (var i = 0; i < 6; i++)
            {
                Console.WriteLine($"peek {stack.Peek()}");
                Console.WriteLine($"pop {stack.Pop()}");
            }
            Console.ReadKey();
        }
    }
}