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
            Node<int> n2 = BuildNodeChain2();
            Console.WriteLine(n2);            
        }

        // Exam 
        public static Node<int> ListOfSquares(Node<int> L1, Node<int> L2)
        {
            Node<int> L1Temp = L1;
            Node<int> L2Temp = L2;
            Node<int> L3 = new Node<int>(-1);
            Node<int> L3Temp = L3;
            while (L1Temp != null)
            {
                while(L2Temp != null)
                {
                    if (Math.Pow(L1Temp.GetInfo(), 2) == L2Temp.GetInfo())
                        L3Temp = InsertValueToChain(L1Temp.GetInfo(), L3Temp);
                    L2Temp = L2Temp.GetNext();
                }
                L2Temp = L2;
                L1Temp = L1Temp.GetNext();
            }
            return L3.GetNext();
        }

        // Exam
        public static Node<int> InsertValueToChain(int value, Node<int> n)
        {
            Node<int> next = new Node<int>(value);
            n.SetNext(next);
            return n.GetNext();
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

        public static Node<int> BuildNodeChain2()
        {
            Node<int> n1 = new Node<int>(144);
            Node<int> n2 = new Node<int>(4);
            Node<int> n3 = new Node<int>(5);
            Node<int> n4 = new Node<int>(16);
            Node<int> n5 = new Node<int>(19);
            Node<int> n6 = new Node<int>(20);
            Node<int> n7 = new Node<int>(25);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);
            n4.SetNext(n5);
            n5.SetNext(n6);
            n6.SetNext(n7);
            return n1;
        }

        // Exam 2010 2, this function creates a RangeNode chain
        public static Node<RangeNode> CreateRangeNodeList(Node<int> sourceNode)
        {
            Node<int> lastNode;
            Node<RangeNode> root, temp;
            lastNode = LastNodeInRange(sourceNode);
            root = CreateRangeNodeInNode(sourceNode.GetInfo(), lastNode.GetInfo());
            temp = root;
            sourceNode = lastNode.GetNext();
            while (sourceNode != null)
            {
                lastNode = LastNodeInRange(sourceNode);
                temp.SetNext(CreateRangeNodeInNode(sourceNode.GetInfo(), lastNode.GetInfo()));
                temp = temp.GetNext();
                sourceNode = lastNode.GetNext();
            }
            return root;
        }

        // Exam 2010 2, this function is a helper function, it returns the last node in the range of a given chain
        public static Node<int> LastNodeInRange(Node<int> n)
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

        // Exam 2010 2, this function is a helper function, it return a RangeNode object inside of a Node
        public static Node<RangeNode> CreateRangeNodeInNode(int from , int to)
        {
            Node<RangeNode> rangeNodeInNode;
            RangeNode r = new RangeNode(from, to);
            rangeNodeInNode = new Node<RangeNode>(r);
            return rangeNodeInNode;
        }
    }
}
