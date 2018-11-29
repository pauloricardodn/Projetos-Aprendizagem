using SMN.Administracao.Dominio;
using SMN.Administracao.Repositorio.DataBase;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SMN.Administracao.Repositorio
{
    public class RepositorioFuncionario 
    {
       
       

        public void InserirUsuario(Funcionarios funcionario)
        {
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("CadastrarFunc", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Nome", funcionario.Nome));
            comando.Parameters.Add(new SqlParameter("@Endereco", funcionario.Endereco));
            comando.Parameters.Add(new SqlParameter("@Sexo", funcionario.Sexo));
            comando.Parameters.Add(new SqlParameter("@DataNasc", funcionario.DataNasc));           
            comando.ExecuteNonQuery();
           // using (var reader = comando.ExecuteReader())
             //   if (reader.Read()) ;


        }
        public void EditarUsuario(Funcionarios funcionario)
        {
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("AlterarFunc", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Id", funcionario.IdFuncionario));
            comando.Parameters.Add(new SqlParameter("@Nome", funcionario.Nome));
            comando.Parameters.Add(new SqlParameter("@Endereco", funcionario.Endereco));
            comando.Parameters.Add(new SqlParameter("@Sexo", funcionario.Sexo));
            comando.Parameters.Add(new SqlParameter("@DataNasc", funcionario.DataNasc));
            comando.ExecuteNonQuery();
            //using (var reader = comando.ExecuteReader())
               // if (reader.Read()) ;

        }
        public IEnumerable<Funcionarios> ListarUsuario()
        {
            var listFuncionario = new List<Funcionarios>();

            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("listarFunc", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            using (var reader = comando.ExecuteReader())
                while (reader.Read())
                    listFuncionario.Add(new Funcionarios
                    {
                        IdFuncionario = reader.GetInt32(reader.GetOrdinal("IdFuncionario")),
                        Nome = reader.GetString(reader.GetOrdinal("Nome")),
                        Endereco = reader.GetString(reader.GetOrdinal("Endereco")),
                        Sexo = reader.GetString(reader.GetOrdinal("Sexo")),
                        DataNasc = reader.GetDateTime(reader.GetOrdinal("DataNasc"))

                    });

            return listFuncionario;

        }
        public Funcionarios ListarUsuarioPorId(int Id)
        {
            Funcionarios fun = new Funcionarios();
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("ListarFuncPorId", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Id", Id));
            using (var reader = comando.ExecuteReader())
                if(reader.Read())
                    fun = (new Funcionarios
                    {
                        IdFuncionario = reader.GetInt32(reader.GetOrdinal("IdFuncionario")),
                        Nome = reader.GetString(reader.GetOrdinal("Nome")),
                        Endereco = reader.GetString(reader.GetOrdinal("Endereco")),
                        Sexo = reader.GetString(reader.GetOrdinal("Sexo")),
                        DataNasc = reader.GetDateTime(reader.GetOrdinal("DataNasc"))

                    });

            return fun;

        }
        public void Deletar(int id)
        {
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("DeletarFunc", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Id", id));
            
            comando.ExecuteNonQuery();
            //using (var reader = comando.ExecuteReader())
            // if (reader.Read()) ;

        }





    }
}
