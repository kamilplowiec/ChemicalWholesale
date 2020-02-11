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
    public partial class ListaProduktow : Form
    {
        Baza baza = new Baza();
        EdycjaProduktuTyp trybEdycji;
        public int SelectedProductId { get; set; }

        public ListaProduktow(EdycjaProduktuTyp typ)
        {
            InitializeComponent();

            trybEdycji = typ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EdycjaProduktu edycja = new EdycjaProduktu();
            if (edycja.ShowDialog(this) == DialogResult.OK)
            {
                LadujProdukty();
            }
        }

        private void LadujProdukty()
        {
            baza.Produkt.Load();
            this.dataGridView1.DataSource = baza.Produkt.Select(x => new
            {
                x.Id,
                x.Nazwa,
                x.Cena
            }).ToList();

            this.dataGridView1.Columns["Id"].Visible = false;
        }

        private void ListaProduktow_Shown(object sender, EventArgs e)
        {
            LadujProdukty();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (trybEdycji == EdycjaProduktuTyp.WyborProduktu)
            {
                int produktId;
                if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString(), out produktId))
                {
                    SelectedProductId = produktId;
                    DialogResult = DialogResult.OK;
                }
            }
            else if(trybEdycji == EdycjaProduktuTyp.ListaProduktow)
            {
                int produktId;
                if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString(), out produktId))
                {
                    EdycjaProduktu edycja = new EdycjaProduktu(produktId);
                    if(edycja.ShowDialog(this) == DialogResult.OK)
                    {
                        LadujProdukty();
                    }
                }
            }
        }
    }
}
