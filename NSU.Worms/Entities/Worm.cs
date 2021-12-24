using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using NSU.WormsGame.Entities.Directions;

namespace NSU.WormsGame.Entities
{
    public class Worm : ICloneable
    {
        public Point Pos { get; set; }
        public string Name { get; set; }

        public int HP { get; set; }

        public Worm(string name, Point pos, int hp) => (Name, Pos, HP) = (name, pos, hp);

        public override string ToString()
        {
            return $"{Name}-{HP}({Pos.X},{Pos.Y})";
        }
        public void Move(Direction direction)
        {
            Pos = direction.getNextPoint(Pos);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}