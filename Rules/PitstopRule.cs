using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder.Rules
{
    public class PitstopRule : IRule
    {
        private int _pitPosition;
        private int _unitsOfEnergy;

        public int PitPosition { get { return _pitPosition; } }
        public int UnitsOfEnergy { get { return _unitsOfEnergy; } }
        public RuleType Type { get { return RuleType.P; } }      
       
        
        public bool ValidateInitialize(string[] paramters)
        {
            if (paramters.Length != 2)
            {
                return false;
            }
            return Int32.TryParse(paramters[0], out _pitPosition) && Int32.TryParse(paramters[1], out _unitsOfEnergy);
        }

     

    }

}
