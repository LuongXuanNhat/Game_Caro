using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Caro
{
    [Serializable]
    public class SocketData
    {
        private int command;
        private Point point;
        private string message;


        public SocketData(int command,string? mesage, Point point)
        {
            this.Command = command;
            this.Point = point;
            this.Message = mesage;
        }
        public int Command { get => command; set => command = value; }
        public Point Point { get => point; set => point = value; }
        public string Message { get => message; set => message = value; }
    }

    public enum SocketComand
    {
        SEND_POINT,
        NOTIFY,
        NEW_GAME,
        UNDO,
        END_GAME_LOSS,
        END_GAME_WIN,
        TIME_OUT,
        QUIT,
        CONNECT_SUCCESS
    }
}
