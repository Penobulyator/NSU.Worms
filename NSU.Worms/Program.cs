using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSU.Worms.Entities.Worm;
using NSU.Worms.Simulation;
using NSU.WormsGame.Worms;
namespace NSU.WormsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameState game = new GameState();
            game.Worms = new List<AbstactWorm> {
                new ClockwiseMovingWorm("bob", new System.Drawing.Point(5, 5), 20)
            };

            WormsSimulator wormsSimulator = new WormsSimulator(game);
            wormsSimulator.Run((gameState) =>
            {
                Console.WriteLine(gameState.ToString());
            });
        }
    }
}
