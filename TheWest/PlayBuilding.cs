using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa bastrakcyjna PlayBuilding, dziedzicza po nie budynki przeznaczone do grania w pokera lub obstawiania wyscigow konnych
    /// </summary>
    public abstract class PlayBuilding
    {
        //zmienna ktora bedzie przechowywala wartosc 
        protected int tempOfPermutation;


        public void SetTempOfPermutation(int temp)
        {
            tempOfPermutation = temp;
        }

        public virtual bool Permutation()
        {
            // Instantiate random number generator using system-supplied value as seed.
            var rand = new Random();

            //losowanie liczby
            int randomNumber = rand.Next(101);
            Console.WriteLine(randomNumber);
            //jesli pseudo liczba mniejsza od 50 lub 75 to wygrana pieniedzy, około 50% lub 75% na przegranie zależy od parametru
            if (randomNumber > tempOfPermutation)
            {
                return true;
            }
            else
            {
                return false;
            }
                
                
        }

    }
}
