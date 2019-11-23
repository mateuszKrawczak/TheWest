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
{
    public partial class Form1 : Form
    {
        int hour, day = 1;
        WindowsMediaPlayer player = new WindowsMediaPlayer();
       
        Arthur arthur = new Arthur("Arthur",1 , 5,5, 500,100,100);
        Person luke= new Person("Luke",6, 95, 90, 10000);
        Person joe= new Person("Joe",4, 60, 60, 2000);
        Person mary= new Person("Mary", 2, 30,35,1000);
        Home home;
        public Form1()
        {
            InitializeComponent();
            player.URL = "oldtown.mp3";
            home = new Home(arthur);
            player.controls.play();
            timer.Interval = 1000;
            timer.Start();
            pictureBox_Star.BackColor = Color.Transparent;
            pictureBox_TW.BackColor = Color.Transparent;
            // pictureBox1_Map.BackColor = Color.Transparent;
            pictureBox_Arthur.BackColor = Color.Transparent;
            pictureBox_Mary.BackColor = Color.Transparent;
            pictureBox_FatJoe.BackColor = Color.Transparent;
            pictureBox_LuckyLuke.BackColor = Color.Transparent;
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
            label_Level_Stat.Text = arthur.Level.ToString();
            label_Energy_Stat.Text = arthur.Energy.ToString();
            label_Life_Stat.Text = arthur.Life.ToString();
            label_Mind_Stat.Text = arthur.Mind.ToString();
            label_Money_Stat.Text = arthur.Money.ToString();
            label_Aim_Stat.Text = arthur.Aim.ToString();
            progressBar_Exp.Value = arthur.Expierence;

            //pictureBox4.BackColor = Color.Transpar
            // progressBar_Life.ForeColor = Color.FromArgbent;(255, 0, 0);
            // progressBar_Life.Colo = Color.FromArgb(150, 0, 0);

        }

        private void button1_Instruction_Click(object sender, EventArgs e)
        {
            MessageBox.Show("INSTRUCTION\nYou are new man in town and your main goal it's to take control over village Old Town Road. Unfortunetly Old Town Road is controlled by Lucky Luke's Gang. Your plan is to attack 3 main people of the gang. First and most powerful is of course Luke, next one is his right hand, Fat Joe. Last but not least is Luke's girlfriend, Bloody Mary.  ");
        }

        private void buttonUpgradeHome_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// funkcja odpowiedzialna za czytanie ksiazki; +5 do inteligncji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReadBook_Click(object sender, EventArgs e)
        {
            //jesli mind<100 wywoluje funkcje
            if (arthur.Mind < 100 && arthur.Energy >= 10)
            {
                //wywoluje funkcje readBook()
                home.readBook();
                arthur.IsReading = true;



                //zmieniam wartosc label na aktualna
                label_Mind_Stat.Text = arthur.Mind.ToString();

                increaseExperience(10);
                decrementOfEnergy(50);


            }
            else if (arthur.Mind < 100 && arthur.Energy < 10)
            {
                MessageBox.Show("You are out of energy");
            }else
            {
                MessageBox.Show("Mind is max value");
            }

        }

        private void buttonRestHome_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick_1(object sender, EventArgs e)
        {

            hour++;
            label_Hour_Stat.Text = hour.ToString();
            

            // aktualizacja liczby dni gdy miną 24 godziny
            if (hour == 24)
            {
                // wyzerowanie liczby godzin
                hour = 0;
                // zwiększenie dni o 1
                day++;
                
                label_Hour_Stat.Text = hour.ToString();
                label_Day_Stat.Text = day.ToString();
                
            }
            if (arthur.IsReading)
             {
                blockButtons();
               // arthur.addActivity(25);
                if (progressBar_Activity.Value < 100) 
                    progressBar_Activity.Value += 25;
                if (progressBar_Activity.Value == 100)
                {
                    arthur.IsReading = false;
                    progressBar_Activity.Value = 0;
                    
                    unlockButtons();
                }
                
             }
                

                    

        }
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
            buttonUpgradeHome.Enabled = false;
            buttonUpgradeHome.Enabled = false;
            buttonUpgradeStore.Enabled = false;
            buttonUpgradeWarehouse.Enabled = false;
            buttonWorkWood.Enabled = false;
            
        }
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
            buttonUpgradeHome.Enabled = true;
            buttonUpgradeHome.Enabled = true;
            buttonUpgradeStore.Enabled = true;
            buttonUpgradeWarehouse.Enabled = true;
            buttonWorkWood.Enabled = true;

        }

        public void increaseExperience(int value)
        {
            if (arthur.Expierence < 100)
            {
                arthur.Expierence += 50;
                progressBar_Exp.Value = arthur.Expierence;

            }
            if(arthur.Expierence >= 100)
            {
                arthur.Expierence = 0;
                progressBar_Exp.Value = arthur.Expierence;
                arthur.increaseLevel();
                //arthur.Expierence += 50;
                label_Level_Stat.Text = arthur.Level.ToString();
            }
            
        }
        public void decrementOfEnergy(int value)
        {
            if (arthur.Energy >= 10)
            {
                arthur.Energy -= value;
                label_Energy_Stat.Text = arthur.Energy.ToString();
            }
            else
            {
                MessageBox.Show("You are to tired for it");
            }
            


        }
    }

        

 }
