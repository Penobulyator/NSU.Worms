using NSU.WormsGame.Simulation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSU.WormsGame.Services
{
    public interface IGameStateWriterService
    {
        public void WriteState(GameState state);
    }
    internal class GameStateWriterService : IGameStateWriterService
    {
        public void WriteState(GameState state)
        {
            Console.WriteLine(state.ToString());
        }
    }
}
