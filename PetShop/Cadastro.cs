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
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            return id;
        }
    }
}
