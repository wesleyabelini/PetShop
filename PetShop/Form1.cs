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
    public partial class Form1 : Form
    {
        Cadastro cadastro = new Cadastro();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCadastroPet_Click(object sender, EventArgs e)
        {
            //CADASTRO DE CACHORROS DO CLIENTE

            string cmdidcli = @"SELECT idCliente FROM CLIENTES WHERE CPF='" + textBoxCPFCliente.Text + "'";
            int idcliente = cadastro.idcliente(cmdidcli); //   << PEGA O ID DO CLIENTE NO QUAL ESTA FAZENDO O CADASTRO

            string cmdSelectAnimal = @"SELECT nomeAnimal FROM ANIMAIS WHERE idCliente=" + idcliente + ";";

            /*string cmdInsert = @"INSERT INTO ANIMAIS (nomeAnimal, Porte, Tipo, Observacoes, idCliente) VALUES ('" + textBoxNomePet.Text + "', '" +
                comboBoxPortePet.Text + "', '" + textBoxRacaPet.Text + "', '" + textBoxAlergiaPet.Text + "', " + idcliente + ");";    */

            string cmdInsert = @"INSERT INTO ANIMAIS (nomeAnimal, Observacoes, idCliente) VALUES ('" + textBoxNomePet.Text + "', '" + 
                textBoxAlergiaPet.Text + "', " + idcliente + ");";

            //OBS >>> VERIFICAR A EXISTENCIA DE TABELAS (PORTE E TIPO) <<<<<

            cadastro.cadastro(cmdInsert);

            cadastro.listaTable(cmdSelectAnimal, dataGridView1);
        }

        private void buttonCadastroFuncionario_Click(object sender, EventArgs e)
        {
            //CADASTRO DE USUARIOS - FUNCIONARIOS COM SEUS LOGINS

            string cmdInsert = @"INSERT INTO LOGINS VALUES('" + textBoxNomeUsuario.Text + "', '" + textBoxLoginUsuario.Text + "', '" + 
                textBoxSenhaUsuario.Text + "');";

            cadastro.cadastro(cmdInsert);
        }

        private void buttonCadastroCasa_Click(object sender, EventArgs e)
        {
            //Cadastro da Casa - Pet

            string cmdInsert = @"INSERT INTO CASAS VALUES ('" + textBoxNomeCasa.Text + "');";

            cadastro.cadastro(cmdInsert);
        }

        private void buttonCadastroServico_Click(object sender, EventArgs e)
        {
            //CADASTRO DE SERVIÇOS REALIZADOS PELA PET

            string cmdInsert = @"INSERT INTO SERVICOS VALUES ('" + textBoxNomeServico.Text + "', '" + textBoxDescricaoServico.Text + "');";

            cadastro.cadastro(cmdInsert);
        }

        private void ListarPets_Click(object sender, EventArgs e)
        {
            //LISTAR OS PETS DO CLIENTE PARA AGENDAR

            string cmdSelect = @"SELECT nomeAnimal AS 'Nome' FROM ANIMAIS WHERE EXISTS(SELECT CPF FROM Clientes WHERE cpf='" + textBoxAgendCPF.Text + "')";

            cadastro.listaTable(cmdSelect, dataGridView2);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //CONFORME ALTERAÇÃO DE DATA >>>>>>>>> Executa a listagem da agenda para o dia....<<<<<<<<<<

            string data = monthCalendar1.SelectionRange.Start.ToString();

            string cmdSelect = @"SELECT nomeCliente AS 'Cliente', nomeAnimal AS 'Animal' FROM AGENDA AS A
INNER JOIN Clientes AS CLI ON CLI.idCliente=A.idCliente
INNER JOIN Animais AS AN ON AN.idCliente=CLI.idCliente
WHERE data='" + data + "';";

            cadastro.listaTable(cmdSelect, dataGridView3);
        }

        private void buttonCadastroCliente_Click(object sender, EventArgs e)
        {
            //CADASTRAR CLIENTE NO BANCO

            string cmdInsert = @"INSERT INTO CLIENTES VALUES('" + textBoxNomeCliente.Text + "', '" + textBoxCPFCliente.Text + "', '" +
                textBoxEnderecoCliente.Text + "', '" + textBoxNumCliente.Text + "', '" + textBoxBairroCliente.Text + "', '" + 
                textBoxTel1Cliente.Text + "', '" + textBoxTel2Cliente.Text + "')";

            cadastro.cadastro(cmdInsert);

            buttonCadastroPet.Enabled = true;  //  << HABILITAR BOTÃO PARA CADASTRAR OS PETS DESTE CLIENTE

            buttonCadastroCliente.Enabled = false;
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            //Novo Cadastro Cliente

            buttonCadastroCliente.Enabled = true;

            limpacadastrocliente();
        }

        private void limpacadastrocliente()
        {
            textBoxNomeCliente.Clear();
            textBoxCPFCliente.Clear();
            textBoxEnderecoCliente.Clear();
            textBoxNumCliente.Clear();
            textBoxBairroCliente.Clear();
            textBoxTel1Cliente.Clear();
            textBoxTel2Cliente.Clear();
        }

        private void buttonAgendamento_Click(object sender, EventArgs e)
        {
            //AGENDAMENTO

            int buscarpet = 0;
            int levarpet = 0;

            if(checkBoxBuscarPet.Checked==true)
            {
                buscarpet = 1;
            }

            if(checkBoxLevarPet.Checked==true)
            {
                levarpet = 1;
            }
        }
    }
}
