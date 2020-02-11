using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HurtowniaChemiczna
{
    public partial class EdycjaProduktu : Form
    {
        Baza baza = new Baza();
        Produkt produkt = new Produkt();

        public EdycjaProduktu(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
                produkt = baza.Produkt.FirstOrDefault(x => x.Id == id);
        }

        private void EdycjaProduktu_Shown(object sender, EventArgs e)
        {
            if(produkt.Id > 0)
            {
                textBox1.Text = produkt.Nazwa;
                textBox2.Text = produkt.Cena.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            produkt.Nazwa = textBox1.Text;

            decimal cena;
            if (decimal.TryParse(textBox2.Text, out cena))
            {
                produkt.Cena = cena;
            }
            else
            {
                MessageBox.Show("Podaj poprawną cenę!");
                return;
            }

            if (produkt.Id == 0)
                baza.Produkt.Add(produkt);

            baza.SaveChanges();

            DialogResult = DialogResult.OK;
        }
    }
}
