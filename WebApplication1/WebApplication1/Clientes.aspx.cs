using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void CarregarClientes()
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            String sql = "SELECT IdCliente, Nome, Telefone, Email FROM Cliente";

            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();

            SqlDataReader dados = cmd.ExecuteReader();

            GridView1.DataSource = dados;
            GridView1.DataBind();

            conexao.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarClientes();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "Informe o nome do cliente.";
                txtNome.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "Informe o telefone.";
                txtTelefone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) && !txtEmail.Text.Contains("@"))
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "Informe o e-mail válido.";
                txtEmail.Focus();
                return;
            }

            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);
            conexao.Open();

            String nome = txtNome.Text;
            String telefone = txtTelefone.Text;
            String email = txtEmail.Text;

            String sql = @"INSERT INTO Cliente (Nome, Telefone, Email)" +
                "values(@Nome, @Telefone, @Email)";

            SqlCommand cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue ("@Telefone", telefone);
            cmd.Parameters.AddWithValue("@Email", email);

            cmd.ExecuteNonQuery();
            CarregarClientes();
            lblMensagem.Text = "Cliente salvo com sucesso!";
            conexao.Close();
            LimparCampos();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtidCliente.Text = GridView1.SelectedRow.Cells[1].Text;
            txtNome.Text = GridView1.SelectedRow.Cells[2].Text;
            txtTelefone.Text = GridView1.SelectedRow.Cells[3].Text;
            txtEmail.Text = GridView1.SelectedRow.Cells[4].Text;

            btnSalvar.Enabled = false;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;

        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "Informe o nome do cliente.";
                txtNome.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "Informe o telefone.";
                txtTelefone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) && !txtEmail.Text.Contains("@"))
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "Informe o e-mail válido.";
                txtEmail.Focus();
                return;
            }


            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            String sql = @"UPDATE Cliente SET Nome=@Nome, Telefone=@Telefone, Email=@Email WHERE IdCliente=@IdCliente";

            SqlCommand cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@IdCliente", txtidCliente.Text);
            cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

            conexao.Open();
            cmd.ExecuteNonQuery();
            CarregarClientes();
            lblMensagem.Text = "Cliente alterado com sucesso!";
            conexao.Close();
            LimparCampos();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            String sql = "DELETE FROM Cliente WHERE IdCliente=@IdCliente";

            SqlCommand cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@IdCliente", txtidCliente.Text);

            conexao.Open();
            cmd.ExecuteNonQuery();
            CarregarClientes();
            lblMensagem.Text = "Cliente excluido com sucesso!";
            conexao.Close();
            LimparCampos();
        }

        private void LimparCampos() 
        {
            txtidCliente.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";

            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;

            txtNome.Focus();
        }
    }
}