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


        public RangeNode(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public int From { get => from; set => from = value; }
        public int To { get => to; set => to = value; }

        public override string ToString()
        {
            string s = "[" + this.from + "," + this.to + "]";
            return s;
        }
    }
}
