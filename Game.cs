using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    class Game
    {
        public Player[] Players { get; set; }

        public void PlayGame()
        {
            var isWon = false;

            Board board = new Board();
            if (Int32.TryParse(Console.ReadLine(), out int noOfCells))
            {
                board.Cells = new Cell[noOfCells + 1].Select(cell => new Cell()).ToArray();
            }

            if (Int32.TryParse(Console.ReadLine(), out int noOfPlayers))
            {
                Players = new Player[noOfPlayers].Select(cell => new Player()).ToArray();
            }

            var applyingRule = true;
            Rule rule;
            while (applyingRule)
            {
                var ruleString = Console.ReadLine();
                if (RuleUtilities.TryParseRule(ruleString, out rule))
                {
                    RuleUtilities.ValidateApplyRule(rule, board);
                }

                applyingRule = !string.IsNullOrEmpty(ruleString);
            }

            foreach(var player in Players)
            {
                player.EnergyLevel = board.Cells[1].Rules[RuleType.P][0];
                player.CurrentPositionCusror = 0;
                player.LastPositions[0] = 1;
            }

            var currentPlayerIndex = 0;
            var currentPlayer = Players[0];
            string startPosition;            
            while (!isWon)
            {
                if(Int32.TryParse(Console.ReadLine(),out int diceValue))
                {
                    Console.WriteLine(diceValue);
                    startPosition = currentPlayer.LastPositions[currentPlayer.CurrentPositionCusror].ToString();
                    board.ApplyMove(currentPlayer, diceValue);
                    Console.WriteLine(startPosition + currentPlayer.PathTravelled);

                    currentPlayerIndex = currentPlayerIndex + 1 / noOfPlayers;

                    Console.WriteLine(CreateDisplayScores(currentPlayerIndex));
                }
            }
        }

        private string CreateDisplayScores(int currentPlayerIndex)
        {
            var noOfPlayers = Players.Count();
            var scoreStirng = "";
            for (int i=0; i< noOfPlayers; i++)
            {
                var playerIndex = (currentPlayerIndex + i) / noOfPlayers;
                var player = Players[playerIndex];
                scoreStirng  += "[" + playerIndex + ":" + player.LastPositions[player.CurrentPositionCusror] + ":" + player.EnergyLevel + "]";
            }
            return scoreStirng;            
        }
    }
}
