using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SnakeLadder
{
    public class Player
    {
        private int _currentPositionIndexInLastPositions;

        public int EnergyLevel { get; set; }
        public bool  IsMagic { get; set; }


        public int CurrentPosition
        {
            get { return _lastPositions[_currentPositionIndexInLastPositions]; }
            set
            {
                CurrentPosition = value;
                _currentPositionIndexInLastPositions = _currentPositionIndexInLastPositions + 1 % LastPositions.Count();
                LastPositions[_currentPositionIndexInLastPositions] = value;
            }
        }

        private int[] _lastPositions = new int[Constants.DiceSize];
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

        public int GetPostionBeforeTurns(int noOfTurns)
        {
            return _currentPositionIndexInLastPositions + 1 >= noOfTurns
                ? _currentPositionIndexInLastPositions - noOfTurns : LastPositions.Count() + _currentPositionIndexInLastPositions - noOfTurns;
        }

        public void DecreaseEnergy(int decreaseBy = 1)
        {
            EnergyLevel -= decreaseBy;
        }
    }
}
