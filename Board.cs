using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLadder.Rules;

namespace SnakeLadder
{
    //public class Board1
    //{
    //    private Cell1[] _cells;

    //    public Cell1[] BoardMatrix
    //    {
    //        get { return this._cells;  }
    //    }

    //    public Board1(int size)
    //    {
    //        _cells = new Cell1[size + 1];
    //        _cells[0] = new Cell1();
    //        for(int i = 1; i <= size; i++)
    //        {
    //            _cells[i] = new Cell1() { id = i };
    //        }           
    //    }

    //    public void Evalute(Player p)
    //    {
    //        foreach (Rule r in p.CurrentPosition.Rules)
    //        {
    //            var current = r.Eval(p.CurrentPosition.id);
    //            p.CurrentPosition = this.BoardMatrix[current];
    //        }
    //    }

    //}

    public class Board
    {
        public Board(int noOfCells)
        {
            Cells = new Cell[noOfCells + 1].Select(cell => new Cell(new Dictionary<RuleType, List<int>>())).ToArray();
        }

        public Cell[] Cells { get; set; }
        public int SideLength { get; set; }
        public int NoOfCells { get; set; }

        //public void ApplyMove(Player player, int diceValue)
        //{
        //    var currentCellNumber = player.LastPositions[player.CurrentPositionCursor];
        //    var currentCell = Cells[currentCellNumber];
        //    Dictionary<RuleType, List<int>> currentCellRules;
        //    currentCellNumber = currentCellNumber + diceValue;

        //    var isCellInvestigationRequired = true;

        //    while (isCellInvestigationRequired && currentCellNumber < Cells.Count())
        //    {
        //        currentCell = Cells[currentCellNumber];
        //        currentCellRules = currentCell.Rules;

        //        if (currentCellRules.ContainsKey(RuleType.MA))
        //        {
        //            player.IsMagic = !player.IsMagic;
        //        }

        //        if (currentCellRules.ContainsKey(RuleType.ME))
        //        {
        //            Console.WriteLine("Memoried");
        //        }

        //        if (currentCellRules.ContainsKey(RuleType.S))
        //        {
        //            Console.WriteLine("Snaked");
        //        }

        //        if (currentCellRules.ContainsKey(RuleType.L))
        //        {
        //            Console.WriteLine("Laddered");
        //        }

        //        if (currentCellRules.ContainsKey(RuleType.T))
        //        {
        //            Console.WriteLine("Trampolined");
        //        }

        //        if (currentCellRules.ContainsKey(RuleType.E))
        //        {
        //            Console.WriteLine("Elevatored");
        //        }

        //        if (currentCellRules.ContainsKey(RuleType.P))
        //        {
        //            Console.WriteLine("Pitspotted");
        //        }

        //        isCellInvestigationRequired = false;
        //    }
        //}
    }
}
