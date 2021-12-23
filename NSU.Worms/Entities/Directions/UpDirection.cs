using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSU.WormsGame.Entities.Directions
{
    class UpDirection : Direction
    {
        public int getX()
        {
            return 0;
        }

        public int getY()
        {
            return 1;
        }
    }
}
