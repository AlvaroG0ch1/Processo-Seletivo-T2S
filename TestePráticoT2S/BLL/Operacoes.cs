using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestePráticoT2S.DAOs;
using System.Data;

namespace TestePráticoT2S.BLL
{
    public class Operacoes
    {
        BancoDAO banco = new BancoDAO();
        #region CRUD Container
        public string CadastrarOperacao(string nome, string container, string tipo, string status, string categoria)
        {
            DataTable verificador = banco.PesquisarContainer($"SELECT * FROM Crud_Container WHERE CtNumero = '{container}'");
            if (verificador.Rows.Count == 0)
            {
                var query = banco.OperacaoBanco($@"INSERT INTO Crud_container
                                                    (CtCliente, CtNumero, CtTipo, CtStatus, CtCategoria) 
                                             VALUES ('{nome}', '{container}', '{tipo}', '{status}', '{categoria}')");
                return query;
            }
            else
            {
                var erroCadastrado = "<br/><div class='alert alert-danger'><h3>ERRO: ESTES DADOS JÁ ESTÃO CADASTRADOS!</h3></div>";
                return erroCadastrado;
            }
        }
        public string DeletarOperacao(string container)
        {
            DataTable verificador = banco.PesquisarContainer($"SELECT * FROM Crud_Container WHERE CtNumero = '{container}'");
            if (verificador.Rows.Count == 1)
            {
                var query = banco.OperacaoBanco($@"DELETE FROM Crud_container
                                                    WHERE CtNumero = '{container}'");
                return query;
            }
            else
            {
                var erroCadastrado = "<br /><div class='alert alert-danger'><h3>ERRO: ESTE DADO NÃO FOI ENCONTRADO</h3></div>";
                return erroCadastrado;
            }
        }
        public DataTable ConsultarContainer(string container)
        {
            DataTable consulta = banco.PesquisarContainer($"SELECT * FROM Crud_Container WHERE CtNumero = '{container}'");
            if (consulta.Rows.Count == 1)
            {
                return consulta;
            }
            else
            {
                DataTable erro = new DataTable();
                erro.Columns.Add("ERRO!", typeof(String));
                erro.Rows.Add("ESSE CONTAINER NÃO FOI ENCONTRADO");
                return erro;
            }
        }
        public string AtualizarOperacao(string nome, string container, string tipo, string status, string categoria)
        {
            DataTable verificador = banco.PesquisarContainer($"SELECT * FROM Crud_Container WHERE CtNumero = '{container}'");
            if (verificador.Rows.Count == 1)
            {
                var query = banco.OperacaoBanco($@"UPDATE Crud_container SET
                                                    CtCliente = '{nome}', CtTipo = '{tipo}', CtStatus = '{status}', CtCategoria = '{categoria}' 
                                             WHERE CtNumero = '{container}'");
                return query;
            }
            else
            {
                var erroCadastrado = "<br /><div class='alert alert-danger'><h3>ERRO: ESTES DADOS NÃO FORAM ENCONTRADOS</h3></div>";
                return erroCadastrado;
            }
        }
        #endregion
        #region CRUD Movimentação
        public string CadastrarOperacaoMov(string codigo, string TipoMov, string DataInicial, string HoraInicial, string DataFinal, string HoraFinal)
        {
            DataTable verificador = banco.PesquisarContainer($"SELECT * FROM Crud_Container WHERE CtNumero = '{codigo}'");
            if (verificador.Rows.Count == 1)
            {
                var query = banco.OperacaoBanco($@"INSERT INTO Crud_Movimentacao
                                                    (MovNumero, MovTipo, MovDataInicial, MovHoraInicial, MovDataFinal, MovHoraFinal) 
                                             VALUES ('{codigo}', '{TipoMov}', '{DataInicial}', '{HoraInicial}', '{DataFinal}', '{HoraFinal}')");
                return query;
            }
            else
            {
                var erroCadastrado = "<br/><div class='alert alert-danger'><h3>ERRO: ESTE CONTAINER NÃO EXISTE!</h3></div>";
                return erroCadastrado;
            }
        }
        public string DeletarOperacaoMov(string codigo)
        {
            DataTable verificador = banco.PesquisarContainerMov($"SELECT * FROM Crud_Movimentacao WHERE MovId = '{codigo}'");
            if (verificador.Rows.Count == 1)
            {
                var query = banco.OperacaoBanco($@"DELETE FROM Crud_Movimentacao
                                                    WHERE MovId = '{codigo}'");
                return query;
            }
            else
            {
                var erroCadastrado = "<br/><div class='alert alert-danger'><h3>ERRO: ESTA MOVIMENTAÇÃO NÃO FOI ENCONTRADA</h3></div>";
                return erroCadastrado;
            }
        }
        public DataTable ConsultarContainerMov(string codigo)
        {
            DataTable consulta = banco.PesquisarContainerMov($"SELECT * FROM Crud_Movimentacao WHERE MovNumero = '{codigo}'");
            if (consulta.Rows.Count > 0)
            {
                return consulta;
            }
            else
            {
                DataTable erro = new DataTable();
                erro.Columns.Add("ERRO!", typeof(String));
                erro.Rows.Add("ESSA MOVIMENTAÇÃO NÃO FOI ENCONTRADA");
                return erro;
            }
        }
        public string AtualizarOperacaoMov(string codigo, string TipoMov, string DataInicial, string HoraInicial, string DataFinal, string HoraFinal)
        {
            DataTable verificador = banco.PesquisarContainerMov($"SELECT * FROM Crud_Movimentacao WHERE MovId = '{codigo}'");
            if (verificador.Rows.Count == 1)
            {
                var query = banco.OperacaoBanco($@"UPDATE Crud_Movimentacao SET
                                                     MovTipo = '{TipoMov}', MovDataInicial = '{DataInicial}', MovHoraInicial = '{HoraInicial}', MovDataFinal = '{DataFinal}', MovHoraFinal = '{HoraFinal}' 
                                             WHERE MovId = '{codigo}'");
                return query;
            }
            else
            {
                var erroCadastrado = "<br /><div class='alert alert-danger'><h3>ERRO: ESTA MOVIMENTAÇÃO NÃO FOI ENCONTRADA</h3></div>";
                return erroCadastrado;
            }
        }
        #endregion
        #region Relatório
        public DataTable Relatorio()
        {
            DataTable consulta = banco.PesquisarRelatorio($"SELECT c.CtNumero, c.CtCliente, c.CtCategoria, m.MovTipo, CONCAT(m.MovDataInicial,' | ', m.MovHoraInicial) AS \"DataHoraInicial\", CONCAT(m.MovDataFinal, ' | ', m.MovHoraFinal) AS \"DataHoraFinal\"  FROM crud_container c INNER JOIN crud_movimentacao m ON (c.ctNumero = m.MovNumero) ORDER BY c.CtCliente, MovTipo");
            if (consulta.Rows.Count > 0)
            {
                return consulta;
            }
            else
            {
                DataTable erro = new DataTable();
                erro.Columns.Add("ERRO!", typeof(String));
                erro.Rows.Add("NÃO HÁ MOVIMENTAÇÕES CADASTRADAS!");
                return erro;
            }
        }
        #endregion
        #region Relatório Container
        public DataTable RelatorioContainer()
        {
            DataTable consulta = banco.PesquisarRelatorioContainer($"SELECT CtCliente, CtNumero, CtTipo, CtStatus, CtCategoria FROM crud_container ORDER BY CtCliente");
            if (consulta.Rows.Count > 0)
            {
                return consulta;
            }
            else
            {
                DataTable erro = new DataTable();
                erro.Columns.Add("ERRO!", typeof(String));
                erro.Rows.Add("NÃO HÁ CONTAINERS CADASTRADOS!");
                return erro;
            }
        }
        #endregion
        #region Relatório Soma
        public DataTable RelatorioSoma()
        {
            DataTable consulta = banco.PesquisarRelatorioSoma($"select count(c.CtCategoria) from crud_container c inner join crud_movimentacao m on c.ctNumero = m.MovNumero where c.CtCategoria = 'Import';");
            if (consulta.Rows.Count > 0)
            {
                return consulta;
            }
            else
            {
                DataTable erro = new DataTable();
                erro.Columns.Add("ERRO!", typeof(String));
                erro.Rows.Add("NÃO HÁ DADOS!");
                return erro;
            }
        }
        public DataTable RelatorioSoma2()
        {
            DataTable consulta = banco.PesquisarRelatorioSoma2($"select count(c.CtCategoria) from crud_container c inner join crud_movimentacao m on c.ctNumero = m.MovNumero where c.CtCategoria = 'Export'; ");
            if (consulta.Rows.Count > 0)
            {
                return consulta;
            }
            else
            {
                DataTable erro = new DataTable();
                erro.Columns.Add("ERRO!", typeof(String));
                erro.Rows.Add("NÃO HÁ DADOS!");
                return erro;
            }
        }
        #endregion
    }
}