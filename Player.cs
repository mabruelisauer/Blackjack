using System;
using System.Collections;
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

        public void PrintHand()
        {
            int sum = 0;
            int numberOfAces = 0;

            foreach (int card in Hand)
            {
                if (card == 11)
                {
                    numberOfAces++;
                }
                sum += card;
            }

            while (sum > 21 && numberOfAces > 0)
            {
                sum -= 10;
                numberOfAces--;
            }

            string listOfCards = string.Join(", ", Hand);
            Console.Clear();
            Console.WriteLine($"You have the cards {listOfCards} on your hand.");
            Console.WriteLine($"The sum of your cards is: {sum}");
        }
    }
}
