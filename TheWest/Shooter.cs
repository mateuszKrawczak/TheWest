using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa dziedziczaca po klasie Unit, odpowiada za jednostke strzelca
    /// </summary>
    class Shooter : Unit
    {
        public Shooter()
        {
            //ustawiam statystyki i koszt jednostki
            SetAttacking(5);
            SetDefending(20);
            SetCostOfUnit(50);
        }
    }
}
