using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder.Rules
{
    class EscalatorRule : IRule
    {
        private int _startPosition;
       
        public int StartPosition { get { return _startPosition; } }
        public RuleType Type { get { return RuleType.E; } }

        public bool ValidateInitialize(string[] paramters)
        {
            if (paramters.Length != 1)
            {
                return false;
            }
            return Int32.TryParse(paramters[0], out _startPosition);
        }
    }
}
