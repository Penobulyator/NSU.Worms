using System;
using System.Collections.Generic;
using System.Text;
using NSU.WormsGame.Entities;
using System.Drawing;
namespace NSU.WormsGame.Services
{
    public interface IFoodGeneratorService
    {
        public Food GenerateFood(List<Food> otherFood);
    }
    public class FoodGeneratorService : IFoodGeneratorService
    {
        private Random r = new Random();
        public Food GenerateFood(List<Food> otherFood)
        {
            Food food = new Food();

            food.HP = 10;

            while (true)
            {
                int x = NextNormal();
                int y = NextNormal();

                bool ok = true;

                foreach (Food foodIntem in otherFood)
                {
                    if (foodIntem.Pos.X.Equals(x) && foodIntem.Pos.Y.Equals(y))
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    food.Pos = new Point(x, y);
                    return food;
                }
            }
        }
        private int NextNormal(double mu = 0, double sigma = 5)

        {

            var u1 = r.NextDouble();

            var u2 = r.NextDouble();

            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

            var randNormal = mu + sigma * randStdNormal;

            return (int)Math.Round(randNormal);

        }
    }
}
