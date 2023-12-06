using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class ConsoleHelper
    {
        public void PrintRoundStartMessage(decimal cash)
        {
            Console.WriteLine("Place your bets, please.");
            Console.WriteLine("Cash: " + cash + " CHF");
            Console.WriteLine("MIN: 1 CHF");
            Console.WriteLine("MAX: 500 CHF");
        }

        public decimal GetValidBet(decimal cash)
        {
            string input;
            do { input = Console.ReadLine(); }
            while (!ValidBet(cash, input));

            return decimal.Parse(input);
        }

        public bool ValidBet(decimal cash, string input)
        {
            bool Parsebool = decimal.TryParse(input, out decimal result);
            if (!Parsebool)
            {
                Console.WriteLine("Please enter a number.");
                return false;
            }
            else if (result < 1 || result > 500)
            {
                Console.WriteLine("Please enter a number between 1 and 500.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetValidSplitDecision(decimal bet, decimal cash)
        {
            string input;
            do { input = Console.ReadLine(); }
            while (!ValidDecision(cash, bet, input, 4));

            return int.Parse(input);
        }

        public int GetValidDoubleDecision(decimal bet, decimal cash)
        {
            string input;
            do { input = Console.ReadLine(); }
            while (!ValidDecision(cash, bet, input, 3));

            return int.Parse(input);
        }

        public int GetValidDecision(decimal bet, decimal cash)
        {
            string input;
            do { input = Console.ReadLine(); }
            while (!ValidDecision(cash, bet, input, 2));

            return int.Parse(input);
        }

        public bool ValidDecision(decimal cash, decimal bet, string input, int possibleDecisions)
        {
            bool Parsebool = int.TryParse(input, out int result);
            if (!Parsebool)
            {
                Console.WriteLine("Please enter a number.");
                return false;
            }
            else if (result < 1 || result > possibleDecisions)
            {
                Console.WriteLine($"Please enter a number between 1 and {possibleDecisions}.");
                return false;
            }
            else
            {
                if (int.Parse(input) == 3 || int.Parse(input) == 4)
                {
                    if (cash > bet)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"With {cash} CHF your cash is to low to double or split {bet} CHF.");
                        Console.WriteLine("Please decide accordingly.");
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
        }

        internal void PrintLostMessage(Player player, Dealer dealer)
        {
            Console.WriteLine($"\nYou lost the Round! You have {player.GetHandSum()}, while the dealer has {dealer.GetHandSum()}");
            Console.WriteLine("\nPress any key to start the next round...");
        }

        internal void PrintDrawMessage(decimal bet)
        {
            Console.WriteLine("\nPush!");
            Console.WriteLine($"You get back your bet of {bet}");
            Console.WriteLine("\nPress any key to start the next round...");
        }

        internal void PrintWonMessage(Player player, Dealer dealer, decimal payout)
        {
            Console.WriteLine($"\nYou won the Round! You have {player.GetHandSum()}, while the dealer has {dealer.GetHandSum()}");
            Console.WriteLine($"You get a payout of {payout}");
            Console.WriteLine("\nPress any key to start the next round...");
        }

        internal void PrintBlackjackMessage(Player player, Dealer dealer, decimal payout)
        {
            Console.WriteLine($"\nYou have Blackjack! The dealer has {dealer.GetHandSum()}");
            Console.WriteLine($"You get a payout of {payout}");
            Console.WriteLine("\nPress any key to start the next round...");
        }
    }
}
