using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    class RuleUtilities
    {
        public bool ValidateRule(Rule rule)
        {
            switch (rule.Type)
            {
                case RuleType.E:
                    return true;
                default:
                    return true;
            }
                      
        }  
        

        public bool ValidateRuleString()
        {
            
        }

        public bool TryParseRule(string ruleString, out Rule rule)
        {
            var ruleParts = ruleString.Split(' ').ToArray();
            var isValid = true;
            rule = new Rule();
            if(ruleParts.Length < 2)
            {
                isValid = false;
            }
            isValid = Enum.TryParse<RuleType>(ruleParts[0],out RuleType ruleType);

            rule.Type = ruleType;
            rule.Params = ruleParts.Skip(1).Take(ruleParts.Length - 2).ToArray();
            
        }             
    }
}
