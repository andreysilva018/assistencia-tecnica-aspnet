using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        private void CarregarTecnicos()
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            String sql = "SELECT IdTecnico, Nome FROM Tecnico";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();

            SqlDataReader dados = cmd.ExecuteReader();

            tblTecnico.DataSource = dados;
            tblTecnico.DataBind();

            conexao.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarTecnicos();

                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "Informe o nome do técnico.";
                txtNome.Focus();
                return;
            }

            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);
            conexao.Open();

            String nome = txtNome.Text;

            String sql = @"INSERT INTO Tecnico (Nome) values(@Nome)";

            SqlCommand cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@Nome", nome);

            cmd.ExecuteNonQuery();
            CarregarTecnicos();
            lblMensagem.Text = "Tecnico salvo com sucesso!";
            conexao.Close();
            LimparCampos();
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "Informe o nome do técnico.";
                txtNome.Focus();
                return;
            }
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            String sql = @"UPDATE Tecnico SET Nome=@Nome WHERE IdTecnico=@IdTecnico";

            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdTecnico", txtIdTecnico.Text);
            cmd.Parameters.AddWithValue("@Nome", txtNome.Text);

            conexao.Open();
            cmd.ExecuteNonQuery();
            CarregarTecnicos();
            lblMensagem.Text = "Tecnico alterado com sucesso";
            conexao.Close();
            LimparCampos();
        }

        protected void tblTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdTecnico.Text = tblTecnico.SelectedRow.Cells[1].Text;
            txtNome.Text = tblTecnico.SelectedRow.Cells[2].Text;

            btnSalvar.Enabled = false;

            btnAlterar.Enabled = true;

            btnExcluir.Enabled = true;
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            String sql = @"DELETE FROM Tecnico WHERE IdTecnico=@IdTecnico";

            SqlCommand cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@IdTecnico", txtIdTecnico.Text);

            conexao.Open();
            cmd.ExecuteNonQuery();
            CarregarTecnicos();
            lblMensagem.Text = "Tecnico excluido com sucesso";
            conexao.Close();
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtIdTecnico.Text = "";
            txtNome.Text = "";

            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;

            txtNome.Focus();
        }
    }
}