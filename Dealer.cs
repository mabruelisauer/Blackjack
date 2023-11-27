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

        public Dealer()
        {
            Hand = new List<int>();
        }
    }
}
