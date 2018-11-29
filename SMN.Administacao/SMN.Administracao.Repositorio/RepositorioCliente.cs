using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMN.Administracao.Dominio;
using System.Data.SqlClient;
using SMN.Administracao.Repositorio.DataBase;
using System.Data;

namespace SMN.Administracao.Repositorio
{
    public class RepositorioCliente
    {
        public void InserirCLiente(Cliente cliente)
        {
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("CadCliente",conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Nome", cliente.Nome));
            comando.Parameters.Add(new SqlParameter("@Endereco", cliente.Endereco));
            comando.Parameters.Add(new SqlParameter("@Celular", cliente.Celular));
            comando.Parameters.Add(new SqlParameter("@Sexo", cliente.Sexo));
            comando.Parameters.Add(new SqlParameter("@Cpf", cliente.Cpf));
            comando.Parameters.Add(new SqlParameter("@DataNasc", cliente.DataNasc));
            comando.Parameters.Add(new SqlParameter("@DataCad", cliente.DataCad));
            comando.ExecuteNonQuery();
        }
        public void EditarCLiente(Cliente cliente)
        {
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("AltCliente", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@IdCliente", cliente.IdCliente));
            comando.Parameters.Add(new SqlParameter("@Nome", cliente.Nome));
            comando.Parameters.Add(new SqlParameter("@Endereco", cliente.Endereco));
            comando.Parameters.Add(new SqlParameter("@Celular", cliente.Celular));
            comando.Parameters.Add(new SqlParameter("@Sexo", cliente.Sexo));
            comando.Parameters.Add(new SqlParameter("@Cpf", cliente.Cpf));
            comando.Parameters.Add(new SqlParameter("@DataNasc", cliente.DataNasc));
            comando.Parameters.Add(new SqlParameter("@DataCad", cliente.DataCad));
            comando.ExecuteNonQuery();
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            var listCliente = new List<Cliente>();

            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("ListarCliente", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            using (var reader = comando.ExecuteReader())
                while (reader.Read())
                    listCliente.Add(new Cliente
                    {
                        IdCliente = reader.GetInt32(reader.GetOrdinal("IdCliente")),
                        Nome = reader.GetString(reader.GetOrdinal("Nome")),
                        Endereco = reader.GetString(reader.GetOrdinal("Endereco")),
                        Celular = reader.GetString(reader.GetOrdinal("Celular")),
                        Sexo = reader.GetString(reader.GetOrdinal("Sexo")),
                        Cpf = reader.GetString(reader.GetOrdinal("Cpf")),
                        DataNasc = reader.GetDateTime(reader.GetOrdinal("DataNasc")),
                        DataCad = reader.GetDateTime(reader.GetOrdinal("DataCad"))
                    });
            return listCliente;
        }
        public Cliente ListarClientePorId(int id)
        {
            var cliente = new Cliente();
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("ListarClientePorId", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Id", id));
            using (var reader = comando.ExecuteReader())
                if(reader.Read())
                    cliente=(new Cliente
                    {
                        IdCliente = reader.GetInt32(reader.GetOrdinal("IdCliente")),
                        Nome = reader.GetString(reader.GetOrdinal("Nome")),
                        Endereco = reader.GetString(reader.GetOrdinal("Endereco")),
                        Celular = reader.GetString(reader.GetOrdinal("Celular")),
                        Sexo = reader.GetString(reader.GetOrdinal("Sexo")),
                        Cpf = reader.GetString(reader.GetOrdinal("Cpf")),
                        DataNasc = reader.GetDateTime(reader.GetOrdinal("DataNasc")),
                        DataCad = reader.GetDateTime(reader.GetOrdinal("DataCad"))
                    });

            return cliente;

        }
        public void Deletar(int id)
        {
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("DeletarCliente", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Id", id));

            comando.ExecuteNonQuery();

        }
    }
}
