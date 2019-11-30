using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    //klasa Warehouse dziedziczy po UpgradeBuilding poniewaz mozna ulepszac magazyn 
    public class Warehouse : UpgradeBuilding
    {
        //zmienne kosztu kupienia magazynuu i wzaplatys
        private int costBuy = 1000;
        private int salary = 20;

        Arthur arthur;
        //konstruktor wraz z przypisaniem wartosci
        public Warehouse(Arthur person)
        {
            this.arthur = person;
            CurrentBuildingLevel = 1;
            CostUpgrade = 150;
           
        }

        //gettery i settery
        public int CostBuy { get => costBuy; set => costBuy = value; }
        public int Salary { get => salary; set => salary = value; }

        

        /// <summary>
        /// funkcja ustawia koszt ulepszenia i pendsje w zaleznosci od poziomu
        /// </summary>
        public override void SetLevel()
        {
            switch (CurrentBuildingLevel)
            {
                case 1:
                    CostUpgrade = 150;
                    salary = 20;
                    break;


                case 2:
                    CostUpgrade = 300;
                    salary += 20;
                    break;
                case 3:
                    CostUpgrade = 500;
                    salary += 20;
                    break;


                case 4:
                    CostUpgrade = 700;
                    salary += 20;
                    break;



                case 5:
                    CostUpgrade = 900;
                    salary += 20;
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
