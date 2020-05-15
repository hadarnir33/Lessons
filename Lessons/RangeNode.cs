using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class RangeNode
    {
        private int from;
        private int to;


        public RangeNode(int low, int high)
        {
            this.from = low;
            this.to = high;
        }

        public int Low { get => from; set => from = value; }
        public int High { get => to; set => to = value; }

        public override string ToString()
        {
            string s = "[" + this.from + "," + this.to + "]";
            return s;
        }
    }
}
