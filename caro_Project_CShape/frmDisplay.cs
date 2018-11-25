using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caro_Project_CShape
{
    public partial class frmDisplay : Form
    {

        #region khai báo tham số đầu vào

        private caroChess _chess;
        private Graphics g;
        private int countTime = 0;

        #endregion

        #region phương thức khởi tạo ban đầu
        public frmDisplay()
        {
            InitializeComponent();
            _chess = new caroChess();
            g = pnlCaroBoard.CreateGraphics();
            _chess.initArrChess();
        }
        private void frmDisplay_Load(object sender, EventArgs e)
        {
            Refresh();
            lbTextHuongDan.Text = "";
            lbTurn.Text = "Lượt chơi:\n    Cờ O đi trước\n    Cờ X đi sau";
        }

        #endregion

        private void pnlCaroBoard_Paint(object sender, PaintEventArgs e)
        {
            _chess.paintChessBoard(g);
            _chess.paintAgain(g);
        }

        private void pnlCaroBoard_MouseClick(object sender, MouseEventArgs e)
        {
            _chess.paintChess(g);
            if (_chess.ready == false)
                return;
            if(_chess.playChess(g,e.X,e.Y))
            {
                if (_chess.checkWin(g))
                    _chess.endGame();
                else if(_chess.gameMode==1)
                {
                    _chess.Computer(g);
                    if (_chess.checkWin(g))
                        _chess.endGame();
                }
                countTime = 0;
            }
            lbChessO.Text = "Chess O: " + _chess.chessO.ToString();
            lbChessX.Text = "Chess X: " + _chess.chessX.ToString();
        }

        #region button Click

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnPlayer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn chơi mới?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmDisplay_Load(sender, e);
                _chess.resetTurn();
                countTime = 0;
                g.Clear(pnlCaroBoard.BackColor);
                _chess.start_2Player(g);
                lbChessO.Text = "Chess O: " + _chess.chessO.ToString();
                lbChessX.Text = "Chess X: " + _chess.chessX.ToString();

            }
        }
        private void btnCom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn chơi mới?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmDisplay_Load(sender, e);
                _chess.resetTurn();
                g.Clear(pnlCaroBoard.BackColor);
                _chess.start_Computer(g);
                countTime = 0;
                lbChessO.Text = "Chess O: " + _chess.chessO.ToString();
                lbChessX.Text = "Chess X: " + _chess.chessX.ToString();
            }
        }

        #endregion

        #region toolstripmenu
        private void playerVsPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPlayer_Click(sender, e);
        }
        private void playerVsComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCom_Click(sender, e);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbTurn.Text = "";
            lbTextHuongDan.Text = "Luật chơi" +
                "\n  Trên bàn cờ 22x22 ô " +
                "\n  vuông.Một người đi X," +
                "\n  một người đi O." +
                "\n  Khi đến lượt mình," +
                "\n  người chơi phải tích" +
                "\n  vào một ô trên bàn cờ." +
                "\n  Người chơi phải tìm " +
                "\n  cách tích đủ 5 ô theo" +
                "\n  chiều dọc hoặc chiều " +
                "\n  ngang hoặc đường " +
                "\n  chéo mà không bị chặn " +
                "\n  2 đầu thì sẽ thắng hoặc " +
                "\n  5 ô và bị chặn một đầu " +
                "\n  sẽ thắng." +
                "\n  Nếu quá thời gian 30s " +
                "\n  mà người chơi không ra " +
                "\n  nước cờ coi như thua.\n\n " +
                "  Luật hòa" +
                "\n + Trong quá trình chơi, " +
                "\n    khi một chời chơi " +
                "\n    xin hòa và đối phương  " +
                "\n    đồng Ý" +
                "\n + Khi đã đi hết bàn cờ mà " +
                "\n    chưa phân thắng bại " +
                "\n    thì cũng coi như hòa.";
        }
        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            countTime = 0;
            g.Clear(pnlCaroBoard.BackColor);
            _chess.undo(g);
            _chess.paintAgain(g);
            lbChessO.Text = "Chess O: " + _chess.chessO.ToString();
            lbChessX.Text = "Chess X: " + _chess.chessX.ToString();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game CaroChess\n Ngôn Ngữ Lập Trình C#\n Nguyễn Duy Minh\n 16521735", "About CaroGame", MessageBoxButtons.OK);
        }
        #endregion

        private void frmDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void timerCount_Tick(object sender, EventArgs e)
        {
            if (_chess.ready == true)
            {
                lbTime.Text = "Time: " + (30 - countTime).ToString() + "s";
                if (countTime == 30)
                {
                    _chess.ready = false;
                    if (_chess.turn == 1)
                        MessageBox.Show("Time Out cờ O thua ", "Kết Quả Trò Chơi", MessageBoxButtons.OK);
                    else
                        MessageBox.Show("Time Out cờ X thua", "Kết Quả Trò Chơi", MessageBoxButtons.OK);
                }
                countTime = countTime + 1;
            }
        }


        private void timeText_Tick(object sender, EventArgs e)
        {
            lbTurn.Location = new Point(lbTurn.Location.X, lbTurn.Location.Y - 1);
            lbTextHuongDan.Location= new Point(lbTextHuongDan.Location.X, lbTextHuongDan.Location.Y - 1);
            if (lbTurn.Location.Y+lbTurn.Height<0)
            {
                lbTurn.Location = new Point(lbTurn.Location.X, pnlText.Height);
            }
            if (lbTextHuongDan.Location.Y + lbTextHuongDan.Height < 0)
            {
                lbTextHuongDan.Location = new Point(lbTextHuongDan.Location.X, pnlText.Height);
            }
        }

    }
}
