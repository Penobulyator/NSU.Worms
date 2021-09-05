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

        public AbstactWorm(string name, Point pos) => (Name, Pos) = (name, pos);
        public AbstactWorm(string name) : this(name, new Point(0, 0)) { }

        public override string ToString()
        {
            return $"{Name}({Pos.X},{Pos.Y})";
        }
        public void Move(Direction direction)
        {
            int difX = 0;
            int difY = 0;
            switch (direction)
            {
                case Direction.UP:
                    difY = 1;
                    break;
                case Direction.DOWN:
                    difY = -1;
                    break;
                case Direction.RIGHT:
                    difX = 1;
                    break;
                case Direction.LEFT:
                    difX = -1;
                    break;
            }
            Pos.X += difX;
            Pos.Y += difY;
        }
        
        abstract public Direction AskToMove(GameState state);
    }
}
