using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder.Rules
{
    class LadderRule : IRule
    {
        private int _bottom;
        private int _top;

        public int Bottom { get { return _bottom; } }
        public int Top { get { return _top; } }
        public RuleType Type { get { return RuleType.L; } }       

        public bool ValidateInitialize(string[] paramters)
        {            
            if (paramters.Length != 2)
            {
                return false;
            }
            return Int32.TryParse(paramters[0],out _bottom) && Int32.TryParse(paramters[1],out _top);
        }

        public bool TryApplyOnBoard(Board board)
        {
            return true;
        }
    }
}
