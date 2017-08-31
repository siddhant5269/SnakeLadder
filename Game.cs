using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    public class Game
    {
        public Player[] Players { get; set; }
        public Board Board { get; set; }
        public int CurrentPlayerIndex { get; set; }
        public Player CurrentPlayer { get { return Players[CurrentPlayerIndex]; } }

        

        /*public Player[] Players { get; set; }

        public void PlayGame()
        {         

            Board board;
            if (!Int32.TryParse(Console.ReadLine(), out int noOfCells))
            {
                Console.WriteLine("Not Proper Size");
                return;
            }
            board = new Board(noOfCells);
            if (!Int32.TryParse(Console.ReadLine(), out int noOfPlayers))
            {
                Console.WriteLine("Invalid no of players");
                return;
            }

            Players = new Player[noOfPlayers].Select(cell => new Player()).ToArray();
            var applyingRule = true;

            while (applyingRule)
            {
                var ruleString = Console.ReadLine();
                if (RuleUtilities.TryParseRule(ruleString, out Rule rule))
                {
                    RuleUtilities.ValidateApplyRule(rule, board);
                }

                applyingRule = !string.IsNullOrEmpty(ruleString);
            }

            foreach (var player in Players)
            {
                player.EnergyLevel = board.Cells[1].Rules[RuleType.P][0];
                player.CurrentPositionCursor = 0;
                player.LastPositions[0] = 1;
            }

            var currentPlayerIndex = 0;
            var currentPlayer = Players[0];
            string startPosition;            
            while (true)
            {
                if(Int32.TryParse(Console.ReadLine(),out int diceValue))
                {
                    Console.WriteLine(diceValue);
                    startPosition = currentPlayer.LastPositions[currentPlayer.CurrentPositionCursor].ToString();
                    board.ApplyMove(currentPlayer, diceValue);
                    Console.WriteLine(startPosition + currentPlayer.PathTravelled);

                    if (HasPlayerWon(currentPlayer,board))
                    {
                        Console.WriteLine(CreateDisplayScores(currentPlayerIndex));
                        break;
                    }

                    currentPlayerIndex = currentPlayerIndex + 1 / noOfPlayers;

                    Console.WriteLine(CreateDisplayScores(currentPlayerIndex));                    
                }
            }
        }

        private bool HasPlayerWon(Player player,Board board)
        {
            return player.LastPositions[player.CurrentPositionCursor] == board.Cells.Count() - 1;
        }

        private string CreateDisplayScores(int currentPlayerIndex)
        {
            var noOfPlayers = Players.Count();
            var scoreStirng = "";
            for (int i=0; i< noOfPlayers; i++)
            {
                var playerIndex = (currentPlayerIndex + i) / noOfPlayers;
                var player = Players[playerIndex];
                scoreStirng  += "[" + playerIndex + ":" + player.LastPositions[player.CurrentPositionCursor] + ":" + player.EnergyLevel + "]";
            }
            return scoreStirng;            
        }*/
    }
}
