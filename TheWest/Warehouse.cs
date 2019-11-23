using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    //klasa warehouse
    public class Warehouse : UpgradeBuilding
    {
        //zmienne kosztu kupienia magazynuu i wzaplatys
        private int costBuy = 1000;
        private int salary = 20;

        //konstruktor wraz z przypisaniem wartosci
        public Warehouse(Arthur person) : base(person)
        {
            this.arthur = person;
            this.CurrentBuildingLevel = 1;
            this.CostUpgrade = 100;
            this.AllCostForupgrade = this.CostUpgrade;
        }

        //gettery i settery
        public int CostBuy { get => costBuy; set => costBuy = value; }
        public int Salary { get => salary; set => salary = value; }

        public void risingSalary()
        {
            salary += 10;
    }
    }
}
