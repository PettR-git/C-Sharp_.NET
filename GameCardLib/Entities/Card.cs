using UtilitiesLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib.Entities
{
    public class Card : Hand
    {
        private int points;
        private Suit suit;
        public Card()
        {
        }

        public Card(int points, Suit suit)
        {
            this.points = points;
            this.suit = suit;
        }

        public int Points { get { return points; } set { points = value; } }

        public Suit Suit { get { return suit; } set { suit = value; } }
    }
}
