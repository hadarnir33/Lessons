using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class List<T>
    {
        private Node<T> first;
        /* הפעולה בונה ומחזירה רשימה ריקה */
        public List()
        {
            this.first = null;
        }
        /*הפעולה מחזירה את החוליה הראשונה ברשימה 
          אם הרשימה ריקה הפעולה מחזירה null*/
        public Node<T> GetFirst()
        {
            return first;
        }
        /*הפעולה מכניסה לרשימה חוליה חדשה שהערך שלה הוא info  אחרי החוליה p 
        הפעולה מחזירה את החוליה החדשה שהוכנסה
        כדי להכניס איבר ראשון לרשימה הערך של הפרמטר p צריך להיות null
        הנחה: החוליה next קיימת ברשימה   */
        public Node<T> Insert(Node<T> p, T info)
        {
            Node<T> q = new Node<T>(info);
            if (p == null)
            {
                q.SetNext(first);
                first = q;
            }
            else
            {
                q.SetNext(p.GetNext());
                p.SetNext(q);
            }
            return q;
        }
        /*הפעולה מוציאה את החוליה p מן הרשימה ומחזירה את החוליה הבאה אחריה
        אם הוצאה החוליה האחרונה ברשימה הפעולה תחזיר null
        הנחה: החוליה p קיימת ברשימה*/
        public Node<T> Remove(Node<T> p)
        {
            if (first == p)
            {
                first = p.GetNext();
                return first;
            }
            else
            {
                Node<T> prev = first;
                while (prev.GetNext() != p)
                    prev = prev.GetNext();
                prev.SetNext(p.GetNext());
                return prev.GetNext();
            }
        }
        /* הפעולה מחזירה 'אמת' אם הרשימה ריקה, ומחזירה 'שקר' אחרת **/
        public bool IsEmpty()
        {
            return first == null;
        }
        /* הפעולה מחזירה מחרוזת המתארת את הרשימה */
        public override string ToString()
        {
            string s = "[";
            Node<T> p = this.first;
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
