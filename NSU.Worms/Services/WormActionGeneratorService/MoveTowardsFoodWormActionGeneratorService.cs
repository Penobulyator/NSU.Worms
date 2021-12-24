using NSU.WormsGame.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NSU.WormsGame.Services.WormActionGeneratorService
{
    public class MoveTorawdsFoodWormActionGeneratorService : IWormActionGeneratorService
    {
        public WormAction GenerateWormAction(Worm worm, GameState gameState)
        {
            Point targetPoint = FindNearestFood(worm.Pos, gameState.Food);
            return MoveTowardsPointWormActionGenerator.AskToMoveTowardsPoint(worm.Pos, targetPoint);
        }

        private Point FindNearestFood(Point currentPos, List<Food> food)
        {
            int minDistance = int.MaxValue;
            Point point = currentPos;
            foreach (Food foodItem in food)
            {
                int newDistance = Math.Abs(foodItem.Pos.X - currentPos.X) + Math.Abs(foodItem.Pos.Y - currentPos.Y);
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    point = foodItem.Pos;
                }
            }
            return point;
        }
    }
}
