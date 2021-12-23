using NSU.WormsGame.Entities;
using NSU.WormsGame.Entities.Directions;
using NSU.WormsGame.Entities.Worm;
using NSU.WormsGame.Simulation;
using System;
using System.Collections.Generic;
using System.Drawing;

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
                PerformWormsActions();
            }
        }

        private void PerformWormsActions()
        {
            foreach (AbstactWorm worm in State.Worms)
            {
                WormAction action = worm.AskToMove(State);

                if (action.IsDoNothing())
                    continue;

                Point nextPoint = action.Direction.getNextPoint(worm.Pos);

                if (State.PointIsWorm(nextPoint))
                    continue;

                if (action.Reproduce)
                {
                    if (State.PointIsFood(nextPoint))
                        continue;

                    if (worm.HP > 10)
                    {
                        AbstactWorm newWorm = (AbstactWorm)worm.Clone();
                        newWorm.Pos = nextPoint;
                        newWorm.HP = 10;
                        newWorm.Name = GetUniqueWormName(worm.Name);
                        State.Worms.Add(newWorm);

                        worm.HP -= 10;
                    }
                }
                else
                {
                    worm.Move(action.Direction);

                    for (int i = 0; i < State.Food.Count; i++)
                    {
                        if (State.Food[i].Equals(worm.Pos))
                        {
                            State.Food.RemoveAt(i);
                            worm.HP += 10;
                            break;
                        }
                    }
                }
            }

        }

        private String GetUniqueWormName(String baseName)
        {
            int tryCount = 0;

            while (true)
            {
                String newName = baseName + tryCount;
                AbstactWorm worm = State.Worms.Find(worm => worm.Name.Equals(newName));
                if (worm == null)
                    return newName;

                tryCount++;
            }
        }

    }
}
