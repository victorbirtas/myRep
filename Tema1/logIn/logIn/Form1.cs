using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using BusinessLayer;

namespace logIn
{
    public partial class Form1 : Form
    {

        UserService userBusiness = new UserService();
        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            
            String role = userBusiness.getRole(textBox1.Text, textBox2.Text);

            //MessageBox.Show(role);
            if (role == "user")
            {
                AngajatForm loginForm = new AngajatForm();
                loginForm.Show();
            }else if (role == "admin")
            {
                AdminForm loginForm = new AdminForm();
                loginForm.Show();
            }
            else
            {
                Form2 loginForm = new Form2("Eroare!");
                loginForm.Show();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            userBusiness.resetPassword(tbForgotPassUsername.Text, tbNewPass.Text);
        }
    }
}
