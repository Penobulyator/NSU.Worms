using System;
using System.Collections.Generic;
using System.Text;
using NSU.Worms.Worm;
using System.Linq;
namespace NSU.Worms
{
    class GameState
    {
        public List<AbstactWorm> Worms { get; }
        public GameState()
        {
            Worms = new List<AbstactWorm>();
        }
        public override string ToString()
        {
            string wormsStr = String.Join(',', Worms);
            return $"Worms:[{wormsStr}]";
        }
    }
}
