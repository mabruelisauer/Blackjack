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
    }
}
