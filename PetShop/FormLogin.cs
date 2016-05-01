using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop
{
    public partial class FormLogin : Form
    {
        Cadastro cadastro = new Cadastro();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdSelect = @"SELECT USUARIO, SENHA FROM LOGINS WHERE (USUARIO='" + textBoxUSUARIO.Text + "' AND SENHA ='" + 
                textBoxSENHA.Text + "');";

            if (cadastro.verificaSeTrue(cmdSelect))
            {
                MessageBox.Show("Login");
            }
        }
    }
}
