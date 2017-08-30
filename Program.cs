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

            var board = new Board1(64);
            /*create players*/
            var numberofplayer = 2;
            var player = new Hashtable();
            for(int i =1; i <= numberofplayer; i++)
            {
                player.Add(i.ToString(), new Player(board.BoardMatrix[1]));
            }            

            var sRule = "L 2 9";
            switch(sRule.Split(' ')[0].ToUpper())
            {              
                case "S":                   
                    var sr = new SnakeRule(sRule);
                    sr.ValidateAndCreate();
                    board.BoardMatrix[sr.Head].Rules.Add(sr);
                    board.BoardMatrix[sr.Tail].Rules.Add(sr);
                    break;
                case "L":
                    var lr = new LadderRule("L 2 9");
                    lr.ValidateAndCreate();
                    board.BoardMatrix[lr.Head].Rules.Add(lr);
                    board.BoardMatrix[lr.Tail].Rules.Add(lr);
                    break;
                //case "P":
                //    var pr = new PitstopRule(sRule);
                //    pr.ValidateAndCreate();
                //    board.BoardMatrix[pr.Head].Rules.Add(pr);                   
                //    break;
            }            

            var input = 2;
            var player1 = ((Player)player["1"]);



            var position = player1.CurrentPosition.id + input;
            player1.CurrentPosition = board.BoardMatrix[position];  /// check 1
            board.Evalute(player1);
            





            //var game = new Game();
            //game.PlayGame();
        }
    }
}
