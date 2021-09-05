﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSU.Worms.Worm;
using NSU.Worms.Directions;
using System.IO;
using System.Drawing;
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
