using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class WinChecker
    {
        public bool IsWon {  get; set; }
        public bool IsLost { get; set; }
        public WinChecker() 
        { 
            IsWon = false; 
            IsLost = false;
        }
    }
}
