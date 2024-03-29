using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib.Entities
{
    public class Hand
    {
        private List<Card> cardList;
        public Hand()
        {
            cardList = new List<Card>();
        }

        public int Count =>(cardList.Count);

        //Add the card to hand
        public bool AddCard(Card card)
        {
            try
            {
               cardList.Add(card);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
            
            return true;
        }

        public Card GetCardAt(int index)
        {
            for(int i = 0; i < cardList.Count; i++)
            {
                if(i == index)
                {
                    return cardList[i];
                }
            }
            return null;
        }

        public void ClearHand()
        {
            cardList.Clear();
        }

        //Configure score based on rules 
        public int Score()
        {
            int score = 0;
            int aceCounter=0;

            for (int i = 0; i < cardList.Count; i++)
            {
                switch (cardList[i].Points)
                {
                    case 11:
                    case 12:
                    case 13:
                        score += 10;
                        break;
                    case 14:
                        score += 11;
                        aceCounter++;
                        break;
                    default:
                        score += cardList[i].Points;
                        break;
                }            
            }

            if(score > 21)
            {
                switch (aceCounter)
                {
                    case 0:
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        for(int i = 0; i < aceCounter; i++)
                        {
                            score = score - 10;
                            if (score < 21)
                                break;
                        }
                        break;
                    default:
                        break;
                 
                }
            }
            return score;
        }
    }
}
