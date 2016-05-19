using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Configuration;

namespace PetShop
{
    class Cadastro
    {
        string sqlconexao = ConfigurationManager.ConnectionStrings["ConexaoDb"].ConnectionString;

        public int cadastroComReturnId(string cmdstring)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = sqlconexao;
            int modified = 0;
            try
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand(cmdstring, conexao);
                
                modified = (int)(decimal) cmd.ExecuteScalar();

                conexao.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(cmdstring +"\n\n"+ ex);
            }

            return modified;
        }

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
            TextBox complemento, TextBox textBoxNome2)
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

                    if (reader["complemento"].ToString() != "")
                    {
                        complemento.Text = reader["complemento"].ToString();
                    }

                    if (reader["nomeCliente"].ToString() != "")
                    {
                        textBoxNome2.Text = reader["nomeCliente"].ToString();
                    }


                }

                conexao.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        public void dadospet(string codigo, TextBox porte, TextBox tipo, TextBox obeservacao)
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

        public int insertOrdem(ComboBox pet)
        {
            int idordem = 0;

            string cmdSelect = @"SELECT MAX(IDORDEMDESERVICO) as 'valor' FROM ORDEMDESERVICO";

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = sqlconexao;

            try
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand(cmdSelect, conexao);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idordem =Convert.ToInt16(reader["valor"].ToString());
                }

            }
            catch
            {
                //null
            }

            if (idordem == 0)
            {
                string cmdInsertOrdem = @"INSERT INTO ORDEMDESERVICO (RUA, idAnimal) VALUES ('', " + pet.SelectedValue + ");";

                cadastro(cmdInsertOrdem);

                idordem++;
            }

            return idordem;
        }
        
        public void listaTablePorArray(ComboBox servico, DataGridView grid)
        {
            int rowId = grid.Rows.Add();
            DataGridViewRow row = grid.Rows[rowId];

            // Add the data
            row.Cells["idServico"].Value = servico.SelectedValue;
            row.Cells["nomeServico"].Value = servico.Text;

        }

        public void dadosOrdemServico(int idOrdem, DataGridView dataGridViewServicos,
                TextBox clienteNome,
                TextBox clienteCpf,
                TextBox clienteBairro,
                TextBox clienteEndereco,
                TextBox clienteNumero,
                TextBox clienteTel1,
                TextBox clienteTel2,
                TextBox petNome,
                TextBox petTipo,
                TextBox petPorte,
                TextBox petObs,
                TextBox ordemBairro,
                TextBox ordemEndereco,
                TextBox ordemNumero,
                TextBox ordemComplemento)
        {
            string comando = @"SELECT 
                                    Clientes.*,
                                    Animais.*,
                                    Portes.nomePorte,
                                    Tipos.nomeTipo,
                                    Servicos.*,
                                    OrdemDeServico.*
                            FROM OrdemDeServico
                            LEFT JOIN Animais ON Animais.idAnimal = OrdemDeServico.idAnimal
                            LEFT JOIN Portes ON Portes.idPorte = Animais.idPorte
                            LEFT JOIN Tipos ON Tipos.idTipo = Animais.idTipo
                            LEFT JOIN Clientes ON Clientes.idCliente = Animais.idCliente
                            LEFT JOIN ServicoOS ON ServicoOS.idOrdemDeServico = OrdemDeServico.idOrdemDeServico
                            LEFT JOIN Servicos ON Servicos.idServico = ServicoOS.idServico
                            WHERE OrdemDeServico.idOrdemDeServico = '" + idOrdem +"'; ";
            //preenche textbox com os dados do cliente conforme busca

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = sqlconexao;
            SqlDataReader reader;
            
            try
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand(comando, conexao);

                reader = cmd.ExecuteReader();
                dataGridViewServicos.Rows.Clear();

                Console.WriteLine(reader);


                while (reader.Read())
                {
                    int rowId = dataGridViewServicos.Rows.Add();
                    DataGridViewRow row = dataGridViewServicos.Rows[rowId];
                    
                    row.Cells["id"].Value = reader["idServico"].ToString();
                    row.Cells["servico"].Value = reader["nomeServico"].ToString();
                    
                    if (reader["nomeCliente"].ToString() != "")
                    {
                        clienteNome.Text = reader["nomeCliente"].ToString();
                    }

                    if (reader["cpf"].ToString() != "")
                    {
                        clienteCpf.Text = reader["cpf"].ToString();
                    }
                    
                    if (reader["bairro"].ToString() != "")
                    {
                        clienteBairro.Text = reader["bairro"].ToString();
                    }

                    if (reader["rua"].ToString() != "")
                    {
                        clienteEndereco.Text = reader["rua"].ToString();
                    }

                    if (reader["numero"].ToString() != "")
                    {
                        clienteNumero.Text = reader["numero"].ToString();
                    }

                    if (reader["telefone1"].ToString() != "")
                    {
                        clienteTel1.Text = reader["telefone1"].ToString();
                    }

                    if (reader["telefone2"].ToString() != "")
                    {
                        clienteTel1.Text = reader["telefone2"].ToString();
                    }

                    if (reader["nomeAnimal"].ToString() != "")
                    {
                        petNome.Text = reader["nomeAnimal"].ToString();
                    }

                    if (reader["nomeTipo"].ToString() != "")
                    {
                        petTipo.Text = reader["nomeTipo"].ToString();
                    }

                    /*
                TextBox ordemBairro,
                TextBox ordemEndereco,
                TextBox ordemNumero,
                TextBox ordemComplemento*/
                    if (reader["bairro"].ToString() != "")
                    {
                        petPorte.Text = reader["bairro"].ToString();
                    }
                    if (reader["nomePorte"].ToString() != "")
                    {
                        petPorte.Text = reader["nomePorte"].ToString();
                    }
                    if (reader["nomePorte"].ToString() != "")
                    {
                        petPorte.Text = reader["nomePorte"].ToString();
                    }
                    if (reader["nomePorte"].ToString() != "")
                    {
                        petPorte.Text = reader["nomePorte"].ToString();
                    }
                }

                conexao.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            
        }

        public void listaTableServicosOS(SqlDataAdapter data, DataGridView grid)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = sqlconexao;

            try
            {
                DataTable table = new DataTable();

                data.Fill(table);

                grid.DataSource = table;

                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}