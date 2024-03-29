﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summaryHome>
    /// klasa Church dziedziczy po klasie abstrakcyjnej RestBuilding i interfejsie ICost
    /// </summary>
    public class Home : RestBuilding, ICost
    {
        //zmienne 
        private int cost;
        private int time;
        private int energy;
        private int experience;
        Arthur arthur;

        //konstruktor dziedziczacy z parametrem klasy Arthur
        public Home(Arthur person,int e,int h)
        {
            //przypisanie wartosci
            this.arthur = person;
            SetGivenEnergy(e);
            SetGivenHealth(h);
            cost = 150;
            time = 4;
            energy = 20;
            experience = 10;
        }

        //funkcje ktore zwracaja wartosci
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



        /// <summary>
        /// funkcja odpowiedzialna za czytanie ksiazki, dodaje postaci punkty inteligencji
        /// </summary>
        public void ReadBook()
        {
            //inteligencja+=5 do statysk
            arthur.UpgradeMind(5);
         }

        
    }
}
