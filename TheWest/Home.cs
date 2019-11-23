using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWest
{   /// <summary>
    /// klasa Home dziedziczy po UpgradeBuilding, odpowiada za interakcje zwiazane z domem bohatera Arthura
    /// </summary>
    public class Home 
    {

        Arthur arthur;
        //konstruktor dziedziczacy z parametrem klasy Arthur
        public Home(Arthur person)
        {
            this.arthur = person;
            
        }

        /// <summary>
        /// funkcja odpowiedzialna za czytanie ksiazki, dodaje postaci punkty inteligencji
        /// </summary>
       public void readBook()
        {
            //inteligencja+=5 do statysk
            arthur.upgradeMind(5);
         }

        
       

    }
}
