using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    class Player
    {
        public int PlayerId { get; set; }
        public int EnergyLevel { get; set; }
        public int CurrentPositionCusror { get; set; }
        public string PathTravelled { get; set; }
        private int[] _lastPositions = new int[6];
        public int[] LastPositions
        {
            get
            {
                return _lastPositions;
            }
            set
            {
                _lastPositions = value;
            }
        }

        public void AddPath(RuleType? ruleType,int currentCell)
        {            
            PathTravelled += "-> " + ruleType?.ToString() + currentCell;            
        }

        public bool IsMagic { get; set; }

        public int ApplyDice(int diceValue)
        {
            return LastPositions[CurrentPositionCusror] + diceValue;
        }        
    }
}
