﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        //pensaj otrzymywana w budynkach gdzie mozna pracowac
        int salary;
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

        //lista jednostek jednostek z OldTown
        private List<Unit> unitsOldtown = new List<Unit>();

        //lista jednostek jednostek z Newport
        private List<Unit> unitsNewport = new List<Unit>();

        //liczniki jednostek dla Oldtown
        int counterOfHorsesOldtown = 0;
        int counterOfShootersOldtown = 0;

        //liczniki jednostek dla Newport
        int counterOfHorsesNewport= 0;
        int counterOfShootersNewport = 0;

        //zmienne przechowujace ogolny status obrony jednostek Oldtown
        int overallDefendOldtown = 0;
        int overallAttackOldtown = 0;

        //zmienne przechowujace ogolny status obrony jednostek Newport
        int overallAttackNewport = 0;
        int overallDefendNewport = 0;
        //przypisanie postaci w grze statystyk oraz utworzenie ich obiektow
        Arthur arthur = new Arthur("Arthur", 1,5,40,1000, 100, 100);
        Person luke;
        Person joe;
        Person mary;

        //obiekty klas 
        Home home;
        Store store;
        Warehouse warehouse;
        Church church;
        WoodWork wood;
        HotelWork hotel;
        Saloon saloon;
        StudOfHorses horses;


        //obiekt klasy potrzebnej do wywolania okna
        FormDialog formDialog;

        //obiekty klas abstrakcyjnych
        WorkBuilding work;
        RestBuilding rest;
        PlayBuilding play;
        RandomEvent randomEvent;
        Unit unit;

        //zmienne logiczne, ktore przechowuja czy antygonisci żyja
        bool isMaryDead = false;
        bool isJoeDead=false;
        bool isLukeDead=false;



        //zmienna informujaca czy atakujemy newport
        bool isAttacking = false;

        //konstrukor
        public FormMain()
        {
            //inicjalizacja
            InitializeComponent();

            //zalaczenie pliku mp3
            player.URL = "oldtown.mp3";


            //wlaczenie muzyki
            player.controls.play();

            //inicjalizacja obiektu klaasy Store
            store = new Store(arthur);

            //inicjalizacja obiektu klaasy Warehouse
            warehouse = new Warehouse(arthur);

            //wywolanie funkcji ktora dodaje jednostki Newport
            AddUnitsOfNewport(-5);
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
            labelAttackNewport.BackColor = Color.Transparent;
            labelRecruit.BackColor = Color.Transparent;
            label_Day.BackColor = Color.Transparent;
            groupBoxArmyOldTown.BackColor = Color.Transparent;
            groupBoxArmyOfNewport.BackColor = Color.Transparent;
            radioButtonShooter.BackColor = Color.Transparent;
            radioButtonHorse.BackColor = Color.Transparent;
            radioButtonAttack.BackColor = Color.Transparent;
            radioButtonPeace.BackColor = Color.Transparent;
            pictureBoxHorses.BackColor= Color.Transparent;
            pictureBoxHotel.BackColor = Color.Transparent;
            labelOldtownHorsesStat.BackColor = Color.Transparent;
            labelNewportHorsesStat.BackColor = Color.Transparent;
            labelNewportShootersStat.BackColor = Color.Transparent;
            labelOldtownShootersStat.BackColor = Color.Transparent;

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
                "Last but not least is intelligence. Upgrading this stat will give you more opurtunities in the game and it's very helpful. The new option in the game is " +
                "possibilty of attacking other town - Newport; you can recruit your units from your town for the right amount of money. Horses will give you more attacing stats," +
                " but shooters are better in defending. Good luck!");
        }

        
        /// <summary>
        /// klikniecie buttonReadBook powoduje wywołanie funkcji odpowiedzialnej za czytanie ksiazki; +5 do inteligncji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReadBook_Click(object sender, EventArgs e)
        {
            //rzutowanie na klase abstrakcyjną
            rest = new Home(arthur, 5, 5);
            home = (Home)rest;

            //przypisanie wartosci zmiennych czasu wykonania i energii
            valueActivity = 100 / home.TimeOfActivity();

            //inicjalizacja energii
            valueEnergy = home.EnergyOfActivity() / home.TimeOfActivity();
            
            
            
            valueExperience = home.ExperienceOfActivity();

                 

            //warunek
            if (arthur.Mind < 100 && arthur.Energy >= valueEnergy)
            {
                //wywoluje funkcje readBook()
                home.ReadBook();

                //zmiana bool poniewaz bohater czyta
                arthur.IsReading = true;

                //warunek przeczytania ksiazki w dniu 7
                if (day == 7||day==6)
                {
                    isReaden = true;
                }
                //blokada przyciskow
                BlockButtons();

                
                //zmieniam wartosc label na aktualna
                label_Mind_Stat.Text = arthur.Mind.ToString();

                //wzrost doswiadczenia
                IncreaseExperience(valueExperience);
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
            //rzutowanie na klase abstrakcyjną
            rest = new Home(arthur, 5, 5);
            home = (Home)rest;

            //przypisanie wartosci zmiennych
            valueActivity = 100 / home.TimeOfActivity();
            valueEnergy = home.GetGivenEnergy();
            valueLife = home.GetGivenHealth();

            //przypisanie wartosci logicznej true ""odpoczywa teraz"
            arthur.IsResting = true;

            //blokowanie przyciskow
            BlockButtons();
            
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

                //warunek losowy zabranie pieniedzy z konta, poniewaz przecieka dach
                if (day == 4)
                {
                    //rzutowanie na klase abstrakcyjną
                    randomEvent = new FirstEvent(arthur);
                    FirstEvent first = (FirstEvent)randomEvent;
                    //wywołanie funkcji ze zdarzeniem
                    first.RandomEventInGame();
                    //przypisanie pieniedzy do label'a
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
                        //rzutowanie na klase abstrakcyjną
                        randomEvent = new SecondEvent(arthur);
                        SecondEvent second = (SecondEvent)randomEvent;
                        //wywolanie metody ze zdarzeniem
                        second.RandomEventInGame();
                        //aktualizacja label'a
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
                        //rzutowanie na klase abstrakcyjną
                        randomEvent = new ThirdEvent(arthur);
                        ThirdEvent third = (ThirdEvent)randomEvent;
                        //wywolanie metody ze zdarzeniem
                        third.RandomEventInGame();
                        //aktualizacja label'a
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
                        //aktualizacja label'a
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
                  if (progressBar_Activity.Value < 100)
                {

                    //inkrementuje activity bar o valueActivity
                    progressBar_Activity.Increment(valueActivity);

                    

                    //dekrementacja wartosci energii
                    DecrementOfEnergy(valueEnergy);

                }

                if (progressBar_Activity.Value >= 100)
                {

                    
                    //przypisuje false bo bohater skonczyl czytac ksiazke
                    arthur.IsReading = false;

                    //zeruje pasek aktywnosci
                    progressBar_Activity.Value = 0;
                    
                    //odblokowanie przyciskow
                    UnlockButtons();
                }
                
             }

            //jesli odpoczywa lub sie modli wykonuje instrukcje
            if (arthur.IsResting)
            {
                
                if (progressBar_Activity.Value < 100)
                {

                    //inkrementuje activity bar o valueActivity
                    progressBar_Activity.Increment(valueActivity);

                    //dekrementacja wartosci energii
                    IncrementEnergy(valueEnergy);
                    IncrementLife(valueLife);
                }

                if (progressBar_Activity.Value >= 100)
                {
                    //przypisuje false bo bohater skonczyl czytac ksiazke
                    arthur.IsResting = false;

                    //zeruje pasek aktywnosci
                    progressBar_Activity.Value = 0;

                    //odblokowanie przyciskow
                    UnlockButtons();
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
                    DecrementOfEnergy(valueEnergy);

                }
                if (progressBar_Activity.Value >= 100)
                {
                    //przypisuje false bo bohater skonczyl czytac ksiazke
                    arthur.IsUpgrading = false;

                    //zeruje pasek aktywnosci
                    progressBar_Activity.Value = 0;

                    //odblokowanie przyciskow
                    UnlockButtons();
                }

            }
            //jesli pracuje wykonuje instrukcje
            if (arthur.IsWorking)
            {
                

                if (arthur.Energy - valueEnergy >= 0)
                {
                    if (progressBar_Activity.Value < 100)
                    {

                        //inkrementuje activity bar o 20
                        progressBar_Activity.Increment(valueActivity);

                        //zmienienie wartosci pieniedzy 
                        arthur.Money += salary;

                        //przypisanie wartosci pieniedzy do etykiety
                        label_Money_Stat.Text = arthur.Money.ToString();

                        //dekrementacja wartosci energii
                        DecrementOfEnergy(valueEnergy);
                    }

                    if (progressBar_Activity.Value >= 100)
                    {
                        //przypisuje false bo bohater skonczyl czytac ksiazke
                        arthur.IsWorking = false;

                        //wzrost doswiadczenia
                        IncreaseExperience(valueExperience);

                        //zeruje pasek aktywnosci
                        progressBar_Activity.Value = 0;

                        //odblokowanie przyciskow
                        UnlockButtons();
                    }
                }
                else
                {
                    //jesli nie spelnia warunku
                    arthur.IsWorking = false;
                    UnlockButtons();
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

            if (isAttacking)
            {
                progressBarAttack.Increment(25);
                if (progressBarAttack.Value == 100)
                {
                    progressBarAttack.Value = 0;
                    
                    isAttacking = false;
                    UnlockButtons();
                }
            }



            
        }

        /// <summary>
        /// funkcja blokuje przyciski podczas wykonywania czynnosci
        /// </summary>
        public void BlockButtons()
        {
            buttonReadBook.Enabled = false;
            buttonInstruction.Enabled = false;
            buttonSave.Enabled = false;
            buttonLoad.Enabled = false;
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
            buttonAttack.Enabled = false;
            buttonBetOnHorses.Enabled = false;
            buttonRecruit.Enabled = false;
            buttonWorkHotel.Enabled = false;
        }

        /// <summary>
        /// funkcja odblokowuje przyciski po wykonaniu czynnosci
        /// </summary>
        public void UnlockButtons()
        {
            buttonReadBook.Enabled = true;
            buttonInstruction.Enabled = true;
            buttonSave.Enabled = true;
            buttonLoad.Enabled = true;
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
            buttonAttack.Enabled = true;
            buttonBetOnHorses.Enabled = true;
            buttonRecruit.Enabled = true;
            buttonWorkHotel.Enabled = true;

        }

        /// <summary>
        /// funkcja odpowiedzialna za wzrost doswiadczenia
        /// </summary>
        /// <param name="value"></param>
        public void IncreaseExperience(int value)
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
                arthur.IncreaseLevel();
                MessageBox.Show("Congratulations, level up. You receive "+levelUpMoney+" $");

                //jesli jest wiecej jednostek w oldtown niz w newport to tworze konkurencje mianowicie tworze 
                //konkurencje w postaci dwukrotnej ilosci róznicy jednostek pomiedzy miastami i przypisuje do jednostek w newport
                //roznica pomiedzy iloscia jednostek
                int diffrenceOfUnits = unitsNewport.Count() - unitsOldtown.Count();
                if (diffrenceOfUnits < 0)
                {

                    AddUnitsOfNewport(diffrenceOfUnits);
                    MessageBox.Show("Newport units are gather steam, watch out");
                }
                
                //odblokowanie przyciskow jak w czasie pracy awans
                UnlockButtons();

                //zwiekszenie pieniedzy za poziom
                levelUpMoney += 200;

                //przypisanie i aktualizacja etykiet
                arthur.Money += levelUpMoney;
                label_Money_Stat.Text = arthur.Money.ToString();
                label_Level_Stat.Text = arthur.Level.ToString();

                //odblokowanie przycisku jesli wybralismy pokoj z newport
                buttonAttack.Enabled = true ;
            }
            
        }

        /// <summary>
        /// dekremntacja energii
        /// </summary>
        public void DecrementOfEnergy(int value)
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
        public void IncrementEnergy(int value)
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
        /// funkcja obslugujaca timer do muzyki, zapetla utwor
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
            //rzutowanie na klase abstrakcyjna
            work = new WoodWork(30);
            wood = (WoodWork)work;
            //koszta pracy(energia doswiadczenie)
            valueEnergy = wood.EnergyOfActivity();
            valueExperience = wood.ExperienceOfActivity() ;
            if (arthur.Energy >= valueEnergy)
            {
                //przypisanie wartosci zmiennych(aktywnosci i zapłaty)
                valueActivity = 100 / work.TimeOfActivity();
                salary = work.GetSalaryPerHour();
                //energia na godzine
                valueEnergy = work.EnergyOfActivity() / work.TimeOfActivity();
                //przypisanie praacy i blokada przyciskow
                arthur.IsWorking = true;

                //blokowanie przyciskow
                BlockButtons();
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
            //rzutowanie na klase abstrakcyjna
            rest = new Church(25, 25);
            church = (Church)rest;
            //koszt modlitwy
            int costOfPray = church.CostOfActivity();

            //przypisanie wartosci zmiennych
            valueActivity = 100 / church.TimeOfActivity();
            valueEnergy = church.GetGivenEnergy();
            valueLife = church.GetGivenHealth();


            //doswiadczenie za modlitwe
            valueExperience = church.ExperienceOfActivity(); ;

            //warunek jesli pieniadza sa wieksze od kosztu modlitwy
            if(arthur.Money>= costOfPray)
            {
                
                //wlaczenie modlitwy
                arthur.IsResting = true;

                //wzrost doswaidczenia
                IncreaseExperience(valueExperience);

                //redukcja pieniedzy
                arthur.Money -= costOfPray;

                //aktualizacja etykiety
                label_Money_Stat.Text = arthur.Money.ToString() ;

                //blokowanie przyciskow
                BlockButtons();
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
            

            
            
                //warunki ulepszenia kslepu
                if (arthur.Aim < 100 && arthur.Level >= store.CurrentBuildingLevel && arthur.Money - store.CostUpgrade >= 0&& store.CurrentBuildingLevel<7)
                {
                    //koszt energii
                    valueEnergy = 30;

                    //warunek
                    if (arthur.Energy - valueEnergy >= 0)
                    {
                    //blokowanie klawiszy
                    BlockButtons();

                    //doswiadczenie za ulepszenie
                    valueExperience = 20;
                    
                    //wykonanie czynncosci ulepszania
                    arthur.IsUpgrading = true;

                    //wzrost poziomu budynku
                    store.UpgradeOfBuilding();

                    //zwiekszenie celnosci
                    store.BoostingAim();
                    
                    //wzrost doswiadczenia
                    IncreaseExperience(valueExperience);

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
                    moneyFromDialog = DialogWindow();
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

                        //wlaczenie trybu inwestowania
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
        private int DialogWindow()
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
            moneyFromDialog = DialogWindow();
            
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
                //rzutowanie na klase abstrakcyjna
                play = new Saloon(50);
                saloon = (Saloon)play;

                //warunek zagrania w pokera 10 dnia
                if (day == 10)
                {
                    //pomocnicza zmienna pokazuje czy bohater zagrał 10 dnia potrzebna do losowego zdarzenia
                    isPlayed = true;
                }

                //jesli pseudo liczba mniejsza od 50 to starta pieniedzy, około 50% na przegranie
                if (!play.Permutation())
                {
                    //dektrementacja pieniedzy
                    arthur.Money -= moneyFromDialog;
                    
                    MessageBox.Show("Unfortunetely you lost " + moneyFromDialog);
                }
                else
                {
                    //inkrementacja pieniedzy
                    arthur.Money += moneyFromDialog;
                    
                    MessageBox.Show("Congratulations you won "+ moneyFromDialog);
                }
                //aktualizacja pieniedzy
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
                    //inkrementacja doswiadczenia
                    IncreaseExperience(10);
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
                    BlockButtons();
                    valueExperience = 15;

                    //podniesienie wyplaty
                    warehouse.SetLevel();

                    //wlaczenie trybu ulepszania w zegarze
                    arthur.IsUpgrading = true;

                    //ulepszenie budynku
                    warehouse.UpgradeOfBuilding();


                    //wzrost doswiadczeniancreaseExperience(valueExperience);
                    IncreaseExperience(20);
                    
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
        /// klikniecie przycisku wywoloje pojedynek z Mary 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFightMary_Click(object sender, EventArgs e)
        {
            //energia potrzebna do pojedynku
            valueEnergy = 50;
            

            if (arthur.Energy>= valueEnergy&&arthur.Life>=100)
            {
                //nowy obiekt klasy enemy
                mary = new Enemy("Mary", 2, 30, 35, 600);
                if (mary.Aim >= arthur.Aim)
                {
                    //jesli przegramy: zycie=10 i energia=10;aktualizuje etykiety
                    MessageBox.Show("Unfortunetely you lost but hopefully you ran away");
                    arthur.Life = 10;
                    label_Life_Stat.Text = arthur.Life.ToString();
                    arthur.Energy = 10;
                    label_Energy_Stat.Text = arthur.Energy.ToString();
                }
                else
                {
                    //wylaczam przycisk odpowiadajzy za walke
                    buttonFightMary.Enabled = false;
                    buttonFightMary.Visible = false;
                    //pokazuje krzyzyk informujacy o smierci
                    pictureBoxMaryCross.Visible = true;
                    isMaryDead = true;
                    MessageBox.Show("Congratulations you won, Mary is dead");
                    //dekrementuje energie
                    DecrementOfEnergy(10);
                    label_Energy_Stat.Text = arthur.Energy.ToString();
                    //inkrrmentuje doswiadczenie
                    IncreaseExperience(50);
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

        /// <summary>
        /// klikniecie przycisku wywoloje pojedynek z Joe 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonJoeFight_Click(object sender, EventArgs e)
        {
            //energia potrzebna do pojedynku
            valueEnergy = 50;

            if (arthur.Energy >= valueEnergy && arthur.Life >= 100)
            {
                joe = new Enemy("Joe", 4, 60, 60, 1200);
                if (joe.Aim > arthur.Aim)
                {
                    //jesli przegramy: zycie=10 i energia=10;aktualizuje etykiety
                    MessageBox.Show("Unfortunetely you lost but hopefully you ran away");
                    arthur.Life = 10;
                    label_Life_Stat.Text = arthur.Life.ToString();
                    arthur.Energy = 10;
                    label_Energy_Stat.Text = arthur.Energy.ToString();
                }
                else
                {
                    //wylaczam przycisk odpowiadajzy za walke
                    buttonJoeFight.Enabled = false;
                    buttonJoeFight.Visible = false;
                    //pokazuje krzyzyk informujacy o smierci
                    pictureBoxJoeCross.Visible = true;
                    isJoeDead = true;
                    MessageBox.Show("Congratulations you won, Joe is dead");
                    //dekrementuje energie
                    DecrementOfEnergy(10);
                    label_Energy_Stat.Text = arthur.Energy.ToString();
                    //inkrrmentuje doswiadczenie
                    IncreaseExperience(60);
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
            //energia potrzebna do pojedynku
            valueEnergy = 50;

            if (arthur.Energy >= valueEnergy && arthur.Life >= 100)
            {
                luke = new Enemy("Luke", 6, 95, 90, 5000);
                if (luke.Aim > arthur.Aim)
                {
                    //jesli przegramy: zycie=10 i energia=10;aktualizuje etykiety
                    MessageBox.Show("Unfortunetely you lost but hopefully you ran away");
                    arthur.Life = 10;
                    label_Life_Stat.Text = arthur.Life.ToString();
                    arthur.Energy = 10;
                    label_Energy_Stat.Text = arthur.Energy.ToString();
                }
                else
                {
                    buttonFightLuke.Enabled = false;
                    buttonFightLuke.Visible = false;
                    //pokazuje krzyzyk informujacy o smierci
                    pictureBoxLukeCross.Visible = true;
                    //wylaczam przycisk odpowiadajzy za walke
                    buttonFightLuke.Visible = true;
                    isLukeDead = true;
                    MessageBox.Show("Congratulations, old town is yours. Now just have fun :)");
                    //dekrementuje energie
                    DecrementOfEnergy(10);
                    label_Energy_Stat.Text = arthur.Energy.ToString();
                    //inkrrmentuje doswiadczenie
                    IncreaseExperience(70);
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
        /// funkcja obslugujaca zapis wszelakich informacji o stanie gry 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //przypisanie do tablicy informacji
            string[] lines = {arthur.Name.ToString(),arthur.Life.ToString(),arthur.Energy.ToString(), arthur.Level.ToString(), arthur.Money.ToString(), arthur.Mind.ToString(),
            arthur.Aim.ToString(),arthur.Experience.ToString(),warehouse.CurrentBuildingLevel.ToString(),store.CurrentBuildingLevel.ToString(),isMaryDead.ToString(),isJoeDead.ToString(),isLukeDead.ToString(),arthur.IsHavingWarehouse.ToString(),counterOfHorsesNewport.ToString(),counterOfShootersNewport.ToString(),
            counterOfHorsesOldtown.ToString(),counterOfShootersOldtown.ToString()};
            try {
                //zapisuje do pilku "save.txt"
                System.IO.File.WriteAllLines(@"save.txt", lines);
                MessageBox.Show("The game has been saved!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// opcja czytania stanu gry z pliku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            //string[] lines = System.IO.File.ReadAllLines(@"save.txt");
            try
            {
                //odczytuje dane z pliku "save.txt" i przypisuje elementy tablicy do kazdej statystyki bohatera lub innej zminnej
                string[] lines = System.IO.File.ReadAllLines(@"save.txt");
                arthur.Name = lines[0];
                arthur.Life = int.Parse(lines[1]);
                arthur.Energy = int.Parse(lines[2]);
                arthur.Level = int.Parse(lines[3]);
                arthur.Money = int.Parse(lines[4]);
                arthur.Mind = int.Parse(lines[5]);
                arthur.Aim = int.Parse(lines[6]);
                arthur.Experience = int.Parse(lines[7]);
                
                store.CurrentBuildingLevel = int.Parse(lines[9]);
                Boolean.TryParse(lines[10], out isMaryDead);
                Boolean.TryParse(lines[11], out isJoeDead);
                Boolean.TryParse(lines[12], out isLukeDead);

                //wczytanie stanu jednostek i czyszczenie list i inicjalizacja na nowo
                counterOfHorsesNewport = int.Parse(lines[14]);
               counterOfShootersNewport = int.Parse(lines[15]);
               unitsNewport.Clear();
               LoadUnitsFromFile(unitsNewport);
                counterOfHorsesOldtown = int.Parse(lines[16]);
                counterOfShootersOldtown = int.Parse(lines[17]);
                 unitsOldtown.Clear();
                LoadUnitsFromFile(unitsOldtown);

                //zmienna pomocnicza czy ma magazyn bohater
                bool isHaving = false;
                Boolean.TryParse(lines[13], out isHaving);

                arthur.IsHavingWarehouse = isHaving;


                //przypisanie label'om i paskom aktywnosci wartosci po wczytaniu
                label_Level_Stat.Text = arthur.Level.ToString();
                label_Energy_Stat.Text = arthur.Energy.ToString();
                label_Life_Stat.Text = arthur.Life.ToString();
                label_Mind_Stat.Text = arthur.Mind.ToString();
                label_Money_Stat.Text = arthur.Money.ToString();
                label_Aim_Stat.Text = arthur.Aim.ToString();
                progressBar_Exp.Value = arthur.Experience;

                //pokanani bohaterzy aktualizacja stanu gry
                if (isMaryDead)
                {
                    buttonFightMary.Enabled = false;
                    pictureBoxMaryCross.Visible = false;
                }
                if (isJoeDead)
                {
                    buttonJoeFight.Enabled = false;
                    pictureBoxJoeCross.Visible = false;
                }
                if (isLukeDead)
                {
                    buttonFightLuke.Enabled = false;
                    pictureBoxLukeCross.Visible = false;
                }
                if (arthur.IsHavingWarehouse)
                {
                    //jesli mamy magazyn to ustawiam poziom i lpensje a takze wczytuje poziom magazynu
                    warehouse.CurrentBuildingLevel = int.Parse(lines[8]);
                    warehouse.SetLevel();
                    //wylaczam przycisk kupienia
                    buttonBuyWarehouse.Enabled = false;
                    buttonBuyWarehouse.Visible = false;
                    buttonUpgradeWarehouse.Visible = true;
                }
                MessageBox.Show("The game has been loaded");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// załadowanie jednostek z pliku
        /// </summary>
        /// <param name="listToUpdate"></param>
        private void LoadUnitsFromFile(List<Unit> listToUpdate)
        {
            if (listToUpdate == unitsNewport)
            {
                for(int i = 0; i < counterOfHorsesNewport; i++)
                {
                    //utworzenie nowego obiektu jezdzcy, dodanie do listy i aktualizacja
                    unit = new Horseman();
                    unitsNewport.Add(unit);
                    //aktualizacjao ogolnego ataku i obrony
                    overallDefendNewport += unit.GetDefending();
                    overallAttackNewport += unit.GetAttacking();


                }
                for (int i = 0; i < counterOfShootersNewport; i++)
                {
                    //utworzenie nowego obiektu strzelca, dodanie do listy i aktualizacja
                    unit = new Shooter();
                    unitsNewport.Add(unit);
                    //aktualizacjao ogolnego ataku i obrony
                    overallDefendNewport += unit.GetDefending();
                    overallAttackNewport += unit.GetAttacking();

                }
                //aktualizacja etykiet
                labelNewportHorsesStat.Text = counterOfHorsesNewport.ToString();
                labelNewportShootersStat.Text = counterOfShootersNewport.ToString();

            }
            else
            {
                for (int i = 0; i < counterOfHorsesOldtown; i++)
                {
                    //utworzenie nowego obiektu jezdzcy, dodanie do listy i aktualizacja
                    unit = new Horseman();
                    unitsOldtown.Add(unit);
                    //aktualizacjao ogolnego ataku i obrony
                    overallDefendOldtown += unit.GetDefending();
                    overallAttackOldtown += unit.GetAttacking();


                }
                for (int i = 0; i < counterOfShootersOldtown; i++)
                {
                    //utworzenie nowego obiektu strzelca, dodanie do listy i aktualizacja
                    unit = new Shooter();
                    unitsOldtown.Add(unit);
                    //aktualizacjao ogolnego ataku i obrony
                    overallDefendOldtown += unit.GetDefending();
                    overallAttackOldtown += unit.GetAttacking();
                }

                labelOldtownHorsesStat.Text = counterOfHorsesOldtown.ToString();
                labelOldtownShootersStat.Text = counterOfShootersOldtown.ToString();
            }


        }
       

        /// <summary>
        /// funkcja odpowiedzialna za prace w hotelu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWorkHotel_Click(object sender, EventArgs e)
        {
            //rzutowanie na klase abstrakcyjna
            work = new HotelWork(10);
            hotel = (HotelWork)work;
            //koszta pracy(energia aktywnosc)
            valueEnergy = hotel.EnergyOfActivity();
            valueExperience = hotel.ExperienceOfActivity();
            if (arthur.Energy >= valueEnergy)
            {
                //przypisanie wartosci zmiennych
                valueActivity = 100 / work.TimeOfActivity();
                salary = work.GetSalaryPerHour();
                valueEnergy = work.EnergyOfActivity() / work.TimeOfActivity();
                //przypisanie praacy i blokada przyciskow
                arthur.IsWorking = true;


                BlockButtons();
            }
            else
            {
                //okienko
                MessageBox.Show("You are too tired for it, you need at least " + valueEnergy + " energy");
            }
        }

        /// <summary>
        /// funkcja odpowiedzialna za obstawianie wyscigów konnych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBetOnHorses_Click(object sender, EventArgs e)
        {
            //przydział pieniedzy
            moneyFromDialog = DialogWindow();

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
                //rxzutowanie na klase abstrakcyjna
                play = new StudOfHorses(75);
                horses = (StudOfHorses)play;

               
                //jesli pseudo liczba mniejsza od 50 to starta pieniedzy, około 50% na przegranie
                if (!play.Permutation())
                {
                    //redukcja pieniedzy
                    arthur.Money -= moneyFromDialog;

                    MessageBox.Show("Unfortunetely you lost " + moneyFromDialog);
                }
                else
                {
                    //inkrementacja pieniedzy
                    arthur.Money += 4*moneyFromDialog;

                    MessageBox.Show("Congratulations you won " + 4*moneyFromDialog);
                }
                //aktualzacja etykiety
                label_Money_Stat.Text = (arthur.Money).ToString();

            }
        }

        /// <summary>
        /// funkcja która rekrutue daną jednostkę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRecruit_Click(object sender, EventArgs e)
        {
            //jesli zaznaczono jezdzce
            if (radioButtonHorse.Checked == true)
            {
                
                //utworzenie obiektu UNit, ktory bedzie jezdzca 
                unit = new Horseman();
                //warunek sprawdzajacy czy stac nas na wynajecie jednostki
                if (arthur.Money >= unit.GetCostOfUnit())
                {
                    //dodanie do listy
                    unitsOldtown.Add(unit);
                    //aktualizacja etykiety
                    UpdateOfUnits(unitsOldtown);
                    //odjecie pieniedzy za nabycie jednostki i aktualizacja etykiety
                    arthur.Money -= unit.GetCostOfUnit();
                    label_Money_Stat.Text = arthur.Money.ToString();
                }
                else
                {
                    MessageBox.Show("You don't have enaugh money for buy a horseman, you need at least " + unit.GetCostOfUnit());
                }
                    

            }
            else if(radioButtonShooter.Checked == true)
            {
                //utworzenie obiektu UNit, ktory bedzie jezdzca
                unit = new Shooter();
                //warunek sprawdzajacy czy stac nas na wynajecie jednostki
                if (arthur.Money >= unit.GetCostOfUnit())
                {
                     
                   //dodanie do listy
                    unitsOldtown.Add(unit);
                    //aktualizacja etykiety
                    UpdateOfUnits(unitsOldtown);
                    //odjecie pieniedzy za nabycie jednostki i aktualizacja etykiety
                    arthur.Money -= unit.GetCostOfUnit();
                    label_Money_Stat.Text = arthur.Money.ToString();
                }
                else
                {
                    MessageBox.Show("You don't have enaugh money for buy a horseman, you need at least " + unit.GetCostOfUnit());
                }

            }
            else
            {
                MessageBox.Show("Radiobuttons aren't checked");
            }

            

        }

        /// <summary>
        /// aktualizacja etykiet jendostek danego miasta
        /// </summary>
        /// <param name="listToUpdate"></param>
        public void UpdateOfUnits(List<Unit> listToUpdate)
        {
            //przechowuje ostatni dodany element 
            int index = listToUpdate.Count() - 1;
            

            
            //jesli to Oldtown to licze jednostki dla Oldown
            if (listToUpdate == unitsOldtown)
            {
                if (index >= 0)
                {
                    if (listToUpdate[index] is Horseman)
                    {
                        //zwiekszam liczbe jezdzcow jesli to był Horseman
                        counterOfHorsesOldtown++;
                        overallDefendOldtown += unit.GetDefending();
                        overallAttackOldtown += unit.GetAttacking();
                    }
                    else if (listToUpdate[index] is Shooter)
                    {
                        //zwiekszam liczbe strzelcow jesli to był Shooter
                        counterOfShootersOldtown++;
                        overallDefendOldtown += unit.GetDefending();
                        overallAttackOldtown += unit.GetAttacking();
                    }
                    //aktualizacja etykiet
                    labelOldtownHorsesStat.Text = counterOfHorsesOldtown.ToString();
                    labelOldtownShootersStat.Text = counterOfShootersOldtown.ToString();
                }
                else
                {
                    //aktualizacja etykiet
                    labelOldtownHorsesStat.Text = counterOfHorsesOldtown.ToString();
                    labelOldtownShootersStat.Text = counterOfShootersOldtown.ToString();
                }
            }
            //robie to samo jesli to  miasto Newport(lista)
            else
            {
                if (index >= 0)
                {
                    if (listToUpdate[index] is Horseman)
                    {
                        //dodanie wjednostki i aktualizacja ogolnego ataku i obrony

                        counterOfHorsesNewport++;
                        overallDefendNewport += unit.GetDefending();
                        overallAttackNewport += unit.GetAttacking();

                    }
                    else if (listToUpdate[index] is Shooter)
                    {
                        //dodanie wjednostki i aktualizacja ogolnego ataku i obrony
                        counterOfShootersNewport++;
                        overallDefendNewport += unit.GetDefending();
                        overallAttackNewport += unit.GetAttacking();
                    }
                    //aktualizacja etykiet
                    labelNewportHorsesStat.Text = counterOfHorsesNewport.ToString();
                    labelNewportShootersStat.Text = counterOfShootersNewport.ToString();

                }
                else
                {

                    //aktualizacja etykiet
                    labelNewportHorsesStat.Text = counterOfHorsesNewport.ToString();
                    labelNewportShootersStat.Text = counterOfShootersNewport.ToString();
                }
            }
        }

        

        /// <summary>
        /// funkcja ktora aktualizuje jednostki Newport i dodaje pewną ilosc jak bohater osiagnie kolejny poziom
        /// </summary>
        private void AddUnitsOfNewport(int diffrenceOfUnits)
        {
           
            //pierwszy raz dodaj 10 jezdzcow i i 10 strzelcow żeby było ciekawej dla rozgrywki
           
            if (diffrenceOfUnits > 0)
            {
               
            }
            else
            {
                //petla ktora dodaje  roznice pomiedzy wojskami  żeby było wyzwwanie budowania jednostek
                for (int i= diffrenceOfUnits; i < 0; i++)
                {
                    
                    //utworzenie nowego obiektu jezdzcy, dodanie do listy i aktualizacja, to samo ze strzelcem
                    unit = new Horseman();
                    unitsNewport.Add(unit);
                    UpdateOfUnits(unitsNewport);
                    unit = new Shooter();
                    unitsNewport.Add(unit);
                    UpdateOfUnits(unitsNewport);
                }

            }
        }
        /// <summary>
        /// klikniecie przycisku attack zaczyna walke pomiedyz miastami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAttack_Click(object sender, EventArgs e)
        {
            //jesli zaznaczono jezdzce
            if (radioButtonAttack.Checked == true)
            {

                AttackOnNewport();

            }
            else if (radioButtonPeace.Checked == true)
            {
                MessageBox.Show("You choose peace, so Oldtown and Newport wiil be in peacuful relation  until you increase your level");
                buttonAttack.Enabled = false;

            }
            else
            {
                MessageBox.Show("Radiobuttons aren't checked");
            }
        }

        /// <summary>
        /// funkcja przeprowadza atak na Newport
        /// </summary>
        private void AttackOnNewport()
        {
            BlockButtons();
            //pomocnicza do inicjalizacja progress bar'u
            isAttacking = true;
            if (overallAttackOldtown > overallDefendNewport)
            {
                //pieniadze za przegrana zalezą od poziomu 
                int winningMoney = 2000;
                MessageBox.Show("Congratulations you won, and Newport signed peace pact with Oldtown so you will get rich, you earned " + winningMoney * arthur.Level);
                buttonAttack.Enabled = false;
                //aktualizacja pieniedzy
                arthur.Money += winningMoney * arthur.Level;
                label_Money_Stat.Text = arthur.Money.ToString();
                //redukcja kosztow
                ReductionOfUnits(true);

            }
            else
            {
                MessageBox.Show("Unfotunetely you lost and half your units didn.t come back to Oldtown");
                ReductionOfUnits(false);
            }

        }
        /// <summary>
        /// funkcja redukuje jednostki po przegranej lub przegranej zalezy od strony
        /// </summary>
        /// <param name="win"></param>
        private void ReductionOfUnits(bool win)
        {
           
            
            if (win)
            {
                //zeruje wojska Newport
                counterOfHorsesNewport = 0;
                counterOfShootersNewport = 0;
                unitsNewport.Clear();
                UpdateOfUnits(unitsNewport);
            }
            else
            {
                //zeruje wojska Oldtown
                counterOfHorsesOldtown = 0;
                counterOfShootersOldtown = 0;
                unitsOldtown.Clear();
                UpdateOfUnits(unitsOldtown);
            }
        }
        /// <summary>
        /// funkcja inkrementuje zycie o zadana wartosc
        /// </summary>
        /// <param name="value"></param>
        public void IncrementLife(int value)
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
