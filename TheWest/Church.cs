using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa Church dziedziczy po klasie abstrakcyjnej RestBuilding i interfejsie ICost
    /// </summary>
    public class Church : RestBuilding, ICost
    {
        //zmienne przypisywane w konstruktorze
        private int cost;
        private int time;
        private int energy;
        private int experience;

        //konstruktor klasy Church
        public Church(int h, int e)
        {
            //przypisanie wartosci zmiennym
            SetGivenEnergy(e);
            SetGivenHealth(h);
            cost = 150; 
            time=2;
            energy=0;
            experience=10;
    }
        //gettery ktore zwracaja wartosci zmiennych
        public int CostOfActivity()
        {
            return cost;
        }

        public int EnergyOfActivity()
        {
            return energy;
        }

        public int ExperienceOfActivity()
        {

            return experience;
        }

        public int TimeOfActivity()
        {
            return time;
        }
    }
}
