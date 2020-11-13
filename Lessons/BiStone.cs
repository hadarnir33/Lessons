using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class BiStone
    {
        private int singleDigit;
        private int doubleDigit;

        public BiStone(int singleDigit, int doubleDigit)
        {
            this.singleDigit = singleDigit;
            this.doubleDigit = doubleDigit;
        }

        public bool checkSingleDigitEquality()
        {
            if (this.singleDigit == this.doubleDigit % 10)
                return true;
            return false;
        }
    }
}
