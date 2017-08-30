using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder.Rules
{
    class LadderRule : Rule
    {
        public LadderRule(string exp)
        {
            this.Expression = exp;
        }
        public override string Expression { get; set; }
        public int Head { get; set; }
        public int Tail { get; set; }       

        public override void ValidateAndCreate()
        {
            var expParams = this.Expression.Split(' ');
            if (expParams.Length != 3)
            {
                throw new Exception("Not a valid ladder rule.");
            }
            this.Head = int.Parse(expParams[1]);
            this.Tail = int.Parse(expParams[2]);
        }

        public override int Eval(int pos)
        {
            if (pos == this.Head)
                return this.Tail;
            return pos;

        }

    }
}
