using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    public class Player
    {
        private int _currentPositionIndexInLastPositions = -1;

        public int EnergyLevel { get; set; }
        public bool  IsMagic { get; set; }

        public int CurrentPosition
        {
            get;
            set; 
        }

        private int[] _lastPositions = new int[Constants.DiceSize];
        public int[] LastPositions
        {
            get
            {
                return _lastPositions;
            }           
        }

        public int GetPostionBeforeTurns(int noOfTurns)
        {
            var positionBeforeNoOfTurns = _currentPositionIndexInLastPositions >= noOfTurns
                ? _lastPositions[_currentPositionIndexInLastPositions - noOfTurns] 
                : _lastPositions[(_lastPositions.Count() + _currentPositionIndexInLastPositions) - noOfTurns];
            return positionBeforeNoOfTurns < Constants.StartCellIndex ? Constants.StartCellIndex : positionBeforeNoOfTurns;
        }

        public void DecreaseEnergy(int decreaseBy = 1)
        {
            EnergyLevel -= decreaseBy;
        }

        public void SetTurnOver()
        {
            _currentPositionIndexInLastPositions = (_currentPositionIndexInLastPositions + 1) % LastPositions.Count();
            _lastPositions[_currentPositionIndexInLastPositions] = CurrentPosition;
        }

        public bool IsOutOfEnergy()
        {
            return EnergyLevel == 0;
        }
    }
}
