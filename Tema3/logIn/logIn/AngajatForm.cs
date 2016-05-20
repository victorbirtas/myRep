using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using BL;

namespace logIn
{
    partial class AngajatForm : Form
    {
       
        BileteService bilet = new BileteService();

        public AngajatForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bilet.adaugaBilet(tbSpecatcol.Text,int.Parse(tbRand.Text),int.Parse(tbNumar.Text));
            MessageBox.Show("Bilet adaugat");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = bilet.afisareBilete(tbSpecatcol.Text);
        }

        private void btnCsv_Click(object sender, EventArgs e)
        {
            ExporterFactory exporterFactory = new ExporterFactory();
            Exporter exporterCsv = exporterFactory.getExporter("CSV");
            exporterCsv.export();
        }
    }
}
