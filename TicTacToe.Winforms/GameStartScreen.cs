using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe.Winforms
{
    public partial class GameStartScreen : Form
    {
        Bots.BotFactory factory;
        public GameStartScreen()
        {
            InitializeComponent();

            factory = new Bots.BotFactory();

            //add list with names
            comboBoxBotNames.Items.AddRange(factory.BotTypeNames.ToArray());
            comboBoxBotNames.Text = comboBoxBotNames.Items[0].ToString();
        }

        private void HasBot_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxBotNames.Enabled = HasBot.Checked;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var game = new Logic.Game("player1", HasBot.Checked ? comboBoxBotNames.Text : "player2");

            //maak bot met gegevens er hoeft voor de rest niks mee gedaan worden alles wordt intern afgehandeld
            if (HasBot.Checked)
                factory.CreatBot(comboBoxBotNames.Text, game.Board, game.Players[1]);

            Form f = new MainForm(game);

            f.Show();
        }
    }
}
