using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Logic
{
    public class Player
    {
        //only set in constructor
        readonly FieldSymbol symbol;
        bool hasTurn;
        Game game;
        public event EventHandler OnTurn;

        public event EventHandler OnWin;

        public event EventHandler OnLose;

        internal Player(Game game, FieldSymbol playerSymbol, string name)
        {
            this.game = game;
            symbol = playerSymbol;
            Name = name;
        }
    
        public bool HasTurn
        {
            get
            {
                return hasTurn;
            }
            internal set
            {
                //nothing change
                if (hasTurn == value) return;
                hasTurn = value;
                //not thread safe way
                if (OnTurn != null && value)
                    OnTurn(this, EventArgs.Empty);
            }
        }

        public FieldSymbol Symbol { get { return symbol; } }

        public string Name { get; private set; }

        public void PlayTurn(int x , int y)
        {
            if (!x.IsBetween(0, 2) || !y.IsBetween(0, 2)) throw new ArgumentOutOfRangeException("x/y", "x and y must both between 0 and 2");
            game.PlayTurn(this, x, y);
        }

        internal void HasWin()
        {
            if (OnWin != null)
                OnWin(this, EventArgs.Empty);
        }

        internal void HasLosse()
        {
            if (OnLose != null)
                OnLose(this, EventArgs.Empty);
        }
    }
}
