using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Caro
{
    public class ChessBoardManager
    {
        #region Properties
        private Panel chessBoard;
        private List<Player> players = new List<Player>();
        private int currentPlayer;
        private TextBox playerName;
        private PictureBox mark;
        private List<List<Button>> matrix = new List<List<Button>>();

        public Panel ChessBoard 
        {   get => chessBoard; 
            set => chessBoard = value; 
        }
        public List<Player> Players { get => players; set => players = value; }
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
        public TextBox PlayerName { get => playerName; set => playerName = value; }
        public PictureBox Mark { get => mark; set => mark = value; }
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }
        public Stack<PlayInfor> PlayTimeLine { get => playTimeLine; set => playTimeLine = value; }

        private event EventHandler playerMarked;
        public event EventHandler PlayerMarked
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }
        }

        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add
            {
                endedGame += value;
            }
            remove
            {
                endedGame -= value;
            }
        }

        private Stack<PlayInfor> playTimeLine;
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox mark) { 
            this.chessBoard = chessBoard;
            this.playerName = playerName;
            this.mark = mark;

            this.Players = new List<Player>()
            {
                new Player("Player 1", global::Game_Caro.Properties.Resources.x),
                new Player("Player 2", global::Game_Caro.Properties.Resources.o1),
            };
            
        }
        
        #endregion

        #region Methods
        public void DrawChessBoard()
        {
            ChessBoard.Enabled = true;
            ChessBoard.Controls.Clear();
            PlayTimeLine = new Stack<PlayInfor>();
            CurrentPlayer = 0;
            ChangePlayer();

            Matrix = new List<List<Button>>();


            Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Constant.CHESS_BOARD_ROW; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Constant.CHESS_BOARD_COL; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Constant.CHESS_WEIGHT,
                        Height = Constant.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString(),
                    };

                    btn.Click += btn_Click;

                    chessBoard.Controls.Add(btn);

                    Matrix[i].Add(btn);

                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Constant.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }

        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
                return;
            ChangeMark(btn);

            PlayTimeLine.Push(new PlayInfor (GetChessPoint(btn), CurrentPlayer));
            
            currentPlayer = CurrentPlayer == 0 ? 1 : 0;
            ChangePlayer();

            if (playerMarked != null)
                playerMarked(this, new EventArgs());

            if (isEndGame(btn))
            {
                EndGame();
            }

            
        }
        private void EndGame()
        {
            if (endedGame != null)
                endedGame(this, new EventArgs());

        }
        public bool Undo()
        {
            if(PlayTimeLine.Count <= 0) return false;
            PlayInfor oldPoint = PlayTimeLine.Pop();
            Button btn = Matrix[oldPoint.Point.Y][oldPoint.Point.X];
            btn.BackgroundImage = null;
            
            if (PlayTimeLine.Count <= 0)
            {
                CurrentPlayer = 0;
            }
            else
            {
                oldPoint = PlayTimeLine.Peek();
                CurrentPlayer = oldPoint.Curent_Player == 1 ? 0 : 1;
            }
            ChangePlayer();
            return true;
        }
        private bool isEndGame(Button btn)
        {
            return isEndHorizontal(btn) || isEndVertical(btn) || isEndPrimary(btn) || isEndSub(btn);
        }
        private Point GetChessPoint(Button btn)
        {
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);
            Point point = new Point(horizontal, vertical);

            return point;
        }
        private bool isEndHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countLeft = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                    countLeft++;
                else break;
            }

            int countRight = 0;
            for (int i = point.X+1; i < Constant.CHESS_BOARD_COL; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                    countRight++;
                else break;
            }
            return countLeft + countRight == 5;
        }
        private bool isEndVertical(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                    countTop++;
                else break;
            }

            int countBottom = 0;
            for (int i = point.Y + 1; i < Constant.CHESS_BOARD_ROW; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                    countBottom++;
                else break;
            }
            return countBottom + countTop == 5;
        }
        private bool isEndPrimary(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.Y - i < 0 || point.X - i < 0)
                    break;
                if (Matrix[point.Y-i][point.X-i].BackgroundImage == btn.BackgroundImage)
                    countTop++;
                else break;
            }

            int countBottom = 0;
            for (int i = 1; i <= Constant.CHESS_BOARD_COL - point.X; i++)
            {
                if (point.Y + i >= Constant.CHESS_BOARD_ROW || point.X + i >= Constant.CHESS_BOARD_COL)
                    break;
                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                    countBottom++;
                else break;
            }
            return countBottom + countTop == 5;
        }
        private bool isEndSub(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.Y - i < 0 || point.X + i > Constant.CHESS_BOARD_COL)
                    break;
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                    countTop++;
                else break;
            }

            int countBottom = 0;
            for (int i = 1; i <= Constant.CHESS_BOARD_COL - point.X; i++)
            {
                if (point.Y + i >= Constant.CHESS_BOARD_ROW || point.X - i < 0)
                    break;
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                    countBottom++;
                else break;
            }
            return countBottom + countTop == 5;
        }
        private void ChangeMark(Button btn)
        {
            btn.BackgroundImage = players[CurrentPlayer].Mark;
            
        }
        private void ChangePlayer()
        {
            playerName.Text = players[currentPlayer].Name;
            mark.Image = players[currentPlayer].Mark;
        }
        #endregion


    }
}
