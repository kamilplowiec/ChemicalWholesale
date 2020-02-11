using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HurtowniaChemiczna
{
    public partial class HurtowniaChemiczna : Form
    {
        public HurtowniaChemiczna()
        {
            InitializeComponent();
        }

        Baza baza = new Baza();
        Klient klient;
        bool admin = false;

        private void HurtowniaChemiczna_Shown(object sender, EventArgs e)
        {
            Logowanie l = new Logowanie();
            if (l.ShowDialog(this) == DialogResult.OK)
            {
                klient = l.klient;

                admin = klient.Login == "p";

                label1.Text = klient.Nazwa;
            }
            else
            {
                Close();
            }

            LadujZamowienia();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            dataGridView1.DataSource = null;
            HurtowniaChemiczna_Shown(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListaProduktow lista = new ListaProduktow(EdycjaProduktuTyp.ListaProduktow);
            lista.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EdycjaZamowienia edycja = new EdycjaZamowienia(klientId: klient.Id);
            if (edycja.ShowDialog(this) == DialogResult.OK)
            {
                dataGridView1.DataSource = null;
                LadujZamowienia();
            }
        }

        private decimal KwotaZamowienia(int zamowienieId)
        {
            baza.ProduktZamowienia.Where(x => x.Zamowienie_Id == zamowienieId).Select(x => new { k = baza.Produkt.FirstOrDefault(p => p.Id == x.Produkt_Id).Cena }).Sum(t => t.k);

            decimal kwota = 0;
            foreach (var pz in baza.ProduktZamowienia.Where(x => x.Zamowienie_Id == zamowienieId))
            {
                decimal k = baza.Produkt.FirstOrDefault(x => x.Id == pz.Produkt_Id).Cena;

                kwota += k;
            }

            return kwota;
        }

        private void LadujZamowienia()
        {
            baza.Zamowienie.Load();

            if (admin)
            {
                dataGridView1.DataSource = baza.Zamowienie.Select(x => new
                {
                    x.Id,
                    x.Nazwa,
                    Klient = baza.Klient.FirstOrDefault(k => k.Id == x.Klient_Id).Nazwa,
                    Kwota = baza.ProduktZamowienia.Where(z => z.Zamowienie_Id == x.Id).Select(t => new { k = baza.Produkt.Where(p => p.Id == t.Produkt_Id).Sum(p => p.Cena) }).Sum(t => t.k)
                }).ToList();
            }
            else
                dataGridView1.DataSource = baza.Zamowienie.Where(x => x.Klient_Id == klient.Id).Select(x => new
                {
                    x.Id,
                    x.Nazwa,
                    Kwota = baza.ProduktZamowienia.Where(z => z.Zamowienie_Id == x.Id).Select(t => new { k = baza.Produkt.Where(p => p.Id == t.Produkt_Id).Sum(p => p.Cena) }).Sum(t => t.k)
                }).ToList();

            dataGridView1.Columns["Id"].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int zamowienieId;
            if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString(), out zamowienieId))
            {
                EdycjaZamowienia edycja = new EdycjaZamowienia(zamowienieId);
                if(edycja.ShowDialog(this) == DialogResult.OK)
                {
                    dataGridView1.DataSource = null;
                    LadujZamowienia();
                }
            }
        }
    }

    public enum EdycjaProduktuTyp
    {
        ListaProduktow = 1,
        WyborProduktu = 2
    }

}
