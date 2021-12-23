using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSU.WormsGame.Entities.Directions
{
    class RightDirection : Direction
    {
        public int getX()
        {
            return 1;
        }

        public int getY()
        {
            return 0;
        }
    }
}
