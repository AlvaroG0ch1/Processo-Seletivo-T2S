using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TestePráticoT2S.DAOs
{
    public class BancoDAO
    {
        MySqlCommand comando;
        MySqlConnection conexao;
        MySqlDataReader leitor;

        public BancoDAO()
        {
            conexao = new MySqlConnection("Server=localhost;Database=T2S;Uid=root;");
        }
        public string OperacaoBanco(String sql)
        {
            try
            {
                comando = null;
                comando = new MySqlCommand(sql, conexao);
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();
                return "<div class='alert alert-success'><h3>Operação realizada com sucesso!</h3></div>";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #region CRUD Container
        public DataTable PesquisarContainer(String sql)
        {
            DataTable valores = new DataTable();
            valores.Columns.Add("ID", typeof(String));
            valores.Columns.Add("Cliente", typeof(String));
            valores.Columns.Add("Contêiner", typeof(String));
            valores.Columns.Add("Tipo", typeof(String));
            valores.Columns.Add("Status", typeof(String));
            valores.Columns.Add("Categoria", typeof(String));
            try
            {
                comando = null;
                comando = new MySqlCommand(sql, conexao);
                conexao.Open();
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    valores.Rows.Add(leitor["CtId"].ToString(), leitor["CtCliente"].ToString(), leitor["CtNumero"].ToString(), leitor["CtTipo"].ToString(), leitor["CtStatus"].ToString(), leitor["CtCategoria"].ToString() == "Import" ? "Importação" : "Exportação");
                }
                conexao.Close();
                return valores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conexao.Close(); }
        }
        #endregion
        #region CRUD Movimentação
        public DataTable PesquisarContainerMov(String sql)
        {
            DataTable valores = new DataTable();
            valores.Columns.Add("ID", typeof(String));
            valores.Columns.Add("Contêiner", typeof(String));
            valores.Columns.Add("Tipo de Movimentação", typeof(String));
            valores.Columns.Add("Data Inicial", typeof(String));
            valores.Columns.Add("Hora Inicial", typeof(String));
            valores.Columns.Add("Data Final", typeof(String));
            valores.Columns.Add("Hora Final", typeof(String));
            try
            {
                comando = null;
                comando = new MySqlCommand(sql, conexao);
                conexao.Open();
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    valores.Rows.Add(leitor["MovId"].ToString(),leitor["MovNumero"].ToString(), leitor["MovTipo"].ToString(), leitor["MovDataInicial"].ToString(), leitor["MovHoraInicial"].ToString(), leitor["MovDataFinal"].ToString(), leitor["MovHoraFinal"].ToString());
                }
                conexao.Close();
                return valores;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { conexao.Close(); }
        }
        #endregion
        #region Relatório
        public DataTable PesquisarRelatorio(String sql)
        {
            DataTable valores = new DataTable();
            valores.Columns.Add("Contêiner", typeof(String));
            valores.Columns.Add("Cliente", typeof(String));
            valores.Columns.Add("Categoria", typeof(String));
            valores.Columns.Add("Tipo de Movimentação", typeof(String));
            valores.Columns.Add("DataHoraInicial", typeof(String));
            valores.Columns.Add("DataHoraFinal", typeof(String));
            try
            {
                comando = null;
                comando = new MySqlCommand(sql, conexao);
                conexao.Open();
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    valores.Rows.Add(leitor["CtNumero"].ToString(), leitor["CtCliente"].ToString(), leitor["CtCategoria"].ToString() == "Import" ? "Importação" : "Exportação", leitor["MovTipo"].ToString(), leitor["DataHoraInicial"].ToString(), leitor["DataHoraFinal"].ToString());
                }
                conexao.Close();
                return valores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conexao.Close(); }
        }
        #endregion
        #region Relatório Container
        public DataTable PesquisarRelatorioContainer(String sql)
        {
            DataTable valores = new DataTable();
            valores.Columns.Add("Cliente", typeof(String));
            valores.Columns.Add("Contêiner", typeof(String));
            valores.Columns.Add("Tipo", typeof(String));
            valores.Columns.Add("Status", typeof(String));
            valores.Columns.Add("Categoria", typeof(String));
            try
            {
                comando = null;
                comando = new MySqlCommand(sql, conexao);
                conexao.Open();
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    valores.Rows.Add(leitor["CtCliente"].ToString(), leitor["CtNumero"].ToString(), leitor["CtTipo"].ToString(), leitor["CtStatus"].ToString(), leitor["CtCategoria"].ToString() == "Import" ? "Importação" : "Exportação");
                }
                conexao.Close();
                return valores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conexao.Close(); }
        }
        #endregion
        #region Relatório Soma
        public DataTable PesquisarRelatorioSoma(String sql)
        {
            DataTable valores = new DataTable();
            valores.Columns.Add("Total de Importações", typeof(String));
            try
            {
                comando = null;
                comando = new MySqlCommand(sql, conexao);
                conexao.Open();
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    valores.Rows.Add(leitor["COUNT(c.CtCategoria)"].ToString());
                }
                conexao.Close();
                return valores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conexao.Close(); }
        }
        public DataTable PesquisarRelatorioSoma2(String sql)
        {
            DataTable valores = new DataTable();
            valores.Columns.Add("Total de Exportações", typeof(String));
            try
            {
                comando = null;
                comando = new MySqlCommand(sql, conexao);
                conexao.Open();
                leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    valores.Rows.Add(leitor["COUNT(c.CtCategoria)"].ToString());
                }
                conexao.Close();
                return valores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conexao.Close(); }
        }
        #endregion
    }
}