using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            NodeStack<int> a = new NodeStack<int>();
            for (int i = 0; i < 6; i++)
                a.Push(i);
            for (int i = 0; i < 6; i++)
                Console.WriteLine(a.Pop());
            Console.WriteLine(a.Count);
            Console.ReadKey();
        }
    }
}