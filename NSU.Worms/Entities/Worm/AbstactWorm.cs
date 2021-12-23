﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using NSU.WormsGame.Simulation;
using NSU.WormsGame.Entities.Directions;

namespace NSU.WormsGame.Entities.Worm
{
    public abstract class AbstactWorm : ICloneable
    {
        public Point Pos { get; set; }
        public string Name { get; set; }

        public int HP { get; set; }

        public AbstactWorm(string name, Point pos, int hp) => (Name, Pos, HP) = (name, pos, hp);

        public override string ToString()
        {
            return $"{Name}({Pos.X},{Pos.Y})";
        }
        public void Move(Direction direction)
        {
            Pos = direction.getNextPoint(Pos);
        }

        abstract public WormAction AskToMove(GameState state);

        public object Clone()
        {
            return this;
        }
    }
}