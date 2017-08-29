using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    class Board
    {
        public Cell[] Cells { get; set; }
        public int SideLength { get; set; }

        public void ApplyMove(Player player,int diceValue)
        {            
            var currentCellNumber = player.LastPositions[player.CurrentPositionCusror];
            var currentCell = Cells[currentCellNumber];
            Dictionary<RuleType,List<int>> currentCellRules;
            List<RuleType> currentCellRuleTypeCollection;
            currentCellNumber = currentCellNumber + diceValue;

            var isCellInvestigationRequired = true;
            
            while (isCellInvestigationRequired && currentCellNumber < Cells.Count())
            {
                currentCell = Cells[currentCellNumber];
                currentCellRules = currentCell.Rules;                

                if (currentCellRules.ContainsKey(RuleType.MA))
                {
                    player.IsMagic = !player.IsMagic;
                }

                if (currentCellRules.ContainsKey(RuleType.ME))
                {
                    Console.WriteLine("Memoried");
                }

                if (currentCellRules.ContainsKey(RuleType.S))
                {
                    Console.WriteLine("Snaked");
                }

                if (currentCellRules.ContainsKey(RuleType.L))
                {
                    Console.WriteLine("Laddered");
                }

                if (currentCellRules.ContainsKey(RuleType.T))
                {
                    Console.WriteLine("Trampolined");
                }

                if (currentCellRules.ContainsKey(RuleType.E))
                {
                    Console.WriteLine("Elevatored");
                }

                if (currentCellRules.ContainsKey(RuleType.P))
                {
                    Console.WriteLine("Pitspotted");
                }

                isCellInvestigationRequired = false;
            }             
        }        
    }
}
