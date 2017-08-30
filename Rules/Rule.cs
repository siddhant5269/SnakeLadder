using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SnakeLadder.Rules
{
    public abstract class Rule
    {
        //public RuleType Type { get; set; }     
        public abstract string Expression { get; set; }
        //public abstract ArrayList Params { get; set; }
        public abstract void ValidateAndCreate();

        public abstract int Eval(int pos);

    }
}
