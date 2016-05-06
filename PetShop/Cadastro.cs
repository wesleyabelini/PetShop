using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace PetShop
{
    class Cadastro
    {
        string sqlconexao = @"Data Source=DESKTOP-L6FI1GU; Initial Catalog = HIDRAPETSOFT; Integrated Security = true;";

        public void cadastro(string cmdstring)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = sqlconexao;

            try
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand(cmdstring , conexao);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cadastrado", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conexao.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        public void listaTable(string cmdstring, DataGridView grid)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = sqlconexao;

            try
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand(cmdstring, conexao);
                SqlDataAdapter data = new SqlDataAdapter(cmd);

                DataTable table = new DataTable();

                data.Fill(table);

                grid.DataSource = table;

                conexao.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        public bool verificaSeTrue(string cmdstring)
        {
            bool existe = false;

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = sqlconexao;

            try
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand(cmdstring, conexao);
                SqlDataReader reader = cmd.ExecuteReader();

                existe = reader.HasRows;

                conexao.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            return existe;
        }

        public int idcliente(string sqlcommand)
        {
            //retorna o id do cliente no qual a busca será realizada

            int id = 0;

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = sqlconexao;

            try
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand(sqlcommand, conexao);
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    id = Convert.ToInt16(reader["idCliente"].ToString());
                }

                conexao.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            return id;
        }

        public void atulizaCombo(string cmdSelect, ComboBox tabela, string campotabela, string idtabela)
        {
            //Atualiza os dados ja cadastrados no sistema

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = sqlconexao;

            try
            {
                conexao.Open();

                SqlDataAdapter ad = new SqlDataAdapter(cmdSelect, conexao);
                DataTable table = new DataTable();
                table.Clear();

                ad.Fill(table);

                tabela.DataSource = table;
                tabela.DisplayMember = campotabela;
                tabela.ValueMember = idtabela;
                tabela.SelectedIndex = -1;

                tabela.Refresh();

                conexao.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        public void dadosCliente(string comando, TextBox telefone1, TextBox telefone2, TextBox endereco, TextBox num, TextBox bairro, 
            TextBox complemento, TextBox nome)
        {
            //preenche textbox com os dados do cliente conforme busca

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = sqlconexao;

            try
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand(comando, conexao);
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    if(reader["telefone1"].ToString() !="")
                    {
                        telefone1.Text = reader["telefone1"].ToString();
                    }

                    if(reader["telefone2"].ToString() !="")
                    {
                        telefone2.Text = reader["telefone2"].ToString();
                    }

                    if(reader["rua"].ToString() !="")
                    {
                        endereco.Text = reader["rua"].ToString();
                    }

                    if(reader["numero"].ToString()!="")
                    {
                        num.Text = reader["numero"].ToString();
                    }

                    if(reader["Bairro"].ToString()!="")
                    {
                        bairro.Text = reader["Bairro"].ToString();
                    }

                    if(reader["complemento"].ToString()!="")
                    {
                        complemento.Text = reader["complemento"].ToString();
                    }

                    if(reader["nomeCliente"].ToString() !="")
                    {
                        nome.Text = reader["nomeCliente"].ToString();
                    }
                    
                }

                conexao.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        public void dadospet(string codigo, TextBox nome, TextBox porte, TextBox tipo, TextBox obeservacao)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = sqlconexao;

            try
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand(codigo, conexao);
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    if(reader["nomeAnimal"].ToString() !="")
                    {
                        nome.Text = reader["nomeAnimal"].ToString();
                    }

                    if(reader["nomePorte"].ToString() !="")
                    {
                        porte.Text = reader["nomePorte"].ToString();
                    }

                    if(reader["nomeTipo"].ToString()!="")
                    {
                        tipo.Text = reader["nomeTipo"].ToString();
                    }

                    if(reader["observacoes"].ToString()!="")
                    {
                        obeservacao.Text = reader["observacoes"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}