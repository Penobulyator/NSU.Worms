using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NSU.Worms.Directions;
namespace NSU.Worms.Worm
{
    abstract class MovingTowardsPointWorm : AbstactWorm
    {
        protected Point TargetPoint;
        public MovingTowardsPointWorm(string name, Point pos) : base(name, pos) { }
        public MovingTowardsPointWorm(string name) : base(name) { }
        protected Direction AskToMoveTowardsPoint()
        {
            if (Pos.Equals(TargetPoint))
            {
                return null;
            }
            else
            {
                int difX = TargetPoint.X - Pos.X;
                int difY = TargetPoint.Y - Pos.Y;

                if (Math.Abs(difX) > Math.Abs(difY))
                {
                    return difX > 0 ? new RightDirection() : new LeftDirection();
                }
                else
                {
                    return difY > 0 ? new UpDirection() : new DownDirection();
                }
            }
        }
    }
}
