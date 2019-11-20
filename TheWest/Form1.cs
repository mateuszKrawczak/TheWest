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
        public Form1()
        {
            InitializeComponent();
            player.URL = "oldtown.mp3";
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
            label_Shooting_Stat.BackColor = Color.Transparent;
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
            //pictureBox4.BackColor = Color.Transpar
            // progressBar_Life.ForeColor = Color.FromArgbent;(255, 0, 0);
            // progressBar_Life.Colo = Color.FromArgb(150, 0, 0);

        }

        private void button1_Instruction_Click(object sender, EventArgs e)
        {
            MessageBox.Show("INSTRUCTION\nYou are new man in town and your main goal it's to take control over village Old Town Road. Unfortunetly Old Town Road is controlled by Lucky Luke's Gang. Your plan is to attack 3 main people of the gang. First and most powerful is of course Luke, next one is his right hand, Fat Joe. Last but not least is Luke's girlfriend, Bloody Mary.  ");
        }

        private void timer_Tick_1(object sender, EventArgs e)
        {

            hour++;
            label_Hour_Stat.Text = hour.ToString();

            // aktualizacja stanu wojsk przeciwników co 24h:



            // aktualizacja liczby dni gdy miną 24 godziny
            if (hour == 24)
            {
                // wyzerowanie liczby godzin
                hour = 0;
                // zwiększenie dni o 1
                day++;
                // aktualizacja wyświetlanych na ekranie danych dotyczących czasu
                label_Hour_Stat.Text = hour.ToString();
                label_Day_Stat.Text = day.ToString();
                // Wydarzenia w trakcie rozgrywki
            }

        }
    }

        

 }
