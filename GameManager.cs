using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var position = currentPlayer.CurrentPosition;
            int oldPosition = 0;            
            while(position != oldPosition)
            {
                var currentCell = _game.Board.Cells[position];
                oldPosition = position;
                foreach (RuleType ruleType in Enum.GetValues(typeof(RuleType)))
                {
                    if (currentCell.Rules.ContainsKey(ruleType))
                    {
                        _ruleManager.ApplyRule(currentCell.Rules[ruleType],currentPlayer,_game.Board,diceValue);
                    }                    
                }                
                position = currentPlayer.CurrentPosition;
            }
        }

        internal void IntilizeGameParameters()
        {
            foreach (var player in _game.Players)
            {
                var pitstopRule = _game.Board.Cells[Constants.StartCellIndex].Rules[RuleType.P];
                player.EnergyLevel = 
                player.CurrentPositionCursor = 0;
                player.LastPositions[0] = 1;
            }
        }

        internal bool IsValidGame()
        {
            throw new NotImplementedException();
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
                scoreStirng += "[" + playerIndex + ":" + player.LastPositions[player.CurrentPositionCursor] + ":" + player.EnergyLevel + "]";
            }
            return scoreStirng;
        }
    }
}
