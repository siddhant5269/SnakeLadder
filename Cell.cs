using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    class Cell
    {
        public int CellId { get; set; }
        public Dictionary<string,List<int>> Rules { get; set; }
    }
}
