using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSU.WormsGame.Simulation;
using NSU.WormsGame.Entities.Worm;
namespace NSU.WormsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameState game = new GameState();
            game.Worms = new List<AbstactWorm> {
                new MovingTowardsFoodWorm("bob", new System.Drawing.Point(5, 5), 20)
            };

            WormsSimulator wormsSimulator = new WormsSimulator(game);
            wormsSimulator.Run((gameState) =>
            {
                String str = gameState.ToString();
                Console.WriteLine(str);
                return;
            });
        }
    }
}
