using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestePráticoT2S.BLL;
using TestePráticoT2S.DAOs;

namespace TestePráticoT2S
{
    public partial class Default : System.Web.UI.Page
    {
        private string id;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region Botões Principais
        protected void btnCrudContainer_Click(object sender, EventArgs e)
        {
            btnCrudContainer.Enabled = false;
            btnCrudMovimentacao.Enabled = true;
            btnRelatorio.Enabled = true;
            gdvRelatorio.Visible = false;
            gdvSoma.Visible = false;
            gdvSoma2.Visible = false;
            gdvContainer.Visible = false;
            lblInfRelatorio.Visible = false;
            pnlMenuPrincipal.Style.Value = "display: none;";
            pnlPainelContainer.Style.Value = "display: inline;";
            pnlPainelMovimentacao.Style.Value = "display: none;";
            pnlInformacoes.Style.Value = "display: none;";
            pnlRelatorio.Style.Value = "display: none;";
            txtContainer.Text = "";
        }
        protected void btnCrudMovimentacao_Click(object sender, EventArgs e)
        {
            btnCrudContainer.Enabled = true;
            btnCrudMovimentacao.Enabled = false;
            btnRelatorio.Enabled = true;
            gdvRelatorio.Visible = false;
            gdvSoma.Visible = false;
            gdvSoma2.Visible = false;
            gdvContainer.Visible = false;
            lblInfRelatorio.Visible = false;
            pnlMenuPrincipal.Style.Value = "display: none;";
            pnlPainelContainer.Style.Value = "display: none;";
            pnlPainelMovimentacao.Style.Value = "display: inline;";
            pnlInformacoes.Style.Value = "display: none;";
            pnlRelatorio.Style.Value = "display: none;";
        }
        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            btnCrudContainer.Enabled = true;
            btnCrudMovimentacao.Enabled = true;
            btnRelatorio.Enabled = false;
            btnRelatorioContainer.Enabled = true;
            btnRelatorioMovimentacao.Enabled = true;
            lblInfRelatorio.Visible = true;
            pnlMenuPrincipal.Style.Value = "display: inline;";
            pnlPainelContainer.Style.Value = "display: none;";
            pnlPainelMovimentacao.Style.Value = "display: none;";
            pnlInformacoes.Style.Value = "display: none;";
            pnlRelatorio.Style.Value = "display: inline;";
        }

            #region Relatórios de Container e Movimentação
        protected void btnRelatorioContainer_Click(object sender, EventArgs e)
        {
            btnRelatorioContainer.Enabled = false;
            btnRelatorioMovimentacao.Enabled = true;
            gdvContainer.Visible = true;
            gdvRelatorio.Visible = false;
            gdvSoma.Visible = false;
            gdvSoma2.Visible = false;
            gdvContainer.DataSource = null;
            gdvContainer.DataBind();
            Operacoes operador = new Operacoes();
            gdvContainer.DataSource = operador.RelatorioContainer();
            gdvContainer.DataBind();
        }
        protected void btnRelatorioMovimentacao_Click(object sender, EventArgs e)
        {
            btnRelatorioContainer.Enabled = true;
            btnRelatorioMovimentacao.Enabled = false;
            gdvRelatorio.Visible = true;
            gdvSoma.Visible = true;
            gdvSoma2.Visible = true;
            gdvContainer.Visible = false;
            gdvRelatorio.DataSource = null;
            gdvRelatorio.DataBind();
            gdvSoma.DataSource = null;
            gdvSoma.DataBind();
            gdvSoma2.DataSource = null;
            gdvSoma2.DataBind();
            Operacoes operador = new Operacoes();
            gdvRelatorio.DataSource = operador.Relatorio();
            gdvRelatorio.DataBind();
            gdvSoma.DataSource = operador.RelatorioSoma();
            gdvSoma.DataBind();
            gdvSoma2.DataSource = operador.RelatorioSoma2();
            gdvSoma2.DataBind();
        }
        #endregion

        #endregion
        #region Botões CRUD Container
        protected void btnContainerCadastrar_Click(object sender, EventArgs e)
        {
            btnContainerCadastrar.Enabled = false;
            btnContainerConsultar.Enabled = true;
            btnContainerAtualizar.Enabled = true;
            btnContainerDeletar.Enabled = true;
            lblNome.Visible = true;
            lblNome.Text = "<h3>Informe o nome do cliente:</h3>";
            txtNome.Visible = true;
            lblContainer.Text = "<h3>Informe o código do container:</h3>";
            txtContainer.Visible = true;
            lblTipo.Visible = true;
            lblTipo.Text = "<h3>Informe o tipo do container:</h3>";
            rdbTipo1.Visible = true;
            rdbTipo2.Visible = true;
            lblStatus.Visible = true;
            lblStatus.Text = "<h3>Informe o status do conatiner:</h3>";
            rdbStatus1.Visible = true;
            rdbStatus2.Visible = true;
            lblCategoria.Visible = true;
            lblCategoria.Text = "<h3>Informe a categoria do container:</h3>";
            rdbCategoria1.Visible = true;
            rdbCategoria2.Visible = true;
            btnEnviar.Visible = true;
            gdvConsultar.Visible = false;
            lblAviso.Visible = true;
            lblAviso.Text = " ";
            pnlInformacoes.Style.Value = "display: inline;";
            txtNome.Text = "";
            txtHoraInicial.Text = "00:00";
            txtHoraFinal.Text = "00:00";
            txtDataInicial.Text = "0001-01-01";
            txtDataFinal.Text = "0001-01-01";
            txtContainer.Text = "";
            txtContainerMovimentacao.Text = "";
        }
        protected void btnContainerConsultar_Click(object sender, EventArgs e)
        {
            btnContainerCadastrar.Enabled = true;
            btnContainerConsultar.Enabled = false;
            btnContainerAtualizar.Enabled = true;
            btnContainerDeletar.Enabled = true;
            lblNome.Visible = false;
            txtNome.Visible = false;
            lblContainer.Text = "<h3>Informe o código do container:</h3>";
            txtContainer.Visible = true;
            lblTipo.Visible = false;
            rdbTipo1.Visible = false;
            rdbTipo2.Visible = false;
            lblStatus.Visible = false;
            rdbStatus1.Visible = false;
            rdbStatus2.Visible = false;
            lblCategoria.Visible = false;
            rdbCategoria1.Visible = false;
            rdbCategoria2.Visible = false;
            btnEnviar.Visible = true;
            gdvConsultar.Visible = true;
            lblAviso.Visible = true;
            lblAviso.Text = " ";
            pnlInformacoes.Style.Value = "display: inline;";
            txtNome.Text = "-";
            txtHoraInicial.Text = "00:00";
            txtHoraFinal.Text = "00:00";
            txtDataInicial.Text = "0001-01-01";
            txtDataFinal.Text = "0001-01-01";
            txtContainer.Text = "";
            txtContainerMovimentacao.Text = "";
            gdvConsultar.DataSource = null;
            gdvConsultar.DataBind();
        }
        protected void btnContainerAtualizar_Click(object sender, EventArgs e)
        {
            btnContainerCadastrar.Enabled = true;
            btnContainerConsultar.Enabled = true;
            btnContainerAtualizar.Enabled = false;
            btnContainerDeletar.Enabled = true;
            lblNome.Visible = true;
            lblNome.Text = "<h3>Informe o nome do cliente:</h3>";
            txtNome.Visible = true;
            lblContainer.Text = "<h3>Informe o código do container:</h3>";
            txtContainer.Visible = true;
            lblTipo.Visible = true;
            lblTipo.Text = "<h3>Informe o tipo do container:</h3>";
            rdbTipo1.Visible = true;
            rdbTipo2.Visible = true;
            lblStatus.Visible = true;
            lblStatus.Text = "<h3>Informe o status do conatiner:</h3>";
            rdbStatus1.Visible = true;
            rdbStatus2.Visible = true;
            lblCategoria.Visible = true;
            lblCategoria.Text = "<h3>Informe a categoria do container:</h3>";
            rdbCategoria1.Visible = true;
            rdbCategoria2.Visible = true;
            btnEnviar.Visible = true;
            gdvConsultar.Visible = false;
            lblAviso.Visible = true;
            lblAviso.Text = " ";
            pnlInformacoes.Style.Value = "display: inline;";
            txtNome.Text = "";
            txtHoraInicial.Text = "00:00";
            txtHoraFinal.Text = "00:00";
            txtDataInicial.Text = "0001-01-01";
            txtDataFinal.Text = "0001-01-01";
            txtContainer.Text = "";
            txtContainerMovimentacao.Text = "";
        }
        protected void btnContainerDeletar_Click(object sender, EventArgs e)
        {
            btnContainerCadastrar.Enabled = true;
            btnContainerConsultar.Enabled = true;
            btnContainerAtualizar.Enabled = true;
            btnContainerDeletar.Enabled = false;
            lblNome.Visible = false;
            txtNome.Visible = false;
            lblContainer.Text = "<h3>Informe o código do container:</h3>";
            txtContainer.Visible = true;
            lblTipo.Visible = false;
            rdbTipo1.Visible = false;
            rdbTipo2.Visible = false;
            lblStatus.Visible = false;
            rdbStatus1.Visible = false;
            rdbStatus2.Visible = false;
            lblCategoria.Visible = false;
            rdbCategoria1.Visible = false;
            rdbCategoria2.Visible = false;
            btnEnviar.Visible = true;
            gdvConsultar.Visible = false;
            lblAviso.Visible = true;
            lblAviso.Text = " ";
            pnlInformacoes.Style.Value = "display: inline;";
            txtNome.Text = "-";
            txtHoraInicial.Text = "00:00";
            txtHoraFinal.Text = "00:00";
            txtDataInicial.Text = "0001-01-01";
            txtDataFinal.Text = "0001-01-01";
            txtContainer.Text = "";
            txtContainerMovimentacao.Text = "";
        }
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            btnCrudContainer.Enabled = true;
            btnCrudMovimentacao.Enabled = true;
            btnRelatorio.Enabled = true;
            btnContainerCadastrar.Enabled = true;
            btnContainerConsultar.Enabled = true;
            btnContainerAtualizar.Enabled = true;
            btnContainerDeletar.Enabled = true;
            lblAviso.Visible = false;
            btnEnviar.Visible = false;
            lblAviso.Visible = false;
            lblAviso.Text = " ";
            pnlMenuPrincipal.Style.Value = "display: inline;";
            pnlPainelContainer.Style.Value = "display: none;";
            pnlInformacoes.Style.Value = "display: none;";
        }
        #endregion
        #region Botões CRUD Movimentação
        protected void btnMovimentacaoCadastrar_Click(object sender, EventArgs e)
        {
            btnMovimentacaoCadastrar.Enabled = false;
            btnMovimentacaoConsultar.Enabled = true;
            btnMovimentacaoAtualizar.Enabled = true;
            btnMovimentacaoDeletar.Enabled = true;
            lblContainerMovimentacao.Visible = true;
            txtContainerMovimentacao.Visible = true;
            txtIdMovimentacao.Visible = false;
            lblTipoMovimentacao.Visible = true;
            rdbTipoMovimentacao1.Visible = true;
            rdbTipoMovimentacao2.Visible = true;
            rdbTipoMovimentacao3.Visible = true;
            rdbTipoMovimentacao4.Visible = true;
            rdbTipoMovimentacao5.Visible = true;
            rdbTipoMovimentacao6.Visible = true;
            rdbTipoMovimentacao7.Visible = true;
            lblDataHoraInicial.Visible = true;
            lblDataHoraFinal.Visible = true;
            txtDataInicial.Visible = true;
            txtHoraInicial.Visible = true;
            txtDataFinal.Visible = true;
            txtHoraFinal.Visible = true;
            btnEnviar.Visible = true;
            gdvConsultarMov.Visible = false;
            lblAviso.Visible = true;
            lblAviso.Text = " ";
            lblContainerMovimentacao.Text = "<h3>Informe o código do Container:</h3>";
            lblAlertMov1.Text = "<h5>Lembrando que o código do Container deve ser constituído por 4 LETRAS e 7 NUMEROS.</h5>";
            lblAlertMov2.Text = "<h6>Exemplo: ABCD1234567</h6>";
            pnlInformacoesMov.Style.Value = "display: inline;";
            txtNome.Text = "-";
            txtHoraInicial.Text = "";
            txtHoraFinal.Text = "";
            txtDataInicial.Text = "";
            txtDataFinal.Text = "";
            txtContainer.Text = "";
            txtContainerMovimentacao.Text = "";
            txtContainer.Text = "";
        }
        protected void btnMovimentacaoConsultar_Click(object sender, EventArgs e)
        {
            btnMovimentacaoCadastrar.Enabled = true;
            btnMovimentacaoConsultar.Enabled = false;
            btnMovimentacaoAtualizar.Enabled = true;
            btnMovimentacaoDeletar.Enabled = true;
            lblContainerMovimentacao.Visible = true;
            txtContainerMovimentacao.Visible = true;
            txtIdMovimentacao.Visible = false;
            lblTipoMovimentacao.Visible = false;
            rdbTipoMovimentacao1.Visible = false;
            rdbTipoMovimentacao2.Visible = false;
            rdbTipoMovimentacao3.Visible = false;
            rdbTipoMovimentacao4.Visible = false;
            rdbTipoMovimentacao5.Visible = false;
            rdbTipoMovimentacao6.Visible = false;
            rdbTipoMovimentacao7.Visible = false;
            lblDataHoraInicial.Visible = false;
            lblDataHoraFinal.Visible = false;
            txtDataInicial.Visible = false;
            txtHoraInicial.Visible = false;
            txtDataFinal.Visible = false;
            txtHoraFinal.Visible = false;
            btnEnviar.Visible = true;
            gdvConsultarMov.Visible = true;
            lblAviso.Visible = true;
            lblAviso.Text = " ";
            lblContainerMovimentacao.Text = "<h3>Informe o código do Container:</h3>";
            lblAlertMov1.Text = "<h5>Lembrando que o código do Container deve ser constituído por 4 LETRAS e 7 NUMEROS.</h5>";
            lblAlertMov2.Text = "<h6>Exemplo: ABCD1234567</h6>";
            pnlInformacoesMov.Style.Value = "display: inline;";
            txtNome.Text = "-";
            txtHoraInicial.Text = "00:00";
            txtHoraFinal.Text = "00:00";
            txtDataInicial.Text = "0001-01-01";
            txtDataFinal.Text = "0001-01-01";
            txtContainer.Text = "";
            txtContainerMovimentacao.Text = "";
            txtContainer.Text = "";
            gdvConsultarMov.DataSource = null;
            gdvConsultarMov.DataBind();
        }
        protected void btnMovimentacaoAtualizar_Click(object sender, EventArgs e)
        {
            btnMovimentacaoCadastrar.Enabled = true;
            btnMovimentacaoConsultar.Enabled = true;
            btnMovimentacaoAtualizar.Enabled = false;
            btnMovimentacaoDeletar.Enabled = true;
            lblContainerMovimentacao.Visible = true;
            lblContainerMovimentacao.Text = "<h3>Informe o ID da movimentação:</h3>";
            lblAlertMov1.Text = "<h5>O ID da movimentação pode ser encontrando na Consulta da Movimentação.</h5>";
            lblAlertMov2.Text = " ";
            txtContainerMovimentacao.Visible = false;
            txtIdMovimentacao.Visible = true;
            lblTipoMovimentacao.Visible = true;
            rdbTipoMovimentacao1.Visible = true;
            rdbTipoMovimentacao2.Visible = true;
            rdbTipoMovimentacao3.Visible = true;
            rdbTipoMovimentacao4.Visible = true;
            rdbTipoMovimentacao5.Visible = true;
            rdbTipoMovimentacao6.Visible = true;
            rdbTipoMovimentacao7.Visible = true;
            lblDataHoraInicial.Visible = true;
            lblDataHoraFinal.Visible = true;
            txtDataInicial.Visible = true;
            txtHoraInicial.Visible = true;
            txtDataFinal.Visible = true;
            txtHoraFinal.Visible = true;
            btnEnviar.Visible = true;
            gdvConsultarMov.Visible = false;
            lblAviso.Visible = true;
            lblAviso.Text = " ";
            pnlInformacoesMov.Style.Value = "display: inline;";
            txtNome.Text = "-";
            txtHoraInicial.Text = "";
            txtHoraFinal.Text = "";
            txtDataInicial.Text = "";
            txtDataFinal.Text = "";
            txtContainer.Text = "";
            txtContainerMovimentacao.Text = "";
            txtContainer.Text = "ABCD1234567";
        }
        protected void btnMovimentacaoDeletar_Click(object sender, EventArgs e)
        {
            btnMovimentacaoCadastrar.Enabled = true;
            btnMovimentacaoConsultar.Enabled = true;
            btnMovimentacaoAtualizar.Enabled = true;
            btnMovimentacaoDeletar.Enabled = false;
            lblContainerMovimentacao.Visible = true;
            txtContainerMovimentacao.Visible = false;
            txtIdMovimentacao.Visible = true;
            lblTipoMovimentacao.Visible = false;
            rdbTipoMovimentacao1.Visible = false;
            rdbTipoMovimentacao2.Visible = false;
            rdbTipoMovimentacao3.Visible = false;
            rdbTipoMovimentacao4.Visible = false;
            rdbTipoMovimentacao5.Visible = false;
            rdbTipoMovimentacao6.Visible = false;
            rdbTipoMovimentacao7.Visible = false;
            lblDataHoraInicial.Visible = false;
            lblDataHoraFinal.Visible = false;
            txtDataInicial.Visible = false;
            txtHoraInicial.Visible = false;
            txtDataFinal.Visible = false;
            txtHoraFinal.Visible = false;
            btnEnviar.Visible = true;
            gdvConsultarMov.Visible = false;
            lblAviso.Visible = true;
            lblAviso.Text = " ";
            lblContainerMovimentacao.Text = "<h3>Informe o ID da movimentação:</h3>";
            lblAlertMov1.Text = "<h5>O ID da movimentação pode ser encontrando na Consulta da Movimentação.</h5>";
            lblAlertMov2.Text = " ";
            pnlInformacoesMov.Style.Value = "display: inline;";
            txtNome.Text = "-";
            txtHoraInicial.Text = "00:00";
            txtHoraFinal.Text = "00:00";
            txtDataInicial.Text = "0001-01-01";
            txtDataFinal.Text = "0001-01-01";
            txtContainer.Text = "";
            txtContainerMovimentacao.Text = "";
            txtContainer.Text = "ABCD1234567";
        }
        protected void btnMovimentacaoVoltar_Click(object sender, EventArgs e)
        {
            btnCrudContainer.Enabled = true;
            btnCrudMovimentacao.Enabled = true;
            btnRelatorio.Enabled = true;
            btnMovimentacaoCadastrar.Enabled = true;
            btnMovimentacaoConsultar.Enabled = true;
            btnMovimentacaoAtualizar.Enabled = true;
            btnMovimentacaoDeletar.Enabled = true;
            btnEnviar.Visible = false;
            lblAviso.Visible = false;
            lblAviso.Text = " ";
            pnlMenuPrincipal.Style.Value = "display: inline;";
            pnlPainelMovimentacao.Style.Value = "display: none;";
            pnlInformacoesMov.Style.Value = "display: none;";
        }
        #endregion
        #region Botão Enviar
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            #region Validações + Enviar Dados
            char[] array = txtContainer.Text.ToCharArray();
            bool val = true;
            if (txtNome.Text == "")
            {
                val = false;
                lblAviso.Text = "<div class='alert alert-danger'><h3>É PRECISO PREENCHER O NOME DO CLIENTE!</h3></div>";
            }
            Regex regex = new Regex(@"^[a-zA-Z]{4}\d{7}$");
            if (regex.IsMatch(txtContainer.Text) || regex.IsMatch(txtContainerMovimentacao.Text))
            {
                lblAviso.Visible = false;
                val = true;
            }
            else
            {
                val = false;
                lblAviso.Visible = true;
                lblAviso.Text = "<div class='alert alert-danger'><h3>Preenchimento inválido! VERIFIQUE.</h3></div>";
                gdvConsultar.DataSource = null;
                gdvConsultar.DataBind();
                gdvConsultarMov.DataSource = null;
                gdvConsultarMov.DataBind();
            }
            if (string.IsNullOrEmpty(txtDataInicial.Text) || string.IsNullOrEmpty(txtDataFinal.Text) || string.IsNullOrEmpty(txtHoraInicial.Text) || string.IsNullOrEmpty(txtHoraFinal.Text))
            {
                val = false;
                lblAviso.Visible = true;
                lblAviso.Text = "<div class='alert alert-danger'><h3>Preenchimento inválido! VERIFIQUE.</h3></div>";
            }
            else if (Convert.ToDateTime(txtDataInicial.Text) > Convert.ToDateTime(txtDataFinal.Text))
            {
                val = false;
                lblAviso.Visible = true;
                lblAviso.Text = "<div class='alert alert-danger'><h3>Data Inicial não pode ser maior que a data final.</h3></div>";
            }
            if (val)
            {
                #region Container Enviar Info
                lblAviso.Visible = true;
                Operacoes operador = new Operacoes();
                string nome = txtNome.Text;
                string container = txtContainer.Text;
                string tipo = rdbTipo1.Checked ? "20" : "40";
                string status = rdbStatus1.Checked ? "Cheio" : "Vazio";
                string categoria = rdbCategoria1.Checked ? "Import" : "Export";
                if (btnContainerCadastrar.Enabled == false)
                {
                    lblAviso.Text = operador.CadastrarOperacao(nome, container, tipo, status, categoria);
                }
                else if (btnContainerConsultar.Enabled == false)
                {
                    gdvConsultar.DataSource = operador.ConsultarContainer(container);
                    gdvConsultar.DataBind();
                }
                else if (btnContainerAtualizar.Enabled == false)
                {
                    lblAviso.Text = operador.AtualizarOperacao(nome, container, tipo, status, categoria);
                }
                else if (btnContainerDeletar.Enabled == false)
                {
                    lblAviso.Text = operador.DeletarOperacao(container);
                }
                #endregion
                #region Movimentação Enviar Info
                lblAviso.Visible = true;
                Operacoes operadorMov = new Operacoes();                
                container = txtContainerMovimentacao.Text;
                string id = txtIdMovimentacao.Text;
                string tipoMov = null;
                if (rdbTipoMovimentacao1.Checked) tipoMov = "Embarque";
                else if (rdbTipoMovimentacao2.Checked) tipoMov = "Descarga";
                else if (rdbTipoMovimentacao3.Checked) tipoMov = "Gate In";
                else if (rdbTipoMovimentacao4.Checked) tipoMov = "Gate Out";
                else if (rdbTipoMovimentacao5.Checked) tipoMov = "Posicionamento Pilha";
                else if (rdbTipoMovimentacao6.Checked) tipoMov = "Pesagem";
                else if (rdbTipoMovimentacao7.Checked) tipoMov = "Scanner";
                string dataInicial = txtDataInicial.Text;
                string horaInicial = txtHoraInicial.Text;
                string dataFinal = txtDataFinal.Text;
                string horaFinal = txtHoraFinal.Text;
                if (btnMovimentacaoCadastrar.Enabled == false)
                {
                    lblAviso.Text = operadorMov.CadastrarOperacaoMov(container, tipoMov, dataInicial, horaInicial, dataFinal, horaFinal);
                }
                else if (btnMovimentacaoConsultar.Enabled == false)
                {
                    gdvConsultarMov.DataSource = operadorMov.ConsultarContainerMov(container);
                    gdvConsultarMov.DataBind();
                }
                else if (btnMovimentacaoAtualizar.Enabled == false)
                {
                    lblAviso.Text = operadorMov.AtualizarOperacaoMov(id, tipoMov, dataInicial, horaInicial, dataFinal, horaFinal);
                }
                else if (btnMovimentacaoDeletar.Enabled == false)
                {
                    lblAviso.Text = operadorMov.DeletarOperacaoMov(id);
                }
                #endregion
            }
            #endregion
        }
        #endregion
    }
}