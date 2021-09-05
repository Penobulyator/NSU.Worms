using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSU.Worms.Worm;
namespace NSU.Worms
{
    class Program
    {
        static public void Main(String[] args)
        {
            GameState state = new GameState();
            state.Worms.Add(new ClockwiseMovingWorm());
            WormsSimulator simulator = new WormsSimulator(state);
            simulator.Run();
        }
    }
}
