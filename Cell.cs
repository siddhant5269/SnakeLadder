using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLadder.Rules;
using System.Collections;

namespace SnakeLadder
{
    class Cell
    {        
        public Cell(Dictionary<RuleType,Rule> rulesDict)
        {
            Rules = rulesDict;
        }
        public Dictionary<RuleType,Rule> Rules { get; set; }
        public int PlayerInsideCount { get; set; }
    }

    public class Cell1
    {
        public Cell1()
        {
            this.id = -1;
            this.Rules = new ArrayList();
        }
        public ArrayList Rules { get; set; }
        public int id { get; set; }
        
    }
}
