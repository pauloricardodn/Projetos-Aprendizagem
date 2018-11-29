using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMN.Administracao.Repositorio.DataBase
{
    public class Utils
    {   
        public static SqlConnection GetConexao()
        {
            SqlConnection conexao = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Administracao;User Id=sa;Password = root; ");
            conexao.Open();
            return conexao;
        }
        public static SqlCommand GetCommand(string nomeComando, SqlConnection conexao)
        {
            SqlCommand command = new SqlCommand(nomeComando, conexao);
            return command;
        }

        public static DbDataReader GetDataReader(DbCommand command)
        {
            return command.ExecuteReader();
        }
    }
}
