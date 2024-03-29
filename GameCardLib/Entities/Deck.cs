using UtilitiesLib.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesLib;
using UtilitiesLib.Logger;

namespace GameCardLib.Entities
{
    public class Deck
    {
        private List<Card> cards;
        private readonly Random random;
        private int nmbrCardsFrStart;
        private bool isShuffled;
        private FileLogger fileLogger;
        private ConsoleLogger consoleLogger;

        public Deck(int amountOfDecks)
        {
            cards = new List<Card>();
            InitializeDeck(amountOfDecks);
            random = new Random();
            ShuffleDeck();
            nmbrCardsFrStart = 52 * amountOfDecks;
            IsQuarterDeckShuffled = false;

            //fileLogger = new FileLogger();
            //consoleLogger = new ConsoleLogger();
    }

        public int Count => (cards.Count);

        public bool IsQuarterDeckShuffled { get { return isShuffled; } set { isShuffled = value; } }

        public bool QuarterDeckLeft()
        {
            if(nmbrCardsFrStart * 0.25 >= cards.Count)
                return true;

            return false;
        }

        //Pop cards from deck and give it to the player's hand
        public Card PopFromDeck(Player player, int amountOfCards)
        {
            int i = 0;
            try
            {
                while (amountOfCards > 0)
                {
                    //fileLogger.WriteToFile(player.ID + " is drawing a card.");
                    //consoleLogger.WriteToFile(player.ID + " is drawing a card.");

                    i++;
                    player.Hand.AddCard(cards.First());
                    cards.RemoveAt(0);
                    amountOfCards--;
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
            return cards[0];
        }
        
        //Put in all cards needed
        private void InitializeDeck(int numOfDecks)
        {
            for(int i = 0; i<numOfDecks; i++)
            {
                for(int j=2; j<15; j++)
                {
                    cards.Add(new Card(j, Suit.clubs));
                    cards.Add(new Card(j, Suit.hearts));
                    cards.Add(new Card(j, Suit.spades));
                    cards.Add(new Card(j, Suit.diamonds));
                }    
            }
        }

        public void ShuffleDeck()
        {
            cards = cards.OrderBy(card => random.Next()).ToList();
        }


    }
}
