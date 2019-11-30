using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// abstrakcyjna klasa odpowiedzialna za jednostke do walki pomiedzy miastami
    /// </summary>
    public abstract class Unit
    {
        //statystyki obrony, ataku i koszt jednostki
        protected int defending;
        protected int attacking;
        protected int costOfUnit;

        //ustawiam statystyke obrony
        public virtual void SetDefending(int temp)
        {
            defending = temp;
        }
        //ustawiam statystyke ataku
        public virtual void SetAttacking(int temp)
        {
            attacking = temp;
        }
        //pobieram statystyke ataku
        public virtual int GetAttacking()
        {
            return attacking;
        }
        //pobieram statystyke obrony
        public virtual int GetDefending()
        {
            return defending;
        }
        //ustawiam koszt jednostki
        public virtual void SetCostOfUnit(int temp)
        {
            costOfUnit = temp;
        }
        //pobierma koszt jednostki
        public virtual int GetCostOfUnit()
        {
           return costOfUnit;
        }
       
    }
}
