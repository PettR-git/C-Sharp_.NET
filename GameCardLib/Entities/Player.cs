using GameCardLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib.Entities
{
    public class Player
    {
        private Hand hand;
        private Dealer dealer;
        private string id;
        private bool isStanding;
        private bool isWinner;
        private bool isBusted;

        public Player() 
        {
            hand = new Hand();
            isWinner = false;
            isStanding = false;
        }

        public Player(Hand hand, string id, bool isStanding, bool isWinner, bool isBusted) : this()
        {
            this.hand = hand;
            this.id = id;
            this.isStanding = isStanding;
            this.isWinner = isWinner;
            this.isBusted = isBusted;
        }

        public Dealer Dealer
        {
            get { return dealer; }
            set { dealer = value; }
        }

        public Hand Hand { get { return hand; } set { hand = value; } }

        public bool IsBusted { get { return isBusted; } set { isBusted = value; } }

        public string ID { get { return id; } set { id = value; } }

        public bool IsStanding { get { return isStanding; } set { isStanding = value; } }

        public bool IsWinner { get { return isWinner; } set { isWinner = value; } }

    }
}
