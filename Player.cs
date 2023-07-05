using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Caro
{
    public class Player
    {
        private string name; // Ctrl + R +E

        public string Name { get => name; set => name = value; }
        public Image Mark { get => mark; set => mark = value; }

        private Image mark;

        public Player(string name, Image mark) { 
            this.name = name;
            this.mark = mark;
        }

    }
}
