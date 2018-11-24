﻿using System;
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
            frmDisplay_Load(sender, e);
            _chess.resetTurn();
            countTime = 0;
            g.Clear(pnlCaroBoard.BackColor);
            _chess.start_2Player(g);
            lbChessO.Text = "Chess O: " + _chess.chessO.ToString();
            lbChessX.Text = "Chess X: " + _chess.chessX.ToString();

        }
        private void btnCom_Click(object sender, EventArgs e)
        {
            frmDisplay_Load(sender, e);
            _chess.resetTurn();
            g.Clear(pnlCaroBoard.BackColor);
            _chess.start_Computer(g);
            countTime = 0;
                        lbChessO.Text = "Chess O: " + _chess.chessO.ToString();
            lbChessX.Text = "Chess X: " + _chess.chessX.ToString();

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
            rtText.Text = "Luật chơi\nTrên bàn cờ 22x22 ô vuông.Một người đi X," +
                " một người đi O.\nKhi đến lượt mình, người chơi phải tích vào một ô trên bàn cờ." +
                "Người chơi phải tìm cách tích đủ 5 ô theo chiều dọc hoặc chiều ngang hoặc đường " +
                "chéo mà không bị chặn 2 đầu thì sẽ thắng hoặc 5 ô và bị chặn một đầu sẽ thắng." +
                "Nếu quá thời gian 30s mà người chơi không ra nước cờ coi như thua.\n\n " +
                "    Luật hòa\n + Trong quá trình chơi, khi một chời chơi xin hòa và đối phương đồng ý." +
                "\n + Khi đã đi hết bàn cờ mà chưa phân thắng bại thì cũng coi như hòa.";
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
    }
}
