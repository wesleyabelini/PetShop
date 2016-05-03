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

            //Operações dafault apos cadastro

            textBoxNomePet.Clear();
            textBoxAlergiaPet.Clear();
            comboBoxPortePet.SelectedIndex = -1;
            comboBoxTipoPet.SelectedIndex = -1;
        }

        private void ListarPets_Click(object sender, EventArgs e)
        {
            //LISTAR OS PETS DO CLIENTE PARA AGENDAR

            limpezaListagemDadosPet(); //limpar os campos para receber novos dados referente dono pet

            string cmdSelectCliente = @"SELECT * FROM CLIENTES WHERE CPF='" + textBoxAgendCPF.Text + "';";
            string cmdSelect = @"SELECT A.idAnimal, A.nomeAnimal as 'Nome' FROM ANIMAIS AS A INNER JOIN Clientes AS B ON B.idCliente = A.idCliente 
WHERE B.cpf = '" + textBoxAgendCPF.Text + "'";

            cadastro.listaTable(cmdSelect, dataGridView2);

            cadastro.dadosCliente(cmdSelectCliente, textBoxtelefone1, textBoxtelefone2, textBoxEndereco, textBoxNum, textBoxBairro, 
                textBoxComplementoAgend);
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
                textBoxEnderecoCliente.Text + "', '" + textBoxNumCliente.Text + "', '" + textBoxComplemento.Text + "', '" + 
                textBoxBairroCliente.Text + "', '" + textBoxTel1Cliente.Text + "', '" + textBoxTel2Cliente.Text + "')";

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

            if(textBoxHora.Text != "" && dataGridView2.Rows.Count >1)
            {
                string dia = monthCalendar2.SelectionRange.Start.ToString("MM/dd/yyyy");
                string data = dia + " " + textBoxHora.Text + ":00";
                int buscarpet = 0;
                int levarpet = 0;
                int idlogin = 1;

                string idanimal = dataGridView2.CurrentRow.Cells[0].Value.ToString();

                if (checkBoxBuscarPet.Checked == true)
                {
                    buscarpet = 1;
                }

                if (checkBoxLevarPet.Checked == true)
                {
                    levarpet = 1;
                }

                string cmdInsert = @"INSERT INTO AGENDA VALUES ('" + data + "', '" + textBoxEndereco.Text + "', '" + textBoxNum.Text + "', '" +
                    textBoxComplementoAgend.Text + "', '" + textBoxBairro.Text + "', '" + textBoxtelefone1.Text + "', '" + textBoxtelefone2.Text +
                    "', " + idanimal + ", " + idlogin + ", " + buscarpet + ", " + levarpet + ");";

                cadastro.cadastro(cmdInsert);
            }
            else
            {
                MessageBox.Show("Campo hora não deve ficar vazio", "Erro hora", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //atualiza casa
            cadastro.atulizaCombo(cmdSelect + "Casas", comboBoxCasa, "nomeCasa", "idCasa");

            //atualiza serviço
            cadastro.atulizaCombo(cmdSelect + "Servicos", comboBoxServicos, "nomeServico", "idServico");
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

        private void comboBoxPortePet_Click(object sender, EventArgs e)
        {
            //atualizar porte do pet

            string cmdSelect = @"SELECT * FROM ";

            cadastro.atulizaCombo(cmdSelect + "Portes", comboBoxPortePet, "nomePorte", "idPorte");
        }

        private void comboBoxTipoPet_Click(object sender, EventArgs e)
        {
            string cmdSelect = @"SELECT * FROM ";

            cadastro.atulizaCombo(cmdSelect + "Tipos", comboBoxTipoPet, "nomeTipo", "idTipo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAdmin admin = new FormAdmin();
            admin.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Relatório

            this.reportViewer1.RefreshReport();
        }

        private void buttonAddServico_Click(object sender, EventArgs e)
        {
            //Inserir o Serviço na Agenda
        }
    }
}
