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
    public class UniqueNamesTests
    {
        [TestMethod]
        public void UniqueNamesTest()
        {
            List<Worm> wormsList = new List<Worm>();
            IWormNamesGeneratorService wormNamesGenerator = new WormNamesGeneratorService();

            for (int i = 0; i < 100; i++)
            {
                string newWormName = wormNamesGenerator.GenerateWormName("someTestBaseName", wormsList);
                Assert.IsNull(wormsList.Find((worm) => worm.Name.Equals(newWormName)));

                wormsList.Add(new Worm(newWormName, new Point(), 0));
            }
        }
    }
}
