using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Blackjack
{
    public class Box
    {
        public List<int> RandomBox = new List<int>();
        public int AceCounter {  get; set; }
        public int TwoCounter { get; set; }
        public int ThreeCounter { get; set; }
        public int FourCounter { get; set; }
        public int FiveCounter { get; set; }
        public int SixCounter { get; set; }
        public int SevenCounter { get; set; }
        public int EightCounter { get; set; }
        public int NineCounter { get; set; }
        public int TenCounter { get; set; }

        public Box()
        {
            AceCounter = 0;
            TwoCounter = 0;
            ThreeCounter = 0;
            FourCounter = 0;
            FiveCounter = 0;
            SixCounter = 0;
            SevenCounter = 0;
            EightCounter = 0;
            NineCounter = 0;
            TenCounter = 0;
        }



        public void GenerateRandomBox() 
        {
            Random random = new Random();

            for (int i = 0; i <= 416; i++)
            {
                int randomNumber = random.Next(1,14);
                if (randomNumber == 1 && AceCounter <= 31)
                {
                    RandomBox.Add(randomNumber);
                    AceCounter++;
                }
                else if (randomNumber == 2 && TwoCounter <= 31)
                {
                    RandomBox.Add(randomNumber);
                    TwoCounter++;
                }
                else if (randomNumber == 3 && ThreeCounter <= 31)
                {
                    RandomBox.Add(randomNumber);
                    ThreeCounter++;
                }
                else if (randomNumber == 4 && FourCounter <= 31)
                {
                    RandomBox.Add(randomNumber);
                    FourCounter++;
                }
                else if (randomNumber == 5 && FiveCounter <= 31)
                {
                    RandomBox.Add(randomNumber);
                    FiveCounter++;
                }
                else if (randomNumber == 6 && SixCounter <= 31)
                {
                    RandomBox.Add(randomNumber);
                    SixCounter++;
                }
                else if (randomNumber == 7 && SevenCounter <= 31)
                {
                    RandomBox.Add(randomNumber);
                    SevenCounter++;
                }
                else if (randomNumber == 8 && EightCounter <= 31)
                {
                    RandomBox.Add(randomNumber);
                    EightCounter++;
                }
                else if (randomNumber == 9 && NineCounter <= 31)
                {
                    RandomBox.Add(randomNumber);
                    NineCounter++;
                }
                else if (randomNumber >= 10 && randomNumber <= 13 && TenCounter <= 127)
                {
                    RandomBox.Add(10);
                    TenCounter++;
                }
                else
                {
                    if (i == 416)
                    {
                        continue;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }
    }
}
