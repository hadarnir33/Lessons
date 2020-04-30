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
            Console.WriteLine(LessThanTree(t, 4));
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

        // Exam 2018 6, this function checks wheter all the nodes in the tree have higher values than x
        public static bool LessThanTree(BinTreeNode<int> t, int x)
        {
            if (t == null)
                return true;
            else
            {
                Console.WriteLine(t.GetInfo());
                if (t.GetInfo() <= x)
                    return false;
                return LessThanTree(t.GetRight(), x) && LessThanTree(t.GetLeft(), x);
            }
        }
    }
}
