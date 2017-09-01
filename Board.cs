using System.Collections.Generic;
using System.Linq;
using SnakeLadder.Rules;
using System;

namespace SnakeLadder
{
    public class Board
    {
        public Board(int noOfCells)
        {
            Cells = new Dictionary<int, Cell>();
            for(int key=1; key <= noOfCells; key++)
            {
                Cells.Add(key, new Cell(new Dictionary<RuleType, IRule>()));
            }            
            NoOfCells = noOfCells;
            SideLength = (int)Math.Pow(noOfCells, 0.5);
        }

        public Dictionary<int, Cell> Cells { get; }
        public int SideLength { get; set; }
        public int NoOfCells { get; set; }
    }
}
