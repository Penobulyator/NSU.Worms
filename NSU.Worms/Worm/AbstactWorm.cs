using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace NSU.Worms.Worm
{
    abstract class AbstactWorm
    {
        private Point Coord;
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}({Coord.X},{Coord.Y})";
        }
        abstract public Direction AskToMove(GameState state);
    }
}
