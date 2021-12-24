using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSU.WormsGame.Entities;
using NSU.WormsGame.Entities.Directions;
using NSU.WormsGame.Services;
using NSU.WormsGame.Services.WormActionGeneratorService;
using System.Drawing;
using Moq;
using System;
using System.Collections.Generic;

namespace NSU.WormsGame.Tests
{
    [TestClass]
    public class MoveTowardsFoodTests
    {
        [TestMethod]
        public void MoveTowardsFoodTest()
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(p => p.GetService(typeof(IWormActionGeneratorService))).Returns(new MoveTorawdsFoodWormActionGeneratorService());

            Food foodToAdd = new Food();
            foodToAdd.Pos = new Point(10, 10);
            foodToAdd.HP = 20;

            GameState gameState = new GameState();
            gameState.Worms.Add(new Worm("bob", new Point(0, 0), 100));
            gameState.Food.Add(foodToAdd);

            WormsSimulatorService wormsSimulator = new WormsSimulatorService(serviceProviderMock.Object);
            wormsSimulator.State = gameState;

            int distance = foodToAdd.Pos.X + foodToAdd.Pos.Y;

            for (int i = 0; i < 19; i++)
            {
                wormsSimulator.PerformWormsActions();

                Assert.IsTrue(wormsSimulator.State.Worms.Count.Equals(1));
                Assert.IsTrue(wormsSimulator.State.Food.Count.Equals(1));

                Worm worm = wormsSimulator.State.Worms[0];
                Food food = wormsSimulator.State.Food[0];

                int newDistance = Math.Abs(food.Pos.X - worm.Pos.X) + Math.Abs(food.Pos.Y - worm.Pos.Y);
                Assert.IsTrue(newDistance < distance);
                distance = newDistance;
            }
        }
    }
}
