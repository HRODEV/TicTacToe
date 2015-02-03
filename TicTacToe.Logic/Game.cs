using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Logic
{
    public class Game
    {
        private int indexActivePlayer;

        public event EventHandler OnActivePlayerChange;

        public event EventHandler OnPlayerHasWon;

        public Game(string playerName1, string playerName2)
        {
            //check on null or empty
            if (string.IsNullOrWhiteSpace(playerName1)) throw new ArgumentNullException("playerName1");
            if (string.IsNullOrWhiteSpace(playerName2)) throw new ArgumentNullException("playerName2");


            //intitialize object for game
            Board = new Board();
            Turn = 1;
            indexActivePlayer = (new Random()).Next(1);//set o 0 or 1
            Players = new[]{
                new Player(this, FieldSymbol.Circle, playerName1),
                new Player(this, FieldSymbol.Cross, playerName2)
            };
        }

        public int Turn { get; private set; }

        public Player[] Players { get; private set; }

        public Board Board{get;private set;}
        

        public Player ActivePlayer
        {
            get
            {
                return Players[indexActivePlayer];
            }
        }

        internal void PlayTurn(Player player, int x, int y)
        {
            /*
             * check if player is onturn
             * check if field isempty
            */
            if (!object.ReferenceEquals(player, ActivePlayer)) throw new Exception();
            if (Board.Fields[x, y].FieldStatus != FieldSymbol.Empty) throw new WrongPlayTurnException();

            //set field on on player symbol.
            Board.Fields[x, y].FieldStatus = player.Symbol;

            //if game is not end trigger actions for next turn
            if(!this.isGameEnd())
            {
                this.newTurn();
            }
        }

        private void newTurn()
        {
            Turn++;

            //set first player on inactive
            ActivePlayer.HasTurn = false;

            //here are always 2 players so %2
            indexActivePlayer = ++indexActivePlayer % 2;

            //set player on active
            ActivePlayer.HasTurn = true;

            //active player has change so trigger event
            if (OnActivePlayerChange != null)
                OnActivePlayerChange(ActivePlayer, EventArgs.Empty);
        }

        private bool isGameEnd()
        {
            if (Turn == 9)
                return true;

            //check horizontal and vertical
            for (int i = 0; i < 3; i++)
            {
                //horizontal
                if(Board.Fields[i,0].FieldStatus !=  FieldSymbol.Empty && IsSame(Board.Fields[i,0].FieldStatus, Board.Fields[i,1].FieldStatus, Board.Fields[i,2].FieldStatus))
                {
                    WinnerWithSymbol(Board.Fields[i, 0].FieldStatus);
                    return true;
                }
                //vertical
                else if (Board.Fields[0, i].FieldStatus != FieldSymbol.Empty && IsSame(Board.Fields[0, i].FieldStatus, Board.Fields[1, i].FieldStatus, Board.Fields[2, i].FieldStatus)) 
                {
                    WinnerWithSymbol(Board.Fields[0, i].FieldStatus);
                    return true;
                }
            }
            //daigonaal
            if (Board.Fields[1, 1].FieldStatus != FieldSymbol.Empty
                && (IsSame(Board.Fields[0, 0].FieldStatus, Board.Fields[1, 1].FieldStatus, Board.Fields[2, 2].FieldStatus)
                || IsSame(Board.Fields[0, 2].FieldStatus, Board.Fields[1, 1].FieldStatus, Board.Fields[2, 0].FieldStatus)))
            {
                WinnerWithSymbol(Board.Fields[1,1].FieldStatus);
                return true;
            }

            return false;
        }

        private void WinnerWithSymbol(FieldSymbol fieldSymbol)
        {
            if (fieldSymbol == null) throw new ArgumentNullException("fieldSymbol");
            if (fieldSymbol == FieldSymbol.Empty) throw new ArgumentException("there can be no player with symbol empty");

            //search player that wins and trigger event's
            var winningplayer = Players.FirstOrDefault(p => p.Symbol == fieldSymbol);
            var lossingplayer = Players.FirstOrDefault(p => p.Symbol != fieldSymbol);
            //null checks
            if (winningplayer == null) throw new InvalidOperationException();
            if (lossingplayer == null) throw new InvalidOperationException();
            //trigger event
            if (OnPlayerHasWon != null)
                OnPlayerHasWon(winningplayer, EventArgs.Empty);

            winningplayer.HasWin();
            lossingplayer.HasLosse();

        }

        static bool IsSame(params object[] values)
        {
            if (values == null) throw new ArgumentNullException("values");
            if (values.Length < 2) throw new ArgumentException("array mus have at least 2 objects");
            for(int i=1;i<values.Length;i++)
            {
                if (!values[0].Equals(values[i])) return false;
            }
            return true;
        }
    }
}
