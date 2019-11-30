using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa abstrakcyjna odpowiedizalna za losowe zdarzenia w grze
    /// </summary>
    public abstract class RandomEvent
    {
        //obiekt klasy Arthur
        protected Arthur arthur;

        /// <summary>
        /// funkcja abstrakcyjna, ktora opisuje w kazdej z klasie losowe zdarzenie
        /// </summary>
        public abstract void RandomEventInGame();
    }
}
