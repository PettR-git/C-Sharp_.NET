using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib.Entities
{
    public class GameManager
    {
        private List<Player> players;
        private int nextPlayersTurn;
    
        public GameManager()
        {
            players = new List<Player>();
            nextPlayersTurn = 0;
        }

        //Return which players turn
        public Player PlayersTurn()
        {
            Player player = GetPlayerAt(nextPlayersTurn);

            return player;
        }

        //Next turn, new player
        public int NextPlayersTurn()
        {
            if (nextPlayersTurn == players.Count()-1)
            {
                nextPlayersTurn = 0;
            }
            else
            {
                nextPlayersTurn++;
            }
            return nextPlayersTurn;
        }

        //Add a new player to game
        public bool AddPlayer(Player player)
        {
            try
            {
                players.Add(player);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
            return true;
        }

        //Return highest score of the players
        private int HighestScore(Dealer dealer)
        {
            int[] scores = new int[players.Count];

            for(int i = 0; i < players.Count(); i++)
            {
                if (players[i].Hand.Score() <= 21)
                {
                    scores[i] = players[i].Hand.Score();
                }
            }
            
            //set dealer to winner if score higher than all players
            if(scores.Max() <= dealer.Hand.Score())
            {
                dealer.IsWinner = true;
            }
            else
            {
                dealer.IsWinner = false;
            }

            return scores.Max();
        }

        //If only dealer won
        public bool IsDealerAloneWinner(Dealer dealer)
        {
            if (HighestScore(dealer) >= dealer.Hand.Score() || dealer.IsBusted) 
                return false;

            return true;
        }

        //Determine all winners
        public bool Winners(Dealer dealer)
        {
            if (IsDealerAloneWinner(dealer))
                return false;

            for(int i = 0; i < players.Count(); i++)
            {
                if (players[i].IsBusted)
                {
                    players[i].IsWinner = false;
                }
                else if (dealer.IsBusted)
                {
                    players[i].IsWinner = true;
                    dealer.IsWinner = false;
                }
                else if (dealer.Hand.Score() < players[i].Hand.Score())
                {
                    players[i].IsWinner = true;
                    dealer.IsWinner = false;    
                }
                else if(dealer.IsWinner && dealer.Hand.Score() == players[i].Hand.Score())
                {
                    players[i].IsWinner = true;
                }
            }
            return true;
        }

        //Clear list to reconfigure game
        public bool DeleteAllPlayers()
        {
            try
            {
                players.Clear();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
            return true;
        }

        public int Count => (players.Count);
        public bool CheckIndex(int index)
        {
            return (players != null) & (index < players.Count) & (index >= 0);
        }

        //Get a player at index
        public Player GetPlayerAt(int index)
        {
            if (CheckIndex(index))
            {
                return players[index];
            }
            else
            {
                return null;
            }
        }
    }
}
