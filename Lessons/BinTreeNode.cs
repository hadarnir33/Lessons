using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class BinTreeNode<T>
    {
        private T info;
        private BinTreeNode<T> left;
        private BinTreeNode<T> right;
        public BinTreeNode(T info)
        {
            this.info = info;
            this.left = null;
            this.right = null;
        }
        public BinTreeNode(BinTreeNode<T> left, T info, BinTreeNode<T> right)
        {
            this.info = info;
            this.left = left;
            this.right = right;
        }
        public T GetInfo()
        {
            return info;
        }
        public BinTreeNode<T> GetLeft()
        {
            return left;
        }
        public BinTreeNode<T> GetRight()
        {
            return right;
        }
        public void SetInfo(T info)
        {
            this.info = info;
        }
        public void SetLeft(BinTreeNode<T> left)
        {
            this.left = left;
        }
        public void SetRight(BinTreeNode<T> right)
        {
            this.right = right;
        }
        public override string ToString()
        {
            return " ( " + left + " " + info + " " + right + " ) ";
        }
    }
}
