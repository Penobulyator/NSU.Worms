using System;
using System.Collections.Generic;
using System.Text;
using NSU.Worms.Worm;
using System.Linq;
namespace NSU.Worms
{
    class GameState
    {
        private Dictionary<string, AbstactWorm> Worms { get; }
        public override string ToString()
        {
            string wormsStr = String.Join(',', Worms.Values.ToList());
            return $"Worms:[{wormsStr}]";
        }
    }
}
