<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<main>

    <section class="jumbotron text-center">
        <h1>Sistema de Assistência Técnica</h1>

        <p class="lead">
            Gerencie clientes, técnicos, equipamentos e ordens de serviço
            de forma simples e organizada.
        </p>

        <p>
            <a href="Clientes.aspx" class="btn btn-primary btn-lg">
                Cadastrar Clientes
            </a>    

            <a href="OrdemdeServico.aspx" class="btn btn-success btn-lg">
                Abrir Ordem de Serviço
            </a>
        </p>
    </section>

    <div class="row">

        <section class="col-md-3">
            <div class="card">
                <div class="card-body">
                    <h3>Clientes</h3>
                    <p>
                        Cadastro e gerenciamento dos clientes da assistência técnica.
                    </p>

                    <a href="Clientes.aspx" class="btn btn-primary">
                        Acessar
                    </a>
                </div>
            </div>
        </section>

        <section class="col-md-3">
            <div class="card">
                <div class="card-body">
                    <h3>Técnicos</h3>
                    <p>
                        Cadastro dos técnicos responsáveis pelos atendimentos.
                    </p>

                    <a href="Tecnicos.aspx" class="btn btn-primary">
                        Acessar
                    </a>
                </div>
            </div>
        </section>

        <section class="col-md-3">
            <div class="card">
                <div class="card-body">
                    <h3>Equipamentos</h3>
                    <p>
                        Controle dos equipamentos cadastrados pelos clientes.
                    </p>

                    <a href="Equipamentos.aspx" class="btn btn-primary">
                        Acessar
                    </a>
                </div>
            </div>
        </section>

        <section class="col-md-3">
            <div class="card">
                <div class="card-body">
                    <h3>Ordens de Serviço</h3>
                    <p>
                        Acompanhamento dos reparos e serviços executados.
                    </p>

                    <a href="OrdemdeServico.aspx" class="btn btn-primary">
                        Acessar
                    </a>
                </div>
            </div>
        </section>

    </div>

    <br />

    <div class="row">

        <div class="col-md-12">

            <div class="alert alert-info">

                <h4>Sobre o Sistema</h4>

                <p>
                    Este sistema foi desenvolvido em ASP.NET Web Forms e SQL Server
                    para auxiliar no gerenciamento de uma assistência técnica,
                    permitindo o cadastro de clientes, técnicos, equipamentos
                    e o controle completo das ordens de serviço.
                </p>

            </div>

        </div>

    </div>

</main>

</asp:Content>
