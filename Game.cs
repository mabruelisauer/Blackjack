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
        ConsoleHelper consoleHelper = new ConsoleHelper();

        public void Start()
        {
            Console.WriteLine("Welcome to Blackjack. Best of luck ;)");
            box.GenerateRandomBox();
            Console.WriteLine("Press any key to start...");
            while (!Console.KeyAvailable){}
            StartRound();
        }

        public void StartRound()
        {
            Console.Clear();
            consoleHelper.PrintRoundStartMessage(player.Cash);
            decimal bet = consoleHelper.GetValidBet(player.Cash);
        }
    }
}
