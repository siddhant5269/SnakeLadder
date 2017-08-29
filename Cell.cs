using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    class Cell
    {        
        public Dictionary<RuleType,List<int>> Rules { get; set; }
        public int PlayerInsideCount { get; set; }
    }
}
