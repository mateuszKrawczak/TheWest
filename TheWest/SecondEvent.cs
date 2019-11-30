using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheWest
{
    /// <summary>
    /// klasa dziedzicz po klasie abst. RandomEvent i obsługuje drugie zdarzenie losowe w grze
    /// </summary>
    public class SecondEvent : RandomEvent
    {
        /// <summary>
        /// konstruktor w ktorym przypisujemy aktualny stan obiektu klasy Arthur
        /// </summary>
        /// <param name="person"></param>
        public SecondEvent(Arthur person)
        {
            arthur = person;


        }
        /// <summary>
        /// funkcja ktora ndpisuje metode klasy abst. i jest zawarte w niej drugie zdarzenie losowe
        /// </summary>
        public override void RandomEventInGame()
        {
            //jesli nie mamy odejmuje 1/10 naszego stanu konta
            int civilCodeMoney = arthur.Money / 10;
            MessageBox.Show("You had to pay " + civilCodeMoney + " $");
            //przypisanie nowej zmiennej i aktualizacja etykiety
            arthur.Money -= civilCodeMoney;
           

        }
    }
}