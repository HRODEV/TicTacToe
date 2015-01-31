using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Logic
{
    public class Board
    {
        internal Board()
        {
            Fields = new BoardField[3, 3];
            for(int i=0;i<9;i++)
            {
                Fields[i / 3, i % 3] = new BoardField();
            }
        }

        public BoardField[,] Fields { get; private set; }
    }
}
