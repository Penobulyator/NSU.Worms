using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSU.WormsGame.Entities.Directions;
namespace NSU.WormsGame.Entities
{
    public class WormAction
    {
        public Direction Direction { get; set; }
        public bool Reproduce { get; set; }

        public WormAction(Direction direction, bool reproduce) => (Direction, Reproduce) = (direction, reproduce);

        public bool IsDoNothing() => Direction == null;
    }
}
