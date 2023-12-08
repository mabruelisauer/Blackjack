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
        public bool PlayerIsBust { get; set; }
        public bool DealerIsBust { get; set; }
        public WinChecker() 
        { 
            IsDraw = false;
            IsWon = false; 
            IsLost = false;
            PlayerIsBust = false;
            DealerIsBust = false;
        }

        public void CheckWinner(Player player, Dealer dealer)
        {
            if (player.GetHandSum() > dealer.GetHandSum())
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

        internal void ResetVariables()
        {
            IsLost = false;
            IsDraw = false;
            IsWon = false;
            PlayerIsBust = false;
            DealerIsBust = false;
        }
    }
}
