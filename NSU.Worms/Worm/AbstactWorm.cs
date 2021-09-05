using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace NSU.Worms.Worm
{
    abstract class AbstactWorm
    {
        protected Point Pos;
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}({Pos.X},{Pos.Y})";
        }
        abstract public Direction AskToMove(GameState state);
    }
}
