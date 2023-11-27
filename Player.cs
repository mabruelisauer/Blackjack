using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player
    {
        public decimal Cash { get; set; }
        public List<int> Hand { get; set; }

        public Player()
        {
            Cash = 5000;
            Hand = new List<int>();
        }

        public void PrintCard()
        {
            int card = Hand[0];
            Console.WriteLine($"You have {card} on your hand.", card);
        }
    }
}
