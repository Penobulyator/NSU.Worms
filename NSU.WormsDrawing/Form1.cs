using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using NSU.Worms;
using NSU.Worms.Worm;
namespace NSU.WormsDrawing
{
    public partial class Worms : Form
    {
        private int CellsCount = 20;
        private int CellSize;
        public Worms()
        {
            InitializeComponent();
            Width = 1000;
            Height = 1000;
            CellSize = Width / CellsCount;
        }

        private void Worms_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Black);
            g.Clear(Color.White);
            //draw grid
            for (int y = 0; y < CellsCount; ++y)
            {
                g.DrawLine(blackPen, 0, y * CellSize, CellsCount * CellSize, y * CellSize);
            }

            for (int x = 0; x < CellsCount; ++x)
            {
                g.DrawLine(blackPen, x * CellSize, 0, x * CellSize, CellsCount * CellSize);
            }

            //draw simulation
            WormsSimulator simulator = GetSimulator();
            simulator.Run((state)=>
            {
                DrawState(state, g);
            }
            );
        }
        private int ConvertCoord(int cord)
        {
            return (cord + CellsCount / 2) * CellSize;
        }
        private void DrawState(GameState state, Graphics graphics)
        {
            Brush wormBrush = new SolidBrush(Color.Brown);
            foreach(AbstactWorm worm in state.Worms)
            {
                int x = ConvertCoord(worm.Pos.X);
                int y = ConvertCoord(worm.Pos.Y);
                graphics.FillRectangle(wormBrush, x + 1, y + 1, CellSize - 1, CellSize - 1);
            }

            Thread.Sleep(100);

            Brush whiteBrush = new SolidBrush(Color.White);
            foreach (AbstactWorm worm in state.Worms)
            {
                int x = ConvertCoord(worm.Pos.X);
                int y = ConvertCoord(worm.Pos.Y);
                graphics.FillRectangle(whiteBrush, x + 1, y + 1, CellSize - 1, CellSize - 1);
            }

        }
        private WormsSimulator GetSimulator()
        {
            GameState state = new GameState();
            state.Worms.Add(new ClockwiseMovingWorm("John"));
            return new WormsSimulator(state);
        }
    }

}
