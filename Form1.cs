using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gierka_na_zajęcia_V2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int zycie = 100;        
            string nazwa1 = textBox1.Text;
            string nazwa2 = textBox4.Text;
            int sila1 = int.Parse(textBox2.Text);
            int sila2 = int.Parse(textBox5.Text);
            int obrona1 = int.Parse(textBox3.Text);
            int obrona2 = int.Parse(textBox6.Text);
            int roznica_sily1 = sila1 - sila2;
            int roznica_sily2 = sila2 - sila1;
            
            //-------------------------------------------------------------
            //Sprawdzanie czy podano prawidlowe liczby

            int roznica_obrony1 = obrona1 - obrona2;
            int roznica_obrony2 = obrona2 - obrona1;
            bool tak_nie = true;
                                    
            if (roznica_sily1 != roznica_obrony2 || roznica_sily2 != roznica_obrony1)
            {
                MessageBox.Show("Nieprawidlowe liczby. Zapoznaj się ze wskazówkami");
                tak_nie = false;
            }
            else
            {
                tak_nie = true;
            }


            //-------------------------------------------------------------------------------
            //Obliczanie pozostalego zycia jesli wartosci sa poprawne
            if (tak_nie == true)
            {
                Random r = new Random();
                int atak = r.Next(5, 10);     //atak dla gracza 1
                int atak2 = r.Next(5, 10);     // atak dla gracza 2
                int obrazenia1 = atak * sila1 - obrona2;    // ile punktow zostanie odjete graczowi 2
                int obrazenia2 = atak2 * sila2 - obrona1; //ile puntow zostanie odjete graczowi 1
                int pozostale_zycie_gracza2 = zycie - obrazenia1;    //ile zostalo
                int pozostale_zycie_gracza1 = zycie - obrazenia2;     //ile zostalo
                //-----------------------------------------------------
                //Wylanianie zwyciezcy

                if (pozostale_zycie_gracza1 > pozostale_zycie_gracza2)
                {
                    MessageBox.Show("K.O", "Gracz " + nazwa1 + " wygrywa!");
                }
                else if (pozostale_zycie_gracza2 > pozostale_zycie_gracza1)
                {
                    MessageBox.Show("K.O", "Gracz " + nazwa2 + " wygrywa!");
                }
                else
                {
                    MessageBox.Show("Jest remis!");
                }

            }
        }
    }
}
