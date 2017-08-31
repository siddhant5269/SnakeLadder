using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SnakeLadder.Rules
{
    public class SnakeRule : IRule
    {


        public RuleType Type { get { return RuleType.S; } }

        private int _head;
        private int _tail;
        private int _hunger;
        public int Head { get { return _head; } }
        public int Tail { get { return _tail; } }
        public int Hunger { get { return _hunger; } }       

        public bool ValidateInitialize(string[] paramters)
        {
            if (paramters.Length != 3)
            {
                return false; 
            }
            return Int32.TryParse(paramters[0], out _head) && Int32.TryParse(paramters[1], out _tail) && Int32.TryParse(paramters[1], out _hunger);          
        }

        public bool TryApplyOnBoard(Board board)
        {
            return true;
        }

        public void DecreaseHunger(int decreaseBy = 1)
        {
            _hunger -= decreaseBy;
        }
    }
}
