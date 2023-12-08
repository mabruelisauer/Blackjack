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
        public int FaceDownCard { get; set; }

        public Dealer()
        {
            Hand = new List<int>();
            FaceDownCard = 0;
        }

        public void PrintCard()
        {
            Console.WriteLine($"Dealer: {GetHandSum()}");
        }

        public void AddFaceDownCard()
        {
            Hand.Add(FaceDownCard);
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

            string listOfCards = string.Join(" + ", Hand);
            Console.Clear();
            Console.WriteLine($"Dealer: {listOfCards} = {sum}");
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

        public void FinishHand(Box box, WinChecker winChecker)
        {
            int sum = GetHandSum();

            while (sum < 17) 
            {
                Hand.Add(box.DealCard());
                sum = GetHandSum();
            }

            if (GetHandSum() > 21)
            {
                winChecker.DealerIsBust = true;
            }
                
            PrintHand();
        }
    }
}
