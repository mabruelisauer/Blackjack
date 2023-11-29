using System;
using System.Collections.Generic;
using System.Linq;
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

            StartRound();
        }

        public void StartRound()
        {
            Console.Clear();
            consoleHelper.PrintRoundStartMessage(player.Cash);
            decimal bet = consoleHelper.GetValidBet(player.Cash);
            player.ChargeBet(bet);

            player.Hand.Clear();
            dealer.Hand.Clear();

            box.GenerateRandomBox();
            player.Hand.Add(box.DealCard());
            dealer.Hand.Add(box.DealCard());
            player.Hand.Add(box.DealCard());

            player.PrintHand();
            dealer.PrintCard();
            int decision = player.GetPlayerDecision(bet); //Test if split and double doesn't work with too low cash
            //Change IsWon or IsLost if either of the players has Blackjack

            if (!winChecker.IsWon && !winChecker.IsLost)
            {
                switch (decision)
                {
                    case 1:

                        break;
                }
            }
        }
    }
}
