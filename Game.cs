using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Game
    {
        Box box = new Box();
        Player player = new Player();
        Dealer dealer = new Dealer();
        ConsoleHelper consoleHelper = new ConsoleHelper();
        WinChecker winChecker = new WinChecker();

        public void Start()
        {
            Console.WriteLine("Welcome to Blackjack. Best of luck ;)");
            Console.WriteLine("Press any key to start...");
            while (!Console.KeyAvailable){}

            box.GenerateRandomBox();
            StartRound();
        }

        public void StartRound()
        {
            decimal bet = 0;
            Console.Clear();
            consoleHelper.PrintRoundStartMessage(player.Cash);
            bet = consoleHelper.GetValidBet(player.Cash);
            player.ChargeBet(bet);

            player.Hand.Clear();
            dealer.Hand.Clear();
            winChecker.IsLost = false;
            winChecker.IsDraw = false;
            winChecker.IsWon = false;

            player.Hand.Add(box.DealCard());
            dealer.Hand.Add(box.DealCard());
            player.Hand.Add(box.DealCard());
            dealer.FaceDownCard = box.DealCard();

            player.PrintHand();
            dealer.PrintCard();

            GetPlayerDecisionLoop(bet);
        }

        public void GetPlayerDecisionLoop(decimal bet)
        {
            while (!winChecker.IsWon && !winChecker.IsLost && !winChecker.IsDraw)
            {
                int decision = player.GetPlayerDecision(bet); //Test if split and double doesn't work with too low cash
                                                              //Change IsWon or IsLost if either of the players has Blackjack

                switch (decision)
                {
                    case 1: //STAND
                        if (dealer.Hand.Count == 1)
                        {
                            Console.Clear();
                            Console.WriteLine($"You have {player.GetHandSum()}, the dealer has {dealer.GetHandSum()}");
                            dealer.AddFaceDownCard();
                            Console.WriteLine($"The dealer's face-down card is {dealer.FaceDownCard}, he has now {dealer.GetHandSum()}");
                            dealer.FinishHand(box);
                            winChecker.CheckWinner(player, dealer);
                        }
                        else
                        {
                            dealer.FinishHand(box);
                            winChecker.CheckWinner(player, dealer);
                        }
                        break;
                    case 2: //HIT
                        Console.Clear();

                        break;
                    case 3: //DOUBLE
                        Console.Clear();
                        break;
                    case 4: //SPLIT
                        Console.Clear();
                        break;
                }

                if (winChecker.IsLost)
                {
                    consoleHelper.PrintLostMessage(player, dealer);
                    while (!Console.KeyAvailable) { }

                    StartRound();
                }
                if (winChecker.IsDraw)
                {
                    consoleHelper.PrintDrawMessage(bet);
                    player.Cash += bet;
                    while (!Console.KeyAvailable) { }

                    StartRound();
                }
                if (!winChecker.IsWon)
                {
                    if (player.Hand.Count == 2 && player.GetHandSum() == 21)
                    {
                        decimal payout = 2.5m * bet;
                        consoleHelper.PrintBlackjackMessage(player, dealer, payout);
                        player.Cash += payout;
                        while (!Console.KeyAvailable) { }

                        StartRound();
                    }
                    else
                    {
                        decimal payout = 2 * bet;
                        consoleHelper.PrintWonMessage(player, dealer, payout);
                        player.Cash += payout;
                        while (!Console.KeyAvailable) { }

                        StartRound();
                    }
                }
            }
        }
    }
}
