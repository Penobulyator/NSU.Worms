using Microsoft.Extensions.Hosting;
using NSU.WormsGame.Entities;
using NSU.WormsGame.Simulation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NSU.WormsGame.Services.WormActionGeneratorService;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;

namespace NSU.WormsGame.Services
{
    internal class WormsSimulatorService : IHostedService
    {
        private GameState State;
        private bool Running = true;
        private IServiceProvider ServiceProvider;

        public WormsSimulatorService(IServiceProvider sp) => ServiceProvider = sp;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(RunAsync);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Running = false;
            return Task.CompletedTask;
        }

        private void RunAsync()
        {
            InitState();
            while (Running)
            {
                PlaceFood();
                PerformWormsActions();
                ReduceAndCheckHp();
                ServiceProvider.GetService<IGameStateWriterService>().WriteState(State);

                Thread.Sleep(500);
            }
        }

        private void InitState()
        {
            State = new GameState();
            State.Worms = new List<Worm> { new Worm("bob", new Point(0, 0), 20) };
        }

        private void PerformWormsActions()
        {
            foreach (Worm worm in State.Worms)
            {
                WormAction action= ServiceProvider.GetService<IWormActionGeneratorService>().GenerateWormAction(worm, State);

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
                        Worm newWorm = (Worm)worm.Clone();
                        newWorm.Pos = nextPoint;
                        newWorm.HP = 10;
                        newWorm.Name = ServiceProvider.GetService<IWormNamesGeneratorService>().GenerateWormName(worm.Name, State.Worms);
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

        private void ReduceAndCheckHp()
        {
            State.Food.RemoveAll((food) => --food.HP == 0);
            State.Worms.RemoveAll((worm) => --worm.HP == 0);
        }

        private void PlaceFood()
        {
            Food food = ServiceProvider.GetService<IFoodGeneratorService>().GenerateFood(State.Food);

            foreach (Worm worm in State.Worms)
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
