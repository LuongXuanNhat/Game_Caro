namespace Game_Caro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlChessBeard = new Panel();
            panel2 = new Panel();
            pctbAvatar = new PictureBox();
            panel3 = new Panel();
            label1 = new Label();
            btnLan = new Button();
            pctbMark = new PictureBox();
            prcbCoolDown = new ProgressBar();
            txbIP = new TextBox();
            txbPlayerName = new TextBox();
            tmCoolDown = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbAvatar).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbMark).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlChessBeard
            // 
            pnlChessBeard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlChessBeard.BackColor = SystemColors.Control;
            pnlChessBeard.Location = new Point(12, 27);
            pnlChessBeard.Name = "pnlChessBeard";
            pnlChessBeard.Size = new Size(873, 444);
            pnlChessBeard.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.Controls.Add(pctbAvatar);
            panel2.Location = new Point(12, 477);
            panel2.Name = "panel2";
            panel2.Size = new Size(114, 114);
            panel2.TabIndex = 0;
            // 
            // pctbAvatar
            // 
            pctbAvatar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pctbAvatar.BackgroundImage = Properties.Resources.xo;
            pctbAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            pctbAvatar.Location = new Point(0, 0);
            pctbAvatar.Name = "pctbAvatar";
            pctbAvatar.Size = new Size(114, 114);
            pctbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            pctbAvatar.TabIndex = 0;
            pctbAvatar.TabStop = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnLan);
            panel3.Controls.Add(pctbMark);
            panel3.Controls.Add(prcbCoolDown);
            panel3.Controls.Add(txbIP);
            panel3.Controls.Add(txbPlayerName);
            panel3.Location = new Point(132, 477);
            panel3.Name = "panel3";
            panel3.Size = new Size(753, 114);
            panel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat ExtraBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.LimeGreen;
            label1.Location = new Point(180, 10);
            label1.Name = "label1";
            label1.Size = new Size(262, 39);
            label1.TabIndex = 4;
            label1.Text = "5 in a line to win";
            // 
            // btnLan
            // 
            btnLan.Location = new Point(395, 78);
            btnLan.Name = "btnLan";
            btnLan.Size = new Size(94, 29);
            btnLan.TabIndex = 3;
            btnLan.Text = "LAN";
            btnLan.UseVisualStyleBackColor = true;
            btnLan.Click += btnLan_Click;
            // 
            // pctbMark
            // 
            pctbMark.Location = new Point(631, 10);
            pctbMark.Name = "pctbMark";
            pctbMark.Size = new Size(94, 94);
            pctbMark.SizeMode = PictureBoxSizeMode.StretchImage;
            pctbMark.TabIndex = 2;
            pctbMark.TabStop = false;
            // 
            // prcbCoolDown
            // 
            prcbCoolDown.Location = new Point(495, 45);
            prcbCoolDown.Name = "prcbCoolDown";
            prcbCoolDown.Size = new Size(105, 29);
            prcbCoolDown.TabIndex = 1;
            // 
            // txbIP
            // 
            txbIP.Location = new Point(495, 80);
            txbIP.Name = "txbIP";
            txbIP.Size = new Size(105, 27);
            txbIP.TabIndex = 0;
            txbIP.Text = "127.0.0.1";
            // 
            // txbPlayerName
            // 
            txbPlayerName.Location = new Point(495, 12);
            txbPlayerName.Name = "txbPlayerName";
            txbPlayerName.ReadOnly = true;
            txbPlayerName.Size = new Size(105, 27);
            txbPlayerName.TabIndex = 0;
            // 
            // tmCoolDown
            // 
            tmCoolDown.Tick += tmCoolDown_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(887, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, undoToolStripMenuItem, quitToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(60, 24);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newGameToolStripMenuItem.Size = new Size(218, 26);
            newGameToolStripMenuItem.Text = "New Game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(218, 26);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.E;
            quitToolStripMenuItem.Size = new Size(218, 26);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(14, 24);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 599);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(pnlChessBeard);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Game Caro Fun ( Line up 5 )";
            FormClosing += Form1_FormClosed;
            Shown += Form1_Shown;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pctbAvatar).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctbMark).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlChessBeard;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pctbAvatar;
        private PictureBox pctbMark;
        private ProgressBar prcbCoolDown;
        private TextBox textBox2;
        private TextBox txbPlayerName;
        private Button btnLan;
        private PictureBox pictureBox2;
        private TextBox txbIP;
        private Label label1;
        private System.Windows.Forms.Timer tmCoolDown;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
    }
}