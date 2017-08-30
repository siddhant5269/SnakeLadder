//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SnakeLadder.Rules;

//namespace SnakeLadder
//{
//    static class RuleUtilities
//    {
//        public static void ExecuteRule(Board board, Player player,Rule rule)
//        {
//            switch (rule.Type)
//            {
//                case RuleType.S:
//                    SnakeRule snakeRule = (SnakeRule)rule;
//                    if (player.IsMagic)
//                    {
//                        if(player.LastPositions[player.CurrentPositionCursor] == snakeRule.End)
//                        {
//                            player.CurrentPositionCursor = (player.CurrentPositionCursor + 1) % player.LastPositions.Count();
//                            if(snakeRule.Hunger > 0)
//                            {
//                                player.LastPositions[player.CurrentPositionCursor] = snakeRule.Start;
//                            } 
//                        }
//                    }
//                    else
//                    {
//                        player.CurrentPositionCursor = (player.CurrentPositionCursor + 1) % player.LastPositions.Count();
//                        if (snakeRule.Hunger > 0)
//                        {
//                            player.LastPositions[player.CurrentPositionCursor] = snakeRule.End;
//                        }
//                    }
//                    break;
//                case RuleType.L:
//                    LadderRule ladderRule = (LadderRule)rule;
//                    if (player.IsMagic)
//                    {
//                        if (player.LastPositions[player.CurrentPositionCursor] == ladderRule.End)
//                        {
//                            player.CurrentPositionCursor = (player.CurrentPositionCursor + 1) % player.LastPositions.Count();
//                            if (board.Cells[ladderRule.Start].PlayerInsideCount == 0)
//                            {
//                                player.LastPositions[player.CurrentPositionCursor] = ladderRule.Start;
//                            }
//                        }
//                    }
//                    else
//                    {
//                        player.CurrentPositionCursor = (player.CurrentPositionCursor + 1) % player.LastPositions.Count();
//                        if (board.Cells[ladderRule.End].PlayerInsideCount == 0)
//                        {
//                            player.LastPositions[player.CurrentPositionCursor] = ladderRule.End;
//                        }
//                    }
//                    break;
//                case RuleType.E:
//                    //board.Cells[rule.Params[0]].Rules.Add(rule.Type, rule.Params.ToList());
//                    break;
//                case RuleType.T:
//                    //board.Cells[rule.Params[0]].Rules.Add(rule.Type, rule.Params.ToList());
//                    break;
//                case RuleType.P:
//                   // board.Cells[rule.Params[0]].Rules.Add(rule.Type, rule.Params.ToList());
//                    break;
//                case RuleType.ME:
//                    //board.Cells[rule.Params[0]].Rules.Add(rule.Type, rule.Params.ToList());
//                    break;
//                case RuleType.MA:
//                    //board.Cells[rule.Params[0]].Rules.Add(rule.Type, rule.Params.ToList());
//                    break;
//                default:
//                    return;
//            }
//        }

//        public static bool ValidateApplyRule(Rule rule,Board board)
//        {
//            var isValid = true;
//            switch (rule.Type)
//            {
//                case RuleType.S:
//                    SnakeRule snakeRule = (SnakeRule)rule;
//                    board.Cells[snakeRule.Start].Rules.Add(rule.Type, snakeRule);
//                    board.Cells[snakeRule.End].Rules.Add(rule.Type, snakeRule);                    
//                    break;
//                case RuleType.L:
//                    LadderRule ladderRule = (LadderRule)rule;
//                    board.Cells[ladderRule.Start].Rules.Add(rule.Type, ladderRule);
//                    board.Cells[ladderRule.End].Rules.Add(rule.Type, ladderRule);
//                    break;
//                case RuleType.E:
//                    EscalatorRule escalatorRule = (EscalatorRule)rule;
//                    board.Cells[escalatorRule.Start].Rules.Add(rule.Type, escalatorRule);                    
//                    break;
//                case RuleType.T:
//                    TrampolineRule trampolineRule = (TrampolineRule)rule;
//                    board.Cells[trampolineRule.Start].Rules.Add(rule.Type, trampolineRule);
//                    break;
//                case RuleType.P:
//                    PitstopRule pitstopRule = (PitstopRule)rule;
//                    board.Cells[pitstopRule.Position].Rules.Add(rule.Type, pitstopRule);
//                    break;
//                case RuleType.ME:
//                    MemoryRule memoryRule = (MemoryRule)rule;
//                    board.Cells[memoryRule.Position].Rules.Add(rule.Type, memoryRule);
//                    break;
//                case RuleType.MA:
//                    MagicRule magicRule = (MagicRule)rule;
//                    board.Cells[magicRule.Position].Rules.Add(rule.Type, magicRule);
//                    break;
//                default:
//                    return true;
//            }
//            return isValid;
//        }        

//        public static bool TryParseRule(string ruleString, out Rule rule)
//        {
//            var ruleParts = ruleString.Split(' ').ToArray();           
            
//            if (ruleParts.Length < 2 || !Enum.TryParse<RuleType>(ruleParts[0], out RuleType ruleType))
//            {
//                return false;
//            }
//            switch (ruleType)
//            {
//                case RuleType.S:
//                    rule = new SnakeRule();
                   
//                    break;
//                case RuleType.L:
                    
//                    break;
//                case RuleType.E:
                    
//                    break;
//                case RuleType.T:
                    
//                    break;
//                case RuleType.P:
                  
//                    break;
//                case RuleType.ME:
                   
//                    break;
//                case RuleType.MA:
                    
//                    break;
//                default:
//                    return true;
//            }            
//            for(int i = 1; i < ruleParts.Length; i++)
//            {
//                if(!Int32.TryParse(ruleParts[i],out rule.Params[i - 1]))
//                {
//                    return false;
//                }
//            }
//            return true;
//        }
//    }
//}
