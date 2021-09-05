using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NSU.Worms.Directions;
namespace NSU.Worms.Worm
{
    public class ClockwiseMovingWorm : MovingTowardsPointWorm
    {
        private const int SIDE_LENGTH = 5;
        private Point[] Points = { new Point(SIDE_LENGTH, SIDE_LENGTH), new Point(SIDE_LENGTH, -SIDE_LENGTH), new Point(-SIDE_LENGTH, -SIDE_LENGTH), new Point(-SIDE_LENGTH, SIDE_LENGTH) };
        private int CurrentPointIndex = 0;
        public ClockwiseMovingWorm(string name, Point pos) : base(name, pos)
        {
            TargetPoint = Points.First();
        }
        public ClockwiseMovingWorm(string name) : base(name)
        {
            TargetPoint = Points.First();
        }
        public override Direction AskToMove(GameState state)
        {
            Direction direction = AskToMoveTowardsPoint();
            if (direction != null)
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
