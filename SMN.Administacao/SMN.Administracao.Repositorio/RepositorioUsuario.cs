using SMN.Administracao.Dominio;
using SMN.Administracao.Repositorio.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMN.Administracao.Repositorio
{
    public class RepositorioUsuario
    {
        public Usuario AutenticarUsuario(string login, string senha)
        {
            var usuario = new Usuario();
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("AutUsuario", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Login", login));
            comando.Parameters.Add(new SqlParameter("@Senha", senha));
            using (var reader = comando.ExecuteReader())
                if (reader.Read())
                    usuario = (new Usuario
                    {
                        Codigo = reader.GetInt32(reader.GetOrdinal("Codigo")),
                        Nome = reader.GetString(reader.GetOrdinal("Nome")),
                      
                    });

            return usuario;

        }
    }
}
