﻿using System;
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
            BinTreeNode<int> t1 = BuildTree();
            BinTreeNode<int> t2 = BuildDebugTree();
            Console.WriteLine(IsAcopy(t1, t2));
        }

        // This function creates a three level tree with hardcoded values.
        public static BinTreeNode<int> BuildTree()
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
        public static BinTreeNode<int> BuildDebugTree()
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

        // This function creates an hardcoded Range tree
        public static BinTreeNode<Range> BuildRangeTree()
        {
            Range r1 = new Range(1, 10);
            Range r2 = new Range(5, 10);
            Range r3 = new Range(1, 4);
            Range r4 = new Range(8, 10);
            BinTreeNode<Range> t1 = new BinTreeNode<Range>(r1);
            BinTreeNode<Range> t2 = new BinTreeNode<Range>(r2);
            BinTreeNode<Range> t3 = new BinTreeNode<Range>(r3);
            BinTreeNode<Range> t4 = new BinTreeNode<Range>(r4);
            t1.SetRight(t2);
            t1.SetLeft(t3);
            t2.SetRight(t4);
            return t1;
        }

        // This function creates an hardcoded stack tree
        public static BinTreeNode<Stack<int>> BuildStackTree()
        {
            BinTreeNode<Stack<int>> st1 = new BinTreeNode<Stack<int>>(BuildStackFromArray(new int[] { 7, 9, 4, 8 }));
            BinTreeNode<Stack<int>> st2 = new BinTreeNode<Stack<int>>(BuildStackFromArray(new int[] { 2, 1, 8, 1 }));
            BinTreeNode<Stack<int>> st3 = new BinTreeNode<Stack<int>>(BuildStackFromArray(new int[] { 1, 3 }));
            BinTreeNode<Stack<int>> st4 = new BinTreeNode<Stack<int>>(BuildStackFromArray(new int[] { }));
            BinTreeNode<Stack<int>> st5 = new BinTreeNode<Stack<int>>(BuildStackFromArray(new int[] { 1, 4, 9, 2 }));
            st1.SetRight(st2);
            st2.SetLeft(st3);
            st2.SetRight(st4);
            st4.SetLeft(st5);
            return st1;
        }

        // This function creates a stack from an array
        public static Stack<int> BuildStackFromArray(int[] arr)
        {
            Stack<int> s = new Stack<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                s.Push(arr[i]);
            }
            return s;
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

        // Exam 2019 6, this function checks wheter the given tree is a Range tree
        public static bool Order(BinTreeNode<Range> rt)
        {
            bool firstCondition = false, secondCondition = false, thirdCondition = false;
            if (rt == null || rt.GetRight() == null && rt.GetLeft() == null)
                return true;
            else
            {
                if ((rt.GetLeft() != null && rt.GetInfo().Low == rt.GetLeft().GetInfo().Low && rt.GetInfo().High >= rt.GetLeft().GetInfo().High) || rt.GetLeft() == null)
                    firstCondition = true;
                if ((rt.GetRight() != null && rt.GetInfo().High == rt.GetRight().GetInfo().High && rt.GetInfo().Low <= rt.GetRight().GetInfo().Low) || rt.GetRight() == null)
                    secondCondition = true;
                if ((rt.GetRight() != null && rt.GetLeft() != null && rt.GetLeft().GetInfo().High < rt.GetRight().GetInfo().Low) || !(rt.GetRight() != null && rt.GetLeft() != null))
                    thirdCondition = true;
                if(firstCondition && secondCondition && thirdCondition)
                    return Order(rt.GetRight()) && Order(rt.GetLeft());
                return false;
            }
        }

        // Exam 2012 2, this function returns a stack than contains the sum of the top three values in the stack inside each node of the tree
        public static Stack<int> SumStacksInTreeToStack(BinTreeNode<Stack<int>> st, Stack<int> s)
        {
            if(st != null)
            {
                SumStacksInTreeToStack(st.GetLeft(), s);
                s.Push(SumTopThreeInStack(st.GetInfo()));
                SumStacksInTreeToStack(st.GetRight(), s);
            }
            return s;
        }

        // Exam 2012 2, this function is a helper function, it sums the top 3 values in a stack
        public static int SumTopThreeInStack(Stack<int> s)
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                if (s.IsEmpty())
                    break;
                else
                    sum += s.Pop();
            }
            return sum;
        }

        public static bool FindThreeSixTimes(BinTreeNode<int> bt, Stack<int> s)
        {
            if (s.Top() == 6)
                return true;
            if (bt == null)
                return false;
            else
            {
                if(bt.GetInfo() == 3)
                {
                    s.Push(s.Pop() + 1);
                    return FindThreeSixTimes(bt.GetRight(), s) || FindThreeSixTimes(bt.GetLeft(), s);
                }
                return false;
            } 
        }

        // Exam 2011 4 a, this function inserts to a stack the values inside the nodes of the tree
        public static void Leaves(BinTreeNode<int> t, Stack<int> s)
        {
            if(t != null)
            {
                Leaves(t.GetRight(), s);
                s.Push(t.GetInfo());
                Leaves(t.GetLeft(), s);
            }
        }

        // Exam 2011 4 b, this function checkes wether the given tress are the same
        public static bool IsAcopy(BinTreeNode<int> t1, BinTreeNode<int> t2)
        {
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();
            Leaves(t1, s1);
            Leaves(t2, s2);
            while(!s1.IsEmpty() && !s2.IsEmpty())
            {
                if (s1.Pop() != s2.Pop())
                    return false;
            }
            if (!s1.IsEmpty() || !s2.IsEmpty())
                return false;
            return true;
        }
    }
}
