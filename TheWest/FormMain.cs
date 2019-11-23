using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace TheWest

{   /// <summary>
    /// klasa ta odpowiada za okno głowne aplikacji
    /// </summary>
    public partial class FormMain : Form
    {   
        //inicjacja godziny i dnia
        int hour, day = 1;

        //zmienna przechowuje wartosc zmiany energii
        int valueEnergy;
        
        //zmienna przechowuje wartosc zmiany zycia
        int valueLife;
        
        //zmienna przechowuje wartosc zmiany aktywnosci
        int valueActivity;

        //zmienna przechowuje wartosc zmiany aktywnosci
        int valueExperience;

        //pieniadze przyznawane za nowy poziom

        int levelUpMoney = 400;
        //obiet windowsmediaplayer - potrzebny do muzyki
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        //pieniadze wprowadze w dodatkowym oknie 
        int moneyFromDialog = 0;

        //pomocniczy licxznik uzywany np do IsInvested
        int counter = 0;

        //zmienna potrzebna do przechowywania piniedzy z banku
        int bankMoney=0;

        //zmienna potrzebna do przeczytania ksiazki w zdarzeniu losowym
        bool isReaden = false;

        //zmienna potrzebna do przeczytania ksiazki w zdarzeniu losowym
        bool isPlayed = false;

        //przypisanie postaci w grze statystyk oraz utworzenie ich obiektow
        Arthur arthur = new Arthur("Arthur", 1,5,40,400, 100, 100);
        Person luke= new Person("Luke",6, 95, 90, 5000);
        Person joe= new Person("Joe",4, 60, 60, 1200);
        Person mary= new Person("Mary", 2, 30,35,600);

        //obiekty klas 
        Home home;
        Store store;
        Warehouse warehouse;

        //obiekt klasy potrzebnej do wywolania okna
        FormDialog formDialog;

        //obiekt klasy store 
        UpgradeBuilding building;

        //konstrukor
        public FormMain()
        {
            //inicjalizacja
            InitializeComponent();

            //zalaczenie pliku mp3
            player.URL = "oldtown.mp3";


            //wlaczenie muzyki
            player.controls.play();

            //inicjacja obiektow
            home = new Home(arthur);
            store = new Store(arthur);
            warehouse = new Warehouse(arthur);
            building = new UpgradeBuilding(arthur);
            
            //timer ustawiony co sekunde i wystartowanie czasu
            timerGlobal.Interval = 1000;
            timerGlobal.Start();

            //Ttimer obslugujacy muzyke, ustawiony co 150 sekund tyle trwa utwor
            timerMusic.Interval = 150000;
            timerMusic.Start();
            
            //przypisanie funkcji transparentności obrazkom
            pictureBox_Star.BackColor = Color.Transparent;
            pictureBox_TW.BackColor = Color.Transparent;
            pictureBox_Arthur.BackColor = Color.Transparent;
            panelLuke.BackColor = Color.Transparent;
            panelJoe.BackColor = Color.Transparent;
            panelMary.BackColor = Color.Transparent;
            label_Stats.BackColor = Color.Transparent;
            label_Money.BackColor = Color.Transparent;
            label_Shooting.BackColor = Color.Transparent;
            label_Mind.BackColor = Color.Transparent;
            label_Luke.BackColor = Color.Transparent;
            label_Joe.BackColor = Color.Transparent;
            label_Mary.BackColor = Color.Transparent;
            label_Life.BackColor = Color.Transparent;
            label_Energy.BackColor = Color.Transparent;
            label_Money_Stat.BackColor = Color.Transparent;
            label_Mind_Stat.BackColor = Color.Transparent;
            label_Aim_Stat.BackColor = Color.Transparent;
            pictureBox_Money.BackColor = Color.Transparent;
            pictureBox_Mind.BackColor = Color.Transparent;
            pictureBox_Gun.BackColor = Color.Transparent;
            label_Dollar.BackColor = Color.Transparent;
            pictureBox_Saloon.BackColor = Color.Transparent;
            pictureBox_Bank.BackColor = Color.Transparent;
            pictureBox_Home.BackColor = Color.Transparent;
            pictureBox_Wood.BackColor = Color.Transparent;
            pictureBox_Church.BackColor = Color.Transparent;
            pictureBox_Warehouse.BackColor = Color.Transparent;
            pictureBoxMaryCross.BackColor = Color.Transparent;
            pictureBoxLukeCross.BackColor = Color.Transparent;
            pictureBoxJoeCross.BackColor = Color.Transparent;
            pictureBox_Store.BackColor = Color.Transparent;
            label_Life_Stat.BackColor = Color.Transparent;
            label_Energy_Stat.BackColor = Color.Transparent;
            label_Wanted.BackColor = Color.Transparent;
            label_Work.BackColor = Color.Transparent;
            label_Level.BackColor = Color.Transparent;
            label_Level_Stat.BackColor = Color.Transparent;
            label_Experience.BackColor = Color.Transparent;
            label_Hour_Stat.BackColor = Color.Transparent;
            label_Day_Stat.BackColor = Color.Transparent;
            label_Hours.BackColor = Color.Transparent;
            label_Day.BackColor = Color.Transparent;

            //przypisanie label'om i paskom aktywnosci wartosci startowych
            label_Level_Stat.Text = arthur.Level.ToString();
            label_Energy_Stat.Text = arthur.Energy.ToString();
            label_Life_Stat.Text = arthur.Life.ToString();
            label_Mind_Stat.Text = arthur.Mind.ToString();
            label_Money_Stat.Text = arthur.Money.ToString();
            label_Aim_Stat.Text = arthur.Aim.ToString();
            progressBar_Exp.Value = arthur.Experience;

          

        }


        /// <summary>
        /// instrukcja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Instruction_Click(object sender, EventArgs e)
        {

            MessageBox.Show("INSTRUCTION\nYou are new man in town and your main goal it's to take control over Old Town." +
                " Unfortunetly Old Town is controlled by Lucky Luke's Gang. Your plan is to attack 3 main people of the gang. " +
                "First and most powerful is of course Luke, next one is his right hand, Fat Joe. " +
                "Last but not least is Luke's girlfriend, Bloody Mary.  You have 3 main statistisc which you can improve." +
                "Money, mind and aim - improving these statistisc will help you in duels with gang." +
                "Money is important to upgrading store. If you upgrade a store, your aim will be automicaly higher. Aim is important and crucial in duels with gang." +
                "Last but not least is intelligence. Upgrading this stat will give you more opurtunities in the game and it's very helpful. Good luck!");
        }

        
        /// <summary>
        /// klikniecie buttonReadBook powoduje wywołanie funkcji odpowiedzialnej za czytanie ksiazki; +5 do inteligncji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReadBook_Click(object sender, EventArgs e)
        {
            //inicjalizacja energii
            valueEnergy = 20;

            //warunek
            if (arthur.Mind < 100 && arthur.Energy >= valueEnergy)
            {
                //wywoluje funkcje readBook()
                home.readBook();

                //zmiana bool poniewaz bohater czyta
                arthur.IsReading = true;

                //warunek przeczytania ksiazki w dniu 7
                if (day == 7||day==6)
                {
                    isReaden = true;
                }
                //blokada przyciskow
                blockButtons();

                
                //zmieniam wartosc label na aktualna
                label_Mind_Stat.Text = arthur.Mind.ToString();

                //wzrost doswiadczenia
                increaseExperience(10);
            }
            else if (arthur.Mind < 100 && arthur.Energy < valueEnergy)
            {
                //wyswietlenie okna z informacja
                MessageBox.Show("You are out of energy");
            }else
            {
                //wyswietlenie okna z informacja
                MessageBox.Show("Mind is max value");
            }

        }


        /// <summary>
        /// klikniecie buttonRestHome powoduje wywołanie funkcji odpowiedzialnej za odpoczynek, przydizał punktow energii i zdrowia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRestHome_Click(object sender, EventArgs e)
        {
            //przypisanie wartosci logicznej true ""odpoczywa teraz"
            arthur.IsResting = true;

            //blokowanie przyciskow
            blockButtons();
            
          }

        /// <summary>
        /// funkcja obsluguje timer globalny czyli głowny programu są tu przede wszystkim warunki if z para,etrem bool, ktora sprawdza czy nasza głowna postac wykonuje dana czynnosc 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick_1(object sender, EventArgs e)
        {
            //aktualizacja godziny i etykiety
            hour++;
            label_Hour_Stat.Text = hour.ToString();
            

            // aktualizacja liczby dni gdy miną 24 godziny
            if (hour == 24)
            {
                // wyzerowanie liczby godzin
                hour = 0;

                // zwiększenie dni o 1
                day++;

                //warunek losowy zabranie pieniedzy z konta
                if (day == 4)
                {
                    int roofRepairMoney = arthur.Money /10;
                    MessageBox.Show("Oh no, your roof in home is leaking, you must reapir it. It will cost "+ roofRepairMoney+" $");
                    arthur.Money -= roofRepairMoney;
                    label_Money_Stat.Text = arthur.Money.ToString();

                }

                //warunek losowy mus przeczytania  ksiazki w ciagu dnia
                if (day == 6)
                {
                    MessageBox.Show("Oh no, sheriff of Old Town had everyone in the town read the civil code. Tommorow is deadline. You will pay money if you won't read it!");
                }

                //warunek losowy mus przeczytania  ksiazki w ciagu dnia
                if (day ==8)
                {
                    if (isReaden)
                    {
                        MessageBox.Show("Well done you are good inhabitant");
                    }
                    else
                    {
                        //jesli nie mamy odejmuje 1/10 naszego stanu konta
                        int civilCodeMoney = arthur.Money / 10;
                        MessageBox.Show("You had to pay "+ civilCodeMoney + " $");
                        //przypisanie nowej zmiennej i aktualizacja etykiety
                        arthur.Money -= civilCodeMoney;
                        label_Money_Stat.Text = arthur.Money.ToString();
                       
                    }
                    
                }

                ////warunek losowy zagrania w kasynie 10 dnia
                if (day == 9)
                {
                    
                        MessageBox.Show("Your old friend will be tommorow in Old Town, you must go with him to saloon play some poker. It can be dangerous for you if you won't play there...");
                   

                }
                //warynek
                if (day == 11)
                {
                    if (isPlayed)
                    {
                        MessageBox.Show("Nice work you are good friend");
                    }
                    else
                    {
                        //uszkodzenie zdrowia gracza i aktualizacja etykiety
                        MessageBox.Show("Your friend is quite temperamental, he was drunk and almost kill you...");
                        arthur.Life = 10;
                        label_Life_Stat.Text = arthur.Life.ToString();

                    }

                }
                //przypisanie aktualnych wartosci do etykiet
                label_Hour_Stat.Text = hour.ToString();
                label_Day_Stat.Text = day.ToString();

                //jesli inwestuje
                if (arthur.IsInvesting)
                {
                    counter++;
                    if(counter>=2)
                    {
                        //pomnozenie pieniedzy
                        arthur.Money = bankMoney * 2;
                        counter = 0;
                        label_Money_Stat.Text = arthur.Money.ToString();
                        MessageBox.Show("Well done you earned from bank " + arthur.Money.ToString() + " $");
                        arthur.IsInvesting = false;
                        buttonInvest.Enabled = true; ;
                    }
                }
            }

            //jesli czyta wykonuje instrukcje
            if (arthur.IsReading)
             {
                //przypisanie wartosci zmiennych
                valueActivity = 25;
                valueEnergy = 5;

                
                if (progressBar_Activity.Value < 100)
                {

                    //inkrementuje activity bar o valueActivity
                    progressBar_Activity.Increment(valueActivity);

                    

                    //dekrementacja wartosci energii
                    decrementOfEnergy(valueEnergy);

                }

                if (progressBar_Activity.Value >= 100)
                {

                    
                    //przypisuje false bo bohater skonczyl czytac ksiazke
                    arthur.IsReading = false;

                    //zeruje pasek aktywnosci
                    progressBar_Activity.Value = 0;
                    
                    //odblokowanie przyciskow
                    unlockButtons();
                }
                
             }

            //jesli odpoczywa wykonuje instrukcje
            if (arthur.IsResting)
            {
                //przypisanie wartosci zmiennych
                valueActivity = 20;
                valueEnergy = 4;
                valueLife = 8;

                if (progressBar_Activity.Value < 100)
                {

                    //inkrementuje activity bar o valueActivity
                    progressBar_Activity.Increment(valueActivity);

                    //dekrementacja wartosci energii
                    incrementEnergy(valueEnergy);
                    incrementLife(valueLife);
                }

                if (progressBar_Activity.Value >= 100)
                {
                    //przypisuje false bo bohater skonczyl czytac ksiazke
                    arthur.IsResting = false;

                    //zeruje pasek aktywnosci
                    progressBar_Activity.Value = 0;

                    //odblokowanie przyciskow
                    unlockButtons();
                }

            }
            //jesli sie modli wykonuje instrukcje
            if (arthur.IsPraying)
            {
                //przypisanie wartosci zmiennych
                valueActivity = 50;
                valueEnergy = 25;

                if (progressBar_Activity.Value < 100)
                {

                    //inkrementuje activity bar o valueActivity
                    progressBar_Activity.Increment(valueActivity);

                    //dekrementacja wartosci energii
                    incrementEnergy(valueEnergy);

                }
                if (progressBar_Activity.Value >= 100)
                {
                    //przypisuje false bo bohater skonczyl czytac ksiazke
                    arthur.IsPraying = false;

                    //zeruje pasek aktywnosci
                    progressBar_Activity.Value = 0;

                    //odblokowanie przyciskow
                    unlockButtons();
                }

            }
            //jesli ulepsza wykonuje instrukcje
            if (arthur.IsUpgrading)
            {
                //przypisanie wartosci zmiennych
                valueActivity = 20;
                valueEnergy = 6;

                if (progressBar_Activity.Value < 100)
                {
                    
                    //inkrementuje activity bar o valueActivity
                    progressBar_Activity.Increment(valueActivity);

                    //dekrementacja wartosci energii
                    decrementOfEnergy(valueEnergy);

                }
                if (progressBar_Activity.Value >= 100)
                {
                    //przypisuje false bo bohater skonczyl czytac ksiazke
                    arthur.IsUpgrading = false;

                    //zeruje pasek aktywnosci
                    progressBar_Activity.Value = 0;

                    //odblokowanie przyciskow
                    unlockButtons();
                }

            }
            //jesli pracuje wykonuje instrukcje
            if (arthur.IsWorking)
            {
                //przypisanie wartosci zmiennych
                valueActivity = 20;
                valueEnergy = 6;

                if (arthur.Energy - valueEnergy >= 0)
                {
                    if (progressBar_Activity.Value < 100)
                    {

                        //inkrementuje activity bar o 20
                        progressBar_Activity.Increment(valueActivity);

                        //zmienienie wartosci pieniedzy 
                        arthur.Money += valueActivity;

                        //przypisanie wartosci pieniedzy do etykiety
                        label_Money_Stat.Text = arthur.Money.ToString();

                        //dekrementacja wartosci energii
                        decrementOfEnergy(valueEnergy);
                    }

                    if (progressBar_Activity.Value >= 100)
                    {
                        //przypisuje false bo bohater skonczyl czytac ksiazke
                        arthur.IsWorking = false;

                        //zeruje pasek aktywnosci
                        progressBar_Activity.Value = 0;

                        //odblokowanie przyciskow
                        unlockButtons();
                    }
                }
                else
                {
                    arthur.IsWorking = false;
                    unlockButtons();
                    MessageBox.Show("You are too tired for working");
                }
            }
            //sprawdza czy kupilismy magazyn
            if (arthur.IsHavingWarehouse)
            {
                //jak tak pieniadze są dodawane co godzine do konta
                arthur.Money += warehouse.Salary;
                   
                          

                 //przypisanie wartosci pieniedzy do etykiety
                 label_Money_Stat.Text = arthur.Money.ToString();

                           
             }





            
        }

        /// <summary>
        /// funkcja blokuje przyciski podczas wykonywania czynnosci
        /// </summary>
        public void blockButtons()
        {
            buttonReadBook.Enabled = false;
            button1_Instruction.Enabled = false;
            button2_Save.Enabled = false;
            button3_Load.Enabled = false;
            buttonBuyWarehouse.Enabled = false;
            buttonInvest.Enabled = false;
            buttonPoker.Enabled = false;
            buttonPray.Enabled = false;
            buttonRestHome.Enabled = false;
            buttonUpgradeStore.Enabled = false;
            buttonUpgradeWarehouse.Enabled = false;
            buttonWorkWood.Enabled = false;
            buttonFightLuke.Enabled = false;
            buttonFightMary.Enabled = false;
            buttonJoeFight.Enabled = false;
            
        }

        /// <summary>
        /// funkcja odblokowuje przyciski po wykonaniu czynnosci
        /// </summary>
        public void unlockButtons()
        {
            buttonReadBook.Enabled = true;
            button1_Instruction.Enabled = true;
            button2_Save.Enabled = true;
            button3_Load.Enabled = true;
            buttonBuyWarehouse.Enabled = true;
            buttonInvest.Enabled = true;
            buttonPoker.Enabled = true;
            buttonPray.Enabled = true;
            buttonRestHome.Enabled = true;
            buttonUpgradeStore.Enabled = true;
            buttonUpgradeWarehouse.Enabled = true;
            buttonWorkWood.Enabled = true;
            buttonFightLuke.Enabled = true;
            buttonFightMary.Enabled = true;
            buttonJoeFight.Enabled = true;

        }

        /// <summary>
        /// funkcja odpowiedzialna za wzrost doswiadczenia
        /// </summary>
        /// <param name="value"></param>
        public void increaseExperience(int value)
        {
            //zmienna pomocnicza potrzebna do punktow doswiadczenia w przypadku awansu poziomu naszej postaci 
            int diffrenceExperience=0;

            //jesli doswiadczenie <100 dodaje zadana wartosc punktow do doswiadczenia i przypisuje do paska
            if (arthur.Experience < 100&&100- arthur.Experience>value)
            {
                //doswiadczenie inkrementuje o zadana wartosc
                arthur.Experience += value;
                //przypisanie do paska doświadczenia
                progressBar_Exp.Value = arthur.Experience;

            }else
            {
                //roznica pomiedzy supa doswiadczenia bohatera i wartosci doswiadczenia a 100 czyli pełnym doświadczeniem 
                diffrenceExperience = arthur.Experience + value - 100;

                //jesli ma 100 lub wiecej doswiadczenia, wzrasta poziom postaci a doświadczenie=0
                arthur.Experience = diffrenceExperience;
                progressBar_Exp.Value = arthur.Experience;

                //zwrost poziomu
                arthur.increaseLevel();
                MessageBox.Show("Congratulations, level up. You receive "+levelUpMoney+" $");

                //zwiekszenie pieniedzy za poziom
                levelUpMoney += 200;

                //przypisanie i aktualizacja etykiet
                arthur.Money += levelUpMoney;
                label_Money_Stat.Text = levelUpMoney.ToString();
                label_Level_Stat.Text = arthur.Level.ToString();
            }
            
        }

        /// <summary>
        /// dekremntacja energii
        /// </summary>
        public void decrementOfEnergy(int value)
        {
            //jesli spelnia warunek  to dekrementacja energii i przypisanie do etykiety
            if (arthur.Energy>= value)
            {
                arthur.Energy -= value;
                label_Energy_Stat.Text = arthur.Energy.ToString();
            }
            else
            {
                //wyswietlenie okna z informacja
                MessageBox.Show("You are to tired for it");
            }
            


        }

        /// <summary>
        /// inkrementacja energii o zadana wartosc
        /// </summary>
        /// <param name="value"></param>
        public void incrementEnergy(int value)
        {
            //jesli spelnia warunek  to dekrementacja energii i przypisanie do etykiety
            if (arthur.Energy <= 100-value)
            {
                //zwiekszenie energii
                arthur.Energy += value;
                
            }
            else
            {
                //przypisanie 100 ak wyjdzie poza zakres
                arthur.Energy = 100;
                
            }
            //aktualizacja etykiety
            label_Energy_Stat.Text = arthur.Energy.ToString();

        }

        /// <summary>
        /// funkcja obslugujaca timer do muzyki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerMusic_Tick(object sender, EventArgs e)
        {

            //obiet windowsmediaplayer - potrzebny do muzyki
              player = new WindowsMediaPlayer();

            //zalaczenie pliku mp3
              player.URL = "oldtown.mp3";


            //wlaczenie muzyki
              player.controls.play();

        }

        /// <summary>
        /// funkcja która przypisuje wartosc true isReading, oznacza to że nasza postac pracuje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWorkWood_Click(object sender, EventArgs e)
        {
            //koszta pracy(energia aktywnosc)
            valueEnergy = 30;
            valueExperience = 20;
            if (arthur.Energy >= valueEnergy)
            {
                //przypisanie praacy i blokada przyciskow
                arthur.IsWorking = true;

                //wzrost doswiadczenia
                increaseExperience(valueExperience);
                 blockButtons();
            }
            else
            {
                //okienko
                MessageBox.Show("You are too tired for it, you need at least " + valueEnergy+" energy");
            }


        }

        /// <summary>
        /// przycisk odpowiedzialny za rozpoczecie modlenia sie, powoduje wzrost energii
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPray_Click(object sender, EventArgs e)
        {
            //koszt modlitwy
            int costOfPray = 150;

            //doswiadczenie za modlitwe
            valueExperience = 10;

            //warunek jesli pieniadza sa wieksze od kosztu modlitwy
            if(arthur.Money>= costOfPray)
            {
                //wlaczenie modlitwy
                arthur.IsPraying = true;

                //wzrost doswaidczenia
                increaseExperience(valueExperience);

                //redukcja pieniedzy
                arthur.Money -= costOfPray;
                label_Money_Stat.Text = arthur.Money.ToString() ;
                blockButtons();
            }
            else
            {
                MessageBox.Show("If you want to pray you must have more money, at least "+ costOfPray+" $");
            }
        }

        /// <summary>
        /// klikniecie przycisku buttonUpgradeStore ulepsza sklep i tym samym polepszamy swoją celność
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeStore_Click(object sender, EventArgs e)
        {


            //warunek
                if (arthur.Aim < 100 && arthur.Level >= store.CurrentBuildingLevel && arthur.Money - store.CostUpgrade >= 0&& store.CurrentBuildingLevel<7)
                {
                    //koszt energii
                    valueEnergy = 30;

                    //warunek
                    if (arthur.Energy - valueEnergy >= 0)
                    {
                    //blokowanie klawiszy
                    blockButtons();

                    //doswiadczenie za ulepszenie
                    valueExperience = 20;
                    
                    //wykonanie czynncosci ulepszania
                    arthur.IsUpgrading = true;

                    //wzrost poziomu budynku
                    building.upgradeBuilding(store);

                    //zwiekszenie celnosci
                    store.boostingAim();

                    //wzrost doswiadczenia
                    increaseExperience(valueExperience);

                    //aktualizcaja etykiet
                    label_Aim_Stat.Text = arthur.Aim.ToString();
                    label_Money_Stat.Text = arthur.Money.ToString();
                 }
                    else
                    {
                        MessageBox.Show("You are to tired for it, you need at least " + valueEnergy + " energy");

                    }

                }
                else if (store.CurrentBuildingLevel >= 6)
                {
                MessageBox.Show("Store is upgraded on full level");
                }
                else if (arthur.Level < store.CurrentBuildingLevel)
                {
                MessageBox.Show("You must to increase your level to upgrade building");
                }
            else if ((arthur.Money - store.CostUpgrade) < 0)
                {
                    MessageBox.Show("You don't have enaugh money, you need at least " + store.CostUpgrade+"  $");
            }
            else
            {
                MessageBox.Show("Aim is max value");
            }

            

        }

        /// <summary>
        /// klikniecie przycisku buttonInvest_Cick powoduje mozliwosc zainwestowania przez uzytkownika pieniedzy 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInvest_Click(object sender, EventArgs e)
        {
            //jesli nie inwestuje spelnia warunek
            if (arthur.IsInvesting != true)
            {


                if (arthur.Mind >= 50)
                {
                    //otwieram dodatkowe okno z textboxem do wpisania ilosci pieniedzy i przypisuje
                    moneyFromDialog = dialogWindow();
                    bankMoney = moneyFromDialog;

                    if (moneyFromDialog < 100)
                    {
                        MessageBox.Show("You should enter at least 100$");

                    }
                    else if (moneyFromDialog > arthur.Money)
                    {
                        MessageBox.Show("You don't have that money");
                    }
                    else
                    {
                        //aktualizacja pieniedzy i przypisaniewartosci 
                        MessageBox.Show("After 4 days you will earn doble amount of given money");
                        arthur.Money -= bankMoney;
                        label_Money_Stat.Text = arthur.Money.ToString();
                        arthur.IsInvesting = true;
                        buttonInvest.Enabled = false;
                    }
                }
                else if (arthur.Mind < 50)
                {
                    MessageBox.Show("You are not clever enaugh for investing at the bank, you need 50 points of mind");
                }
            }
            else
            {
                MessageBox.Show("You are currently investing.");

            }
        }

        /// <summary>
        ///funkcja otwiera okno dialogowe potrzebne do podania ilosci pieniedzy 
        /// </summary>
        private int dialogWindow()
        {
            //zmienna pomocnicza
            int amountOfmoney = 0;
            
            //nowe okno dodatkowe potrzebne do podania ilosci pieniedzy
            formDialog = new FormDialog();
            formDialog.ShowDialog();
            amountOfmoney = formDialog.moneyAmount;

            //zwracam ilosc pieniedzy
            return amountOfmoney;
        }

        /// <summary>
        /// funkcja klikniecia przycisku ktora jest odpowiedzialna za granie w pseudo "pokera"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPoker_Click(object sender, EventArgs e)
        {   
            
            //przydział pieniedzy
            moneyFromDialog = dialogWindow();
            
            if (moneyFromDialog < 50)
            {
                MessageBox.Show("You should enter at least 50$.");

            }
            else if (moneyFromDialog > arthur.Money)
            {
                MessageBox.Show("You don't have that money!");
            }
            else
            {
                // Instantiate random number generator using system-supplied value as seed.
                var rand = new Random();

                //losowanie liczby
                int randomNumber = rand.Next(101);

                //warunek zagrania w pokera 10 dnia
                if (day == 10)
                {
                    isPlayed = true;
                }
                //jesli pseudo liczba mniejsza od 50 to starta pieniedzy, około 50% na przegranie
                if (randomNumber < 50)
                {
                    arthur.Money -= moneyFromDialog;
                    
                    MessageBox.Show("Unfortunetely you lost " + moneyFromDialog);
                }
                else
                {
                    arthur.Money += moneyFromDialog;
                    
                    MessageBox.Show("Congratulations you won "+ moneyFromDialog);
                }
                label_Money_Stat.Text = (arthur.Money).ToString();

            }
        }

        /// <summary>
        /// klikniecie przycisku powoduje kupienie magazynu, mozemy otrzymawac pieniadze nie robić zadnych czynnosci
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBuyWarehouse_Click(object sender, EventArgs e)
        {
            //warunek to intelgencja>=40
            if (arthur.Mind >= 60)
            {
               
                if (arthur.Money< warehouse.CostBuy)
                {
                    MessageBox.Show("You should have  "+warehouse.CostBuy+" $ to buy warehouse.");

                }
                else
                {
                    //znikniecie przycisku
                    buttonBuyWarehouse.Enabled = false;
                    buttonBuyWarehouse.Visible = false;
                    
                    //redukcja piebniedzy
                    arthur.Money -= warehouse.CostBuy;
                    MessageBox.Show("Congratulations you bought warehouse, now you can earn money all the time!");
                    increaseExperience(10);
                    //pokazanie przycisku do ulepszania
                    buttonUpgradeWarehouse.Visible = true;
                    arthur.IsHavingWarehouse = true;
                }
            }
            else if (arthur.Mind < 60)
            {
                MessageBox.Show("You are not clever enaugh to buy warehouse, you nead at least "+60+" points of mind");
            }
        }

        /// <summary>
        /// klikniecie przycisku powoduje ulepszenie magazynu =>lepsza wypłata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeWarehouse_Click(object sender, EventArgs e)
        {
            if (arthur.Level >= warehouse.CurrentBuildingLevel && arthur.Money - warehouse.CostUpgrade >= 0&& warehouse.CurrentBuildingLevel < 6)
            {
                //koszt energii ulepszenia
                valueEnergy = 30;


                if (arthur.Energy - valueEnergy >= 0)
                {
                    //blokowanie pieniedzy
                    blockButtons();
                    valueExperience = 15;
                    
                    //podniesienie wyplaty
                    warehouse.risingSalary();

                    //wlaczenie trybu ulepszania w zegarze
                    arthur.IsUpgrading = true;

                    //ulepszenie budynku
                    building.upgradeBuilding(warehouse);


                    //wzrost doswiadczeniancreaseExperience(valueExperience);
                    increaseExperience(20);
                    
                }
                else
                {
                    MessageBox.Show("You are to tired for it, you need at least "+ valueEnergy+" energy");

                }

            }
            else if (warehouse.CurrentBuildingLevel >= 5)
            {
                MessageBox.Show("Warehouse is upgraded on full level");
            }
            else if (arthur.Level < warehouse.CurrentBuildingLevel)
            {
                MessageBox.Show("You must to increase your level to upgrade building");
            }
            else if ((arthur.Money - warehouse.CostUpgrade) < 0)
            {
                MessageBox.Show("You don't have enaugh money");
            }
        }

        /// <summary>
        /// klikniecie przycisku wywoloje 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFightMary_Click(object sender, EventArgs e)
        {
            valueEnergy = 50;

            if(arthur.Energy>= valueEnergy&&arthur.Life>=100)
            {
                if (mary.Aim >= arthur.Aim)
                {
                    MessageBox.Show("Unfortunetely you lost but hopefully you ran away");
                    arthur.Life = 10;
                    label_Life_Stat.Text = arthur.Life.ToString();
                    arthur.Energy = 10;
                    label_Energy_Stat.Text = arthur.Energy.ToString();
                }
                else
                {
                    buttonFightMary.Enabled = false;
                    pictureBoxMaryCross.Visible = true;
                    MessageBox.Show("Congratulations you won, Mary is dead");
                    decrementOfEnergy(10);
                    label_Energy_Stat.Text = arthur.Energy.ToString();
                    increaseExperience(50);
                    arthur.Money += mary.Money;
                    label_Money_Stat.Text = arthur.Money.ToString();
                }


            }
            else if(arthur.Energy < valueEnergy)
            {
                MessageBox.Show("You need at least 50 points of energy to fight");
            }else if(arthur.Life < 100)
            {
                MessageBox.Show("You need full points of health  to fight");
            }

        }

        private void buttonJoeFight_Click(object sender, EventArgs e)
        {
            valueEnergy = 50;

            if (arthur.Energy >= valueEnergy && arthur.Life >= 100)
            {
                if (joe.Aim > arthur.Aim)
                {
                    MessageBox.Show("Unfortunetely you lost but hopefully you ran away");
                    arthur.Life = 10;
                    label_Life_Stat.Text = arthur.Life.ToString();
                    arthur.Energy = 10;
                    label_Energy_Stat.Text = arthur.Energy.ToString();
                }
                else
                {
                    buttonJoeFight.Enabled = false;
                    pictureBoxJoeCross.Visible = true;
                    MessageBox.Show("Congratulations you won, Joe is dead");
                    decrementOfEnergy(10);
                    label_Energy_Stat.Text = arthur.Energy.ToString();
                    increaseExperience(60);
                    arthur.Money += joe.Money;
                    label_Money_Stat.Text = arthur.Money.ToString();
                }


            }
            else if (arthur.Energy < valueEnergy)
            {
                MessageBox.Show("You need at least 50 points of energy to fight");
            }
            else if (arthur.Life < 100)
            {
                MessageBox.Show("You need full points of health  to fight");
            }
        }

        private void buttonFightLuke_Click(object sender, EventArgs e)
        {
            valueEnergy = 50;

            if (arthur.Energy >= valueEnergy && arthur.Life >= 100)
            {
                if (luke.Aim > arthur.Aim)
                {
                    MessageBox.Show("Unfortunetely you lost but hopefully you ran away");
                    arthur.Life = 10;
                    label_Life_Stat.Text = arthur.Life.ToString();
                    arthur.Energy = 10;
                    label_Energy_Stat.Text = arthur.Energy.ToString();
                }
                else
                {
                    buttonFightLuke.Enabled = false;
                    pictureBoxLukeCross.Visible = true;
                    MessageBox.Show("Congratulations, old town is yours. Now just have fun :)");
                    decrementOfEnergy(10);
                    label_Energy_Stat.Text = arthur.Energy.ToString();
                    increaseExperience(50);
                    arthur.Money += luke.Money;
                    label_Money_Stat.Text = arthur.Money.ToString();



                }


            }
            else if (arthur.Energy < valueEnergy)
            {
                MessageBox.Show("You need at least 50 points of energy to fight");
            }
            else if (arthur.Life < 100)
            {
                MessageBox.Show("You need full points of health  to fight");
            }
        }

        


        
        /// <summary>
        /// funkcja inkrementuje zycie o zadana wartosc
        /// </summary>
        /// <param name="value"></param>
        public void incrementLife(int value)
        {
            //jesli spelnia warunek  to dekrementacja energii i przypisanie do etykiety
            if (arthur.Life <= 100 - value)
            {
                arthur.Life += value;

            }
            else
            {
                arthur.Life = 100;

            }

            label_Life_Stat.Text = arthur.Life.ToString();

        }
    }

        

 }
