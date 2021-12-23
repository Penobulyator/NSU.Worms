using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NSU.WormsGame.Entities.Directions
{
    public interface Direction
    {
        public int getX();
        public int getY();

        public Point getNextPoint(Point point)
        {
            return new Point(point.X + getX(), point.Y + getY());
        }
    }
}
