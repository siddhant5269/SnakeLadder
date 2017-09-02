using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder.Rules
{
    class MemoryRule : IRule
    {        
        private int _position;

        public int Position { get { return _position; } }        
        public RuleType Type { get { return RuleType.ME; } }

        public bool ValidateInitialize(string[] paramters)
        {
            if (paramters.Length != 1)
            {
                return false;
            }
            return Int32.TryParse(paramters[0], out _position);
        }     
    }
}
