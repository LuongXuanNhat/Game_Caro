using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Game_Caro
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;

        SocketManager socket;
        #endregion
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            ChessBoard = new ChessBoardManager(pnlChessBeard, txbPlayerName, pctbMark);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;

            prcbCoolDown.Step = Constant.COOL_DOWN_STEP;
            prcbCoolDown.Maximum = Constant.COOL_DOWN_TIME;
            prcbCoolDown.Value = 0;
            tmCoolDown.Interval = Constant.COOL_DOWN_INTERVAL;

            socket = new SocketManager();

            NewGame();
        }

        #region
        void EndGame()
        {
            tmCoolDown.Stop();
            pnlChessBeard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
        }
        void ChessBoard_PlayerMarked(object? sender, ButtonClickEvent e)
        {
            tmCoolDown.Stop();
            pnlChessBeard.Enabled = false;
            prcbCoolDown.Value = 0;

            socket.Send(new SocketData((int)SocketComand.SEND_POINT, "", e.ClickedPoint));
            undoToolStripMenuItem.Enabled = false;
            Listen();
        }

        void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();


            socket.Send(new SocketData((int)SocketComand.END_GAME, "", new Point()));

        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            prcbCoolDown.PerformStep();
            if (prcbCoolDown.Value >= prcbCoolDown.Maximum)
            {
                EndGame();
                socket.Send(new SocketData((int)SocketComand.TIME_OUT, "", new Point()));

            }
        }

        void NewGame()
        {
            tmCoolDown.Stop();
            prcbCoolDown.Value = 0;
            undoToolStripMenuItem.Enabled = true;
            ChessBoard.DrawChessBoard();

        }

        void Quit()
        {
            Application.Exit();
        }

        void Undo()
        {
            prcbCoolDown.Value = 0;
            ChessBoard.Undo();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            lbRole.Enabled = false;
            lbRole.Text = "Host";
            lbNameXO.Text = "You are ";
            pctbXO.Image = global::Game_Caro.Properties.Resources.x;
            pctbXO.BackgroundImageLayout = ImageLayout.Stretch;
            pnlChessBeard.Enabled = true;

            socket.Send(new SocketData((int)SocketComand.NEW_GAME, "", new Point()));
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
            socket.Send(new SocketData((int)SocketComand.UNDO, "", new Point()));
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosed(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the game ?", "Notification", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketComand.QUIT, "", new Point()));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void btnLan_Click(object sender, EventArgs e)
        {
            socket.IP = txbIP.Text;
            if (!socket.ConnectServer())
            {
                prcbCoolDown.Maximum = Constant.COOL_DOWN_TIME1MINUTE;
                tmCoolDown.Start();
                lbLoading.Text = "Đang chờ đối thủ";
                socket.isServer = true;
                pnlChessBeard.Enabled = true;
                socket.CreateServer();
                lbRole.Enabled = false;
                lbRole.Text = "Host";
                lbNameXO.Text = "You are ";
                pctbXO.Image = global::Game_Caro.Properties.Resources.x;
                pctbXO.BackgroundImageLayout = ImageLayout.Stretch;
                pnlChessBeard.Enabled = true;
            }
            else
            {
                tmCoolDown.Stop();
                prcbCoolDown.Value = 0;
                socket.isServer = false;
                pnlChessBeard.Enabled = false;
                lbRole.Enabled = false;
                lbRole.Text = "Guest";
                lbNameXO.Text = "You are ";
                pctbXO.Image = global::Game_Caro.Properties.Resources.o1;
                pctbXO.BackgroundImageLayout = ImageLayout.Stretch;
                socket.Send(new SocketData((int)SocketComand.CONNECT_SUCCESS, "", new Point()));
                Listen();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txbIP.Text))
            {
                txbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        void Listen()
        {

            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();
                    ProcessData(data);
                }
                catch (Exception)
                {

                    throw;
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();


        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketComand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketComand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pnlChessBeard.Enabled = false;
                        lbRole.Enabled = false;
                        lbRole.Text = "Guest";
                        lbNameXO.Text = "You are ";
                        pctbXO.Image = global::Game_Caro.Properties.Resources.o1;
                        pctbXO.BackgroundImageLayout = ImageLayout.Stretch;
                    }));
                    break;
                case (int)SocketComand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        prcbCoolDown.Value = 0;
                        pnlChessBeard.Enabled = true;
                        tmCoolDown.Start();
                        undoToolStripMenuItem.Enabled = true;
                        ChessBoard.OtherPlayerMark(data.Point);
                    }));
                    break;
                case (int)SocketComand.UNDO:
                    Undo();
                    prcbCoolDown.Value = 0;
                    break;
                case (int)SocketComand.END_GAME:
                    prcbCoolDown.Value = 0;
                    CustomMessageBox message = new CustomMessageBox("Game Over! You loss!", Color.BlueViolet);
                    message.ShowDialog();
                    break;
                case (int)SocketComand.TIME_OUT:
                    MessageBox.Show("Time out");
                    break;
                case (int)SocketComand.QUIT:
                    tmCoolDown.Stop();
                    MessageBox.Show("The opponent has left the game");
                    break;
                case (int)SocketComand.CONNECT_SUCCESS:
                    //this.Invoke((MethodInvoker)(() =>
                    //{
                    //    tmCoolDown.Stop();
                    //    prcbCoolDown.Value = 0;
                    //    lbLoading.Text = "Kết nối thành công";
                    //}));
                    tmCoolDown.Stop();
                    prcbCoolDown.Value = 0;
                    lbLoading.Text = "Kết nối thành công";
                    break;

            }
            Listen();
        }
        #endregion


    }
}