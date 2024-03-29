//Petter Rignell - ak5670
//Assignment 4 - Blackjack game
//Logger not implemented
//2022-10-22

using GameCardLib.Entities;
using System.Diagnostics;
using UtilitiesLib;
using UtilitiesLib.Enums;
using UtilitiesLib.Logger;
using static Blackjack.InitializeGameForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Blackjack
{
    public partial class MainForm : Form
    {
        private InitializeGameForm initializeGameForm;
        private GameManager gameManager;
        private Deck deck;
        private int playerID;
        public MainForm()
        {
            InitializeComponent();

            InitializeGUI();
            InitializeInitGameForm();
        }

        #region GUI-related
        private void InitializeGUI()
        {
            gpxPlayer.Text = "";
            lblPlayerScore.Text = "";
            lblWinner.Text = "";
            lblDealerScore.Text = "";

            ClearDealerPictureBoxes();
            ClearPlayerPictureBoxes();
        }

        private void DisableButtons()
        {
            btnHit.Enabled = false;
            btnShuffle.Enabled = false;
            btnStand.Enabled = false;
        }

        private void EnableButtons()
        {
            btnHit.Enabled = true;
            btnShuffle.Enabled = true;
            btnStand.Enabled = true;
            btnNewGame.Enabled = true;
        }
        #endregion

        #region Initialize Game

        //Create a Initializion-form and show it
        //While mainform is minimized and its buttons are disabled
        private void InitializeInitGameForm()
        {
            initializeGameForm = new InitializeGameForm();
            initializeGameForm.decksPlayersInfo = new InitializeGameForm.DecksAndPlayersInfo(InitializeGame);
            initializeGameForm.Show();
        }

        //Initialize
        private void InitializeGame(int decks, int players)
        {
            NewGame(decks, players);

            EnableButtons();
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            lblDecks.Text = "Decks: " + decks;
            lblPlayers.Text = "Players: " + players;
        }

        //Creates a new game with appropriate objects
        private void NewGame(int decks, int players)
        {
            deck = new Deck(decks);

            Dealer dealer = new Dealer();
            deck.PopFromDeck(dealer, 1);
            gpxDealer.Text = dealer.ID;
            lblDealerScore.Text = dealer.Hand.Score().ToString();
            DisplayImage(dealer, InvolvedPersons.Dealer);

            Player player;
            gameManager = new GameManager();

            for(int i = 0; i<players; i++)
            {
                playerID++;
                player = new Player();
                player.Dealer = dealer;
                player.ID = "Player" + playerID;
                deck.PopFromDeck(player, 2);
                gameManager.AddPlayer(player);   
            }

            gpxPlayer.Text = gameManager.GetPlayerAt(0).ID;
            lblPlayerScore.Text = gameManager.GetPlayerAt(0).Hand.Score().ToString();
            DisplayImage(gameManager.GetPlayerAt(0), InvolvedPersons.Player);
        }
        #endregion

        #region Game transitions

        //Configure next players turn
        private void NextPlayer()
        {
            int playerTurn = 0;
            Player player = null;

            do
            {
                EnableButtons();
                ClearPlayerPictureBoxes();
                playerTurn = gameManager.NextPlayersTurn();
                player = gameManager.PlayersTurn();
                gpxPlayer.Text = player.ID;
                DisplayImage(player, InvolvedPersons.Player);
                lblPlayerScore.Text = player.Hand.Score().ToString();

                if ((deck.QuarterDeckLeft()) && (!deck.IsQuarterDeckShuffled)) 
                {
                    WantsToShuffle();
                    deck.IsQuarterDeckShuffled = true;
                }
                    
                if (playerTurn == 0)
                {
                    DisableButtons();
                    DealerDesicion(player);
                    break;
                }  

            } while (player.IsStanding);
            
        }

        //Dealer to make a desicion
        private async void DealerDesicion(Player player)
        {
            Dealer dealer = player.Dealer;

            while(dealer.IsStanding == false && dealer.IsBusted == false)
            {
                switch (dealer.Hand.Score() < 17)
                {
                    case true:
                        btnNewGame.Enabled = false;

                        deck.PopFromDeck(dealer, 1);
                        DisplayImage(dealer, InvolvedPersons.Dealer);
                        lblDealerScore.Text = dealer.Hand.Score().ToString();
                        await Task.Delay(1000);

                        if (dealer.Hand.Score() > 21)
                        {
                            gpxDealer.Text = "Busted";
                            dealer.IsBusted = true;
                        }
                        break;
                    case false:
                        dealer.IsStanding = true;
                        break;
                }
            }
            EvaluateWinners();
        }

        //Decide which players won
        private void EvaluateWinners()
        {
            string winners = "The winners are: ";

            if (gameManager.Winners(gameManager.GetPlayerAt(0).Dealer))
            {
                for (int i = 0; i < gameManager.Count; i++)
                {
                    if (gameManager.GetPlayerAt(i).IsWinner == true)
                    {
                        winners += gameManager.GetPlayerAt(i).ID + ", ";
                    }
                }
            }

            if (gameManager.GetPlayerAt(0).Dealer.IsWinner == true)
            {
                winners += "The House";
            }
            else
            {
                winners = winners.Substring(0, winners.Length - 2);
            }

            MessageBox.Show(winners, "Winners", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNewGame.Enabled = true;
        }

        //25% deck left, case user want to shuffle
        private bool WantsToShuffle()
        {
            DialogResult dialogResult = MessageBox.Show("25% of the cards are remaining. Do you want to shuffle the deck?",
                    "Shuffle?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                deck.ShuffleDeck();
            }

            return false;
        }
        #endregion

        #region Buttons for MainForm
        //Pop card from deck and give it to a player
        //In case busted -> next player's turn
        private async void btnHit_Click(object sender, EventArgs e)
        {
            Player player = gameManager.PlayersTurn();

            deck.PopFromDeck(player, 1);
            DisplayImage(player, InvolvedPersons.Player);
            lblPlayerScore.Text = player.Hand.Score().ToString();

            if (player.Hand.Score() > 21)
            {
                DisableButtons();
                player.IsBusted = true;
                gpxPlayer.Text = "Busted";
                await Task.Delay(1000);
                NextPlayer();
            }
            if(!player.IsBusted)
                EnableButtons();
        }

        //Stand and next player's turn
        private async void btnStand_Click(object sender, EventArgs e)
        {
            Player player = gameManager.PlayersTurn();
            player.IsStanding = true;
            NextPlayer();
        }

        //Shuffle deck 
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            deck.ShuffleDeck();
        }

        //Reconfigure game
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            playerID = 0;
            gameManager.DeleteAllPlayers();
            InitializeGUI();
            InitializeInitGameForm();
        }
        #endregion

        #region ImageList and Pictureboxes
        //Takes info from players hand and create an index to be compare with index of 
        //an imagelist in MainForm
        private void DisplayImage(Player player, InvolvedPersons pers)
        {
            int index = 0;
            int listImgIntervall = 0;

            for (int i = 0; i < player.Hand.Count; i++)
            {
                for (int j = 1; j < 15; j++)
                {
                    if (player.Hand.GetCardAt(i).Points == j)
                    {
                        switch (player.Hand.GetCardAt(i).Suit)
                        {
                            case Suit.clubs:
                                index = listImgIntervall - 3;
                                break;
                            case Suit.diamonds:
                                index = listImgIntervall - 2;
                                break;
                            case Suit.hearts:
                                index = listImgIntervall - 1;
                                break;
                            case Suit.spades:
                                index = listImgIntervall;
                                break;
                            default:
                                break;
                        }
                        DisplayImg(index, i + 1, pers);
                    }
                    listImgIntervall += 4;
                }
                listImgIntervall = 0;
            }
        }

        //Compares indexes to display image of card for a dealer or for a player
        private void DisplayImg(int index, int cardNmbr, InvolvedPersons pers)
        {
            if (pers == InvolvedPersons.Dealer)
            {
                switch (cardNmbr)
                {
                    case 1:
                        pictureBox1.Image = imgListCards.Images[index];
                        break;
                    case 2:
                        pictureBox2.Image = imgListCards.Images[index];
                        break;
                    case 3:
                        pictureBox3.Image = imgListCards.Images[index];
                        break;
                    case 4:
                        pictureBox4.Image = imgListCards.Images[index];
                        break;
                    case 5:
                        pictureBox5.Image = imgListCards.Images[index];
                        break;
                    case 6:
                        pictureBox6.Image = imgListCards.Images[index];
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (cardNmbr)
                {
                    case 1:
                        pictureBox7.Image = imgListCards.Images[index];
                        break;
                    case 2:
                        pictureBox8.Image = imgListCards.Images[index];
                        break;
                    case 3:
                        pictureBox9.Image = imgListCards.Images[index];
                        break;
                    case 4:
                        pictureBox10.Image = imgListCards.Images[index];
                        break;
                    case 5:
                        pictureBox11.Image = imgListCards.Images[index];
                        break;
                    case 6:
                        pictureBox12.Image = imgListCards.Images[index];
                        break;
                    default:
                        break;
                }
            }
        }

        private void ClearPlayerPictureBoxes()
        {
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
            pictureBox10.Image = null;
            pictureBox11.Image = null;
            pictureBox12.Image = null;
        }

        private void ClearDealerPictureBoxes()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}