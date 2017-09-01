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
                    if (snakeRule.ValidateInitialize(ruleParameters) && snakeRule.TryApplyOnBoard(game.Board))
                    {
                        isValid = true;
                        game.Board.Cells[snakeRule.Head].Rules.Add(snakeRule.Type, snakeRule);
                        game.Board.Cells[snakeRule.Tail].Rules.Add(snakeRule.Type, snakeRule);
                    }
                    break;
                case RuleType.L:
                    var ladderRule = new LadderRule();
                    if (ladderRule.ValidateInitialize(ruleParameters) && ladderRule.TryApplyOnBoard(game.Board))
                    {
                        isValid = true;
                        game.Board.Cells[ladderRule.Bottom].Rules.Add(ladderRule.Type, ladderRule);
                        game.Board.Cells[ladderRule.Top].Rules.Add(ladderRule.Type, ladderRule);
                    }
                    break;
                case RuleType.E:
                    var escalatorRule = new EscalatorRule();
                    if (escalatorRule.ValidateInitialize(ruleParameters) && escalatorRule.TryApplyOnBoard(game.Board))
                    {
                        isValid = true;
                        game.Board.Cells[escalatorRule.StartPosition].Rules.Add(escalatorRule.Type, escalatorRule);
                    }
                    break;
                case RuleType.T:
                    var trampolineRule = new TrampolineRule();
                    if (trampolineRule.ValidateInitialize(ruleParameters) && trampolineRule.TryApplyOnBoard(game.Board))
                    {
                        isValid = true;
                        game.Board.Cells[trampolineRule.StartPosition].Rules.Add(trampolineRule.Type, trampolineRule);
                    }
                    break;
                case RuleType.P:
                    var pitstopRule = new PitstopRule();
                    if (pitstopRule.ValidateInitialize(ruleParameters) && pitstopRule.TryApplyOnBoard(game.Board))
                    {
                        isValid = true;
                        game.Board.Cells[pitstopRule.PitPosition].Rules.Add(pitstopRule.Type, pitstopRule);
                    }
                    break;
                case RuleType.ME:
                    var memoryRule = new MemoryRule();
                    if (memoryRule.ValidateInitialize(ruleParameters) && memoryRule.TryApplyOnBoard(game.Board))
                    {
                        isValid = true;
                        game.Board.Cells[memoryRule.Position].Rules.Add(memoryRule.Type, memoryRule);
                    }
                    break;
                case RuleType.MA:
                    var magicRule = new MagicRule();
                    if (magicRule.ValidateInitialize(ruleParameters) && magicRule.TryApplyOnBoard(game.Board))
                    {
                        isValid = true;
                        game.Board.Cells[magicRule.Position].Rules.Add(magicRule.Type, magicRule);
                    }
                    break;               
            }
            return isValid;
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
                        }
                    }
                    else
                    {

                        if (snakeRule.Hunger > 0 && player.CurrentPosition == snakeRule.Head)
                        {
                            player.CurrentPosition = snakeRule.Tail;
                        }
                    }
                    snakeRule.DecreaseHunger();
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
                    if (player.IsMagic)
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
                    player.EnergyLevel = (int)(Math.Pow(pitstopRule.UnitsOfEnergy, 2) / 3);
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
