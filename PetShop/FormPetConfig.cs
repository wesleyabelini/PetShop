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
    public partial class FormPetConfig : Form
    {
        Cadastro cadastro = new Cadastro();
        public FormPetConfig()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cadastrar tipo de animal e tamanho

            string tabela = "";

            if(radioButton1.Checked==true)
            {
                tabela = "Portes";
            }
            else if(radioButton2.Checked==true)
            {
                tabela = "Tipos";
            }

            string cmdInsert = "INSERT INTO " + tabela + " VALUES ('" + textBox1.Text + "');";

            cadastro.cadastro(cmdInsert);
        }
    }
}
