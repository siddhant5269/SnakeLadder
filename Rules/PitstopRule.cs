//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SnakeLadder.Rules
//{
//    public class PitstopRule:Rule
//    {
//        //public int Position { get; set; }
//        //public int UnitsOfEnergy { get; set; }
//        public PitstopRule(string exp)
//        {
//            this.Expression = exp;
//        }
//        public override string Expression { get; set; }
//        public int Head { get; set; }

//        public override void ValidateAndCreate()
//        {
//            var expParams = this.Expression.Split(' ');
//            if (expParams.Length != 2)
//            {
//                throw new Exception("Not a valid PitstopRule rule.");
//            }
//            this.Head = int.Parse(expParams[1]);   

//        }
//    }
//}
