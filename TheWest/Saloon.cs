using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa saloon ktora odpowiada za granie w pokera w grze , dziedziczy po klasie PlayVuilding
    /// </summary>
    class Saloon : PlayBuilding
    {
        /// <summary>
        /// konstruktor w ktorym przypisujemy wartosc zmienne
        /// </summary>
        /// <param name="temp"></param>
        public Saloon(int temp)
        {
            SetTempOfPermutation(temp);
        }
    }
}
