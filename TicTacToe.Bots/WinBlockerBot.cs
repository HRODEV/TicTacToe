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
                //verticaal
                symbols = new[] { board.Fields[i,0].FieldStatus, board.Fields[i, 1].FieldStatus, board.Fields[i, 2].FieldStatus };
                if (symbols.Count(s => s == opSymbol) == 2 && symbols.Count(s => s == FieldSymbol.Empty) == 1)
                {
                    player.PlayTurn(i, symbols.ToList().IndexOf(FieldSymbol.Empty));
                    return;
                }

                //diagonaal 1
                symbols = new[] { board.Fields[0, 0].FieldStatus, board.Fields[1, 1].FieldStatus, board.Fields[2, 2].FieldStatus };
                if (symbols.Count(s => s == opSymbol) == 2 && symbols.Count(s => s == FieldSymbol.Empty) == 1)
                {
                    for (int j = 0; j < 3;j++ )
                    {
                        if(board.Fields[i,i].FieldStatus == FieldSymbol.Empty)
                        {
                            player.PlayTurn(i, i);
                        }
                    }
                    return;
                }

                //diagonaal 2
                symbols = new[] { board.Fields[2, 0].FieldStatus, board.Fields[1, 1].FieldStatus, board.Fields[0, 2].FieldStatus };
                if (symbols.Count(s => s == opSymbol) == 2 && symbols.Count(s => s == FieldSymbol.Empty) == 1)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board.Fields[2-i, i].FieldStatus == FieldSymbol.Empty)
                        {
                            player.PlayTurn(2-i, i);
                        }
                    }
                    return;
                }
            }

            base.player_OnTurn(sender, e);
        }
    }
}
