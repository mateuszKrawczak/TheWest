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
        
       


        Arthur arthur;
        //konstuktor z obiektem klasy Arthur
        public Store(Arthur person)
        {
            this.arthur = person;
            CurrentBuildingLevel = 1;
            CostUpgrade = 150;

        }

        //podniesienie statystyki celowania,wywolywana podczas ulepszenia 
        public void BoostingAim()
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

        /// <summary>
        /// funkcja ustawia koszt ulepszenia w zaleznosci od poziomu
        /// </summary>
        public override void SetLevel()
        {
            switch (CurrentBuildingLevel)
            {
                case 1:
                    CostUpgrade = 150;
                    break;


                case 2:
                    CostUpgrade = 300;

                    break;
                case 3:
                    CostUpgrade = 500;

                    break;


                case 4:
                    CostUpgrade = 700;
                    break;



                case 5:
                    CostUpgrade = 900;
                    break;





            }
        }

        /// <summary>
        /// funkcja ktora nadpisuje funkcje abst. i zawiera ulepszenie budynku
        /// </summary>
        public override void UpgradeOfBuilding()
        {
            SetLevel();
            arthur.Money -= CostUpgrade;
            CurrentBuildingLevel++;
        }
    }
}
