<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdemdeServico.aspx.cs" Inherits="WebApplication1.OrdemdeServico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container mt-4">

    <asp:TextBox ID="txtIdOrdemServico"
        runat="server"
        Visible="False">
    </asp:TextBox>

    <h2 class="mb-4">Ordem de Serviço</h2>

    <div class="row">

        <div class="col-md-4">
            <asp:Label ID="lblCliente"
                runat="server"
                Text="Cliente">
            </asp:Label>

            <asp:DropDownList ID="ddlCliente"
                runat="server"
                CssClass="form-control"
                AutoPostBack="True"
                OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

        <div class="col-md-4">
            <asp:Label ID="lblEquipamento"
                runat="server"
                Text="Equipamento">
            </asp:Label>

            <asp:DropDownList ID="ddlEquipamento"
                runat="server"
                CssClass="form-control">
            </asp:DropDownList>
        </div>

        <div class="col-md-4">
            <asp:Label ID="lblTécnico"
                runat="server"
                Text="Técnico">
            </asp:Label>

            <asp:DropDownList ID="ddlTecnico"
                runat="server"
                CssClass="form-control">
            </asp:DropDownList>
        </div>

    </div>

    <br />

    <div class="row">

        <div class="col-md-4">
            <asp:Label ID="lblDefeito"
                runat="server"
                Text="Defeito Relatado">
            </asp:Label>

            <asp:TextBox ID="txtDefeito"
                runat="server"
                CssClass="form-control"
                TextMode="MultiLine"
                Rows="4">
            </asp:TextBox>
        </div>

        <div class="col-md-4">
            <asp:Label ID="lblDiagnostico"
                runat="server"
                Text="Diagnóstico">
            </asp:Label>

            <asp:TextBox ID="txtDiagnostico"
                runat="server"
                CssClass="form-control"
                TextMode="MultiLine"
                Rows="4">
            </asp:TextBox>
        </div>

        <div class="col-md-4">
            <asp:Label ID="lblServico"
                runat="server"
                Text="Serviço executado">
            </asp:Label>

            <asp:TextBox ID="txtServico"
                runat="server"
                CssClass="form-control"
                TextMode="MultiLine"
                Rows="4">
            </asp:TextBox>
        </div>

    </div>

    <br />

    <div class="row">

        <div class="col-md-3">
            <asp:Label ID="lblDataEntrada"
                runat="server"
                Text="Data Entrada">
            </asp:Label>

            <asp:TextBox ID="txtDataEntrada"
                runat="server"
                CssClass="form-control"
                TextMode="Date">
            </asp:TextBox>
        </div>

        <div class="col-md-3">
            <asp:Label ID="lblDataSaida"
                runat="server"
                Text="Data Saída">
            </asp:Label>

            <asp:TextBox ID="txtDataSaida"
                runat="server"
                CssClass="form-control"
                TextMode="Date">
            </asp:TextBox>
        </div>

        <div class="col-md-3">
            <asp:Label ID="lblStatus"
                runat="server"
                Text="Status">
            </asp:Label>

            <asp:DropDownList ID="ddlStatus"
                runat="server"
                CssClass="form-control">
                <asp:ListItem>Selecione um status</asp:ListItem>
                <asp:ListItem>Em análise</asp:ListItem>
                <asp:ListItem>Em manutenção</asp:ListItem>
                <asp:ListItem>Aguardando peça</asp:ListItem>
                <asp:ListItem>Finalizado</asp:ListItem>
                <asp:ListItem>Entregue</asp:ListItem>
            </asp:DropDownList>
        </div>

    </div>

    <br />

    <div class="row">
        <div class="col-md-12">

            <asp:Button ID="btnSalvar"
                runat="server"
                Text="Salvar"
                CssClass="btn btn-success"
                OnClick="btnSalvar_Click" />

            <asp:Button ID="btnAlterar"
                runat="server"
                Text="Alterar"
                CssClass="btn btn-warning"
                OnClick="btnAlterar_Click" />

            <asp:Button ID="btnExcluir"
                runat="server"
                Text="Excluir"
                CssClass="btn btn-danger"
                OnClick="btnExcluir_Click" />

        </div>
    </div>

    <br />

    <asp:Label ID="lblMensagem"
        runat="server"
        Visible="False"
        CssClass="alert alert-success d-block">
    </asp:Label>

    <br />

    <asp:GridView ID="tblOrdemServico"
        runat="server"
        CssClass="table table-striped table-bordered table-hover"
        AutoGenerateSelectButton="True"
        OnSelectedIndexChanged="tblOrdemServico_SelectedIndexChanged">
    </asp:GridView>

</div>
</asp:Content>
