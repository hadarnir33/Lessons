using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lessons;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> n = BuildNodeChain();
            Console.WriteLine(n);
        }

        public static Node<int> BuildNodeChain()
        {
            Node<int> n1 = new Node<int>(1);
            Node<int> n2 = new Node<int>(2);
            Node<int> n3 = new Node<int>(4);
            Node<int> n4 = new Node<int>(5);
            Node<int> n5 = new Node<int>(6);
            Node<int> n6 = new Node<int>(10);
            Node<int> n7 = new Node<int>(11);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);
            n4.SetNext(n5);
            n5.SetNext(n6);
            n6.SetNext(n7);
            return n1;
        }
    }
}
