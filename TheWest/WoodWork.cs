using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa odpowiadajaca za prace w lesie(karczowanie), dziedziczy po klasie abstrakcyjnej WorkBuilding i Icost
    /// </summary>
    class WoodWork : WorkBuilding, ICost
    {

        //zmienne kosztów
        private int cost;
        private int time;
        private int energy;
        private int experience;

        //kontruktor i przypisanie wartosci budynku
        public WoodWork(int salary)
        {

            SetSalaryPerHour(salary);
            cost = 0;
            time = 5;
            energy = 30;
            experience = 20;
        }



        //gettery 
        public int CostOfActivity()
        {
            return cost;
        }

        public override int EnergyOfActivity()
        {
            return energy;
        }

        public int ExperienceOfActivity()
        {

            return experience;
        }

        public override int TimeOfActivity()
        {
            return time;
        }
    }
}
