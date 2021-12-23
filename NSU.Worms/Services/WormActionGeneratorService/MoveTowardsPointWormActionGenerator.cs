using NSU.WormsGame.Entities;
using NSU.WormsGame.Entities.Directions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NSU.WormsGame.Services.WormActionGeneratorService
{
    internal class MoveTowardsPointWormActionGenerator
    {
        public static WormAction AskToMoveTowardsPoint(Point curentPos, Point TargetPoint)
        {
            if (curentPos.Equals(TargetPoint))
            {
                return new WormAction(null, false);
            }
            else
            {
                int difX = TargetPoint.X - curentPos.X;
                int difY = TargetPoint.Y - curentPos.Y;
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
