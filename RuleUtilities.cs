using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    static class RuleUtilities
    {
        public static bool ValidateApplyRule(Rule rule,Board board)
        {
            var isValid = true;
            switch (rule.Type)
            {
                case RuleType.S:
                    board.Cells[rule.Params[0]].Rules.Add(rule.Type, rule.Params.ToList());
                    board.Cells[rule.Params[1]].Rules.Add(rule.Type, rule.Params.ToList());
                    break;
                case RuleType.L:
                    board.Cells[rule.Params[0]].Rules.Add(rule.Type, rule.Params.ToList());
                    board.Cells[rule.Params[1]].Rules.Add(rule.Type, rule.Params.ToList());
                    break;
                case RuleType.E:
                    board.Cells[rule.Params[0]].Rules.Add(rule.Type, rule.Params.ToList());                    
                    break;
                case RuleType.T:
                    board.Cells[rule.Params[0]].Rules.Add(rule.Type, rule.Params.ToList());
                    break;
                case RuleType.P:
                    board.Cells[rule.Params[0]].Rules.Add(rule.Type, rule.Params.ToList());
                    break;
                case RuleType.ME:
                    board.Cells[rule.Params[0]].Rules.Add(rule.Type, rule.Params.ToList());
                    break;
                case RuleType.MA:
                    board.Cells[rule.Params[0]].Rules.Add(rule.Type, rule.Params.ToList());
                    break;
                default:
                    return true;
            }
            return isValid;
        }        

        public static bool TryParseRule(string ruleString, out Rule rule)
        {
            var ruleParts = ruleString.Split(' ').ToArray();            
            rule = new Rule();
            if (ruleParts.Length < 2 || Enum.TryParse<RuleType>(ruleParts[0], out RuleType ruleType))
            {
                return false;
            }
            rule.Params = new int[ruleParts.Length - 1];
            for(int i = 1; i < ruleParts.Length; i++)
            {
                if(!Int32.TryParse(ruleParts[i],out rule.Params[i - 1]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
