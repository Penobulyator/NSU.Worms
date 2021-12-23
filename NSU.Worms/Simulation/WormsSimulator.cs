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
                PlaceFood();
                PerformWormsActions();
                ReduceAndCheckHp();
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

                    int foodEaten = State.Food.RemoveAll((food) => food.Pos.Equals(nextPoint));
                    if (foodEaten != 0)
                        worm.HP += 10;
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

        private void ReduceAndCheckHp()
        {
            State.Food.RemoveAll((food) => --food.HP == 0);
            State.Worms.RemoveAll((worm) => --worm.HP == 0);
        }

        private void PlaceFood()
        {
            Food food = new Food(State.Food);

            foreach(AbstactWorm worm in State.Worms)
            {
                if (worm.Pos.Equals(food.Pos))
                {
                    worm.HP += 10;
                    return;
                }
            }

            State.Food.Add(food);
        }
    }
}
