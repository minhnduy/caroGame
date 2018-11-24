using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace caro_Project_CShape
{
    class caroChess
    {
        #region initial set-up procedure

        public bool ready;
        public int turn;
        public int gameMode;//1.computer -- 2. 2 player
        //public Pen pen;
        public chessBoard _chessBoard;
        public int check_win;
        public int chessX = 0, chessO = 0;

        public chess[,] _arrChess;
        public Stack<chess> s_Chess;    // save chess
        public Stack<chess> s_savePos;    // save chess's position
        public Stack<int> s_owned;  // save chess's own

        public caroChess()
        {
            _chessBoard = new chessBoard(25, 25);
            _arrChess = new chess[_chessBoard.Rows, _chessBoard.Columns];
            s_Chess = new Stack<chess>();
            check_win = 0;
        }

        public int resetTurn()
        {
            return turn = 1;
        }

        public void paintChessBoard(Graphics g)
        {
            _chessBoard.paintChessBoard(g);
        }

        public void initArrChess()
        {
            for (int i = 0; i < _chessBoard.Rows; i++)
            {
                for (int j = 0; j < _chessBoard.Columns; j++)
                    _arrChess[i, j] = new chess(i, j, new Point(j * chess._height, i * chess._width), 0);
            }
        }

        public void paintAgain(Graphics g)
        {
            foreach (chess c in s_Chess)
            {
                if (c.Own == 2)
                    _chessBoard.paintChessX(g, c.Pos);
                if (c.Own == 1)
                    _chessBoard.paintChessO(g, c.Pos);
            }
        }

        #endregion

        #region Play Chess

        public void painCurrent(Graphics g, int x, int y)
        {
            x = x / chess._width;
            y = y / chess._height;
            g.DrawRectangle(new Pen(Color.Green,2.0F), x * 20, y * 20, 20, 20);
        }

        public void paintChess(Graphics g)
        {
            foreach (chess c in s_Chess)
                g.DrawRectangle(new Pen(Color.LightGray, 2.0F), c.Pos.X, c.Pos.Y, 20, 20);
        }

        public bool playChess(Graphics g, int mouseX, int mouseY)
        {
            int row = mouseY / chess._width;
            int column = mouseX / chess._height;
            if (_arrChess[row, column].Own != 0)
                return false;           
            switch (turn)
            {
                case 1:
                    _arrChess[row, column].Own = 1;
                    _chessBoard.paintChessO(g, _arrChess[row, column].Pos);
                    chessO += 1;
                    turn = 2;
                    break;
                case 2:
                    _arrChess[row, column].Own = 2;
                    _chessBoard.paintChessX(g, _arrChess[row, column].Pos);
                    chessX += 1;
                    turn = 1;
                    break;
                default:
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK);
                    break;
            }
            painCurrent(g, mouseX, mouseY);
            s_Chess.Push(_arrChess[row, column]);
            return true;
        }

        #endregion

        #region undo 

        public void undo(Graphics g)
        {
            if (s_Chess.Count > 1)
            {
                if (gameMode == 1) //gameMode = 1 vsComputer
                {
                    ready = true;
                    chess c = s_Chess.Pop();
                    chess c1 = s_Chess.Pop();
                    int owned = _arrChess[c1.Row, c1.Column].Own;
                    s_owned.Push(owned);
                    turn = 2;
                    _arrChess[c.Row, c.Column].Own = 0;
                    _arrChess[c1.Row, c1.Column].Own = 0;
                    _chessBoard.paintChessBoard(g);
                    s_savePos.Push(c);
                    chessO--;
                    chessX--;
                }
                else //gameMode = 2  2 player
                {
                    ready = true;
                    chess c = s_Chess.Pop();
                    int owned = _arrChess[c.Row, c.Column].Own;
                    s_owned.Push(owned);
                    if (s_owned.Pop() == 2)
                    {
                        turn = 2;
                        chessX--;
                    }
                    else
                    {
                        turn = 1;
                        chessO--;
                    }
                    _arrChess[c.Row, c.Column].Own = 0;
                    _chessBoard.paintChessBoard(g);
                    s_savePos.Push(c);
                }
            }
        }
        #endregion

        #region endGame processing

        public void paintLineWin(Graphics g, int x1, int y1, int x2, int y2)
        {
            paintChess(g);
            g.DrawLine(new Pen(Color.Green, 3.0F), x1, y1, x2, y2);
        }

        public void endGame()
        {
            ready = false;
            if (gameMode == 1)
                switch (check_win)
                {
                    case 3:
                        MessageBox.Show("HOÀ!!", "Kết quả trò chơi",  MessageBoxButtons.OK);
                        break;
                    case 1:
                        MessageBox.Show("Bạn Thua rồi!!", "Kết quả trò chơi", MessageBoxButtons.OK);
                        break;
                    case 2:
                        MessageBox.Show("Bạn là người chiến thắng!!", "Kết quả trò chơi", MessageBoxButtons.OK);
                        break;
                }
            else
                switch (check_win)
                {
                    case 3:
                        MessageBox.Show("HOÀ!!", "Kết quả trò chơi", MessageBoxButtons.OK);
                        break;
                    case 1:
                        MessageBox.Show("Người chơi cờ O thắng!!", "Kết quả trò chơi", MessageBoxButtons.OK);
                        break;
                    case 2:
                        MessageBox.Show("Người chơi cờ X thắng!!", "Kết quả trò chơi", MessageBoxButtons.OK);
                        break;
                }
        }

        public bool checkWin(Graphics g)
        {
            if (s_Chess.Count == _chessBoard.Rows * _chessBoard.Columns)
            {
                ready = false;
                check_win = 3;
                return true;
            }
            else
            {
                foreach (chess c in s_Chess)
                {
                    if (checkColumn(c.Row, c.Column, c.Own))
                    {
                        check_win = c.Own == 1 ? 1 : 2;
                        paintLineWin(g, c.Column * chess._height + chess._height / 2, c.Row * chess._width + chess._width / 2, c.Column * chess._width + chess._width / 2, (c.Row + 5) * chess._height - chess._height / 2);
                        return true;
                    }
                    if (checkRow(c.Row, c.Column, c.Own))
                    {
                        check_win = c.Own == 1 ? 1 : 2;
                        paintLineWin(g, c.Column * chess._height + chess._height / 2, c.Row * chess._width + chess._width / 2, (c.Column+5) * chess._width - chess._width / 2, c.Row  * chess._height + chess._height / 2);
                        return true;
                    }
                    if (checkDiagonal_1(c.Row, c.Column, c.Own))
                    {
                        check_win = c.Own == 1 ? 1 : 2;
                        paintLineWin(g, c.Column * chess._height + chess._height / 2, c.Row * chess._width + chess._width / 2, (c.Column + 5) * chess._width - chess._width / 2, (c.Row + 5) * chess._height - chess._height / 2);
                        return true;
                    }
                    if (checkDiagonal_2(c.Row, c.Column, c.Own))
                    {
                        check_win = c.Own == 1 ? 1 : 2;
                        paintLineWin(g, c.Column * chess._height + chess._height / 2, c.Row * chess._width + chess._width / 2, (c.Column + 4) * chess._width + chess._width / 2, (c.Row - 4) * chess._height + chess._height / 2);
                        return true;
                    }
                }
            }
            return false;
        }

        // check column
        public bool checkColumn(int r_current, int c_current, int o_current)
        {
            if (r_current > _chessBoard.Rows - 5)
                return false;
            int temp_count;
            for (temp_count = 1; temp_count < 5; temp_count++)
                if (_arrChess[r_current + temp_count, c_current].Own != o_current)
                    return false;
            return true;
        }

        //check row
        public bool checkRow(int r_current, int c_current, int o_current)
        {
            if (r_current > _chessBoard.Columns - 5)
                return false;
            int temp_count;
            for (temp_count = 1; temp_count < 5; temp_count++)
                if (_arrChess[r_current, c_current + temp_count].Own != o_current)
                    return false;
            return true;
        }

        // check diagonal line #1
        public bool checkDiagonal_1(int r_current, int c_current, int o_current)
        {
            if (r_current > _chessBoard.Rows - 5 || c_current > _chessBoard.Columns - 5)
                return false;
            int temp_count;
            for (temp_count = 1; temp_count < 5; temp_count++)
                if (_arrChess[r_current + temp_count, c_current + temp_count].Own != o_current)
                    return false;
            return true;
        }

        // check diagonal line #2
        public bool checkDiagonal_2(int r_current, int c_current, int o_current)
        {
            if (r_current < 4 || c_current > _chessBoard.Columns - 5)
                return false;
            int temp_count;
            for (temp_count = 1; temp_count < 5; temp_count++)
                if (_arrChess[r_current - temp_count, c_current + temp_count].Own != o_current)
                    return false;
            return true;
        }

        #endregion

        #region 2 Player

        public void start_2Player(Graphics g)
        {
            s_savePos = new Stack<chess>();
            s_owned = new Stack<int>();
            s_Chess = new Stack<chess>();
            ready = true;
            gameMode = 2;
            initArrChess();
            _chessBoard.paintChessBoard(g);
            chessX = 0; chessO = 0;
        }

        #endregion

        #region Computer 

        #region start_Computer
        public void start_Computer(Graphics g)
        {
            s_savePos = new Stack<chess>();
            s_owned = new Stack<int>();
            s_Chess = new Stack<chess>();
            ready = true;
            gameMode = 1;
            turn = 1;
            initArrChess();
            _chessBoard.paintChessBoard(g);
            Computer(g);
            chessX = 0; chessO = 1;
        }

        public void Computer(Graphics g)
        {
            if (s_Chess.Count == 0)
                playChess(g, _chessBoard.Rows / 2 * chess._height + 1, _chessBoard.Columns / 2 * chess._width + 1);
            else
            {
                chess c_temp = Search();
                playChess(g, c_temp.Pos.X+1, c_temp.Pos.Y+1);
            }
        }

        public chess Search()
        {
            chess c = new chess();
            long maxTotal = 0;
            for (int i = 0; i < _chessBoard.Rows; i++)
            {
                for (int j = 0; j < _chessBoard.Columns; j++)
                {
                    if (_arrChess[i, j].Own == 0)
                    {
                        long attackPoint = broAttack_Column(i, j) + broAttack_Row(i, j) + broAttackDiagonal_1(i, j) + broAttackDiagonal_2(i, j);
                        long defensePoint = broDefenseRow(i, j) + broDefenseColumn(i, j) + broDefenseDiagonal_1(i, j) + broDefenseDiagonal_2(i, j);
                        long tempPoint = attackPoint > defensePoint ? attackPoint : defensePoint;
                        long totalPoint = (defensePoint + attackPoint) > tempPoint ? (defensePoint + attackPoint) : tempPoint;
                        if (maxTotal < totalPoint)
                        {
                            maxTotal = totalPoint;
                            c = new chess(_arrChess[i, j].Row, _arrChess[i, j].Column, _arrChess[i, j].Pos, _arrChess[i, j].Own);
                        }
                    }
                }
            }
            return c;
        }

        #endregion

        #region AI

        //attack point arr
        private long[] arrAttack = new long[6] { 0, 64, 4096, 262144, 16777216, 1073741824 };
        //defense point arr
        private long[] arrDefense = new long[6] { 0, 8, 512, 32768, 2097152, 134217728 };

        #region Attack point
        //column
        private long broAttack_Column(int r_current,int c_current)
        {
            long total = 0;
            int chessCom = 0;
            int chessPlayer = 0;
            int chessCom1 = 0;
            int chessPlayer1 = 0;
            int count;
            int count2 = 0;

            //
            for (count = 1; count < 5 && r_current + count < _chessBoard.Rows; count++)
            {
                if (_arrChess[r_current + count, c_current].Own == 1)
                {
                    chessCom++;
                }
                else if (_arrChess[r_current + count, c_current].Own == 2)
                {
                    chessPlayer++;
                    break;
                }
                else // Own = 0
                {
                    for (count2 = 2; count2 < 6 && r_current + count2 < _chessBoard.Rows; count2++)
                        if (_arrChess[r_current + count2, c_current].Own == 1)
                        {
                            chessCom1++;
                        }
                        else if (_arrChess[r_current + count2, c_current].Own == 2)
                        {
                            chessPlayer1++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            for (count = 1; count < 5 && r_current - count >= 0; count++)
            {
                if (_arrChess[r_current - count, c_current].Own == 1)
                {
                    chessCom++;
                }
                else if (_arrChess[r_current - count, c_current].Own == 2)
                {
                    chessPlayer++;
                    break;
                }
                else // Own = 0
                {
                    for (count2 = 2; count2 < 6 && r_current - count2 >= 0; count2++)
                        if (_arrChess[r_current - count2, c_current].Own == 1)
                        {
                            chessCom1++;
                        }
                        else if (_arrChess[r_current - count2, c_current].Own == 2)
                        {
                            chessPlayer1++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            if (chessPlayer == 2)
                return 0;
            if (chessPlayer == 0)
                total += arrAttack[chessCom] * 2;
            else
                total += arrAttack[chessCom];
            if (chessPlayer1 == 0)
                total += arrAttack[chessCom1] * 2;
            else
                total += arrAttack[chessCom1];
            if (chessCom >= chessCom1)
                total -= 1;
            else
                total -= 2;
            if (chessCom == 4)
                total *= 2;
            if (chessCom == 0)
                total += arrDefense[chessPlayer] * 2;
            else
                total += arrDefense[chessPlayer];
            if (chessCom1 == 0)
                total += arrDefense[chessPlayer1] * 2;
            else
                total += arrDefense[chessPlayer1];
            return total;
        }

        //Row
        private long broAttack_Row(int r_current,int c_current)
        {
            long total = 0;
            int chessCom = 0;
            int chessPlayer = 0;
            int chessCom1 = 0;
            int chessPlayer1 = 0;
            //
            for (int count = 1; count < 5 && c_current + count < _chessBoard.Columns; count++)
            {
                if (_arrChess[r_current, c_current + count].Own == 1)
                {
                    chessCom++;
                }
                else if (_arrChess[r_current, c_current + count].Own == 2)
                {
                    chessPlayer++;
                    break;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && c_current + count2 < _chessBoard.Columns; count2++)
                        if (_arrChess[r_current, c_current + count2].Own == 1)
                        {
                            chessCom1++;
                        }
                        else if (_arrChess[r_current, c_current + count2].Own == 2)
                        {
                            chessPlayer1++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int count = 1; count < 5 && c_current - count >= 0; count++)
            {
                if (_arrChess[r_current, c_current - count].Own == 1)
                {
                    chessCom++;
                }
                else if (_arrChess[r_current, c_current - count].Own == 2)
                {
                    chessPlayer++;
                    break;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && c_current - count2 >= 0; count2++)
                        if (_arrChess[r_current, c_current - count2].Own == 1)
                        {
                            chessCom1++;
                        }
                        else if (_arrChess[r_current, c_current - count2].Own == 2)
                        {
                            chessPlayer1++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            if (chessPlayer == 2)
                return 0;
            if (chessPlayer == 0)
                total += arrAttack[chessCom] * 2;
            else
                total += arrAttack[chessCom];
            if (chessPlayer1 == 0)
                total += arrAttack[chessCom1] * 2;
            else
                total += arrAttack[chessCom1];
            if (chessCom >= chessCom1)
                total -= 1;
            else
                total -= 2;
            if (chessCom == 4)
                total *= 2;
            if (chessCom == 0)
                total += arrDefense[chessPlayer] * 2;
            else
                total += arrDefense[chessPlayer];
            if (chessCom1 == 0)
                total += arrDefense[chessPlayer1] * 2;
            else
                total += arrDefense[chessPlayer1];
            return total;
        }

        //Diagonal #1

        private long broAttackDiagonal_1(int r_current, int c_current)
        {
            long total = 0;
            int chessCom = 0;
            int chessPlayer = 0;
            int chessCom1 = 0;
            int chessPlayer1 = 0;
            if (r_current + 1 < _chessBoard.Rows && c_current + 1 < _chessBoard.Columns && _arrChess[r_current + 1, c_current + 1].Own == 0)
            {

            }
            if (r_current > 0 && c_current > 0 && _arrChess[r_current - 1, c_current - 1].Own == 0)
            {

            }
            //
            for (int count = 1; count < 5 && c_current + count < _chessBoard.Columns && r_current + count < _chessBoard.Rows; count++)
            {
                if (_arrChess[r_current + count, c_current + count].Own == 1)
                {
                    chessCom++;
                }
                else if (_arrChess[r_current + count, c_current + count].Own == 2)
                {
                    chessPlayer++;
                    break;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && c_current + count2 < _chessBoard.Columns && r_current + count2 < _chessBoard.Rows; count2++)
                        if (_arrChess[r_current + count2, c_current + count2].Own == 1)
                        {
                            chessCom1++;
                        }
                        else if (_arrChess[r_current + count2, c_current + count2].Own == 2)
                        {
                            chessPlayer1++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int count = 1; count < 5 && c_current - count >= 0 && r_current - count >= 0; count++)
            {
                if (_arrChess[r_current - count, c_current - count].Own == 1)
                {
                    chessCom++;
                }
                else if (_arrChess[r_current - count, c_current - count].Own == 2)
                {
                    chessPlayer++;
                    break;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && c_current - count2 >= 0 && r_current - count2 >= 0; count2++)
                        if (_arrChess[r_current - count2, c_current - count2].Own == 1)
                        {
                            chessCom1++;
                        }
                        else if (_arrChess[r_current - count2, c_current - count2].Own == 2)
                        {
                            chessPlayer1++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            if (chessPlayer == 2)
                return 0;
            if (chessPlayer == 0)
                total += arrAttack[chessCom] * 2;
            else
                total += arrAttack[chessCom];
            if (chessPlayer1 == 0)
                total += arrAttack[chessCom1] * 2;
            else
                total += arrAttack[chessCom1];
            if (chessCom >= chessCom1)
                total -= 1;
            else
                total -= 2;

            if (chessCom == 4)
                total *= 2;
            if (chessCom == 0)
                total += arrDefense[chessPlayer] * 2;
            else
                total += arrDefense[chessPlayer];
            if (chessCom1 == 0)
                total += arrDefense[chessPlayer1] * 2;
            else
                total += arrDefense[chessPlayer1];
            return total;
        }

        // Diagonal #2
        private long broAttackDiagonal_2(int r_current,int c_current)
        {
            long total = 0;
            int chessCom = 0;
            int chessPlayer = 0;
            int chessCom1 = 0;
            int chessPlayer1 = 0;
            if (r_current > 0 && c_current + 1 < _chessBoard.Columns && _arrChess[r_current - 1, c_current + 1].Own == 0)
            {

            }
            if (r_current + 1 < _chessBoard.Rows && c_current > 0 && _arrChess[r_current + 1, c_current - 1].Own == 0)
            {

            }
            //
            for (int count = 1; count < 5 && c_current + count < _chessBoard.Columns && r_current - count > 0; count++)
            {
                if (_arrChess[r_current - count, c_current + count].Own == 1)
                {
                    chessCom++;
                }
                else if (_arrChess[r_current - count, c_current + count].Own == 2)
                {
                    chessPlayer++;
                    break;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && c_current + count2 < _chessBoard.Columns && r_current - count2 > 0; count2++)
                        if (_arrChess[r_current - count2, c_current + count2].Own == 1)
                        {
                            chessCom1++;
                        }
                        else if (_arrChess[r_current - count2, c_current + count2].Own == 2)
                        {
                            chessPlayer1++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int count = 1; count < 5 && c_current - count >= 0 && r_current + count < _chessBoard.Rows; count++)
            {
                if (_arrChess[r_current + count, c_current - count].Own == 1)
                {
                    chessCom++;
                }
                else if (_arrChess[r_current + count, c_current - count].Own == 2)
                {
                    chessPlayer++;
                    break;
                }
                else // Own = 0
                {
                    for (int count2 = 1; count2 < 6 && c_current - count2 >= 0 && r_current + count2 < _chessBoard.Rows; count2++)
                        if (_arrChess[r_current + count2, c_current - count2].Own == 1)
                        {
                            chessCom1++;
                        }
                        else if (_arrChess[r_current + count2, c_current - count2].Own == 2)
                        {
                            chessPlayer1++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            if (chessPlayer == 2)
                return 0;
            if (chessPlayer == 0)
                total += arrAttack[chessCom] * 2;
            else
                total += arrAttack[chessCom];
            if (chessPlayer1 == 0)
                total += arrAttack[chessCom1] * 2;
            else
                total += arrAttack[chessCom1];
            if (chessCom >= chessCom1)
                total -= 1;
            else
                total -= 2;
            if (chessCom == 4)
                total *= 2;
            if (chessCom == 0)
                total += arrDefense[chessPlayer] * 2;
            else
                total += arrDefense[chessPlayer];
            if (chessCom1 == 0)
                total += arrDefense[chessPlayer1] * 2;
            else
                total += arrDefense[chessPlayer1];
            return total;
        }

        #endregion

        #region Defense Point

        // Column
        private long broDefenseColumn(int r_current, int c_current)
        {
            long total = 0;
            int chessCom = 0;
            int chessPlayer = 0;
            int chessCom1 = 0;
            int chessPlayer1 = 0;
            for (int count = 1; count < 5 && r_current + count < _chessBoard.Rows; count++)
            {
                if (_arrChess[r_current + count, c_current].Own == 1)
                {
                    chessCom++;
                    break;
                }
                else if (_arrChess[r_current + count, c_current].Own == 2)
                {
                    chessPlayer++;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && r_current + count2 < _chessBoard.Rows; count2++)
                        if (_arrChess[r_current + count, c_current].Own == 1)
                        {
                            chessCom1++;
                            break;
                        }
                        else if (_arrChess[r_current + count, c_current].Own == 2)
                        {
                            chessPlayer1++;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int count = 1; count < 5 && r_current - count >= 0; count++)
            {
                if (_arrChess[r_current - count, c_current].Own == 1)
                {
                    chessCom++;
                    break;
                }
                else if (_arrChess[r_current - count, c_current].Own == 2)
                {
                    chessPlayer++;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && r_current - count2 >= 0; count2++)
                        if (_arrChess[r_current - count2, c_current].Own == 1)
                        {
                            chessCom1++;
                            break;
                        }
                        else if (_arrChess[r_current - count2, c_current].Own == 2)
                        {
                            chessPlayer1++;
                        }
                        else
                            break;
                    break;
                }
            }
            if (chessCom == 2)
                return 0;
            if (chessCom == 0)
                total += arrDefense[chessPlayer] * 2;
            else
                total += arrDefense[chessPlayer];
            /* 
            if (chessCom1 == 0)
                total += arrDefense[chessPlayer1] * 2;
            else
                total += arrDefense[chessPlayer1];
            */
            if (chessPlayer >= chessPlayer1)
                total -= 1;
            else
                total -= 2;
            if (chessPlayer == 4)
                total *= 2;
            return total;
        }
        // Row
        private long broDefenseRow(int r_current, int c_current)
        {
            long total = 0;
            int chessCom = 0;
            int chessPlayer = 0;
            int chessCom1 = 0;
            int chessPlayer1 = 0;
            for (int count = 1; count < 5 && c_current + count < _chessBoard.Columns; count++)
            {
                if (_arrChess[r_current, c_current + count].Own == 1)
                {
                    chessCom++;
                    break;
                }
                else if (_arrChess[r_current, c_current + count].Own == 2)
                {
                    chessPlayer++;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && c_current + count2 < _chessBoard.Columns; count2++)
                        if (_arrChess[r_current, c_current + count2].Own == 1)
                        {
                            chessCom1++;
                            break;
                        }
                        else if (_arrChess[r_current, c_current + count2].Own == 2)
                        {
                            chessPlayer1++;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int count = 1; count < 5 && c_current - count >= 0; count++)
            {
                if (_arrChess[r_current, c_current - count].Own == 1)
                {
                    chessCom++;
                    break;
                }
                else if (_arrChess[r_current, c_current - count].Own == 2)
                {
                    chessPlayer++;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && c_current - count2 >= 0; count2++)
                        if (_arrChess[r_current, c_current - count2].Own == 1)
                        {
                            chessCom1++;
                            break;
                        }
                        else if (_arrChess[r_current, c_current - count2].Own == 2)
                        {
                            chessPlayer1++;
                        }
                        else break;
                    break;
                }
            }
            if (chessCom == 2)
                return 0;
            if (chessCom == 0)
                total += arrDefense[chessPlayer] * 2;
            else
                total += arrDefense[chessPlayer];
            /* 
            if (chessCom1 == 0)
                total += arrDefense[chessPlayer1] * 2;
            else
                total += arrDefense[chessPlayer1];
            */
            if (chessPlayer >= chessPlayer1)
                total -= 1;
            else
                total -= 2;
            if (chessPlayer == 4)
                total *= 2;
            return total;
        }
        // Diagonal #1
        private long broDefenseDiagonal_1(int r_current, int c_current)
        {
            long total = 0;
            int chessCom = 0;
            int chessPlayer = 0;
            int chessCom1 = 0;
            int chessPlayer1 = 0;
            for (int count = 1; count < 5 && c_current + count < _chessBoard.Columns && r_current + count < _chessBoard.Rows; count++)
            {
                if (_arrChess[r_current + count, c_current + count].Own == 1)
                {
                    chessCom++;
                    break;
                }
                else if (_arrChess[r_current + count, c_current + count].Own == 2)
                {
                    chessPlayer++;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && r_current + count2 < _chessBoard.Rows && c_current + count2 < _chessBoard.Columns; count2++)
                        if (_arrChess[r_current + count2, c_current + count2].Own == 1)
                        {
                            chessCom1++;
                            break;
                        }
                        else if (_arrChess[r_current + count2, c_current + count2].Own == 2)
                        {
                            chessPlayer1++;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int count = 1; count < 5 && c_current - count >= 0 && r_current - count >= 0; count++)
            {
                if (_arrChess[r_current - count, c_current - count].Own == 1)
                {
                    chessCom++;
                    break;
                }
                else if (_arrChess[r_current - count, c_current - count].Own == 2)
                {
                    chessPlayer++;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && c_current - count2 >= 0 && r_current - count2 >= 0; count2++)
                        if (_arrChess[r_current - count2, c_current - count2].Own == 1)
                        {
                            chessCom1++;
                            break;
                        }
                        else if (_arrChess[r_current - count2, c_current - count2].Own == 2)
                        {
                            chessPlayer1++;
                        }
                        else
                            break;
                    break;
                }
            }
            if (chessCom == 2)
                return 0;
            if (chessCom == 0)
                total += arrDefense[chessPlayer] * 2;
            else
                total += arrDefense[chessPlayer];
            /* 
            if (chessCom1 == 0)
                total += arrDefense[chessPlayer1] * 2;
            else
                total += arrDefense[chessPlayer1];
            */
            if (chessPlayer >= chessPlayer1)
                total -= 1;
            else
                total -= 2;
            if (chessPlayer == 4)
                total *= 2;
            return total;
        }
        // Diagonal #2
        private long broDefenseDiagonal_2(int r_current, int c_current)
        {
            long total = 0;
            int chessCom = 0;
            int chessPlayer = 0;
            int chessCom1 = 0;
            int chessPlayer1 = 0;
            for (int count = 1; count < 5 && c_current + count < _chessBoard.Columns && r_current - count > 0; count++)
            {
                if (_arrChess[r_current - count, c_current + count].Own == 1)
                {
                    chessCom++;
                    break;
                }
                else if (_arrChess[r_current - count, c_current + count].Own == 2)
                {
                    chessPlayer++;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && r_current - count2 >= 0 && c_current + count2 < _chessBoard.Columns; count2++)
                        if (_arrChess[r_current - count2, c_current + count2].Own == 1)
                        {
                            chessCom1++;
                            break;
                        }
                        else if (_arrChess[r_current - count2, c_current + count2].Own == 2)
                        {
                            chessPlayer1++;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int count = 1; count < 5 && c_current - count >= 0 && r_current + count < _chessBoard.Rows; count++)
            {
                if (_arrChess[r_current + count, c_current - count].Own == 1)
                {
                    chessCom++;
                    break;
                }
                else if (_arrChess[r_current + count, c_current - count].Own == 2)
                {
                    chessPlayer++;
                }
                else // Own = 0
                {
                    for (int count2 = 2; count2 < 6 && r_current + count2 < _chessBoard.Rows && c_current - count2 >= 0; count2++)
                        if (_arrChess[r_current + count2, c_current - count2].Own == 1)
                        {
                            chessCom1++;
                            break;
                        }
                        else if (_arrChess[r_current + count2, c_current - count2].Own == 2)
                        {
                            chessPlayer1++;
                        }
                        else
                            break;
                    break;
                }
            }
            if (chessCom == 2)
                return 0;
            if (chessCom == 0)
                total += arrDefense[chessPlayer] * 2;
            else
                total += arrDefense[chessPlayer];
            /* 
            if (chessCom1 == 0)
                total += arrDefense[chessPlayer1] * 2;
            else
                total += arrDefense[chessPlayer1];
            */
            if (chessPlayer >= chessPlayer1)
                total -= 1;
            else
                total -= 2;
            if (chessPlayer == 4)
                total *= 2;
            return total;
        }


        #endregion

        #endregion

        #endregion
    }
}
