using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSU.Worms.Worm;
using System.IO;
namespace NSU.Worms
{
    class Program
    {
        static public void Main(String[] args)
        {
            GameState state = new GameState();
            state.Worms.Add(new ClockwiseMovingWorm("John"));
            WormsSimulator simulator = new WormsSimulator(state);

            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                simulator.Run(
                    (state)=>
                    {
                        sw.WriteLine(state);
                    }
                );
            }
        }
    }
}
