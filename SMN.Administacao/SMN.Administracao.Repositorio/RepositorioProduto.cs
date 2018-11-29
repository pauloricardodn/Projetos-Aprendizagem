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
    public class RepositorioProduto
    {
        public void InserirProduto(Produto produto)
        {
           
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("InserirProduto", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Produto",produto.NomeProduto));
            comando.Parameters.Add(new SqlParameter("@QtdEstoque", produto.QtdEstoque));
            comando.Parameters.Add(new SqlParameter("@ValCompra", produto.ValorCompra));
            comando.Parameters.Add(new SqlParameter("@ValVenda", produto.ValorVenda));
            comando.ExecuteNonQuery();
            
        }
        public void AlterarProduto(Produto produto)
        {

            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("AlterarProduto", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@IdProduto", produto.IdProduto));
            comando.Parameters.Add(new SqlParameter("@Produto", produto.NomeProduto));
            comando.Parameters.Add(new SqlParameter("@QtdEstoque", produto.QtdEstoque));
            comando.Parameters.Add(new SqlParameter("@ValCompra", produto.ValorCompra));
            comando.Parameters.Add(new SqlParameter("@ValVenda", produto.ValorVenda));
            comando.ExecuteNonQuery();

        }
        public IEnumerable<Produto> SelecionarProduto()
        {
            var listaProduto = new List<Produto>();
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("SelecionarProduto", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            using (var reader = comando.ExecuteReader())
                while (reader.Read())
                {
                    listaProduto.Add(new Produto
                    {
                        IdProduto= reader.GetInt32(reader.GetOrdinal("IdProduto")),
                        NomeProduto = reader.GetString(reader.GetOrdinal("Produto")),
                        QtdEstoque = reader.GetDecimal(reader.GetOrdinal("QtdEstoque")),
                        ValorCompra = reader.GetDecimal(reader.GetOrdinal("ValCompra")),
                        ValorVenda = reader.GetDecimal(reader.GetOrdinal("ValVenda"))

                    });
                }

            return listaProduto;
        }
        public Produto BuscarProduto(int id)
        {
            Produto produto = new Produto();
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("BuscarProduto", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@IdProduto", id));
            using (var reader = comando.ExecuteReader())
                if (reader.Read())
                    produto = (new Produto
                    {
                        IdProduto = reader.GetInt32(reader.GetOrdinal("IdProduto")),
                        NomeProduto = reader.GetString(reader.GetOrdinal("Produto")),
                        QtdEstoque = reader.GetDecimal(reader.GetOrdinal("QtdEstoque")),
                        ValorCompra = reader.GetDecimal(reader.GetOrdinal("ValCompra")),
                        ValorVenda = reader.GetDecimal(reader.GetOrdinal("ValVenda"))

                    });

            return produto;

        }
        public void DeletarProduto(int id)
        {
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("ExcluirProduto", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@IdProduto", id));

            comando.ExecuteNonQuery();
        }

    }
}
