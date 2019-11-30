using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa abstrakcyjna UpgradeBuilding, po której dziedziczą budynki które da sie ulepszyć czli Store i Warehouse
    /// </summary>
    public abstract class UpgradeBuilding
    {
        //zmienne zwiazanae z ulepszeniem bydynkow
        protected int costUpgrade;
        protected int currentBuildingLevel=1;
        
        
        //obiekt klasy Arthur
        protected Arthur arthur;
        
        

        //gettery i settery
        public int CurrentBuildingLevel { get => currentBuildingLevel; set => currentBuildingLevel = value; }
        public int CostUpgrade { get => costUpgrade; set => costUpgrade = value; }
        


        /// <summary>
        /// funkcja odpowiedzialna za ulepszanie budynku
        /// </summary>
        /// <param name="value"></param>
        public abstract void UpgradeOfBuilding();
        /// <summary>
        /// funkcja odpowiedzialna za ustawienie kosztów ulepszenia
        /// </summary>
        public abstract void SetLevel();
    }
}
