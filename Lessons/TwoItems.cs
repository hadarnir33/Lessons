using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    // Exam 2018: 4.b
    class TwoItems
    {
        private int num1;
        private int num2;


        public TwoItems(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        public int Num1 { get => num1; set => num1 = value; }
        public int Num2 { get => num2; set => num2 = value; }

        public override string ToString()
        {
            string s = "[" + this.num1 + "," + this.num2 + "]";
            return s;
        }
    }
}
