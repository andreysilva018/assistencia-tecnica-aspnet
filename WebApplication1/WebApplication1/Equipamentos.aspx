<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Equipamentos.aspx.cs" Inherits="WebApplication1.Equipamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container mt-4">

    <h2 class="mb-4">Cadastro de Equipamentos</h2>

    <asp:TextBox ID="txtIdEquipamento"
        runat="server"
        Enabled="False"
        Visible="False">
    </asp:TextBox>

    <div class="row">

        <div class="col-md-4">
            <label>Cliente</label>

            <asp:DropDownList ID="ListCliente"
                runat="server"
                CssClass="form-control">
            </asp:DropDownList>
        </div>

        <div class="col-md-4">
            <label>Tipo de Equipamento</label>

            <asp:DropDownList ID="ListEquipment"
                runat="server"
                CssClass="form-control">
                <asp:ListItem>Selecionar equipamento</asp:ListItem>
                <asp:ListItem>Notebook</asp:ListItem>
                <asp:ListItem>Desktop</asp:ListItem>
                <asp:ListItem>Impressora</asp:ListItem>
                <asp:ListItem>Monitor</asp:ListItem>
                <asp:ListItem>Mouse</asp:ListItem>
                <asp:ListItem>Teclado</asp:ListItem>
            </asp:DropDownList>
        </div>

    </div>

    <br />

    <div class="row">

        <div class="col-md-4">
            <label>Marca</label>

            <asp:TextBox ID="txtMarca"
                runat="server"
                CssClass="form-control"
                placeholder="Digite a marca">
            </asp:TextBox>
        </div>

        <div class="col-md-4">
            <label>Modelo</label>

            <asp:TextBox ID="txtModelo"
                runat="server"
                CssClass="form-control"
                placeholder="Digite o modelo">
            </asp:TextBox>
        </div>

        <div class="col-md-4">
            <label>Número de Série</label>

            <asp:TextBox ID="txtNumSerie"
                runat="server"
                CssClass="form-control"
                placeholder="Digite o número de série">
            </asp:TextBox>
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

    <asp:GridView ID="tblEquipment"
        runat="server"
        CssClass="table table-striped table-bordered table-hover"
        AutoGenerateSelectButton="True" OnSelectedIndexChanged="tblEquipment_SelectedIndexChanged">
    </asp:GridView>

</div>
</asp:Content>
