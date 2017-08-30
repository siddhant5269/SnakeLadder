using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SnakeLadder
{
    public class Player
    {
        public int EnergyLevel { get; set; }
        public Cell1 CurrentPosition { get; set; }
        public int id { get; set; }
        public Player(Cell1 c)
        {
            this.CurrentPosition = c;            
        }

       



        //public int EnergyLevel { get; set; }
        //public int CurrentPositionCursor { get; set; }
        //public string PathTravelled { get; set; }
        //public bool IsTurnOver { get; set; }

        //private int[] _lastPositions = new int[Constants.DiceSize];
        //public int[] LastPositions
        //{
        //    get
        //    {
        //        return _lastPositions;
        //    }
        //    set
        //    {
        //        _lastPositions = value;
        //    }
        //}

        //public void AddPath(RuleType? ruleType,int currentCell)
        //{            
        //    PathTravelled += "-> " + ruleType?.ToString() + currentCell;            
        //}

        //public bool IsMagic { get; set; }
    }
}
