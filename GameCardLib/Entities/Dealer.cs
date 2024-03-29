using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib.Entities
{
    public class Dealer : Player
    {
        public Dealer()
        {
            Hand = new Hand();
            IsStanding = false;
            IsWinner = false;
            ID = "Dealer";
        }
        
    }
}
