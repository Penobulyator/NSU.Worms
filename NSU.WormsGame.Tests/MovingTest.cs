using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSU.WormsGame.Entities;
using NSU.WormsGame.Entities.Directions;
using NSU.WormsGame.Services;
using NSU.WormsGame.Services.WormActionGeneratorService;
using System.Drawing;
using Moq;
using System;

namespace NSU.WormsGame.Tests
{
    [TestClass]
    public class MovingTest
    {
        [TestMethod]
        public void MoveToEmptyCellTest()
        {
            var wormActionGeneratorMock = new Mock<IWormActionGeneratorService>();
            wormActionGeneratorMock.Setup(p => p.GenerateWormAction(It.IsAny<Worm>(), It.IsAny<GameState>())).Returns(new WormAction(new RightDirection(), false));

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(p => p.GetService(typeof(IWormActionGeneratorService))).Returns(wormActionGeneratorMock.Object);

            GameState gameState = new GameState();
            gameState.Worms.Add(new Worm("bob", new Point(0, 0), 20));

            WormsSimulatorService wormsSimulator = new WormsSimulatorService(serviceProviderMock.Object);
            wormsSimulator.State = gameState;
            wormsSimulator.PerformWormsActions();

            Assert.IsTrue(wormsSimulator.State.Worms.Count.Equals(1));
            Assert.IsTrue(wormsSimulator.State.Worms[0].Pos.Equals(new Point(1, 0)));
        }

        [TestMethod]
        public void MoveToCellWithFoodTest()
        {
            var wormActionGeneratorMock = new Mock<IWormActionGeneratorService>();
            wormActionGeneratorMock.Setup(p => p.GenerateWormAction(It.IsAny<Worm>(), It.IsAny<GameState>())).Returns(new WormAction(new RightDirection(), false));

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(p => p.GetService(typeof(IWormActionGeneratorService))).Returns(wormActionGeneratorMock.Object);


            Food food = new Food();
            food.Pos = new Point(1, 0);

            GameState gameState = new GameState();
            gameState.Worms.Add(new Worm("bob", new Point(0, 0), 20));
            gameState.Food.Add(food);

            WormsSimulatorService wormsSimulator = new WormsSimulatorService(serviceProviderMock.Object);
            wormsSimulator.State = gameState;
            wormsSimulator.PerformWormsActions();

            Assert.IsTrue(wormsSimulator.State.Worms.Count.Equals(1));
            Assert.IsTrue(wormsSimulator.State.Food.Count.Equals(0));

            Assert.IsTrue(wormsSimulator.State.Worms[0].Pos.Equals(new Point(1, 0)));
            Assert.IsTrue(wormsSimulator.State.Worms[0].HP == 30);
        }

        [TestMethod]
        public void MoveToOccupied—ellTest()
        {
            var wormActionGeneratorMock = new Mock<IWormActionGeneratorService>();
            wormActionGeneratorMock.Setup(p => p.GenerateWormAction(It.IsAny<Worm>(), It.IsAny<GameState>())).Returns(new WormAction(new RightDirection(), false));

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(p => p.GetService(typeof(IWormActionGeneratorService))).Returns(wormActionGeneratorMock.Object);

            GameState gameState = new GameState();
            gameState.Worms.Add(new Worm("bob", new Point(0, 0), 20));
            gameState.Worms.Add(new Worm("bib", new Point(1, 0), 20));

            WormsSimulatorService wormsSimulator = new WormsSimulatorService(serviceProviderMock.Object);
            wormsSimulator.State = gameState;
            wormsSimulator.PerformWormsActions();

            Assert.IsTrue(wormsSimulator.State.Worms[0].Pos.Equals(new Point(0, 0)));
        }
    }
}
