<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="WebApplication1.Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">

        <h2 class="mb-4">Cadastro de Técnicos</h2>

        <asp:TextBox ID="txtIdTecnico"
            runat="server"
            Enabled="False"
            Visible="False">
        </asp:TextBox>

        <div class="row">

            <div class="col-md-6">
                <label>Nome do Técnico</label>

                <asp:TextBox ID="txtNome"
                    runat="server"
                    CssClass="form-control"
                    placeholder="Digite o nome completo">
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

        <asp:GridView ID="tblTecnico"
            runat="server"
            CssClass="table table-striped table-bordered table-hover"
            AutoGenerateSelectButton="True"
            OnSelectedIndexChanged="tblTecnico_SelectedIndexChanged">
        </asp:GridView>

    </div>
</asp:Content>
