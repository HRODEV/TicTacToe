using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Logic;

namespace TicTacToe.Bots
{
    public class CheatBot : AbstactBot
    {
        public CheatBot(Player player, Board board) : base(player, board)
        {
            player.OnTurn += Player_OnTurn;
        }

        private void Player_OnTurn(object sender, EventArgs e)
        {
            var emptyField = this.board.Fields[0, 0].FieldStatus == FieldSymbol.Empty ? this.board.Fields[0, 0] : this.board.Fields[0, 1];
            this.board.Fields[0, 0] = emptyField;
            this.board.Fields[0, 1] = emptyField;
            this.board.Fields[0, 2] = emptyField;

            this.player.PlayTurn(0, 0);
        }
    }
}
