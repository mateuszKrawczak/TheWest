using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    //klasa naszego głownego bohatera
    public class Arthur:Person
    {
        //zmienne Arthura
        private int energy;
        private int life;
        private bool isReading = false;
        private bool isResting = false;
        private bool isWorking = false;
        private bool isUpgrading = false;
        private bool isPraying = false;
        private bool isInvesting = false;
        private bool isHavingWarehouse = false;
        private int timeActivity;
        private int experience = 0;
        
        //konstruktor, ktory dziedziczy po klasie Person i zawiera swoje atrybuty takie ktore posiada tylko postać glowna
        public Arthur(string name, int level, int aim, int mind, int money, int life,int energy) : base(name,level, aim, mind, money)
        {
            this.life = life;
            this.energy = energy;

        }
        //gettery i settery atrybutow
        public int Energy { get => energy; set => energy = value; }
        public int Life { get => life; set => life = value; }
        public bool IsReading { get => isReading; set => isReading = value; }
        public int TimeActivity { get => timeActivity; set => timeActivity = value; }
        public int Experience { get => experience; set => experience = value; }
        public bool IsResting { get => isResting; set => isResting = value; }
        public bool IsWorking { get => isWorking; set => isWorking = value; }
        public bool IsUpgrading { get => isUpgrading; set => isUpgrading = value; }
        public bool IsPraying { get => isPraying; set => isPraying = value; }
        public bool IsInvesting { get => isInvesting; set => isInvesting = value; }
        public bool IsHavingWarehouse { get => isHavingWarehouse; set => isHavingWarehouse = value; }

        /// <summary>
        /// funkcja odpowiedzialna za podniesienie poziomu bohatera gdy doswiadczenie bedzie rowne 100 i przypisanie 0
        /// </summary>
        public void increaseLevel()
        {
               level++;
              
        }
        /// <summary>
        /// funkcja ktora przypisuje zmiennej mind wartosc wieksza o value
        /// </summary>
        /// <param name="value"></param>
        public void upgradeMind(int value)
        {
            mind += value;
        }
        
    }
}
