using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class OrdemdeServico : System.Web.UI.Page
    {

        private void CarregarClientes()
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            string sql = "SELECT IdCliente, Nome FROM Cliente";

            SqlCommand cmd = new SqlCommand(sql, conexao);

            conexao.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            ddlCliente.DataSource = dr;
            ddlCliente.DataTextField = "Nome";
            ddlCliente.DataValueField = "IdCliente";
            ddlCliente.DataBind();

            conexao.Close();

            ddlCliente.Items.Insert(0,
                new ListItem("Selecione um cliente", ""));
        }

        private void CarregarEquipamentosPorCliente()
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            string sql =@"SELECT IdEquipamento, TipoEquipamento + ' - ' + Marca + ' - ' + Modelo + ' - Série: ' + NumeroSerie AS Descricao FROM Equipamento WHERE IdCliente = @IdCliente";

            SqlCommand cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue(
                "@IdCliente",
                ddlCliente.SelectedValue);

            conexao.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            ddlEquipamento.DataSource = dr;
            ddlEquipamento.DataTextField = "Descricao";
            ddlEquipamento.DataValueField = "IdEquipamento";
            ddlEquipamento.DataBind();

            conexao.Close();

            ddlEquipamento.Items.Insert(0,
                new ListItem("Selecione um equipamento", ""));
        }

        private void CarregarTecnicos()
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            string sql = "SELECT IdTecnico, Nome FROM Tecnico";

            SqlCommand cmd = new SqlCommand(sql, conexao);

            conexao.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            ddlTecnico.DataSource = dr;
            ddlTecnico.DataTextField = "Nome";
            ddlTecnico.DataValueField = "IdTecnico";
            ddlTecnico.DataBind();

            conexao.Close();

            ddlTecnico.Items.Insert(0,
                new ListItem("Selecione um técnico", ""));
        }

        private void CarregarOrdensServico()
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            string sql = @"SELECT os.IdOrdemServico, c.Nome AS Cliente, e.TipoEquipamento, t.Nome AS Tecnico, os.Status, os.DataEntrada FROM OrdemServico os INNER JOIN Equipamento e ON os.IdEquipamento = e.IdEquipamento INNER JOIN Cliente c ON e.IdCliente = c.IdCliente INNER JOIN Tecnico t ON os.IdTecnico = t.IdTecnico";
            
            SqlDataAdapter da = new SqlDataAdapter(sql, conexao);

            DataTable dt = new DataTable();

            da.Fill(dt);

            tblOrdemServico.DataSource = dt;
            tblOrdemServico.DataBind();
        }

        private void LimparCampos()
        {
            txtIdOrdemServico.Text = "";

            ddlCliente.SelectedIndex = 0;

            ddlEquipamento.Items.Clear();
            ddlEquipamento.Items.Insert(0,
                new ListItem("Selecione um equipamento", ""));

            ddlTecnico.SelectedIndex = 0;

            txtDefeito.Text = "";
            txtDiagnostico.Text = "";
            txtServico.Text = "";

            txtDataEntrada.Text = "";
            txtDataSaida.Text = "";

            ddlStatus.SelectedIndex = 0;

            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarClientes();
                CarregarTecnicos();
                CarregarOrdensServico();

                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ddlCliente.SelectedIndex == 0)
            {
                lblMensagem.Text = "Selecione um cliente.";
                return;
            }

            if (ddlEquipamento.SelectedIndex == 0)
            {
                lblMensagem.Text = "Selecione um equipamento.";
                return;
            }

            if (ddlTecnico.SelectedIndex == 0)
            {
                lblMensagem.Text = "Selecione um técnico.";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDefeito.Text))
            {
                lblMensagem.Text = "Informe o defeito relatado.";
                txtDefeito.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDataEntrada.Text))
            {
                lblMensagem.Text = "Informe a data de entrada.";
                txtDataEntrada.Focus();
                return;
            }

            if (ddlStatus.SelectedIndex == 0)
            {
                lblMensagem.Text = "Selecione um status.";
                return;
            }

            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            string sql = @"INSERT INTO OrdemServico(IdEquipamento,IdTecnico,DefeitoRelatado,Diagnostico,ServicoExecutado,DataEntrada,DataSaida,Status) VALUES(@IdEquipamento,@IdTecnico,@DefeitoRelatado,@Diagnostico,@ServicoExecutado,@DataEntrada,@DataSaida,@Status)";
            
            SqlCommand cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@IdEquipamento",ddlEquipamento.SelectedValue);

            cmd.Parameters.AddWithValue("@IdTecnico",ddlTecnico.SelectedValue);

            cmd.Parameters.AddWithValue("@DefeitoRelatado",txtDefeito.Text);

            cmd.Parameters.AddWithValue("@Diagnostico",txtDiagnostico.Text);

            cmd.Parameters.AddWithValue("@ServicoExecutado",txtServico.Text);

            cmd.Parameters.AddWithValue("@DataEntrada",txtDataEntrada.Text);

            cmd.Parameters.AddWithValue("@DataSaida",txtDataSaida.Text);

            cmd.Parameters.AddWithValue("@Status",ddlStatus.SelectedItem.Text);

            conexao.Open();

            cmd.ExecuteNonQuery();

            conexao.Close();
            lblMensagem.Visible = true;
            lblMensagem.Text = "Ordem de serviço salva com sucesso.";

            LimparCampos();

            CarregarOrdensServico();

        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if (ddlCliente.SelectedIndex == 0)
            {
                lblMensagem.Text = "Selecione um cliente.";
                return;
            }

            if (ddlEquipamento.SelectedIndex == 0)
            {
                lblMensagem.Text = "Selecione um equipamento.";
                return;
            }

            if (ddlTecnico.SelectedIndex == 0)
            {
                lblMensagem.Text = "Selecione um técnico.";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDefeito.Text))
            {
                lblMensagem.Text = "Informe o defeito relatado.";
                txtDefeito.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDataEntrada.Text))
            {
                lblMensagem.Text = "Informe a data de entrada.";
                txtDataEntrada.Focus();
                return;
            }

            if (ddlStatus.SelectedIndex == 0)
            {
                lblMensagem.Text = "Selecione um status.";
                return;
            }

            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            string sql = @"UPDATE OrdemServico SET DefeitoRelatado = @Defeito, Diagnostico = @Diagnostico, ServicoExecutado = @Servico, DataEntrada = @DataEntrada, DataSaida = @DataSaida, Status = @Status WHERE IdOrdemServico = @Id";

            SqlCommand cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@Id", txtIdOrdemServico.Text);

            cmd.Parameters.AddWithValue("@Defeito", txtDefeito.Text);

            cmd.Parameters.AddWithValue("@Diagnostico", txtDiagnostico.Text);

            cmd.Parameters.AddWithValue("@Servico", txtServico.Text);

            cmd.Parameters.AddWithValue("@DataEntrada", txtDataEntrada.Text);

            cmd.Parameters.AddWithValue("@DataSaida", txtDataSaida.Text);

            cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedItem.Text);

            conexao.Open();
            cmd.ExecuteNonQuery();
            conexao.Close();
            CarregarOrdensServico();
            LimparCampos();
            lblMensagem.Text = "Ordem alterada com sucesso!";
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            string sql = @"DELETE FROM OrdemServico WHERE IdOrdemServico = @Id";

            SqlCommand cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@Id", txtIdOrdemServico.Text);

            conexao.Open();
            cmd.ExecuteNonQuery();
            conexao.Close();
            CarregarOrdensServico();
            LimparCampos();

            lblMensagem.Text = "Ordem excluída com sucesso!";
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarEquipamentosPorCliente();
        }

        protected void tblOrdemServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strConexao = @"Data Source=.\SQLEXPRESS;" +
                "Initial Catalog=AssistenciaTecnica;" +
                "Integrated Security=true;";

            SqlConnection conexao = new SqlConnection(strConexao);

            string sql =@"SELECT * FROM OrdemServico WHERE IdOrdemServico = @Id";

            int id = Convert.ToInt32( tblOrdemServico.SelectedRow.Cells[1].Text);

            SqlCommand cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@Id", id);

            conexao.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtIdOrdemServico.Text = dr["IdOrdemServico"].ToString();

                txtDefeito.Text = dr["DefeitoRelatado"].ToString();

                txtDiagnostico.Text = dr["Diagnostico"].ToString();

                txtServico.Text = dr["ServicoExecutado"].ToString();

                txtDataEntrada.Text = Convert.ToDateTime(dr["DataEntrada"]).ToString("yyyy-MM-dd");

                if (dr["DataSaida"] != DBNull.Value)
                {
                    txtDataSaida.Text = Convert.ToDateTime(dr["DataSaida"]).ToString("yyyy-MM-dd");
                }

                ddlStatus.SelectedValue = dr["Status"].ToString();
            }

            btnSalvar.Enabled = false;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            conexao.Close();
        }
    }
}