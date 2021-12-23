using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NSU.WormsGame.Entities.Directions;

namespace NSU.WormsGame.Entities.Worm
{
    public abstract class MovingTowardsPointWorm : AbstactWorm
    {
        protected Point TargetPoint;
        public MovingTowardsPointWorm(string name, Point pos, int hp) : base(name, pos, hp) { }
        protected WormAction AskToMoveTowardsPoint()
        {
            if (Pos.Equals(TargetPoint))
            {
                return null;
            }
            else
            {
                int difX = TargetPoint.X - Pos.X;
                int difY = TargetPoint.Y - Pos.Y;
                Direction direction = null;

                if (Math.Abs(difX) > Math.Abs(difY))
                {
                    direction = difX > 0 ? new RightDirection() : new LeftDirection();
                }
                else
                {
                    direction = difY > 0 ? new UpDirection() : new DownDirection();
                }

                return new WormAction(direction, false);
            }
        }
    }
}
