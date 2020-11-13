using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class Stones
    {
        private BiStone[] BiStones = new BiStone[49]; 

        public Stones()
        {
            int index = 0;
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 10; j <= 16; j++)
                {
                    BiStone b = new BiStone(i, j);
                    this.BiStones[index] = b;
                    index++;
                }
            }
        }
    }
}
