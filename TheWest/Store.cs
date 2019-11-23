using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{   
    //klasa Store dziedziczy po UpgradeBuilding poniewaz mozna ulepszac sklep 
    public class Store: UpgradeBuilding
    {
        //przypisanie zmiennej
        private int aim = 20;
        //konstuktor z obiektem klasy Arthur
        public Store(Arthur person): base(person)
        {
            this.arthur = person;
            this.CurrentBuildingLevel = 1;
            this.CostUpgrade = 150;
            this.AllCostForupgrade = this.CostUpgrade;
        }

        //podniesienie statystyki celowania,wywolywana podczas ulepszenia 
        public void boostingAim()
        {
            //jesli <100 dodaje 20 a jak nie to przypisuje wartosc maksymalna 100
            if (arthur.Aim + aim <= 100)
            {
                arthur.Aim += aim;
            }
            else
            {
                arthur.Aim = 100;
            }
        }
    }
}
