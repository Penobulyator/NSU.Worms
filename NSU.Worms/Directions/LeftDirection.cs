using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSU.Worms.Directions
{
    class LeftDirection : Direction
    {
        public int getX()
        {
            return -1;
        }

        public int getY()
        {
            return 0;
        }
    }
}
