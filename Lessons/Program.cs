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
            BinTreeNode<int> t2 = buildDebugTree();
            Console.WriteLine(TreeLessThanTree(t2, t));
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
    }
}
