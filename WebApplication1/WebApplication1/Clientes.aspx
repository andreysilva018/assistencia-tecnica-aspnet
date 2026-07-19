<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container mt-4">

    <h2 class="mb-4">Cadastro de Clientes</h2>

    <asp:TextBox ID="txtidCliente"
        runat="server"
        Enabled="False"
        Visible="False">
    </asp:TextBox>

    <div class="row">

        <div class="col-md-4">
            <label>Nome Completo</label>
            <asp:TextBox ID="txtNome"
                runat="server"
                CssClass="form-control"
                placeholder="Digite o nome completo">
            </asp:TextBox>
        </div>

        <div class="col-md-4">
            <label>Telefone</label>
            <asp:TextBox ID="txtTelefone"
                runat="server"
                CssClass="form-control"
                placeholder="(00) 00000-0000">
            </asp:TextBox>
        </div>

        <div class="col-md-4">
            <label>E-mail</label>
            <asp:TextBox ID="txtEmail"
                runat="server"
                CssClass="form-control"
                placeholder="email@exemplo.com">
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

    <asp:GridView ID="GridView1"
        runat="server"
        CssClass="table table-striped table-bordered table-hover"
        AutoGenerateSelectButton="True"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    </asp:GridView>

</div>
</asp:Content>
