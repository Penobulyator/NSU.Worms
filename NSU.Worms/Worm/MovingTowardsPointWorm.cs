using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace NSU.Worms.Worm
{
    abstract class MovingTowardsPointWorm : AbstactWorm
    {
        protected Point TargetPoint;
        protected Direction AskToMoveTowardsPoint()
        {
            if (Pos.Equals(TargetPoint))
            {
                return Direction.NONE;
            }
            else
            {
                int difX = TargetPoint.X - Pos.X;
                int difY = TargetPoint.Y - Pos.Y;

                if (difX > difY)
                {
                    return difX > 0 ? Direction.RIGHT : Direction.LEFT;
                }
                else
                {
                    return difY > 0 ? Direction.UP : Direction.DOWN;
                }
            }
        }
    }
}
