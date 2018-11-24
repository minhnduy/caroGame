using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caro_Project_CShape
{
    class chessBoard
    {
        private int _rows;
        private int _columns;

        public chessBoard(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
        }

        public int Rows { get => _rows; set => _rows = value; }
        public int Columns { get => _columns; set => _columns = value; }

        public void paintChessBoard(Graphics g)
        {
            Pen pen = new Pen(Color.LightGray, 2.0F);
            for (int i = 0; i < Rows; i++)
                g.DrawLine(pen, i * chess._width, 0, i * chess._width, chess._height * Rows);
            for (int i = 0; i < Rows; i++)
                g.DrawLine(pen,0, i * chess._height,chess._width * Columns,i*chess._height);
        }

        public void paintChessX(Graphics g,Point point)
        {
            Pen penblue;
            penblue = new Pen(Color.Blue);
            penblue.Width = 2.5F;
            g.DrawLine(penblue, point.X + 3, point.Y + 3, point.X + 17, point.Y + 17);
            g.DrawLine(penblue, point.X + 3, point.Y + 17, point.X + 17, point.Y + 3);
        }

        public void paintChessO(Graphics g,Point point)
        {
            Pen penred;
            penred = new Pen(Color.Red);
            penred.Width = 2.5F;
            g.DrawEllipse(penred, point.X + 3, point.Y + 3, 14, 14);
        }
    }
}
