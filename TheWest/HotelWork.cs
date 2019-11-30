using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa odpowiadajaca za prace w hotelu, dziedziczy po klasie abstrakcyjnej WorkBuilding i Icost
    /// </summary>
    class HotelWork : WorkBuilding, ICost
    {

        //zmienne 
        private int cost;
        private int time;
        private int energy;
        private int experience;

        //kontruktor i przypisanie wartosci budynku
        public HotelWork(int salary)
        {
            SetSalaryPerHour(salary);
            cost = 0;
            time = 2;
            energy = 10;
            experience = 10;
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
