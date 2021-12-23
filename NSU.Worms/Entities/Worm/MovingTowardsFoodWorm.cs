using NSU.WormsGame.Simulation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSU.WormsGame.Entities.Worm
{
    internal class MovingTowardsFoodWorm : MovingTowardsPointWorm
    {
        public MovingTowardsFoodWorm(string name, Point pos, int hp) : base(name, pos, hp)
        {
        }

        public override WormAction AskToMove(GameState state)
        {
            FindNearestFood(state.Food);

            return AskToMoveTowardsPoint();
        }

        private void FindNearestFood(List<Food> food)
        {
            int minDistance = int.MaxValue;

            foreach(Food foodItem in food)
            {
                int newDistance = Math.Abs(foodItem.Pos.X - Pos.X) + Math.Abs(foodItem.Pos.Y - Pos.Y);
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    TargetPoint = foodItem.Pos;
                }
            }
        }
    }
}
