using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.Logic;

namespace TicTacToe.Bots
{
    public class RandomBot : AbstactBot
    {
        Random rnd = new Random();
        public RandomBot(Player player, Board board) : base(player, board)
        {
            player.OnTurn += player_OnTurn;
        }

        protected RandomBot(Player player, Board board, bool addOnTurnListner)
            : base(player, board)
        {
            if(addOnTurnListner)
                player.OnTurn += player_OnTurn;
        }
        

        protected void player_OnTurn(object sender, EventArgs e)
        {
            while(true)
            {
                var randomTry = rnd.Next(0,9);
                if (board.Fields[randomTry / 3, randomTry % 3].FieldStatus == FieldSymbol.Empty) 
                {
                    player.PlayTurn(randomTry / 3, randomTry % 3);
                    return;
                }
            }
        }
    }
}
