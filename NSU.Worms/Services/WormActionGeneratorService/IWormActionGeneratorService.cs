using System;
using System.Collections.Generic;
using System.Text;
using NSU.WormsGame.Entities;
using NSU.WormsGame.Entities.Directions;
using NSU.WormsGame.Simulation;
using System.Drawing;

namespace NSU.WormsGame.Services.WormActionGeneratorService
{
    public interface IWormActionGeneratorService
    {
        public WormAction GenerateWormAction(Worm worm, GameState gameState);
    }
}
