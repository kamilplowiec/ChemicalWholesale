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
    public partial class EdycjaZamowienia : Form
    {
        Baza baza = new Baza();
        Zamowienie zamowienie = new Zamowienie();

        DataTable products;

        int KlientId { get; set; }

        public EdycjaZamowienia(int id = 0, int klientId = 0)
        {
            InitializeComponent();

            if (klientId > 0)
                KlientId = klientId;

            if (id > 0)
            {
                zamowienie = baza.Zamowienie.FirstOrDefault(x => x.Id == id);
                textBox1.Text = zamowienie.Nazwa;
            }

            products = ConvertToDataTable(
                    baza.ProduktZamowienia.ToList().Where(x => x.Zamowienie_Id == zamowienie.Id).Select(x =>
                         new
                         {
                             x.Id,
                             ProduktId = x.Produkt_Id,
                             Nazwa = baza.Produkt.FirstOrDefault(p => p.Id == x.Produkt_Id).Nazwa,
                             Cena = baza.Produkt.FirstOrDefault(p => p.Id == x.Produkt_Id).Cena
                         }).ToList());

            dataGridView1.DataSource = products;

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["ProduktId"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(KlientId > 0)
                zamowienie.Klient_Id = KlientId;

            zamowienie.Nazwa = textBox1.Text;

            if (zamowienie.Id > 0)
            {
                baza.ProduktZamowienia.RemoveRange(baza.ProduktZamowienia.Where(x => x.Zamowienie_Id == zamowienie.Id));
            }
            else
            {
                baza.Zamowienie.Add(zamowienie);
            }

            baza.SaveChanges();

            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                ProduktZamowienia pz = new ProduktZamowienia();
                pz.Produkt_Id = int.Parse(this.dataGridView1.Rows[i].Cells["ProduktId"].Value.ToString());
                pz.Zamowienie_Id = zamowienie.Id;
                pz.Opis = "";

                baza.ProduktZamowienia.Add(pz);
            }

            baza.SaveChanges();

            DialogResult = DialogResult.OK;
        }

        private void DodajProdukt(int produktId)
        {
            var p = baza.Produkt.FirstOrDefault(x => x.Id == produktId);

            products.Rows.Add(0, p.Id, p.Nazwa, p.Cena);
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListaProduktow lista = new ListaProduktow(EdycjaProduktuTyp.WyborProduktu);
            if(lista.ShowDialog(this) == DialogResult.OK)
            {
                DodajProdukt(lista.SelectedProductId);
            }
        }
    }
}
