using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NSU.WormsGame.Simulation;

namespace NSU.WormsGame.Entities
{
    public class Food
    {
        public Point Pos { get; set; }
        public int HP { get; set; }

        private static Random r = new Random();
        public Food(List<Food> otherFood)
        {
            this.HP = 10;

            while (true)
            {
                int x = NextNormal();
                int y = NextNormal();

                bool ok = true;

                foreach (Food food in otherFood)
                {
                    if (food.Pos.X.Equals(x) && food.Pos.Y.Equals(y))
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    this.Pos = new Point(x, y);
                    break;
                }
            }
        }
        public static int NextNormal(double mu = 0, double sigma = 5)

        {

            var u1 = r.NextDouble();

            var u2 = r.NextDouble();

            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

            var randNormal = mu + sigma * randStdNormal;

            return (int)Math.Round(randNormal);

        }

        public override string ToString()
        {
            return $"({Pos.X}, {Pos.Y})";
        }
    }
}
