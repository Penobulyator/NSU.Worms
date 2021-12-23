using System.Drawing;
using System.Collections.Generic;
using NSU.WormsGame.Entities;

namespace NSU.WormsGame.Simulation
{
    public class GameState
    {
        public List<Worm> Worms { get; set; }
        public List<Food> Food { get; set; }
        public GameState()
        {
            Worms = new List<Worm>();
            Food = new List<Food>();
        }
        public bool PointIsWorm(Point point)
        {
            foreach (Worm worm in Worms)
            {
                if (worm.Pos.Equals(point))
                    return true;
            }
            return false;
        }
        public bool PointIsFood(Point point)
        {
            foreach (Food food in Food)
            {
                if (food.Pos.Equals(point))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            string wormsStr = string.Join(',', Worms);
            string foodStr = string.Join(',', Food);
            return $"Worms:[{wormsStr}],Food:[{foodStr}]";
        }
    }
}
