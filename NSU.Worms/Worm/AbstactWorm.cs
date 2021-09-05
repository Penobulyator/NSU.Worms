﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using NSU.Worms.Directions;
namespace NSU.Worms.Worm
{
    abstract class AbstactWorm
    {
        public Point Pos { get; set; }
        public string Name { get; }

        public AbstactWorm(string name, Point pos) => (Name, Pos) = (name, pos);
        public AbstactWorm(string name) : this(name, new Point(0, 0)) { }

        public override string ToString()
        {
            return $"{Name}({Pos.X},{Pos.Y})";
        }
        public void Move(Direction direction)
        {
            Pos = new Point(Pos.X + direction.getX(), Pos.Y + direction.getY());
        }
        
        abstract public Direction AskToMove(GameState state);
    }
}
