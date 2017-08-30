using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SnakeLadder.Rules
{
    public class SnakeRule : Rule
    {
        //public int Start { get; set; }
        //public int End { get; set; }
        //public int Hunger { get; set; } 

        //public SnakeRule(int start,int end, int hunger)
        //{
        //    Start = start;
        //    End = end;
        //    Hunger = hunger;
        //}  
       
        public SnakeRule(string exp)
        {
            this.Expression = exp;
        }
        public override string Expression { get; set; }
        public int Head { get; set; }
        public int Tail { get; set; }
        public int EnergyLevel { get; set; }

        public override void ValidateAndCreate()
        {
            var expParams = this.Expression.Split(' ');
            if (expParams.Length != 4)
            {
                throw new Exception("Not a valid snake rule.");
            }
            this.Head = int.Parse(expParams[1]);
            this.Tail = int.Parse(expParams[2]);
            this.EnergyLevel = int.Parse(expParams[2]);

            
        }

        public override int Eval(int pos)
        {
            if (pos == this.Head)
                return this.Tail;
            return pos;

        }


    }
}
