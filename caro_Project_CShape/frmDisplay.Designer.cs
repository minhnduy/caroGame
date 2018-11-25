namespace caro_Project_CShape
{
    partial class frmDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDisplay));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.pnlText = new System.Windows.Forms.Panel();
            this.lbTurn = new System.Windows.Forms.Label();
            this.lbTextHuongDan = new System.Windows.Forms.Label();
            this.pictureTitle = new System.Windows.Forms.PictureBox();
            this.lbChessO = new System.Windows.Forms.Label();
            this.lbChessX = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCom = new System.Windows.Forms.Button();
            this.btnPlayer = new System.Windows.Forms.Button();
            this.pnlCaroBoard = new System.Windows.Forms.Panel();
            this.timerCount = new System.Windows.Forms.Timer(this.components);
            this.timeText = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            this.pnlText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.AntiqueWhite;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerVsPlayerToolStripMenuItem,
            this.playerVsComputerToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // playerVsPlayerToolStripMenuItem
            // 
            this.playerVsPlayerToolStripMenuItem.Name = "playerVsPlayerToolStripMenuItem";
            this.playerVsPlayerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.playerVsPlayerToolStripMenuItem.Text = "Player vs Player";
            this.playerVsPlayerToolStripMenuItem.Click += new System.EventHandler(this.playerVsPlayerToolStripMenuItem_Click);
            // 
            // playerVsComputerToolStripMenuItem
            // 
            this.playerVsComputerToolStripMenuItem.Name = "playerVsComputerToolStripMenuItem";
            this.playerVsComputerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.playerVsComputerToolStripMenuItem.Text = "Player vs Computer";
            this.playerVsComputerToolStripMenuItem.Click += new System.EventHandler(this.playerVsComputerToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // hướngDẫnToolStripMenuItem
            // 
            this.hướngDẫnToolStripMenuItem.Name = "hướngDẫnToolStripMenuItem";
            this.hướngDẫnToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.hướngDẫnToolStripMenuItem.Text = "Hướng Dẫn";
            this.hướngDẫnToolStripMenuItem.Click += new System.EventHandler(this.hướngDẫnToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.BackColor = System.Drawing.Color.AntiqueWhite;
            this.pnlDisplay.CausesValidation = false;
            this.pnlDisplay.Controls.Add(this.pnlText);
            this.pnlDisplay.Controls.Add(this.pictureTitle);
            this.pnlDisplay.Controls.Add(this.lbChessO);
            this.pnlDisplay.Controls.Add(this.lbChessX);
            this.pnlDisplay.Controls.Add(this.lbTime);
            this.pnlDisplay.Controls.Add(this.btnExit);
            this.pnlDisplay.Controls.Add(this.btnCom);
            this.pnlDisplay.Controls.Add(this.btnPlayer);
            this.pnlDisplay.Controls.Add(this.pnlCaroBoard);
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(0, 24);
            this.pnlDisplay.MaximumSize = new System.Drawing.Size(784, 570);
            this.pnlDisplay.MinimumSize = new System.Drawing.Size(784, 570);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(784, 570);
            this.pnlDisplay.TabIndex = 1;
            // 
            // pnlText
            // 
            this.pnlText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlText.Controls.Add(this.lbTurn);
            this.pnlText.Controls.Add(this.lbTextHuongDan);
            this.pnlText.Location = new System.Drawing.Point(550, 250);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(215, 178);
            this.pnlText.TabIndex = 5;
            // 
            // lbTurn
            // 
            this.lbTurn.AutoSize = true;
            this.lbTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurn.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lbTurn.Location = new System.Drawing.Point(18, 158);
            this.lbTurn.Name = "lbTurn";
            this.lbTurn.Size = new System.Drawing.Size(0, 17);
            this.lbTurn.TabIndex = 1;
            // 
            // lbTextHuongDan
            // 
            this.lbTextHuongDan.AutoSize = true;
            this.lbTextHuongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTextHuongDan.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lbTextHuongDan.Location = new System.Drawing.Point(13, 156);
            this.lbTextHuongDan.Name = "lbTextHuongDan";
            this.lbTextHuongDan.Size = new System.Drawing.Size(0, 17);
            this.lbTextHuongDan.TabIndex = 0;
            // 
            // pictureTitle
            // 
            this.pictureTitle.Image = ((System.Drawing.Image)(resources.GetObject("pictureTitle.Image")));
            this.pictureTitle.Location = new System.Drawing.Point(550, 30);
            this.pictureTitle.Name = "pictureTitle";
            this.pictureTitle.Size = new System.Drawing.Size(215, 215);
            this.pictureTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureTitle.TabIndex = 0;
            this.pictureTitle.TabStop = false;
            // 
            // lbChessO
            // 
            this.lbChessO.Font = new System.Drawing.Font("iCiel Cucho Bold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChessO.Location = new System.Drawing.Point(427, 537);
            this.lbChessO.Name = "lbChessO";
            this.lbChessO.Size = new System.Drawing.Size(100, 23);
            this.lbChessO.TabIndex = 4;
            this.lbChessO.Text = "Chess O: 0";
            // 
            // lbChessX
            // 
            this.lbChessX.Font = new System.Drawing.Font("iCiel Cucho Bold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChessX.Location = new System.Drawing.Point(272, 537);
            this.lbChessX.Name = "lbChessX";
            this.lbChessX.Size = new System.Drawing.Size(100, 23);
            this.lbChessX.TabIndex = 4;
            this.lbChessX.Text = "Chess X: 0";
            // 
            // lbTime
            // 
            this.lbTime.Font = new System.Drawing.Font("iCiel Cucho Bold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(49, 537);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(100, 23);
            this.lbTime.TabIndex = 4;
            this.lbTime.Text = "Time:  30s";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.CheckedBackColor = System.Drawing.Color.AntiqueWhite;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AntiqueWhite;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("iCiel Cucho Bold", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)), true);
            this.btnExit.Location = new System.Drawing.Point(550, 501);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(215, 30);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCom
            // 
            this.btnCom.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnCom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCom.FlatAppearance.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.btnCom.FlatAppearance.BorderSize = 0;
            this.btnCom.FlatAppearance.CheckedBackColor = System.Drawing.Color.AntiqueWhite;
            this.btnCom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.btnCom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AntiqueWhite;
            this.btnCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCom.Font = new System.Drawing.Font("iCiel Cucho Bold", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)), true);
            this.btnCom.Location = new System.Drawing.Point(550, 464);
            this.btnCom.Name = "btnCom";
            this.btnCom.Size = new System.Drawing.Size(215, 30);
            this.btnCom.TabIndex = 3;
            this.btnCom.Text = "Player vs Computer";
            this.btnCom.UseVisualStyleBackColor = true;
            this.btnCom.Click += new System.EventHandler(this.btnCom_Click);
            // 
            // btnPlayer
            // 
            this.btnPlayer.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayer.FlatAppearance.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.btnPlayer.FlatAppearance.BorderSize = 0;
            this.btnPlayer.FlatAppearance.CheckedBackColor = System.Drawing.Color.AntiqueWhite;
            this.btnPlayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.btnPlayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AntiqueWhite;
            this.btnPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer.Font = new System.Drawing.Font("iCiel Cucho Bold", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)), true);
            this.btnPlayer.Location = new System.Drawing.Point(550, 427);
            this.btnPlayer.Name = "btnPlayer";
            this.btnPlayer.Size = new System.Drawing.Size(215, 30);
            this.btnPlayer.TabIndex = 3;
            this.btnPlayer.Text = "Player vs Player";
            this.btnPlayer.UseVisualStyleBackColor = true;
            this.btnPlayer.Click += new System.EventHandler(this.btnPlayer_Click);
            // 
            // pnlCaroBoard
            // 
            this.pnlCaroBoard.BackColor = System.Drawing.Color.FloralWhite;
            this.pnlCaroBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCaroBoard.Location = new System.Drawing.Point(30, 30);
            this.pnlCaroBoard.Name = "pnlCaroBoard";
            this.pnlCaroBoard.Size = new System.Drawing.Size(500, 500);
            this.pnlCaroBoard.TabIndex = 0;
            this.pnlCaroBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCaroBoard_Paint);
            this.pnlCaroBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlCaroBoard_MouseClick);
            // 
            // timerCount
            // 
            this.timerCount.Enabled = true;
            this.timerCount.Interval = 1000;
            this.timerCount.Tick += new System.EventHandler(this.timerCount_Tick);
            // 
            // timeText
            // 
            this.timeText.Enabled = true;
            this.timeText.Interval = 25;
            this.timeText.Tick += new System.EventHandler(this.timeText_Tick);
            // 
            // frmDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 594);
            this.Controls.Add(this.pnlDisplay);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 633);
            this.MinimumSize = new System.Drawing.Size(800, 633);
            this.Name = "frmDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CARO Game Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDisplay_FormClosing);
            this.Load += new System.EventHandler(this.frmDisplay_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.pnlDisplay.ResumeLayout(false);
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.Panel pnlCaroBoard;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCom;
        private System.Windows.Forms.Button btnPlayer;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timerCount;
        private System.Windows.Forms.PictureBox pictureTitle;
        private System.Windows.Forms.Label lbChessO;
        private System.Windows.Forms.Label lbChessX;
        private System.Windows.Forms.Panel pnlText;
        private System.Windows.Forms.Label lbTextHuongDan;
        private System.Windows.Forms.Timer timeText;
        private System.Windows.Forms.Label lbTurn;
    }
}

