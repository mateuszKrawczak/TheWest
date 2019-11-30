using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa StudOfHorses ktora odpowiada za obstawianie wyscigow konnych , dziedziczy po klasie PlayVuilding
    /// </summary>
    public class StudOfHorses :PlayBuilding
    {
        /// <summary>
        /// [rzypisanie wartosci prawdopodobienstwa
        /// </summary>
        /// <param name="temp"></param>
        public StudOfHorses(int temp)
        {
            SetTempOfPermutation(temp);
        }
    }
}
