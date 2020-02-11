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
    public partial class EdycjaKlienta : Form
    {
        Baza baza = new Baza();
        Klient klient = new Klient();

        public EdycjaKlienta(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
                klient = baza.Klient.FirstOrDefault(x => x.Id == id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            klient.Nazwa = textBox1.Text;
            klient.Adres = textBox2.Text;
            klient.NIP = textBox3.Text;
            klient.Login = textBox4.Text;
            klient.Haslo = textBox5.Text;

            if (klient.Id == 0)
                baza.Klient.Add(klient);

            baza.SaveChanges();

            Close();
        }

        private void EdycjaKlienta_Shown(object sender, EventArgs e)
        {
            if(klient.Id > 0)
            {
                textBox1.Text = klient.Nazwa;
                textBox2.Text = klient.Adres;
                textBox3.Text = klient.NIP;
                textBox4.Text = klient.Login;
                textBox5.Text = klient.Haslo;
            }
        }
    }
}
