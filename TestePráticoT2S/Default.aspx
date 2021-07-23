<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestePráticoT2S.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
    <title>Projeto T2S</title>
    <style>
        html,body
        {
            background-color: #0e4247;
        }
        h1
        {
            text-align: center;
        }
        .Menu
        {
            text-align: center;
            margin-bottom: 20px;
        }
        .SubMenu
        {
            text-align: left;
            margin-bottom: 20px;
            font-size: large;
        }
        .principal {
            padding: 3% 5% 5% 5%;
            background-color: #bff0f5;
            margin: 5%;
            border-radius: 10px;
        }
        .rdb {
            margin-right: 10px;
        }
        .menu2{
            margin-bottom: 8px
        }
        #gdvConsultar th, #gdvConsultarMov th, #gdvRelatorio th{
            text-align: center;
            padding: 5px;
        }
        #gdvConsultar td, #gdvConsultarMov td, #gdvRelatorio td{
            padding: 5px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class = "principal">
            <div class="Menu" style="color: #4570ff">
                <asp:Label ID="lblTitle" runat="server"><h1>TESTE PRÁTICO T2S</h1></asp:Label>
                <asp:Panel ID="pnlMenuPrincipal" runat="server" Style="display:inline">
                <asp:Button ID="btnCrudContainer" runat="server" Text="CRUD Container" style="margin-right: 15px" OnClick="btnCrudContainer_Click" class="btn btn-outline-info"/>
                <asp:Button ID="btnCrudMovimentacao" runat="server" Text="CRUD Movimentação" style="margin-right: 15px" OnClick="btnCrudMovimentacao_Click" class="btn btn-outline-info"/>
                <asp:Button ID="btnRelatorio" runat="server" Text="Relatórios" OnClick="btnRelatorio_Click" class="btn btn-outline-info"/>
                </asp:Panel>
            </div>
            <div class="Menu">
                <asp:Panel ID="pnlPainelContainer" runat="server" Style="display:none">
                    <asp:Label ID="lblInf" runat="server" ><h2>Cadastro de Containers:</h2></asp:Label><br/><br/>
                    <asp:Button ID="btnContainerCadastrar" runat="server" Text="Cadastrar Container" OnClick="btnContainerCadastrar_Click" class="btn btn-info"/>
                    <asp:Button ID="btnContainerConsultar" runat="server" Text="Consultar Container" OnClick="btnContainerConsultar_Click" class="btn btn-info"/>
                    <asp:Button ID="btnContainerAtualizar" runat="server" Text="Atualizar Container" OnClick="btnContainerAtualizar_Click" class="btn btn-info"/>
                    <asp:Button ID="btnContainerDeletar" runat="server" Text="Deletar Container" OnClick="btnContainerDeletar_Click" class="btn btn-info"/>
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" class="btn btn-warning"/>
                    <br/><br/>
                    <asp:Panel ID="pnlInformacoes" runat="server" Style="display:none">
                        <div class="alert alert-warning"> 
                            <asp:Label ID="lblAlert1" runat="server" Font-Bold="True"><h5>Lembrando que o código do Container deve ser constituído por 4 LETRAS e 7 NUMEROS.</h5></asp:Label>
                            <asp:Label ID="lblAlert2" runat="server" Font-Bold="True" Font-Overline="True"><h6>Exemplo: ABCD1234567</h6></asp:Label>
                        </div>
                        <div class="SubMenu">
                        <asp:Label ID="lblNome" runat="server"><h5>Informe o nome do cliente:</h5></asp:Label>
                        <asp:TextBox ID="txtNome" runat="server" MaxLength="50" ToolTip="Nome do Cliente"></asp:TextBox><br/><br/>
                        <asp:Label ID="lblContainer" runat="server" ><h5>Informe o código do container:</h5></asp:Label>
                        <asp:TextBox ID="txtContainer" runat="server" class="text-uppercase" TextMode="SingleLine" ToolTip="Ex.: ABCD1234567" MaxLength="11"></asp:TextBox><br/><br/>
                        <asp:Label ID="lblTipo" runat="server"><h5>Informe o tipo do container:</h5></asp:Label>
                        <asp:RadioButton ID="rdbTipo1" runat="server" Text="20" class="rdb" GroupName="T1" Checked=" true" />
                        <asp:RadioButton ID="rdbTipo2" runat="server" Text="40" class="rdb" GroupName="T1"  /><br/><br/>
                        <asp:Label ID="lblStatus" runat="server"><h5>Informe o status do conatiner:</h5></asp:Label>
                        <asp:RadioButton ID="rdbStatus1" runat="server" Text="Cheio" class="rdb" GroupName="S2" Checked="true" />
                        <asp:RadioButton ID="rdbStatus2" runat="server" Text="Vazio" class="rdb" GroupName="S2" /><br/><br/>
                        <asp:Label ID="lblCategoria" runat="server"><h4>Informe a categoria do container:</h4></asp:Label>
                        <asp:RadioButton ID="rdbCategoria1" runat="server" Text=" Importação" class="rdb" GroupName="C3" Checked="true" />
                        <asp:RadioButton ID="rdbCategoria2" runat="server" Text=" Exportação" class="rdb" GroupName="C3" />
                        <br/><br/>
                        <asp:GridView ID="gdvConsultar" runat="server" HorizontalAlign="Center"></asp:GridView>
                        </div>
                    </asp:Panel>
                </asp:Panel>
            </div>
            <div class="Menu"> 
            <asp:Panel ID="pnlPainelMovimentacao" runat="server" Style="display:none">
                <asp:Label ID="lblInfM" runat="server" ><h2>Cadastro de Movimentações:</h2></asp:Label><br/><br/>
                <asp:Button ID="btnMovimentacaoCadastrar" runat="server" Text="Cadastrar Movimentação" OnClick="btnMovimentacaoCadastrar_Click" class="btn btn-info menu2"/>
                <asp:Button ID="btnMovimentacaoConsultar" runat="server" Text="Consultar Movimentação" OnClick="btnMovimentacaoConsultar_Click" class="btn btn-info menu2"/>
                <asp:Button ID="btnMovimentacaoAtualizar" runat="server" Text="Atualizar Movimentação" OnClick="btnMovimentacaoAtualizar_Click" class="btn btn-info menu2"/>
                <br />
                <asp:Button ID="btnMovimentacaoDeletar" runat="server" Text="Deletar Movimentação" OnClick="btnMovimentacaoDeletar_Click" class="btn btn-info"/>
                <asp:Button ID="btnMovimentacaoVoltar" runat="server" Text="Voltar" OnClick="btnMovimentacaoVoltar_Click" class="btn btn-warning"/>
                <br/><br/>
                <asp:Panel ID="pnlInformacoesMov" runat="server"  Style="display:none">           
                <div class="alert alert-warning"> 
                    <asp:Label ID="lblAlertMov1" runat="server" Font-Bold="True"><h5>Lembrando que o código do Container deve ser constituído por 4 LETRAS e 7 NUMEROS.</h5></asp:Label>
                    <asp:Label ID="lblAlertMov2" runat="server" Font-Bold="True" Font-Overline="True"><h6>Exemplo: ABCD1234567</h6></asp:Label>
                </div>
                <div class="SubMenu">
                    <asp:Label ID="lblContainerMovimentacao" runat="server"><h3>Informe o código do Container:</h3></asp:Label>
                    <asp:TextBox ID="txtContainerMovimentacao" runat="server" class="text-uppercase" ToolTip="Ex.: ABCD1234567" MaxLength="11"></asp:TextBox><br />
                    <asp:TextBox ID="txtIdMovimentacao" runat="server" class="text-uppercase" MaxLength="5"></asp:TextBox><br/><br/>
                    <asp:Label ID="lblTipoMovimentacao" runat="server"><h3 style ="margin-top:10px">Informe o tipo de movimentação:</h3></asp:Label>
                    <asp:RadioButton ID="rdbTipoMovimentacao1" runat="server" Text=" Embarque" class="rdb" GroupName="Tm1" Checked=" true" />
                    <asp:RadioButton ID="rdbTipoMovimentacao2" runat="server" Text=" Descarga" class="rdb" GroupName="Tm1" />
                    <asp:RadioButton ID="rdbTipoMovimentacao3" runat="server" Text=" Gate In" class="rdb" GroupName="Tm1" />
                    <asp:RadioButton ID="rdbTipoMovimentacao4" runat="server" Text=" Gate Out" class="rdb" GroupName="Tm1" />
                    <asp:RadioButton ID="rdbTipoMovimentacao5" runat="server" Text=" Posicionamento Pilha" class="rdb" GroupName="Tm1" />
                    <asp:RadioButton ID="rdbTipoMovimentacao6" runat="server" Text=" Pesagem" class="rdb" GroupName="Tm1" />
                    <asp:RadioButton ID="rdbTipoMovimentacao7" runat="server" Text=" Scanner" class="rdb" GroupName="Tm1" /><br/><br/>
                    <asp:Label ID="lblDataHoraInicial" runat="server"><h3>Digite a data e a hora inicial:</h3></asp:Label>
                    <asp:TextBox ID="txtDataInicial" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:TextBox ID="txtHoraInicial" runat="server" TextMode="Time"></asp:TextBox><br/><br/>
                    <asp:Label ID="lblDataHoraFinal" runat="server"><h3>Digite a data e a hora final:</h3></asp:Label>
                    <asp:TextBox ID="txtDataFinal" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:TextBox ID="txtHoraFinal" runat="server" TextMode="Time"></asp:TextBox><br/><br/>  
                    <asp:GridView ID="gdvConsultarMov" runat="server" HorizontalAlign="Center"></asp:GridView>
                </div>
                </asp:Panel>
            </asp:Panel>
                <br/><asp:Label ID="lblAviso" runat="server"></asp:Label>
                <br/><asp:Button ID="btnEnviar" runat="server" Text="Enviar Informações" Visible="false" OnClick="btnEnviar_Click" class="btn btn-success"/>
                </div>
            <div class="Menu">
                <asp:Label ID="lblInfRelatorio" runat="server" visible="false"><h2>Relatório Geral:</h2></asp:Label><br/><br/>
                <asp:Panel ID="pnlRelatorio" runat="server" Style="display:none">
                    <asp:Button ID="btnRelatorioContainer" runat="server" Text="Relatório de Containers" OnClick="btnRelatorioContainer_Click" class="btn btn-outline-info"/>
                    <asp:Button ID="btnRelatorioMovimentacao" runat="server" Text="Relatório de Movimentações" OnClick="btnRelatorioMovimentacao_Click" class="btn btn-outline-info"/> <br/><br/>
                    <asp:GridView ID="gdvRelatorio" runat="server" HorizontalAlign="Center"></asp:GridView><br/><br/>
                    <asp:GridView ID="gdvSoma" runat="server" HorizontalAlign="Center"></asp:GridView>
                    <asp:GridView ID="gdvSoma2" runat="server" HorizontalAlign="Center"></asp:GridView>
                    <asp:GridView ID="gdvContainer" runat="server" HorizontalAlign="Center"></asp:GridView>
                </asp:Panel>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>
