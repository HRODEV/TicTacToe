using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Logic;

namespace TicTacToe.Bots
{
    public abstract class AbstactBot
    {
        protected Board board;
        protected Player player;
        public AbstactBot(Player player, Board board)
        {
            this.player = player;
            this.board = board;
        }
    }
}
