using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheWest
{
    //klasa jest odpowiedzialna za dodatkowe okno, wpisuje sie w niej wartosc pieniedzy 
    public partial class FormDialog : Form
    {
        //zmienna 
        public int moneyAmount=0;

        //konstruktor
        public FormDialog()
        {
            InitializeComponent();
            labelAmountMoney.BackColor = Color.Transparent;
        }

        /// <summary>
        /// przycisk odpowiedzialny za zatwierdzenie wartosci pieniedzy ktora wprowadzilismy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxAmountMoney.Text, out moneyAmount))
            {
                moneyAmount = int.Parse(textBoxAmountMoney.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("It's not a number");
            }
        }

        
    }
}
