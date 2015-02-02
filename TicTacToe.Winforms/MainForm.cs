using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Logic;

namespace TicTacToe.Winforms
{
    public partial class MainForm : Form
    {
        Game game;

        public MainForm(Game game)
        {
            InitializeComponent();

            this.game = game;

            //set fields
            for(int i=0;i<9;i++)
            {
                var tempfield = new Components.BoardField(game.Board.Fields[i / 3, i % 3]);
                tempfield.Click += tempfield_Click;
                tableLayoutPanel1.Controls.Add(tempfield, i / 3, i % 3);
            }

            //set actual playername
            this.actualPlayerName.Text = game.ActivePlayer.Name;
            //listen to event for changes in the futere
            game.OnActivePlayerChange += game_OnActivePlayerChange;
            game.OnPlayerHasWon += game_OnPlayerHasWon;
        }

        void game_OnPlayerHasWon(object sender, EventArgs e)
        {
            //delete eventListner's for click
            foreach(Components.BoardField field in tableLayoutPanel1.Controls)
            {
                field.Click -= tempfield_Click;
            }

            MessageBox.Show(string.Format("player: {0} has won", (sender as Player).Name));
        }

        void tempfield_Click(object sender, EventArgs e)
        {
            var clickPos = tableLayoutPanel1.Controls.IndexOf(sender as Control);
            //check if field is empty, otherwise there will be throw an error
            if(game.Board.Fields[clickPos / 3, clickPos % 3].FieldStatus == FieldSymbol.Empty)
                game.ActivePlayer.PlayTurn(clickPos / 3, clickPos % 3);
        }

        void game_OnActivePlayerChange(object sender, EventArgs e)
        {
            this.actualPlayerName.Text = game.ActivePlayer.Name;
        }
    }
}
