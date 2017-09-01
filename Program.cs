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
        private static int inputIndex = 0;
        static void Main(string[] args)
        {

            var game = new Game();
            var ruleManager = new RuleManager();
            var gameManager = new GameManager(game,ruleManager);

            if (!Int32.TryParse(getInput(), out int noOfCells))
            {
                Console.WriteLine("Not Proper Size");
                return;
            }
            gameManager.CreateBoard(noOfCells);
            if (!Int32.TryParse(getInput(), out int noOfPlayers))
            {
                Console.WriteLine("Invalid no of players");
                return;
            }
            gameManager.CreatePlayers(noOfPlayers);            

            while (true)
            {
                var ruleString = getInput();
                if (string.IsNullOrEmpty(ruleString))
                {
                    break;
                }
                if (!gameManager.TryAssignRule(ruleString))
                {
                    Console.WriteLine("Not a valid rule for the game setup.");
                }                
            }

            if (gameManager.IsValidGame())
            {
                gameManager.IntilizeGameParameters();
            }

            while(true)
            {
                if(Int32.TryParse(getInput(), out int diceValue))
                {
                    gameManager.PlayDice(diceValue);
                }
                if (gameManager.IsGameOver())
                {
                    break;
                }
                gameManager.SetNextPlayer();
                Console.WriteLine(gameManager.CreateDisplayScores());
            }
        }

        private static string getInput()
        {
            var inputArray = new []{ "64", "2", "S 2 9 4", "P 1 32", "T 7", "E 11", "P 16 5", "ME 23", "MA 8", "MA 22", "S 1 27 6" ,"","3","2","4","3","2","2","2","4","6","3"};
            return inputArray[inputIndex++];
        }
    }
}
