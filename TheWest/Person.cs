using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    //klasa Person odpowiada za atrybuty wszystkich czterech postaci w grze
    public class Person
    {
        //zmienne
        protected string name;//ak klasa dziedziczaca to musze protected
        protected int level;
        protected int aim;
        protected int mind;
        protected int money;
        //kontruktor wraz z przypisaniem nowych wartosci
        public Person(string namePerson,int levelPerson, int aimPerson, int mindPerson, int moneyPerson)
        {
        name=namePerson;
        level=levelPerson;
        aim=aimPerson;
        mind=mindPerson;
        money=moneyPerson;
    }
        //gettery i settery
        public int Level { get => level; set => level = value; }
        public int Aim { get => aim; set => aim = value; }
        public int Mind { get => mind; set => mind = value; }
        public int Money { get => money; set => money = value; }
        public string Name { get => name; set => name = value; }

        
    }
}
