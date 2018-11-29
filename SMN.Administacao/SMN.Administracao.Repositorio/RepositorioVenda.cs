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
    public class RepositorioVenda
    {


        public void RealizarVenda(Venda venda)
        {
            SqlConnection conexao = Utils.GetConexao();
            SqlTransaction tran = conexao.BeginTransaction();

            SqlCommand comando = Utils.GetCommand("RealizarVenda", conexao);
            comando.CommandType = CommandType.StoredProcedure;

            SqlCommand comando2 = Utils.GetCommand("ItenVenda", conexao);
            comando2.CommandType = CommandType.StoredProcedure;

            try
            {
                comando.Parameters.Add(new SqlParameter("@IdCliente", venda.IdCliente));
                comando.Parameters.Add(new SqlParameter("@DataVenda", venda.DataVenda));
                SqlParameter retval = comando.Parameters.Add("@ReturnValue", SqlDbType.Int);
                retval.Direction = ParameterDirection.ReturnValue;
                comando.Transaction = tran;
                comando.ExecuteNonQuery();
                venda.IdVenda = (int)comando.Parameters["@ReturnValue"].Value;

                comando2.Transaction = tran;
                foreach (var item in venda.VendaItem)
                {
                    comando2.Parameters.Add(new SqlParameter("@IdVenda", venda.IdVenda));
                    comando2.Parameters.Add(new SqlParameter("@IdProd", item.IdProduto));
                    comando2.Parameters.Add(new SqlParameter("@ItemQtd", item.Qtd));
                    comando2.Parameters.Add(new SqlParameter("@ValorUnitario", item.ValorUnitario));
                    comando2.ExecuteNonQuery();

                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("  Message: {0}", ex.Message);
                try
                {
                    tran.Rollback();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
            }
        }         

         public void EditarVenda(Venda venda)
        {
            SqlConnection conexao = Utils.GetConexao();
            SqlTransaction tran = conexao.BeginTransaction();

            SqlCommand comando = Utils.GetCommand("ItenVenda", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Transaction = tran;

            SqlCommand comando2 = Utils.GetCommand("EditarItenVenda", conexao);
            comando2.CommandType = CommandType.StoredProcedure;           
            comando2.Transaction = tran;
            try
            {                                      
                foreach (var item in venda.VendaItem)
                {
                    if (item.IdVendaItem == 0)
                    {
                        comando.Parameters.Clear();
                        comando.Parameters.Add(new SqlParameter("@IdVenda", venda.IdVenda));
                        comando.Parameters.Add(new SqlParameter("@IdProd", item.IdProduto));
                        comando.Parameters.Add(new SqlParameter("@ItemQtd", item.Qtd));
                        comando.Parameters.Add(new SqlParameter("@ValorUnitario", item.ValorUnitario));
                        comando.ExecuteNonQuery();
                    }else
                    {
                        comando2.Parameters.Clear();
                        comando2.Parameters.Add(new SqlParameter("@IdVendaItem", item.IdVendaItem));
                        comando2.Parameters.Add(new SqlParameter("@ItemQtd", item.Qtd));
                        comando2.ExecuteNonQuery();
                    }                    
                }
                SqlCommand comando3 = Utils.GetCommand("DeletarItenVenda", conexao);
                comando3.CommandType = CommandType.StoredProcedure;
                comando3.Transaction = tran;
                foreach (var itemDeletar in venda.ItemDeletar)
                {
                    comando3.Parameters.Clear();
                    comando3.Parameters.Add(new SqlParameter("@IdVendaItem", itemDeletar.IdVendaItem));                    
                    comando3.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("  Message: {0}", ex.Message);
                try
                {
                    tran.Rollback();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
            }
        }       
        public IEnumerable<Venda> ListarVenda()
        {
            var listarVenda = new List<Venda>();
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("ListarVenda", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            using (var reader = comando.ExecuteReader())
                while (reader.Read())
                {
                    listarVenda.Add(new Venda(
                            reader.GetInt32(reader.GetOrdinal("IdVenda")),
                            reader.GetInt32(reader.GetOrdinal("IdCliente")),
                            reader.GetString(reader.GetOrdinal("Nome")),
                            reader.GetDateTime(reader.GetOrdinal("DataVenda")),
                            reader.GetDecimal(reader.GetOrdinal("ValorTotal"))

                    ));
                }
            return listarVenda;
        }
        public IEnumerable<VendaItem> BuscarItensVenda(int id)
        {
            SqlConnection conexao = Utils.GetConexao();
            var listVendaItem = new List<VendaItem>();
            SqlCommand comando2 = Utils.GetCommand("BuscarVendaItens", conexao);
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.Add(new SqlParameter("@Id", id));
            using (var reader2 = comando2.ExecuteReader())
                while (reader2.Read())
                {
                    listVendaItem.Add(new VendaItem(
                            reader2.GetInt32(reader2.GetOrdinal("IdItemVenda")),
                            reader2.GetInt32(reader2.GetOrdinal("IdProduto")),
                            reader2.GetString(reader2.GetOrdinal("Produto")),
                            reader2.GetDecimal(reader2.GetOrdinal("ItemQtd")),
                            reader2.GetDecimal(reader2.GetOrdinal("ValorUnitario")),
                            reader2.GetDecimal(reader2.GetOrdinal("ValorTotalItem"))

                    ));
                }
            return listVendaItem;
        }

        public Venda BuscarVenda( int id)
        {
            var venda = new Venda();
            SqlConnection conexao = Utils.GetConexao();
            SqlCommand comando = Utils.GetCommand("BuscarVenda", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Id", id));
            var reader = comando.ExecuteReader();
            if (reader.Read())
                venda = new Venda(
                        reader.GetInt32(reader.GetOrdinal("IdVenda")),
                        reader.GetInt32(reader.GetOrdinal("IdCliente")),
                        reader.GetString(reader.GetOrdinal("Nome")),
                        reader.GetDateTime(reader.GetOrdinal("DataVenda")),
                        reader.GetDecimal(reader.GetOrdinal("ValorTotal"))

                );


            venda.VendaItem = BuscarItensVenda(id);

            return venda;
        }


    }
}
