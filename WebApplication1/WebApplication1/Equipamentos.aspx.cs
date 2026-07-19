using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Equipamentos : System.Web.UI.Page
    {

        private void LimparCampos()
        {
            txtIdEquipamento.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtNumSerie.Text = "";
            ListCliente.SelectedIndex = 0;
            ListEquipment.SelectedIndex = 0;
        }
        private void CarregarCliente()
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            String sql = "SELECT IdCliente, Nome FROM Cliente";

            SqlCommand cmd = new SqlCommand(sql, conexao);

            conexao.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            ListCliente.DataSource = dr;

            ListCliente.DataTextField = "Nome";
            ListCliente.DataValueField = "IdCliente";

            ListCliente.Items.Clear();
            ListCliente.DataBind();
            ListCliente.Items.Insert(0, new ListItem(("Selecione um cliente"), ""));
            conexao.Close();
        }

        private void CarregarEquipamento()
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            String sql = "SELECT IdEquipamento, IdCliente, TipoEquipamento, Marca, Modelo, NumeroSerie FROM Equipamento";

            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();

            SqlDataReader dados = cmd.ExecuteReader();

            tblEquipment.DataSource = dados;
            tblEquipment.DataBind();

            conexao.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarCliente();
                CarregarEquipamento();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);


            String sql = "INSERT INTO Equipamento (IdCliente, TipoEquipamento, Marca, Modelo, NumeroSerie)" +
                "values(@IdCliente, @IdEquipamento, @Marca, @Modelo, @NumeroSerie)";

            SqlCommand cmd = new SqlCommand(sql, conexao);


            if (ListCliente.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "alerta",
                    "alert('Selecione um cliente!');",
                    true
                );
                return;
            }
            int IdCliente = Convert.ToInt32(ListCliente.SelectedValue);

            if (ListEquipment.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "alerta",
                    "alert('Selecione um equipamento!');",
                    true
                );
                return;
            }
            
            String TipoEquipamento = ListEquipment.SelectedValue;

            cmd.Parameters.AddWithValue("@IdEquipamento", TipoEquipamento);
            cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
            cmd.Parameters.AddWithValue("@Marca", txtMarca.Text);
            cmd.Parameters.AddWithValue("@Modelo", txtModelo.Text);
            cmd.Parameters.AddWithValue("@NumeroSerie", txtNumSerie.Text);

            conexao.Open();
            cmd.ExecuteNonQuery();
            lblMensagem.Text = "Equipamento cadastrado com sucesso!";
            CarregarEquipamento();
            conexao.Close();
            LimparCampos();
        }


        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            String sql = @"UPDATE Equipamento SET IdCliente = @IdCliente, TipoEquipamento = @TipoEquipamento, Marca = @Marca, Modelo = @Modelo, NumeroSerie = @NumeroSerie WHERE IdEquipamento = @IdEquipamento";
            
            SqlCommand cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@IdEquipamento", Convert.ToInt32(txtIdEquipamento.Text));

            cmd.Parameters.AddWithValue("@IdCliente", Convert.ToInt32(ListCliente.SelectedValue));

            cmd.Parameters.AddWithValue("@TipoEquipamento", ListEquipment.SelectedValue);

            cmd.Parameters.AddWithValue("@Marca", txtMarca.Text);

            cmd.Parameters.AddWithValue("@Modelo", txtModelo.Text);

            cmd.Parameters.AddWithValue("@NumeroSerie", txtNumSerie.Text);

            conexao.Open();
            cmd.ExecuteNonQuery();
            conexao.Close();
            lblMensagem.Text = "Equipamento alterado com sucesso!";
            CarregarEquipamento();
            LimparCampos();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIdEquipamento.Text))
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "alerta",
                    "alert('Selecione um equipamento!');",
                    true);

                return;
            }

            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            String sql = @"DELETE FROM Equipamento WHERE IdEquipamento = @IdEquipamento";

            SqlCommand cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@IdEquipamento", Convert.ToInt32(txtIdEquipamento.Text));

            conexao.Open();
            cmd.ExecuteNonQuery();
            conexao.Close();
            lblMensagem.Text = "Equipamento excluído com sucesso!";
            CarregarEquipamento();
            LimparCampos();

        }

        protected void tblEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdEquipamento.Text = tblEquipment.SelectedRow.Cells[1].Text;

            ListCliente.SelectedValue = tblEquipment.SelectedRow.Cells[2].Text;

            ListEquipment.SelectedValue = tblEquipment.SelectedRow.Cells[3].Text;

            txtMarca.Text = tblEquipment.SelectedRow.Cells[4].Text;

            txtModelo.Text = tblEquipment.SelectedRow.Cells[5].Text;

            txtNumSerie.Text = tblEquipment.SelectedRow.Cells[6].Text;

            btnSalvar.Enabled = false;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
        }
    }
}