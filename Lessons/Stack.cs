using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonOfListAndGenericList
{
    class Stack<T>
    {
        private Node<T> head;
        /* הפעולה בונה ומחזירה מחסנית ריקה **/
        public Stack()
        {
            this.head = null;
        }
        public void Push(T x)
        {
            Node<T> temp = new Node<T>(x);
            temp.SetNext(head);
            head = temp;
        }
        /* הפעולה מכניסה את הערך x לראש המחסנית הנוכחית **/
        /* הפעולה מוציאה ומחזירה את הערך הנמצא  בראש המחסנית הנוכחית **/
        public T Pop()
        {
            T x = head.GetInfo();
            head = head.GetNext();
            return x;
        }


        /* הפעולה מחזירה את הערך הנמצא  בראש המחסנית הנוכחית **/
        public T Top()
        {
            return head.GetInfo();
        }


        /* הפעולה מחזירה 'אמת' אם המחסנית הנוכחית ריקה, ומחזירה 'שקר' אחרת **/
        public bool IsEmpty()
        {
            return head == null;
        }


        /* הפעולה מחזירה מחרוזת המתארת את המחסנית הנוכחית */
        public override string ToString()
        {
            string s = "[";
            Node<T> p = this.head;
            while (p != null)
            {
                s = s + p.GetInfo().ToString();
                if (p.GetNext() != null)
                    s = s + ",";
                p = p.GetNext();
            }
            s = s + "]";
            return s;
        }
    }
}
