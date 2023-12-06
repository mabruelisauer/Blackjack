﻿using System;
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
            int card = Hand[0];
            Console.WriteLine($"Dealer has {card} on his hand.", card);
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

            string listOfCards = string.Join(", ", Hand);
            Console.WriteLine($"The dealer has the cards {listOfCards} on his hand.");
            Console.WriteLine($"The sum of his cards is: {sum}");
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

        public void FinishHand(Box box)
        {
            int sum = GetHandSum();

            while (sum < 17) 
            {
                Hand.Add(box.DealCard());
                Console.WriteLine($"The dealer draws {Hand[Hand.Count - 1]}, he has now");
                sum = GetHandSum();
            }

            Console.WriteLine($"The final sum of his cards is: {GetHandSum()}");
        }
    }
}
