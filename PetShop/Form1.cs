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

            atualizarComboPet();
        }

        private void buttonCadastroPet_Click(object sender, EventArgs e)
        {
            //CADASTRO DE CACHORROS DO CLIENTE

            string cmdidcli = @"SELECT idCliente FROM CLIENTES WHERE CPF='" + textBoxCPFCliente.Text + "'";
            int idcliente = cadastro.idcliente(cmdidcli); //   << PEGA O ID DO CLIENTE NO QUAL ESTA FAZENDO O CADASTRO

            string cmdSelectAnimal = @"SELECT A.nomeAnimal AS 'Nome', nT.nomeTipo AS 'Tipo', nP.nomePorte AS 'Porte' FROM ANIMAIS AS A 
INNER JOIN TIPOS AS nT ON nT.idTipo = A.idTipo INNER JOIN PORTES AS nP on nP.idPorte = A.idPorte WHERE idCliente=" + idcliente + ";";

            string cmdInsert = @"INSERT INTO ANIMAIS (nomeAnimal, idPorte, idTipo, Observacoes, idCliente) VALUES ('" + textBoxNomePet.Text + "', '" +
                comboBoxPortePet.SelectedValue + "', '" + comboBoxTipoPet.SelectedValue + "', '" + textBoxAlergiaPet.Text + "', " + idcliente + ");";


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

            limpezaListagemDadosPet(); //limpar os campos para receber novos dados referente dono pet

            string cmdSelectCliente = @"SELECT * FROM CLIENTES WHERE CPF='" + textBoxAgendCPF.Text + "';";
            string cmdSelect = @"SELECT A.nomeAnimal as 'Nome' FROM ANIMAIS AS A INNER JOIN Clientes AS B ON B.idCliente = A.idCliente 
WHERE B.cpf = '" + textBoxAgendCPF.Text + "'";

            cadastro.listaTable(cmdSelect, dataGridView2);

            if(radioButton2.Checked==true)
            {
                //dados do cliente referente ao cadastro

                cadastro.dadosCliente(cmdSelectCliente, textBoxtelefone1, textBoxtelefone2, textBoxEndereco, textBoxNum, textBoxBairro);
            }
            else if(radioButton4.Checked==true)
            {
                //dados do cliente para um local fora do cadastro

                limpezaListagemDadosPet();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string cmdSelectCliente = @"SELECT * FROM CLIENTES WHERE CPF='" + textBoxAgendCPF.Text + "';";

            if (radioButton2.Checked == true)
            {
                //dados do cliente referente ao cadastro

                limpezaListagemDadosPet();

                cadastro.dadosCliente(cmdSelectCliente, textBoxtelefone1, textBoxtelefone2, textBoxEndereco, textBoxNum, textBoxBairro);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                limpezaListagemDadosPet();
            }
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

        private void buttonPetConfig_Click(object sender, EventArgs e)
        {
            //Abrir formulario de configuração pet

            FormPetConfig petConfig = new FormPetConfig();
            petConfig.Show();
        }

        private void atualizarComboPet()
        {
            string cmdSelect = @"SELECT * FROM ";

            cadastro.atulizaCombo(cmdSelect + "Portes", comboBoxPortePet, "nomePorte", "idPorte");
            cadastro.atulizaCombo(cmdSelect + "Tipos", comboBoxTipoPet, "nomeTipo", "idTipo");
        }

        private void buttonHoraEntrada_Click(object sender, EventArgs e)
        {
            //hora de entrada

            string data = DateTime.Now.ToLongTimeString();
            textBoxHoraEntrada.Text = data;
        }

        private void buttonHoraSaida_Click(object sender, EventArgs e)
        {
            //hora saida

            string data = DateTime.Now.ToLongTimeString();
            textBoxHoraSaida.Text = data;
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

        private void limpezaListagemDadosPet()
        {
            textBoxtelefone1.Clear();
            textBoxtelefone2.Clear();
            textBoxBairro.Clear();
            textBoxEndereco.Clear();
            textBoxNum.Clear();
        }
    }
}
