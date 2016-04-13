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

namespace logIn
{
    public partial class AdminForm : Form
    {

        UserService userBusiness = new UserService();
        SpectacoleService spectacolBusiness = new SpectacoleService();
        public AdminForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            userBusiness.creareContAngajat(tbNumeAngajat.Text,tbUsernameAngajat.Text,tbPasswordAngajat.Text);
            MessageBox.Show("Contul a fost creat");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            spectacolBusiness.adaugareSpectacol(tbTitlu.Text,tbRegia.Text,tbDistributia.Text,tbPremiera.Value,int.Parse(tbNrBilete.Text));
            MessageBox.Show("Specatacol adaugat");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridSpectacole.DataSource = spectacolBusiness.afisareSpectacole();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                String s = dataGridSpectacole.SelectedRows[0].Cells[0].Value.ToString();
                spectacolBusiness.deleteSpectacolBusiness(s);
                MessageBox.Show("Specatacol sters");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                spectacolBusiness.updateSpectacolBusiness(tbTitlu.Text,tbRegia.Text,tbDistributia.Text,tbPremiera.Value,int.Parse(tbNrBilete.Text));
                MessageBox.Show("Specatacol actualizat");
            }
               catch(Exception ex2) {
                   Console.WriteLine(ex2.Message);
                }
           
        }
    }
}
