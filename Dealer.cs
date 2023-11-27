using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Dealer
    {
        public List<int> Hand { get; set; }

        public Dealer()
        {
            Hand = new List<int>();
        }

        public void PrintCard()
        {
            int card = Hand[0];
            Console.WriteLine($"Dealer has {card} on his hand.", card);
        }
    }
}
