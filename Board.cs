using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLadder.Rules;

namespace SnakeLadder
{
    public class Board
    {
        public Board(int noOfCells)
        {
            Cells = new Cell[noOfCells + 1].Select(cell => new Cell(new Dictionary<RuleType,IRule> ())).ToArray();
        }

        public Cell[] Cells { get; set; }
        public int SideLength { get; set; }
        public int NoOfCells { get; set; }       
    }
}
