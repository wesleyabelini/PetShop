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

            string cmdInsert = @"INSERT INTO ANIMAIS (nomeAnimal, Porte, Tipo, Observacoes) VALUES ('" + textBoxNomePet.Text + "', '" +
                comboBoxPortePet.Text + "', '" + textBoxRacaPet.Text + "', '" + textBoxAlergiaPet + "');";

            cadastro.cadastro(cmdInsert);
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
            //LISTAR OS PETS DO CLIENTE

            string cmdSelect = @"SELECT nomeAnimal, Tipo WHERE EXISTS(SELECT CPF FROM Clientes WHERE cpf='" + textBoxAgendCPF.Text + "'";

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
    }
}
