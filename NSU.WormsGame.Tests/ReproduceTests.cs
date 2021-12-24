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
    public class ReproduceTests
    {
        [TestMethod]
        public void SuccessfulReproduceTest()
        {
            var wormActionGeneratorMock = new Mock<IWormActionGeneratorService>();
            wormActionGeneratorMock.Setup(p => p.GenerateWormAction(It.IsAny<Worm>(), It.IsAny<GameState>())).Returns(new WormAction(new RightDirection(), true));

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(p => p.GetService(typeof(IWormActionGeneratorService))).Returns(wormActionGeneratorMock.Object);
            serviceProviderMock.Setup(p => p.GetService(typeof(IWormNamesGeneratorService))).Returns(new WormNamesGeneratorService());

            GameState gameState = new GameState();
            gameState.Worms.Add(new Worm("bob", new Point(0, 0), 30));

            WormsSimulatorService wormsSimulator = new WormsSimulatorService(serviceProviderMock.Object);
            wormsSimulator.State = gameState;
            wormsSimulator.PerformWormsActions();

            Assert.IsTrue(wormsSimulator.State.Worms.Count.Equals(2));

            Assert.IsTrue(wormsSimulator.State.Worms[0].Pos.Equals(new Point(0, 0)));
            Assert.IsTrue(wormsSimulator.State.Worms[0].HP.Equals(20));

            Assert.IsTrue(wormsSimulator.State.Worms[1].Pos.Equals(new Point(1, 0)));
            Assert.IsTrue(wormsSimulator.State.Worms[1].HP.Equals(10));
        }

        [TestMethod]
        public void FailedReproduceTest()
        {

            var wormActionGeneratorMock = new Mock<IWormActionGeneratorService>();
            wormActionGeneratorMock.Setup(p => p.GenerateWormAction(It.IsAny<Worm>(), It.IsAny<GameState>())).Returns(new WormAction(new RightDirection(), true));

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(p => p.GetService(typeof(IWormActionGeneratorService))).Returns(wormActionGeneratorMock.Object);
            serviceProviderMock.Setup(p => p.GetService(typeof(IWormNamesGeneratorService))).Returns(new WormNamesGeneratorService());

            Food food = new Food();
            food.Pos = new Point(1, 0);

            GameState gameState = new GameState();
            gameState.Worms.Add(new Worm("bob", new Point(0, 0), 30));
            gameState.Food.Add(food);

            WormsSimulatorService wormsSimulator = new WormsSimulatorService(serviceProviderMock.Object);
            wormsSimulator.State = gameState;
            wormsSimulator.PerformWormsActions();

            Assert.IsTrue(wormsSimulator.State.Worms.Count.Equals(1));

            Assert.IsTrue(wormsSimulator.State.Worms[0].Pos.Equals(new Point(0, 0)));
            Assert.IsTrue(wormsSimulator.State.Worms[0].HP.Equals(30));

        }
    }
}
