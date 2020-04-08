using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>();
            FileStream stream = new FileStream(@".\text.txt", FileMode.Open, FileAccess.Read);
            byte[] data = new byte[stream.Length];

            stream.Read(data, 0, data.Length);

            string s = Encoding.UTF8.GetString(data);
            Regex reg = new Regex(@"[а-яА-Я]+");
            MatchCollection matches = reg.Matches(s);


            binaryTree.PrintTree(); 


            Console.ReadLine();
        }
    }
}