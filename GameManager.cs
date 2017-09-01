using System;
using System.Linq;

namespace SnakeLadder
{
    public class GameManager
    {
        private readonly Game _game;
        private readonly RuleManager _ruleManager;
        public GameManager(Game game,RuleManager ruleManager)
        {
            _game = game;
            _ruleManager = ruleManager;
        }

        public void CreateBoard(int noOfCells)
        {
            _game.Board = new Board(64);
        }

        public void CreatePlayers(int noOfPlayers)
        {
            _game.Players = new Player[noOfPlayers].Select(p => { return new Player(); }).ToArray();
        }

        public bool TryAssignRule(string ruleString)
         {
            return _ruleManager.TryAssignRule(ruleString,_game);
        }

        public void PlayDice(int diceValue)
        {            
            var currentPlayer = _game.CurrentPlayer;

            if (!IsDiceWaste(diceValue, currentPlayer.CurrentPosition, _game.Board.NoOfCells))
            {
                var position = currentPlayer.CurrentPosition + diceValue;
                int oldPosition = 0;
                while (position != oldPosition)
                {
                    oldPosition = position;
                    var currentCell = _game.Board.Cells[position];                    
                    foreach (RuleType ruleType in Enum.GetValues(typeof(RuleType)))
                    {
                        if (currentCell.Rules.ContainsKey(ruleType))
                        {
                            _ruleManager.ApplyRule(currentCell.Rules[ruleType], currentPlayer, _game.Board, diceValue);
                        }
                    }
                    position = currentPlayer.CurrentPosition;
                }
                currentPlayer.DecreaseEnergy();
            }            
        }

        private bool IsDiceWaste(int diceValue,int playerCurrentPosition,int sizeOfBoard)
        {
            return diceValue + playerCurrentPosition > sizeOfBoard;
        }

        public void IntilizeGameParameters()
        {
            foreach (var player in _game.Players)
            {
                InitializePlayer(player);
            }
        }


        private void InitializePlayer(Player player)
        {
            player.CurrentPosition = 1;
            _ruleManager.ApplyRule(_game.Board.Cells[1].Rules[RuleType.P], player, _game.Board, 0);
        }

        
        public bool IsValidGame()
        {
            //once validation parameters increase push into different functions
            return _game.Board.Cells[Constants.StartCellIndex].Rules.ContainsKey(RuleType.P);
        }

        public bool IsGameOver()
        {
            return _game.CurrentPlayer.CurrentPosition == _game.Board.NoOfCells;
        }

        public void SetNextPlayer()
        {
            _game.CurrentPlayerIndex = _game.CurrentPlayerIndex + 1 % _game.Players.Count();            
        }

        private string CreateDisplayScores(int currentPlayerIndex)
        {
            var noOfPlayers = _game.Players.Count();
            var scoreStirng = "";
            for (int i = 0; i < noOfPlayers; i++)
            {
                var playerIndex = (currentPlayerIndex + i) / noOfPlayers;
                var player = _game.Players[playerIndex];
                scoreStirng += "[" + playerIndex + ":" + player.CurrentPosition + ":" + player.EnergyLevel + "]";
            }
            return scoreStirng;
        }
    }
}
