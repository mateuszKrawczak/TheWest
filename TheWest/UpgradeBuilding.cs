using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    public class UpgradeBuilding
    {
        //zmienne zwiazanae z ulepszeniem bydynkow
        protected int costUpgrade;
        protected int currentBuildingLevel;
        private int allCostForupgrade;
        
        //obiekt klasy Arthur
        protected Arthur arthur;
        
        //konstuktor
        public UpgradeBuilding(Arthur person)
        {
            arthur = person;
            currentBuildingLevel = 1;
            allCostForupgrade = 1;
        }

        //gettery i settery
        public int CurrentBuildingLevel { get => currentBuildingLevel; set => currentBuildingLevel = value; }
        public int CostUpgrade { get => costUpgrade; set => costUpgrade = value; }
        protected int AllCostForupgrade { get => allCostForupgrade; set => allCostForupgrade = value; }


        /// <summary>
        /// funkcja odpowiedzialna za ulepszanie budynku
        /// </summary>
        /// <param name="value"></param>
        public void upgradeBuilding(UpgradeBuilding building)
        {
            //odjecie pieniedzy za ulepszenie
            arthur.Money = arthur.Money - building.costUpgrade;

            //podwyzszenie nastepnej ceny ulepszania
            building.costUpgrade += building.costUpgrade;

            //inkrementacja poziomu
            building.CurrentBuildingLevel++;
        }
    }
}
