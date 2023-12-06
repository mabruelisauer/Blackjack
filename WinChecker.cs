using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class WinChecker
    {
        public bool IsDraw { get; set; }
        public bool IsWon {  get; set; }
        public bool IsLost { get; set; }
        public WinChecker() 
        { 
            IsDraw = false;
            IsWon = false; 
            IsLost = false;
        }

        public void CheckWinner(Player player, Dealer dealer)
        {
            if (player.GetHandSum() > dealer.GetHandSum() && player.GetHandSum() <= 21 || player.GetHandSum() <= 21 && dealer.GetHandSum() > 21)
            {
                IsWon = true;
            }
            else if (dealer.GetHandSum() > player.GetHandSum())
            {
                IsLost = true;
            }
            else if (player.GetHandSum() == dealer.GetHandSum())
            {
                IsDraw = true;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
