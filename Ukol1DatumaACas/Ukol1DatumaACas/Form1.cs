using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ukol1DatumaACas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime aktualniden = DateTime.Today;
            int nejstarsi = 0;
            for (int i = 0; i < textBox1.Lines.Count(); i++)
            {
                try
                {
                    string text = textBox1.Lines[i];
                    string[] clovek = text.Split(';');
                    string[] datum = clovek[2].Split('/');
                    DateTime date = new DateTime(int.Parse(datum[2]), int.Parse(datum[1]), int.Parse(datum[0]));
                    TimeSpan rozdil = aktualniden - date;

                    int stari = Convert.ToInt32(rozdil.TotalDays);
                    if (nejstarsi < stari)
                    {
                        label2.Text = "Nejstarsi je: " + clovek[0] + " " + clovek[1];
                        nejstarsi = stari;
                    }
                    else if (nejstarsi == stari)
                    {
                        label2.Text += " a " + clovek[0] + " " + clovek[1];
                        nejstarsi = stari;
                    }
                    else label2.Text = "Žádný člověk nenalezen";
                }
                catch
                {
                    MessageBox.Show("Pravděpodobně jsi zadal špatný formát data, závorky u nadpisu ti pomohou :D nebo jsi nechal prázdný řádek", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("V textBox jsou zapsány osoby ve tvaru jméno;příjmení;datum narození, na každém řádku jedna osoba.\r\nZobrazte nejstaršího člověka.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
