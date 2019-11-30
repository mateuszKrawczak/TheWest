using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheWest
{
    /// <summary>
    /// klasa dziedzicz po klasie abst. RandomEvent i obsługuje trzecie zdarzenie losowe w grze
    /// </summary>
    public class ThirdEvent : RandomEvent
    {
        /// <summary>
        /// konstruktor w ktorym przypisujemy aktualny stan obiektu klasy Arthur
        /// </summary>
        /// <param name="person"></param>
        public ThirdEvent(Arthur person)
        {
            arthur = person;


        }
        /// <summary>
        /// funkcja ktora ndpisuje metode klasy abst. i jest zawarte w niej drugie zdarzenie losowe
        /// </summary>
        public override void RandomEventInGame()
        {
            //uszkodzenie zdrowia gracza i aktualizacja etykiety
            MessageBox.Show("Your friend is quite temperamental, he was drunk and almost kill you...");
            arthur.Life = 10;


        }
    }
}