using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.Logic;

namespace TicTacToe.Bots
{
    public class RandomBot : AbstactBot
    {
        public RandomBot(Player player, Board board) : base(player, board)
        {
        }
    }
}
