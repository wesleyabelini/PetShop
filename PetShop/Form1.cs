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
            comboBoxTipoOS.SelectedIndex = comboBoxTipoOS.Items.IndexOf("Buscar PET");
            //tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);

            FormLogin frml = new FormLogin();
            frml.FormClosed += new FormClosedEventHandler(mainForm_FormClosed);
            frml.ShowDialog();
        }

        // this is the method block executes when main form is closed
        void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // here you can do anything

            // we will close the application
            Application.Exit();
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

            if (textBoxAgendCPF.MaskFull)
            {
                textBoxAgendCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            }

            string cmdSelectCliente = @"SELECT * FROM CLIENTES WHERE CPF='" + textBoxAgendCPF.Text + "';";
            //textBoxAgendCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

            string cmdSelect = @"SELECT A.idAnimal, A.nomeAnimal FROM ANIMAIS AS A INNER JOIN Clientes AS B ON B.idCliente = A.idCliente 
            WHERE B.cpf = '" + textBoxAgendCPF.Text + "'";
            
            cadastro.atulizaCombo(cmdSelect, comboBoxNomePet, "nomeAnimal", "idAnimal");
            
            //baixar os dados do cliente

            cadastro.dadosCliente(cmdSelectCliente, textBoxtelefone1, textBoxtelefone2, textBoxEndereco, textBoxNum, textBoxBairro, 
                textBoxComplementoAgend, textBoxNome2);

            if(comboBoxNomePet.Items.Count >=0)
            {
                comboBoxNomePet.SelectedIndex = 0;

                limpaCampoPet();

                string cmdSelectdadosPet = @"SELECT A.NOMEANIMAL, PO.NOMEPORTE, TI.NOMETIPO, A.observacoes FROM Animais AS A
                INNER JOIN Portes AS PO ON PO.idPorte=A.idPorte
                INNER JOIN Tipos AS TI ON TI.idTipo=A.idTipo
                WHERE A.idAnimal=" + comboBoxNomePet.SelectedValue + ";";

                cadastro.dadospet(cmdSelectdadosPet, textBoxPortePetD, textBoxTipoPetD, textBoxObeservacapPetD);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //CONFORME ALTERAÇÃO DE DATA >>>>>>>>> Executa a listagem da agenda para o dia....<<<<<<<<<<

            string data = monthCalendar1.SelectionRange.Start.ToString("dd/MM/yyyy");

            string cmdSelect = @"SELECT A.idOrdemDeServico AS 'ID', nomeCliente AS 'Cliente', nomeAnimal AS 'Animal' FROM OrdemDeServico AS A
                                INNER JOIN Animais AS AN ON AN.idAnimal = A.idAnimal
                                INNER JOIN Clientes AS CLI ON CLI.idCliente=AN.idCliente
                                WHERE Convert(date,A.dataHoraAgenda) = Convert(date,'" + data + "') ;";
            
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
            //AGENDAMENTO >>update ordem de serviço
            
            if (textBoxNome2.Text == "")
            {
                MessageBox.Show("Selecione um cliente.", "Erro campo Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridView4.Rows.Count <= 0)
            {
                MessageBox.Show("Selecione pelo menos um serviço.", "Erro campo PET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string dia = monthCalendar2.SelectionRange.Start.ToString("dd/MM/yyyy");
                string data = dia + " " + maskedTextBox1.Text + ":00";
                int buscarpet = 0;
                int levarpet = 0;

                string idanimal = comboBoxNomePet.SelectedValue.ToString();
                
                if (comboBoxTipoOS.SelectedText == "Buscar PET")
                {
                    buscarpet = 1;
                }
                else if (comboBoxTipoOS.SelectedText == "Levar PET")
                {
                    levarpet = 1;
                }

                string cmdInsert = @"INSERT INTO ORDEMDESERVICO (
                idAnimal, dataHoraAgenda, rua, numero, complemento, bairro, telefone1, telefone2, busca, volta)
                VALUES ("
                + idanimal + ", '" + data + "', '" + textBoxEndereco.Text + "', '" + textBoxNum.Text + "', '"
                + textBoxComplementoAgend.Text + "', '" + textBoxBairro.Text + "', '" + textBoxtelefone1.Text + "', '" 
                + textBoxtelefone2.Text + "', " + buscarpet + ", " + levarpet + ") SELECT SCOPE_IDENTITY();";

                int id = cadastro.cadastroComReturnId(cmdInsert);
                string cmdServicoOS = "";
                string colID;
                foreach (DataGridViewRow dr in dataGridView4.Rows)
                {
                    colID = dr.Cells["idServico"].Value.ToString();
                    cmdServicoOS = cmdServicoOS + @"INSERT INTO SERVICOOS (idServico, idOrdemDeServico) VALUES(" + colID + ", " + id + ");";
                }

                cadastro.cadastro(cmdServicoOS);
                

                //id = cadastro.cadastroComReturnId(cmdServicoOS);

                /*
                string cmdInsert = @"UPDATE ORDEMDESERVICO SET BUSCA =" + buscarpet;
                string cmdInsert2 = @"UPDATE ORDEMDESERVICO SET VOLTA =" + levarpet;

                cadastro.cadastro(cmdServicoOS);
                cadastro.cadastro(cmdInsert2);*/
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

        private void limpaAbaOS()
        {
            textBoxAgendCPF.Clear();
            textBoxNome2.Clear();

            textBoxTipoPetD.Clear();
            textBoxPortePetD.Clear();
            textBoxObeservacapPetD.Clear();
            textBoxEndereco.Clear();
            textBoxNum.Clear();
            textBoxComplementoAgend.Clear();
            textBoxBairro.Clear();
            textBoxtelefone1.Clear();
            textBoxtelefone2.Clear();
            dataGridView4.DataSource = null;
            dataGridView4.Rows.Clear();
            maskedTextBox1.Clear();
            cadastro.atulizaCombo("SELECT * FROM Servicos", comboBoxServicos, "nomeServico", "idServico");

            comboBoxNomePet.DataSource = null;
        }

        private void limpacadastrocliente()
        {
            textBoxNomeCliente.Clear();
            textBoxCPFCliente.Clear();
            textBoxCPFBUSCA.Clear();
            textBoxEnderecoCliente.Clear();
            textBoxNumCliente.Clear();
            textBoxBairroCliente.Clear();
            textBoxTel1Cliente.Clear();
            textBoxTel2Cliente.Clear();
            textBoxComplemento.Clear();
        }

        private void limpezaListagemDadosPet()
        {
            textBoxtelefone1.Clear();
            textBoxtelefone2.Clear();
            textBoxBairro.Clear();
            textBoxEndereco.Clear();
            textBoxNum.Clear();
            textBoxComplementoAgend.Clear();
        }

        private void limpaCampoPet()
        {
            textBoxTipoPetD.Clear();
            textBoxPortePetD.Clear();
            textBoxObeservacapPetD.Clear();
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
            // TODO: This line of code loads data into the 'hidrapetsoftDataSet.OrdemDeServico' table. You can move, or remove it, as needed.
            this.OrdemDeServicoTableAdapter.Fill(this.hidrapetsoftDataSet.OrdemDeServico);
            //Relatório

            this.reportViewer1.RefreshReport();
        }

        private void buttonAddServico_Click(object sender, EventArgs e)
        {
            cadastro.listaTablePorArray(comboBoxServicos, dataGridView4);

            //adicionar serviço à orderm de serviço
            /*
            string dia = monthCalendar2.SelectionRange.Start.ToString("MM/dd/yyyy");

            if(textBoxHora.Text =="")
            {
                textBoxHora.Text = "00";
            }

            string data = dia + " " + textBoxHora.Text + ":00";

            if (textBoxNome2.Text != "" && comboBoxNomePet.SelectedIndex > -1)
            {
                int id = cadastro.insertOrdem(comboBoxNomePet);

                if (textBoxEndereco.Text != "")
                {
                    //Realizar cadatro da Ordem de Serviço
                    string cmdInsertOrdem = @"INSERT INTO ORDEMDESERVICO (IDANIMAL, DATAHORAAGENDA, RUA, NUMERO, COMPLEMENTO, BAIRRO, TELEFONE1, 
TELEFONE2, BUSCA, VOLTA) VALUES (" + comboBoxNomePet.SelectedValue + ", '" + data + "', '" + textBoxEndereco.Text + "', '" + textBoxNum.Text + "', '" +
textBoxComplementoAgend.Text + "', '" + textBoxBairro.Text + "', '" + textBoxtelefone1.Text + "', '" + textBoxtelefone2.Text + "', 0, 0);";

                    cadastro.cadastro(cmdInsertOrdem);

                    string cmdServicoOS = @"INSERT INTO SERVICOOS VALUES(" + comboBoxServicos.SelectedValue + ", " + id + ");";

                    string cmdServTB = @"Select A.nomeServico, A.valor FROM SERVICOS AS A 
INNER JOIN SERVICOOS AS B ON B.IDSERVICO = A.IDSERVICO 
WHERE IDORDEMDESERVICO=" + id + ";";

                    cadastro.cadastro(cmdServicoOS);

                    cadastro.listaTable(cmdServTB, dataGridView4);
                }
            }*/


        }

        private void comboBoxNomePet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (textBoxNome2.Text !="")
            {
                limpaCampoPet();

                string cmdSelectdadosPet = @"SELECT A.NOMEANIMAL, PO.NOMEPORTE, TI.NOMETIPO, A.observacoes FROM Animais AS A
INNER JOIN Portes AS PO ON PO.idPorte=A.idPorte
INNER JOIN Tipos AS TI ON TI.idTipo=A.idTipo
WHERE A.idAnimal=" + comboBoxNomePet.SelectedValue + ";";

                cadastro.dadospet(cmdSelectdadosPet, textBoxPortePetD, textBoxTipoPetD, textBoxObeservacapPetD);
            }
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            //Botao buscar para consultar os dados do pet
            //Este recurso sera utlizado para alteração de dados do cliente, assim como incluir novos pets

            string cmdidcli = @"SELECT idCliente FROM CLIENTES WHERE CPF='" + textBoxCPFBUSCA.Text + "'";
            int idcliente = cadastro.idcliente(cmdidcli);

            string cmdSelect = @"SELECT * FROM CLIENTES WHERE CPF='" + textBoxCPFBUSCA.Text + "';";

            cadastro.dadosCliente(cmdSelect, textBoxTel1Cliente, textBoxTel2Cliente, textBoxEnderecoCliente, textBoxNumCliente,
                textBoxBairroCliente, textBoxComplemento, textBoxNome2);

            textBoxCPFCliente.Text = textBoxCPFBUSCA.Text;

            string cmdSelectAnimal = @"SELECT A.nomeAnimal AS 'Nome', nT.nomeTipo AS 'Tipo', nP.nomePorte AS 'Porte' FROM ANIMAIS AS A 
INNER JOIN TIPOS AS nT ON nT.idTipo = A.idTipo INNER JOIN PORTES AS nP on nP.idPorte = A.idPorte WHERE idCliente=" + idcliente + ";";

            cadastro.listaTable(cmdSelectAnimal, dataGridView1);


            buttonCadastroPet.Enabled = true;
            buttonCadastroCliente.Enabled = false;
            buttonNovoCadastro.Enabled = true;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            //Encerrar o Programa com o X
            if (tabPage6.Focus())
            {
                DialogResult result = MessageBox.Show("Deseja sair do Sistema HydraPetSoft?", "HydraPetSoft", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else if (tabPage3.Focus())
            {
                limpaAbaOS();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string idOrdem = dataGridView3.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            cadastro.dadosOrdemServico(
                Int32.Parse(idOrdem), 
                dataGridView2,
                clienteNome,
                clienteCpf,
                clienteBairro,
                clienteEndereco,
                clienteNumero,
                clienteTel1,
                clienteTel2,
                petNome,
                petTipo,
                petPorte,
                petObs,
                ordemBairro,
                ordemEndereco,
                ordemNumero,
                ordemComplemento                
                );
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAgendCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        /*private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }*/
    }
}
