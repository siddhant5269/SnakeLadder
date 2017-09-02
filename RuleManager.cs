using System;
using System.Linq;
using SnakeLadder.Rules;

namespace SnakeLadder
{
    public class RuleManager
    {
        public bool TryAssignRule(string ruleString, Game game)
        {
            var isValid = false;
            var ruleParts = ruleString.Split(' ').ToArray();
            if (ruleParts.Length < 2 || !Enum.TryParse<RuleType>(ruleParts[0], out RuleType ruleType))
            {
                return false;
            }

            var ruleParameters = ruleParts.Skip(1).ToArray();

            switch (ruleType)
            {
                case RuleType.S:
                    var snakeRule = new SnakeRule();
                    isValid = snakeRule.ValidateInitialize(ruleParameters)
                            && TryApplyRuleOnCell(snakeRule, game.Board.Cells[snakeRule.Head], game.Board)
                            && TryApplyRuleOnCell(snakeRule, game.Board.Cells[snakeRule.Tail], game.Board);
                    break;
                case RuleType.L:
                    var ladderRule = new LadderRule();
                    isValid = ladderRule.ValidateInitialize(ruleParameters)
                            && TryApplyRuleOnCell(ladderRule, game.Board.Cells[ladderRule.Bottom], game.Board)
                            && TryApplyRuleOnCell(ladderRule, game.Board.Cells[ladderRule.Top], game.Board);                   
                    break;
                case RuleType.E:
                    var escalatorRule = new EscalatorRule();                   
                    isValid = escalatorRule.ValidateInitialize(ruleParameters)
                            && TryApplyRuleOnCell(escalatorRule, game.Board.Cells[escalatorRule.StartPosition], game.Board);
                    break;
                case RuleType.T:
                    var trampolineRule = new TrampolineRule();
                    isValid = trampolineRule.ValidateInitialize(ruleParameters)
                            && TryApplyRuleOnCell(trampolineRule, game.Board.Cells[trampolineRule.StartPosition], game.Board);                   
                    break;
                case RuleType.P:
                    var pitstopRule = new PitstopRule();
                    isValid = pitstopRule.ValidateInitialize(ruleParameters)
                           && TryApplyRuleOnCell(pitstopRule, game.Board.Cells[pitstopRule.PitPosition], game.Board);
                    break;
                case RuleType.ME:
                    var memoryRule = new MemoryRule();
                    isValid = memoryRule.ValidateInitialize(ruleParameters)
                          && TryApplyRuleOnCell(memoryRule, game.Board.Cells[memoryRule.Position], game.Board);

                  
                    break;
                case RuleType.MA:
                    var magicRule = new MagicRule();
                    isValid = magicRule.ValidateInitialize(ruleParameters)
                         && TryApplyRuleOnCell(magicRule, game.Board.Cells[magicRule.Position], game.Board);
                    break;               
            }
            return isValid;
        }

        private bool TryApplyRuleOnCell(IRule rule, Cell cell, Board board)
        {
            if(cell == board.Cells[board.NoOfCells]) {
                return false;
            }
            var canBeApplied = true;
            switch (rule.Type)
            {
                case RuleType.S:
                           canBeApplied =!cell.Rules.ContainsKey(RuleType.S) &&
                           !cell.Rules.ContainsKey(RuleType.L) &&
                           !cell.Rules.ContainsKey(RuleType.T) &&
                           !cell.Rules.ContainsKey(RuleType.E);
                    break;
                case RuleType.L:
                    canBeApplied = !cell.Rules.ContainsKey(RuleType.S) &&
                           !cell.Rules.ContainsKey(RuleType.L) &&
                           !cell.Rules.ContainsKey(RuleType.T) &&
                           !cell.Rules.ContainsKey(RuleType.E);
                    break;
                case RuleType.E:
                    canBeApplied = !cell.Rules.ContainsKey(RuleType.S) &&
                            !cell.Rules.ContainsKey(RuleType.L) &&
                            !cell.Rules.ContainsKey(RuleType.T) &&
                            !cell.Rules.ContainsKey(RuleType.E);
                    break;
                case RuleType.T:
                    canBeApplied = !cell.Rules.ContainsKey(RuleType.S) &&
                           !cell.Rules.ContainsKey(RuleType.L) &&
                           !cell.Rules.ContainsKey(RuleType.T) &&
                           !cell.Rules.ContainsKey(RuleType.E);
                    break;
                case RuleType.P:
                    canBeApplied = !cell.Rules.ContainsKey(RuleType.P);
                    break;                   
                case RuleType.ME:
                    canBeApplied = !cell.Rules.ContainsKey(RuleType.ME);
                    break;
                case RuleType.MA:
                    canBeApplied = !cell.Rules.ContainsKey(RuleType.MA);
                    break;
            }
            if (canBeApplied)
            {
                cell.Rules.Add(rule.Type,rule);
            }
            return canBeApplied;            
        }
       

        public bool ApplyRule(IRule rule, Player player, Board board,int diceValue)
        {
            switch (rule.Type)
            {
                case RuleType.S:
                    var snakeRule = (SnakeRule)rule;
                    if (player.IsMagic)
                    {
                        if (snakeRule.Hunger > 0 && player.CurrentPosition == snakeRule.Tail)
                        {
                            player.CurrentPosition = snakeRule.Head;
                            snakeRule.DecreaseHunger();
                        }
                    }
                    else
                    {

                        if (snakeRule.Hunger > 0 && player.CurrentPosition == snakeRule.Head)
                        {
                            player.CurrentPosition = snakeRule.Tail;
                            snakeRule.DecreaseHunger();
                        }
                    }
                    
                    break;
                case RuleType.L:
                    var ladderRule = (LadderRule)rule;
                    if (player.IsMagic)
                    {
                        if (player.CurrentPosition == ladderRule.Top
                           && board.Cells[ladderRule.Bottom].PlayerInsideCount == 0)
                        {
                            player.CurrentPosition = ladderRule.Bottom;
                        }
                    }
                    else
                    {
                        if (player.CurrentPosition == ladderRule.Bottom 
                            && board.Cells[ladderRule.Bottom].PlayerInsideCount == 0)
                        {
                            player.CurrentPosition = ladderRule.Top;
                        }
                    }
                    break;
                case RuleType.E:
                    var escalatorRule = (EscalatorRule)rule;
                    var positionsToBeMoved = board.SideLength * diceValue;
                    if (player.IsMagic)
                    {
                        if (player.CurrentPosition > positionsToBeMoved)
                        {
                            player.CurrentPosition = player.CurrentPosition - positionsToBeMoved;
                        }
                        else
                        {
                            player.CurrentPosition = player.CurrentPosition % board.SideLength;
                        }
                    }
                    else
                    {
                        var positionsLeft = board.NoOfCells - player.CurrentPosition;
                        if (positionsLeft >= positionsToBeMoved)
                        {
                            player.CurrentPosition = player.CurrentPosition + positionsToBeMoved;
                        }
                        else
                        {
                            player.CurrentPosition = player.CurrentPosition +
                                (positionsLeft - (positionsLeft % board.SideLength));
                        }
                    }
                    break;
                case RuleType.T:
                    var trampolineRule = (TrampolineRule)rule;
                    positionsToBeMoved = diceValue;
                    if(player.IsMagic)
                    {
                        player.CurrentPosition = player.CurrentPosition - 
                            Math.Min(positionsToBeMoved, player.CurrentPosition - 1);
                    }
                    else
                    {
                        var positionsLeft = board.NoOfCells - player.CurrentPosition;
                        player.CurrentPosition = player.CurrentPosition + Math.Min(positionsToBeMoved, positionsLeft);
                    }
                    break;
                case RuleType.P:
                    var pitstopRule = (PitstopRule)rule;
                    player.EnergyLevel = player.EnergyLevel + (int)(Math.Pow(pitstopRule.UnitsOfEnergy, 2) / 3);
                    break;
                case RuleType.ME:                    
                    player.CurrentPosition = player.GetPostionBeforeTurns(diceValue);
                    break;
                case RuleType.MA:
                    player.IsMagic = !player.IsMagic;                    
                    break;
                default:
                    return true;
            }
            return true;
        }
    }
}
