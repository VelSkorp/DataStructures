using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace Trees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var binaryTree = new BinaryTree<int>();
            //FileStream stream = new FileStream(@".\text.txt", FileMode.Open, FileAccess.Read);
            //byte[] data = new byte[stream.Length];

            //stream.Read(data, 0, data.Length);

            //string s = Encoding.UTF8.GetString(data);
            //Regex reg = new Regex(@"[а-яА-Я]+");
            //MatchCollection matches = reg.Matches(s);

            //binaryTree.PrintTree(); 

            //Console.ReadLine();

            var bTree = new BTree(3);

            bTree.Insert(1);
            bTree.Insert(3);
            bTree.Insert(2);
            bTree.Insert(4);
            bTree.Insert(5);

            Console.ReadLine();
        }
    }
}