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
    public partial class FormAdmin : Form
    {
        Cadastro cadastro = new Cadastro();

        public FormAdmin()
        {
            InitializeComponent();

            listaFuncao();
        }

        private void buttonCadastroFuncionario_Click(object sender, EventArgs e)
        {
            //CADASTRO DE USUARIOS - FUNCIONARIOS COM SEUS LOGINS

            string cmdInsert = @"INSERT INTO LOGINS (nomeUsuario, usuario, senha, status, idPerfil) VALUES('" + textBoxLoginUsuario.Text + "', '" + textBoxSenhaUsuario.Text + "', '" +
                textBoxNomeUsuario.Text + "', " + comboBoxFuncao.SelectedValue + ", 1);";

            cadastro.cadastro(cmdInsert);

            textBoxNomeUsuario.Clear();
            textBoxLoginUsuario.Clear();
            textBoxSenhaUsuario.Clear();
            comboBoxFuncao.SelectedIndex = -1;
        }

        private void buttonCadastroCasa_Click(object sender, EventArgs e)
        {
            //Cadastro da Casa - Pet

            string cmdInsert = @"INSERT INTO CASAS VALUES ('" + textBoxNomeCasa.Text + "');";

            cadastro.cadastro(cmdInsert);

            textBoxNomeCasa.Clear();
        }

        private void buttonCadastroServico_Click(object sender, EventArgs e)
        {
            //CADASTRO DE SERVIÇOS REALIZADOS PELA PET

            string cmdInsert = @"INSERT INTO SERVICOS VALUES ('" + textBoxNomeServico.Text + "', '" + textBoxDescricaoServico.Text + "', " + 
                textBoxValor.Text + ");";

            cadastro.cadastro(cmdInsert);

            textBoxNomeServico.Clear();
            textBoxDescricaoServico.Clear();
            textBoxValor.Clear();
        }

        private void buttonAddFuncao_Click(object sender, EventArgs e)
        {
            //Adicionar funções ao Funcionario

            string cmdSelect = @"SELECT * FROM PERFIS WHERE nomePerfil='" + comboBoxFuncao.Text + "';";
            string cmdInsert = @"INSERT INTO PERFIS VALUES ('" + comboBoxFuncao.Text + "');";

            if(cadastro.verificaSeTrue(cmdSelect)==false)
            {
                cadastro.cadastro(cmdInsert);
            }

            listaFuncao();
        }

        private void listaFuncao()
        {
            //Listar as funções dos funcionarios

            string cmdSelectPerfil = @"SELECT * FROM PERFIS ";

            cadastro.atulizaCombo(cmdSelectPerfil, comboBoxFuncao, "nomePerfil", "idPerfil");
        }
    }
}
