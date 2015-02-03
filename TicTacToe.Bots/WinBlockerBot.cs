using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.Logic;

namespace TicTacToe.Bots
{
    /// <summary>
    /// this bot checks firts if the can block to win otherwise the will fallback to random
    /// </summary>
    public class WinBlockerBot : RandomBot
    {
        public WinBlockerBot(Player player, Board board) : base(player, board, false)
        {
            player.OnTurn += player_OnTurn_block;
        }

        void player_OnTurn_block(object sender, EventArgs e)
        {
            FieldSymbol opSymbol = player.Symbol == FieldSymbol.Cross ? FieldSymbol.Circle : FieldSymbol.Cross;

            for (int i = 0; i < 3; i++)
            {
                //horizontal check
                var symbols = new[] { board.Fields[0, i].FieldStatus, board.Fields[1, i].FieldStatus, board.Fields[2, i].FieldStatus };
                if (symbols.Count(s => s == opSymbol) == 2 && symbols.Count(s => s == FieldSymbol.Empty) == 1)
                {
                    player.PlayTurn(symbols.ToList().IndexOf(FieldSymbol.Empty), i);
                    return;
                }
            }

            base.player_OnTurn(sender, e);
        }
    }
}
