using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{
    /// <summary>
    /// interfejs, ktory posiada funkcje przypisywane do budynków takie jak koszta aktywnosci, energii, czasu wykonania i doswiadczenia
    /// </summary>
    interface ICost
    {
        
        int CostOfActivity();
        int EnergyOfActivity();
        int TimeOfActivity();
        int ExperienceOfActivity();
    }
}
