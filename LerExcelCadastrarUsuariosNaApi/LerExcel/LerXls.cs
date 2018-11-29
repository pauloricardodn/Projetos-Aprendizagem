using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Data.Common;
using System.Collections.ObjectModel;
using System.Net;
using System.IO;
using System.Collections;
using Json;

namespace LerExcel
{
    class LerXls
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ler Arquivo:");
            Console.WriteLine();
            List<Usuarios> listaUsuarios = ObterUsuarios();
            Cadastrar(listaUsuarios, null);
            Console.WriteLine("Cadastros efetuados com sucesso.");
            Console.ReadKey();
        }

        static List<Usuarios> ObterUsuarios()
        {
            OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\teste\Lista.xlsx;Extended Properties='Excel 12.0;HDR=YES';");
            string comandoSQL = "Select * from [Plan1$]";
            OleDbCommand comando = new OleDbCommand(comandoSQL, conexao);
            List<Entidades> listaDeUsuario = new List<Entidades>();
            List<Usuarios> listaDeUsuarioAgrupada = new List<Usuarios>();
            try
            {
                conexao.Open();
                OleDbDataReader rd = comando.ExecuteReader();
                while (rd.Read())
                {

                    listaDeUsuario.Add(new Entidades
                    {
                        CodigoSuperior = Convert.ToInt32(rd["COD"]),
                        Superior = rd["SUPERIOR"].ToString(),
                        CodigoRepres = Convert.ToInt32(rd["COD_REPRES"]),
                        Fantasia = rd["FANTASIA"].ToString()
                    });

                }

                foreach (var usuario in listaDeUsuario)
                {
                    var LogonSuperior = usuario.Superior.Split(' ')[0];
                    var logonSubordinado = usuario.Fantasia.Split(' ')[0];
                    if (VerificaPossuiLogon(listaDeUsuarioAgrupada, LogonSuperior)){
                        LogonSuperior += '1';
                        if (VerificaPossuiLogon(listaDeUsuarioAgrupada, LogonSuperior))
                        {
                            LogonSuperior += '2';
                            if (VerificaPossuiLogon(listaDeUsuarioAgrupada, LogonSuperior))
                            {
                                LogonSuperior += '3';
                                if (VerificaPossuiLogon(listaDeUsuarioAgrupada, LogonSuperior))
                                {
                                    LogonSuperior += '4';
                                }
                            }
                        }
                        
                    }
                    
                    if (VerificaPossuiLogon(listaDeUsuarioAgrupada, logonSubordinado) || LogonSuperior == logonSubordinado)
                    {
                        logonSubordinado += '1';
                        if (VerificaPossuiLogon(listaDeUsuarioAgrupada, logonSubordinado) || LogonSuperior == logonSubordinado)
                        {
                            logonSubordinado += '2';
                            if (VerificaPossuiLogon(listaDeUsuarioAgrupada, logonSubordinado) || LogonSuperior == logonSubordinado)
                            {
                                logonSubordinado += '3';
                                if (VerificaPossuiLogon(listaDeUsuarioAgrupada, logonSubordinado) || LogonSuperior == logonSubordinado)
                                {
                                    logonSubordinado += '4';
                                }
                            }
                        }

                    }

                    var usuarioCadastro = new Usuarios(
                            usuario.CodigoSuperior,
                            usuario.Superior,
                            LogonSuperior,
                            new List<Usuarios>()
                        );
                    var usuarioSubordinado = new Usuarios(
                            usuario.CodigoRepres,
                            usuario.Fantasia,
                            logonSubordinado,
                            new List<Usuarios>()
                        );
                    AdicionaUsuario(listaDeUsuarioAgrupada, usuarioCadastro, usuarioSubordinado);
                }

                return listaDeUsuarioAgrupada;

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro Ao ler arquivo");
                return null;
            }
            finally
            {
                conexao.Close();
            }

        }
        private static bool VerificaPossuiUsuario(List<Usuarios> usuariosList, int codUsuario)
        {
            foreach (var usuario in usuariosList)
            {
                if (usuario.Codigo == codUsuario)
                {
                    return true;
                }

                else
                {
                    if (VerificaPossuiUsuario(usuario.UsuariosSubordinados, codUsuario))
                        return true;
                }
            }
            return false;
        }
        private static bool VerificaPossuiLogon(List<Usuarios> usuariosList, string logon)
        {
            foreach (var usuario in usuariosList)
            {
                if (usuario.Logon == logon)
                {
                    return true;
                }

                else
                {
                    if (VerificaPossuiLogon(usuario.UsuariosSubordinados, logon))
                        return true;
                }
            }
            return false;
        }
        private static List<Usuarios> AdicionaUsuarioExistente(List<Usuarios> usuariosList, Usuarios usuarioCadastro, Usuarios usuarioSubordinado)
        {
            foreach (var usuario in usuariosList)
            {
                if (usuario.Codigo == usuarioCadastro.Codigo)
                {
                    usuario.UsuariosSubordinados.Add(usuarioSubordinado);
                    return usuariosList;
                }
                else
                {
                    AdicionaUsuarioExistente(usuario.UsuariosSubordinados, usuarioCadastro, usuarioSubordinado);
                }
            }
            return usuariosList;
        }
        private static List<Usuarios> AdicionaUsuario(List<Usuarios> usuariosList, Usuarios usuarioCadastro, Usuarios usuarioSubordinado)
        {
            if (!VerificaPossuiUsuario(usuariosList, usuarioCadastro.Codigo))
            {
                if (!VerificaPossuiUsuario(usuariosList, usuarioSubordinado.Codigo))
                {
                    //superior e subordinado não existe
                    usuariosList.Add(usuarioCadastro);
                    usuariosList.Last().UsuariosSubordinados.Add(usuarioSubordinado);
                }
                else
                {
                    //superior não existe e subordinado existe
                    for (var i = 0; i < usuariosList.Count(); i++)
                    {
                        if (usuariosList[i].Codigo == usuarioSubordinado.Codigo)
                        {
                            usuariosList.Add(usuarioCadastro);
                            usuariosList.Last().UsuariosSubordinados.Add(usuariosList[i]);
                            usuariosList.RemoveAt(i);
                            break;
                        }
                    }
                    //usuariosList.Add(usuarioCadastro);
                    //usuariosList.Last().UsuariosSubordinados.Add(usuarioSubordinado);
                }
            }
            else if (VerificaPossuiUsuario(usuariosList, usuarioCadastro.Codigo))
            {
                if (!VerificaPossuiUsuario(usuariosList, usuarioSubordinado.Codigo))
                {
                    //superior existe e subordinado não
                    //usuariosList.Last().UsuariosSubordinados.Add(usuarioSubordinado);
                    AdicionaUsuarioExistente(usuariosList, usuarioCadastro, usuarioSubordinado);
                }
                else
                {
                    for (var i = 0; i < usuariosList.Count(); i++)
                    {
                        if (usuariosList[i].Codigo == usuarioSubordinado.Codigo)
                        {
                            usuarioCadastro.UsuariosSubordinados.Add(usuariosList[i]);
                            usuariosList.RemoveAt(i);
                            AdicionaUsuarioExistente(usuariosList, usuarioCadastro, usuarioCadastro.UsuariosSubordinados[0]);
                            break;
                        }
                    }
                }


            }

            return usuariosList;
        }
        private static void Cadastrar(List<Usuarios> usuariosList, string idSuperior)
        {
            foreach (var usuario in usuariosList)
            {

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://192.168.7.35:13001/usuario");
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.Headers.Add("Postman-Token", "6ec704c0-629e-5cc8-4495-45e98deed35a");
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.Headers.Add("Authentication", "f0abfba972fb3b33be858c9b472f99005998baa28cae85704e1dd27456e263b4e160eff8e92c449087a764afdb1d37529147b5069ac60cb0b301381584ccd47dd2a90572e71f544cac04b6525a5065f356cd8650f340410d4615331567a4d8cd3b0d84988fc1a61dba5c625960fc349fc8ba9e0c55c44cfeb1fbf8959492332784641bfe21bfcdb4111a");

                    var teste = $"{{\n        \"idSuperior\": " + (!string.IsNullOrEmpty(idSuperior) ? $"\"{idSuperior}\"" : "null") + $",\n        \"idGrupo\": null,\n        \"idEmpresa\": null,\n        \"nome\":\"{usuario.Nome}\",\n        \"logon\":\"{usuario.Logon}\",\n        \"quantidadeDiasExpiraSenha\": null,\n        \"dataExpiracao\": \"2016-12-22T00:00:00.000Z\",\n        \"restringeIp\": false,\n        \"bloqueado\": false,\n        \"dataBloqueio\": null,\n        \"nomeUsuarioBloqueio\": null,\n        \"dataCadastroBloqueio\": null,\n        \"dataDesbloqueio\": null,\n        \"nomeUsuarioDesbloqueio\": null,\n        \"dataCadastroDesbloqueio\": null,\n        \"telefones\": [],\n        \"emails\": [],\n        \"opcoes\": [],\n        \"nomeUsuarioCadastro\": \"Usuário Teste\",\n        \"dataCadastro\": \"2017-12-18T14:37:24.541Z\",\n        \"nomeUsuarioAlteracao\": \"Usuário Teste\",\n        \"dataAlteracao\": \"2017-08-17T15:31:19.776Z\",\n        \"cor\": \"#FBC02D\",\n        \"acessoDiaHora\": [],\n        \"personalizacao\": {{\n        \"cargo\": \"Representante\",\n     \"idCargo\":\"5a1565bd104a67868b0bd21f\",\n        \"usuarioAquarius\":{{\"id\":\"{usuario.Codigo.ToString().PadLeft(6, '0')}\",\n    \"nome\":\"{usuario.Nome}\"       }},\n     \"verTodos\":false }}\n    }}";

                    string postData = teste;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = byteArray.Length;
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                    Console.WriteLine($"{usuario.Codigo} {usuario.Nome} {usuario.Logon}");
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    Console.WriteLine(responseFromServer);
                    var resposta = JsonParser.Deserialize(responseFromServer);
                    var returnIdSuperior = resposta.content.id;
                    // response.ContentLength;
                    reader.Close();
                    dataStream.Close();
                    response.Close();

                    Cadastrar(usuario.UsuariosSubordinados, returnIdSuperior);
                }
                catch (WebException ex)
                {
                    Console.WriteLine($"\nException: {ex.Message} \nUser: {usuario.Codigo}");
                }
            }
        }
    }
}