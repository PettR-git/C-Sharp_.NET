using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitiesLib;

namespace Blackjack
{
    public partial class InitializeGameForm : Form
    {
        public delegate void DecksAndPlayersInfo(int sendDecks, int sendPlayers);         //Delegate to pass initInfo to MainForm
        public DecksAndPlayersInfo decksPlayersInfo;
        private ConvertToNumerical convert;
        public InitializeGameForm()
        {
            InitializeComponent();

            InitializeGUI();
            convert = new ConvertToNumerical();
        }

        private void InitializeGUI()
        {
            tbxDecks.Text = "1";
            tbxPlayers.Text = "2";
        }

        //Pass Initialization-info
        private void btnLetsGo_Click(object sender, EventArgs e)
        {
            int decks = convert.ConvertStringToInteger(tbxDecks.Text);
            int players = convert.ConvertStringToInteger(tbxPlayers.Text);

            if (decksPlayersInfo != null)
            {
                if (players * 4 + 4 > decks*52)
                {
                    MessageBox.Show("Too many players for that amount of decks!");
                    return;
                }
                else
                {
                    decksPlayersInfo(decks, players);
                }
            }
            this.Close();
        }
    }
}
