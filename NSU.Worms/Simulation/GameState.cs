using System;
using System.Collections.Generic;
using NSU.Worms.Entities.Worm;

namespace NSU.Worms.Simulation
{
    public class GameState
    {
        public List<AbstactWorm> Worms { get; set; }
        public GameState()
        {
            Worms = new List<AbstactWorm>();
        }
        public override string ToString()
        {
            string wormsStr = string.Join(',', Worms);
            return $"WormsGame:[{wormsStr}]";
        }
    }
}
