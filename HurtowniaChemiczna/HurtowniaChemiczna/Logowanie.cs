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
    public partial class Logowanie : Form
    {
        public Logowanie()
        {
            InitializeComponent();
        }

        Baza baza = new Baza();

        public Klient klient;

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EdycjaKlienta nowyKlient = new EdycjaKlienta();
            nowyKlient.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var k = baza.Klient.FirstOrDefault(x => x.Login == textBox1.Text && x.Haslo == textBox2.Text);

            if(k != null)
            {
                klient = k;
                DialogResult = DialogResult.OK;
                return;
            }

            MessageBox.Show("Niepoprawne dane logowania.");
        }
    }
}
