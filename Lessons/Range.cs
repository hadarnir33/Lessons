using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class Range
    {
        private int low;
        private int high;


        public Range(int low, int high)
        {
            this.low = low;
            this.high = high;
        }

        public int Low { get => low; set => low = value; }
        public int High { get => high; set => high = value; }

        public override string ToString()
        {
            string s = "[" + this.low + "," + this.high + "]";
            return s;
        }
    }
}
