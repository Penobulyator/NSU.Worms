using System;
using System.Collections.Generic;
using System.Text;
using NSU.WormsGame.Worms;
using System.Linq;
namespace NSU.WormsGame
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
            string wormsStr = String.Join(',', Worms);
            return $"WormsGame:[{wormsStr}]";
        }
    }
}
