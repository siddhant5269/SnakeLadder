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
            currentPlayer.DecreaseEnergy();
            if (!IsDiceWaste(diceValue, currentPlayer.CurrentPosition, _game.Board.NoOfCells))
            {                
                _game.Board.Cells[currentPlayer.CurrentPosition].DecreasePlayerInsideCount();

                var position = currentPlayer.CurrentPosition + diceValue;
                currentPlayer.CurrentPosition = position;

                _game.Board.Cells[currentPlayer.CurrentPosition].IncreasePlayerInsideCount();

                int oldPosition = 0;
                while (position != oldPosition)
                {
                    oldPosition = position;
                    var currentCell = _game.Board.Cells[position];
                    currentCell.DecreasePlayerInsideCount();

                    ApplyCellRulesOnPlayer(currentPlayer, currentCell, diceValue);

                    position = currentPlayer.CurrentPosition;
                    currentCell = _game.Board.Cells[currentPlayer.CurrentPosition];
                    currentCell.IncreasePlayerInsideCount();
                }
                if (!IsGameOver() && currentPlayer.IsOutOfEnergy())
                {
                    InitializePlayer(currentPlayer);
                }
                else
                {
                    currentPlayer.SetTurnOver();
                }
            }            
        }

        private void ApplyCellRulesOnPlayer(Player player,Cell cell,int diceValue)
        {
            foreach (RuleType ruleType in Enum.GetValues(typeof(RuleType)))
            {
                if (cell.Rules.ContainsKey(ruleType))
                {
                    _ruleManager.ApplyRule(cell.Rules[ruleType], player, _game.Board, diceValue);
                }
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
                _game.Board.Cells[Constants.StartCellIndex].IncreasePlayerInsideCount();
            }          
        }


        private void InitializePlayer(Player player)
        {
            player.CurrentPosition = Constants.StartCellIndex;             
            ApplyCellRulesOnPlayer(player,_game.Board.Cells[player.CurrentPosition],0);
            player.SetTurnOver();
        }

        
        public bool IsValidGame()
        {
            //once validation parameters increase push into different functions
            return _game.Board.Cells[Constants.StartCellIndex].Rules.ContainsKey(RuleType.P);
        }

        public bool IsGameOver()
        {
            return _game.Board.Cells[_game.CurrentPlayer.CurrentPosition] == _game.Board.Cells[_game.Board.NoOfCells];
        }

        public void SetNextPlayer()
        {
            _game.CurrentPlayerIndex = (_game.CurrentPlayerIndex + 1) % _game.Players.Count();           
        }

        public string CreateDisplayScores()
        {
            var noOfPlayers = _game.Players.Count();
            var scoreStirng = "";
            for (int i = 0; i < noOfPlayers; i++)
            {
                var playerIndex = (_game.CurrentPlayerIndex + i) % noOfPlayers;
                var player = _game.Players[playerIndex];
                scoreStirng += "[" + playerIndex + ":" + player.CurrentPosition + ":" + player.EnergyLevel + "]";
            }
            return scoreStirng;
        }
    }
}
