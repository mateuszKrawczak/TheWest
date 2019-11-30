using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// klasa, ktorej obiekty są przeciwnikami głownego bohatera
    /// </summary>
    class Enemy: Person
    {
        //konstruktor, ktory dziedziczy po klasie Person i zawiera swoje atrybuty takie ktore posiada tylko postać glowna
        public Enemy(string name, int level, int aim, int mind, int money) : base(name, level, aim, mind, money)
        {

            this.name = name;
            this.level = level;
            this.aim = aim;
            this.mind = mind;
            this.money = money;
        }
    }
}
