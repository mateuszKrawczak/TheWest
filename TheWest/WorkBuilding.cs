using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa abstrakcyjna WorkBuilding, dziedzi poniej budynki zwiazane z pracą czyli HotelWork i WoodWork
    /// </summary>
    public abstract class WorkBuilding
    {
        //zmienna pensji za godzine
        protected int salaryPerHour;

        /// <summary>
        /// metoda pobiera i ustawia pensje za godzine
        /// </summary>
        /// <param name="n"></param>
        public virtual void SetSalaryPerHour(int n)
        {
            salaryPerHour=n;
        }
        
        /// <summary>
        /// funkcja zwraca pensje za godzine
        /// </summary>
        /// <returns></returns>
        public virtual int GetSalaryPerHour()
        {
            return salaryPerHour;
        }

        /// <summary>
        /// funkcja abstrakcyjna ktora zwraca czas aktywnosci
        /// </summary>
        /// <returns></returns>
        abstract public int TimeOfActivity();

        /// <summary>
        /// funkcja abstrakcyjna która zwraca energie potrzebną do pracy
        /// </summary>
        /// <returns></returns>
        abstract public int EnergyOfActivity();
    }
}
