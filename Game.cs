using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    public class Game
    {
        public Player[] Players { get; set; }
        public Board Board { get; set; }
        public int CurrentPlayerIndex { get; set; }
        public Player CurrentPlayer { get { return Players[CurrentPlayerIndex]; } }      
    }
}
