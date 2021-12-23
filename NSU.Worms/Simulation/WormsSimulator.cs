using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSU.WormsGame.Directions;
using System.IO;
using System.Drawing;
using NSU.Worms.Entities.Worm;
using NSU.Worms.Simulation;

namespace NSU.WormsGame
{
    public class WormsSimulator
    {
        private GameState State;
        private const int ITERATIONS = 100;
        public WormsSimulator(GameState initialState)
        {
            State = initialState;
        }


        public void Run(Action<GameState> callback)
        {
            for (int i = 0; i < ITERATIONS; i++)
            {
                callback(State);
                MoveWorms();
            }
        }

        private void MoveWorms()
        {
            foreach (AbstactWorm worm in State.Worms)
            {
                Direction direction = worm.AskToMove(State);

                if (!WormWillCollide(worm, direction))
                {
                    worm.Move(direction);
                }
            }

        }

        private bool WormWillCollide(AbstactWorm worm, Direction direction)
        {
            Point nextPoint = new Point(worm.Pos.X + direction.getX(), worm.Pos.Y + direction.getY());

            foreach (AbstactWorm otherWorm in State.Worms)
            {
                if (!otherWorm.Equals(worm) && otherWorm.Pos.Equals(nextPoint))
                    return true;
            }

            return false;
        }
    }
}
