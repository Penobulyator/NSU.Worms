using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSU.Worms.Worm;
using NSU.Worms.Directions;
using System.IO;
namespace NSU.Worms.Worm
{
    class WormsSimulator
    {
        private GameState State;
        private const int ITERATIONS = 100;
        public WormsSimulator(GameState initialState)
        {
            State = initialState;
        }


        public void Run()
        {
            using (StreamWriter sw = File.CreateText("output.txt"))
            {
                for (int i = 0; i < ITERATIONS; i++)
                {
                    sw.WriteLine(State);

                    MoveWorms();
                }
            }
        }

        private void MoveWorms()
        {
            foreach (AbstactWorm worm in State.Worms)
            {
                Direction direction = worm.AskToMove(State);
                //TODO: Check for collisions
                worm.Move(direction);
            }

        }
    }
}
