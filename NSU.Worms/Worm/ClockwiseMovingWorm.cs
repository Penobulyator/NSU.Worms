using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace NSU.Worms.Worm
{
    class ClockwiseMovingWorm : MovingTowardsPointWorm
    {
        private const int SIDE_LENGTH = 5;
        private Point[] Points = { new Point(SIDE_LENGTH, SIDE_LENGTH), new Point(SIDE_LENGTH, -SIDE_LENGTH), new Point(-SIDE_LENGTH, -SIDE_LENGTH), new Point(-SIDE_LENGTH, SIDE_LENGTH) };
        private int CurrentPointIndex = 0;
        ClockwiseMovingWorm()
        {
            TargetPoint = Points.First();
        }
        public override Direction AskToMove(GameState state)
        {
            Direction direction = AskToMoveTowardsPoint();
            if (direction != Direction.NONE)
            {
                return direction;
            }
            else
            {
                CurrentPointIndex = (CurrentPointIndex + 1) % 4;
                TargetPoint = Points[CurrentPointIndex];
                return AskToMoveTowardsPoint();
            }
        }
    }
}
