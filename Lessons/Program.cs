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
            BinTreeNode<int> t = buildTree();
            Console.WriteLine(UpPath(t));
            Console.WriteLine(t);
        }

        // This function creates a three level tree with hardcoded values.
        public static BinTreeNode<int> buildTree()
        {
            BinTreeNode<int> t1 = new BinTreeNode<int>(1);
            BinTreeNode<int> t2 = new BinTreeNode<int>(2);
            BinTreeNode<int> t3 = new BinTreeNode<int>(3);
            BinTreeNode<int> t4 = new BinTreeNode<int>(4);
            BinTreeNode<int> t5 = new BinTreeNode<int>(5);
            BinTreeNode<int> t6 = new BinTreeNode<int>(6);
            BinTreeNode<int> t7 = new BinTreeNode<int>(7);
            t1.SetRight(t2);
            t1.SetLeft(t3);
            t2.SetRight(t4);
            t2.SetLeft(t5);
            t3.SetRight(t6);
            t3.SetLeft(t7);
            return t1;
        }

        // This function creates an hardcoded tree for debugging
        public static BinTreeNode<int> buildDebugTree()
        {
            BinTreeNode<int> t1 = new BinTreeNode<int>(-2);
            BinTreeNode<int> t2 = new BinTreeNode<int>(-5);
            BinTreeNode<int> t3 = new BinTreeNode<int>(0);
            BinTreeNode<int> t4 = new BinTreeNode<int>(0);
            t1.SetRight(t2);
            t1.SetLeft(t3);
            t2.SetRight(t4);
            return t1;
        }

        // Exam 2018 6, this function checks wheter all the nodes in the tree have higher values than x O(n)
        public static bool LessThanTree(BinTreeNode<int> t, int x)
        {
            if (t == null)
                return true;
            else
            {
                if (t.GetInfo() <= x)
                    return false;
                return LessThanTree(t.GetRight(), x) && LessThanTree(t.GetLeft(), x);
            }
        }

        // Exam 2018 6.a, this function checks wheter each node in the first tree has a lower value than every node in the second tree O(n^2)
        public static bool TreeLessThanTree(BinTreeNode<int> t1, BinTreeNode<int> t2)
        {
            if (t1 == null)
                return true;
            else
            {
                if (LessThanTree(t2, t1.GetInfo()))
                    return TreeLessThanTree(t1.GetRight(), t2) && TreeLessThanTree(t1.GetLeft(), t2);
                else
                    return false;
            }
        }

        // Exam 2017 6.a, this function checks wheter x value exists in one of the nodes in the tree
        public static bool exist(BinTreeNode<int> t, int x)
        {
            if (t == null)
                return false;
            else
            {
                if (t.GetInfo() == x)
                    return true;
                return exist(t.GetRight(), x) || exist(t.GetLeft(), x);
            }
        }

        // Exam 2017 6.b, this function gets two trees and return a list with all the values exists on the first tree but not on the second tree
        public static Node<int> Check(BinTreeNode<int> t1, BinTreeNode<int> t2)
        {
            Node<int> first = new Node<int>(-1);
            first = Check(t1, t2, first);
            return first.GetNext();
        }

        // Exam 2017 6.b, this function inserts to a list all the values that exists on the first tree but not on the other
        public static Node<int> Check(BinTreeNode<int> t1, BinTreeNode<int> t2, Node<int> list)
        {
            if (t1 == null)
                return null;
            else
            {
                if (!exist(t2, t1.GetInfo()))
                {
                    Node<int> nodeToInsert = new Node<int>(t1.GetInfo());
                    list.SetNext(nodeToInsert);
                }
                Node<int> temp = list;
                while (temp.GetNext() != null)
                {
                    temp = temp.GetNext();
                }
                Check(t1.GetRight(), t2, temp);
                temp = list;
                while (temp.GetNext() != null)
                {
                    temp = temp.GetNext();
                }
                Check(t1.GetLeft(), t2, temp);
                return list;
            }
        }

        // Exam 2016 6, this function checks wheter there is a path from the root to one of the leafes that is sorted in ascending order
        public static bool UpPath(BinTreeNode<int> tr)
        {
            bool flagRight = false;
            bool flagLeft = false;
            if (tr.GetLeft() == null || tr.GetRight() == null) { 
                return true;
                }
            else
            {
                if (tr.GetRight() != null && tr.GetInfo() < tr.GetRight().GetInfo())
                    flagRight = UpPath(tr.GetRight());
                if (tr.GetLeft() != null && tr.GetInfo() < tr.GetLeft().GetInfo())
                    flagLeft = UpPath(tr.GetLeft());
                return flagRight || flagLeft;
            }
        }
    }
}
