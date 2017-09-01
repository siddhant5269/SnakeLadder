using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLadder.Rules;
using System.Collections;

namespace SnakeLadder
{
    class Program
    {
        static void Main(string[] args)
        {

            var game = new Game();
            var ruleManager = new RuleManager();
            var gameManager = new GameManager(game,ruleManager);

            if (!Int32.TryParse(Console.ReadLine(), out int noOfCells))
            {
                Console.WriteLine("Not Proper Size");
                return;
            }
            gameManager.CreateBoard(noOfCells);
            if (!Int32.TryParse(Console.ReadLine(), out int noOfPlayers))
            {
                Console.WriteLine("Invalid no of players");
                return;
            }
            gameManager.CreatePlayers(noOfPlayers);

            var applyingRule = true;

            while (applyingRule)
            {
                var ruleString = Console.ReadLine();
                gameManager.TryAssignRule(ruleString);
                applyingRule = !string.IsNullOrEmpty(ruleString);
            }

            if (gameManager.IsValidGame())
            {
                gameManager.IntilizeGameParameters();
            }
        }
    }
}
