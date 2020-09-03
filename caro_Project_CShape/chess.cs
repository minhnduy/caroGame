using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace caro_Project_CShape
{
    class chess
    {
        public const int _height = 20;
        public const int _width = 20;
        private int _row;
        private int _column;
        private Point _pos;
        private int _own;

        public chess(int row, int column,Point pos,int own)
        {
            _row = row;
            _column = column;
            _pos = pos;
            _own = own;
        }
        public chess()
        {
        }

        public int Row { get => _row; set => _row = value; }
        public int Column { get => _column; set => _column = value; }
        public Point Pos { get => _pos; set => _pos = value; }
        public int Own { get => _own; set => _own = value; }
        //test pull
    }
}
