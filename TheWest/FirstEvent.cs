using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheWest
{
    /// <summary>
    /// klasa, ktora jest za pierwsze losowe zdarzenie w grze
    /// </summary>
    public class FirstEvent : RandomEvent
    {
        public FirstEvent(Arthur person)
        {
            arthur = person;


        }
        /// <summary>
        /// funkcja nadpisujaca abstrakcyjna metodę 
        /// </summary>
        public override void RandomEventInGame()
        {
            //koszt naprawy dachu
            int roofRepairMoney = arthur.Money / 10;
            MessageBox.Show("Oh no, your roof in home is leaking, you must reapir it. It will cost " + roofRepairMoney + " $");
            //dekrementacja pieniedzy
            arthur.Money -= roofRepairMoney;
            

        }
    }
}
