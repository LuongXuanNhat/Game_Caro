using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Caro
{
    public class PlayInfor
    {
        private Point point;
        private int curent_Player;
        public Point Point { get => point; set => point = value; }
        public int Curent_Player { get => curent_Player; set => curent_Player = value; }

        public PlayInfor(Point point, int curentPlayer)
        {
            this.point = point;
            this.Curent_Player = curentPlayer;
        }
    }
}
