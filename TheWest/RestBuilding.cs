using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa abstrakcyjna RestBuilding, dziedzicza po niej budynki, wktorych nasz bohater "odpoczywa" czyli kosciol i dom
    /// </summary>
    public abstract class RestBuilding
    {
        //zmenne zdrowia i energii
        protected int givenHealth;
        protected int givenEnergy;


        /// <summary>
        /// funkcja pobiera ilość otrzymywanej energii 
        /// </summary>
        /// <returns></returns>
        public virtual int GetGivenEnergy()
        {
            return givenEnergy;
        }

      /// <summary>
      /// funkcja ustawia ilosc energii ktora ma zostac przyznana dla danego bbudynku
      /// </summary>
      /// <param name="n"></param>
        public virtual void SetGivenEnergy(int n)
        {
            givenEnergy = n;
        }

        /// <summary>
        /// funkcja ustawia ilosc zdrowia ktora ma zostac przyznana dla danego bbudynku
        /// </summary>
        /// <param name="n"></param>
        public virtual void SetGivenHealth(int n)
        {
            givenHealth = n;
        }
        
        /// <summary>
        /// funkcja pobiera ilość zdrowia otrzymanego 
        /// </summary>
        /// <returns></returns>
        public virtual int GetGivenHealth()
        {
            return givenHealth;
        }

        
    }
}
