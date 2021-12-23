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
        public MovingTowardsPointWorm(string name, Point pos, int hp) : base(name, pos, hp) { 
            TargetPoint = pos;
        }
        protected WormAction AskToMoveTowardsPoint()
        {
            if (Pos.Equals(TargetPoint))
            {
                return new WormAction(null, false);
            }
            else
            {
                int difX = TargetPoint.X - Pos.X;
                int difY = TargetPoint.Y - Pos.Y;
                Direction direction = null;

                if (Math.Abs(difX) > Math.Abs(difY))
                {
                    if (difX > 0)
                        direction = new RightDirection();
                    else
                        direction = new LeftDirection();
                }
                else
                {
                    if (difY > 0)
                        direction = new UpDirection();
                    else
                        direction = new DownDirection();
                }

                return new WormAction(direction, false);
            }
        }
    }
}
