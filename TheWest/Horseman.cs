using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa dziedziczaca po klasie Unit, odpowiada za jednostke jezdzcy
    /// </summary>
    class Horseman : Unit
    {
        public Horseman()
        {
            //ustawiam statystyki i koszt jednostki
            SetAttacking(20);
            SetDefending(5);
            SetCostOfUnit(100);
        }
    }
}
