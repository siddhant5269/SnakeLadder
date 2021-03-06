﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLadder.Rules;
using System.Collections;

namespace SnakeLadder
{
    public class Cell
    {
        public Cell(Dictionary<RuleType,IRule> rulesDict)
        {
            Rules = rulesDict;
        }
        public Dictionary<RuleType,IRule> Rules { get; set; }
        public int PlayerInsideCount { get; set; }

        public void DecreasePlayerInsideCount(int decreaseBy = 1)
        {
            PlayerInsideCount -= decreaseBy;
        }

        public void IncreasePlayerInsideCount(int increaseBy = 1)
        {
            PlayerInsideCount += increaseBy;
        }
    }   
}
