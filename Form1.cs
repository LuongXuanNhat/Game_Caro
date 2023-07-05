using System.Net.NetworkInformation;

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
            MessageBox.Show("Game Over!");
        }
        void ChessBoard_PlayerMarked(object? sender, EventArgs e)
        {
            tmCoolDown.Start();
            prcbCoolDown.Value = 0;
        }

        void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            prcbCoolDown.PerformStep();
            if (prcbCoolDown.Value >= prcbCoolDown.Maximum)
            {
                EndGame();
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
            ChessBoard.Undo();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosed(object sender, FormClosingEventArgs e)
        {
            tmCoolDown.Stop();
            if (MessageBox.Show("Are you sure you want to exit the game ?", "Notification", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            tmCoolDown.Start();
        }
        #endregion

        private void btnLan_Click(object sender, EventArgs e)
        {
            socket.IP = txbIP.Text;
            if (!socket.ConnectServer())
            {
                socket.CreateServer();
                Thread listenThread = new Thread(() => {
                    while (true)
                    {
                        Thread.Sleep(500);
                        try
                        {
                            Listen();
                            break;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                });
                listenThread.IsBackground = true;
                listenThread.Start();
            } else
            {
                Thread listenThread = new Thread(() => {
                    Listen();
                });
                listenThread.IsBackground = true;
                listenThread.Start();
                socket.Send("Successful connection!");
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
            string data = (string)socket.Receive();
            MessageBox.Show(data);
        }
    }
}