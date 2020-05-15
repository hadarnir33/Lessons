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
            Console.WriteLine(CreateRangeNode(n));
        }

        public static Node<int> BuildNodeChain()
        {
            Node<int> n1 = new Node<int>(3);
            Node<int> n2 = new Node<int>(4);
            Node<int> n3 = new Node<int>(5);
            Node<int> n4 = new Node<int>(12);
            Node<int> n5 = new Node<int>(19);
            Node<int> n6 = new Node<int>(20);
            Node<int> n7 = new Node<int>(100);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);
            n4.SetNext(n5);
            n5.SetNext(n6);
            n6.SetNext(n7);
            return n1;
        }

        // Exam 2010 2, this function creates a RangeNode chain
        public static Node<RangeNode> CreateRangeNode(Node<int> sourceNode)
        {
            Node<int> lastNode;
            RangeNode rangeObject;
            int to, from;
            Node<RangeNode> root, temp;
            lastNode = lastNodeInRange(sourceNode);
            to = sourceNode.GetInfo();
            from = lastNode.GetInfo();
            rangeObject = new RangeNode(to, from);
            root = new Node<RangeNode>(rangeObject);
            temp = root;
            sourceNode = lastNode.GetNext();
            while (sourceNode != null)
            {
                lastNode = lastNodeInRange(sourceNode);
                to = sourceNode.GetInfo();
                from = lastNode.GetInfo();
                rangeObject = new RangeNode(to, from);
                temp.SetNext(new Node<RangeNode>(rangeObject));
                temp = temp.GetNext();
                sourceNode = lastNode.GetNext();
            }
            return root;
        }

        // Exam 2010 2, this function is a helper function it returns the last node in the range of a given chain
        public static Node<int> lastNodeInRange(Node<int> n)
        {
            while (n.HasNext())
            {
                if (n.GetNext().GetInfo() - 1 == n.GetInfo())
                    n = n.GetNext();
                else
                {
                    break;
                }
            }
            return n;
        }
    }
}
