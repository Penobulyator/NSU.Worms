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
    public class FoodTests
    {
        [TestMethod]
        public void UniqueFoodCoordTest()
        {
            List<Food> foodList = new List<Food>();
            IFoodGeneratorService foodGenerator = new FoodGeneratorService();
            for (int i = 0; i < 100; i++)
            {
                Food newFood = foodGenerator.GenerateFood(foodList);
                Assert.IsNull(foodList.Find((food) => food.Pos.Equals(newFood.Pos)));
                foodList.Add(newFood);
            }
        }

        [TestMethod]
        public void FoodOnCellWithWormTest()
        {
            Food foodToAdd = new Food();
            foodToAdd.Pos = new Point(0, 0);

            var foodGeneratorMock = new Mock<IFoodGeneratorService>();
            foodGeneratorMock.Setup(p => p.GenerateFood(It.IsAny<List<Food>>())).Returns(foodToAdd);

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(p => p.GetService(typeof(IFoodGeneratorService))).Returns(foodGeneratorMock.Object);

            GameState gameState = new GameState();
            gameState.Worms.Add(new Worm("bob", new Point(0, 0), 30));

            WormsSimulatorService wormsSimulator = new WormsSimulatorService(serviceProviderMock.Object);
            wormsSimulator.State = gameState;
            wormsSimulator.PlaceFood();

            Assert.IsTrue(wormsSimulator.State.Food.Count.Equals(0));

            Assert.IsTrue(wormsSimulator.State.Worms.Count.Equals(1));
            Assert.IsTrue(wormsSimulator.State.Worms[0].HP == 40);
        }
    }
}
