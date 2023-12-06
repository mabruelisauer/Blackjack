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

        ConsoleHelper consoleHelper = new ConsoleHelper();

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

        public int GetHandSum()
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

            return sum;
        }

        public void ChargeBet(decimal bet)
        {
            Cash -= bet;
        }

        public int GetPlayerDecision(decimal bet)
        {
            if (Hand.Count == 2 && Hand[0] == Hand[1])
            {
                Console.WriteLine("Press [1] to STAND, [2] to HIT, [3] to DOUBLE or [4] to SPLIT");
                return consoleHelper.GetValidSplitDecision(bet, Cash);
            }
            else if (Hand.Count == 2)
            {
                Console.WriteLine("Press [1] to STAND, [2] to HIT or [3] to DOUBLE");
                return consoleHelper.GetValidDoubleDecision(bet, Cash);
            }
            else
            {
                Console.WriteLine("Press [1] to STAND or [2] to HIT");
                return consoleHelper.GetValidDecision(bet, Cash);
            }
        }
    }
}
