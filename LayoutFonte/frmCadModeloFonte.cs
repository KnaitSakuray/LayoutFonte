using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using System.Data.SqlClient;

namespace LayoutFonte
{
    public partial class frmCadModeloFonte : Form
    {
        public frmCadModeloFonte()
        {
            InitializeComponent();
        }

        private void frmCadModeloFonte_Load(object sender, EventArgs e)
        {
            tbModelo.Focus();
            Consulta();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            cadastroInsert();
            Consulta();

        }

        private void cadastroInsert()
        {
            string PRO = string.Empty;
            if (ckbpPRO.Checked)
            {
                PRO = "SIM";
            }
            else
            {
                PRO = "NAO";
            }


            if (tbModelo.Text == "" || tbCodPa.Text == "")
            { MetroMessageBox.Show(this, "Preencher os campos acima", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop); ; }
            else
            {

                //VERIFICA SE O USUARIO JA EXISTE
                SqlConnection con = new SqlConnection(Conexao.ROTA);
                SqlCommand comande = new SqlCommand("IF EXISTS(select * from [FONTE].[dbo].[MODELO_FONTE] where codigo = @codigo)SELECT 1 ELSE SELECT 0", con);

                comande.Parameters.Add("@codigo", SqlDbType.VarChar).Value = tbCodPa.Text;

                con.Open();
                int USUARIO = Convert.ToInt32(comande.ExecuteScalar());
                con.Close();

                if (USUARIO == 1)
                {
                    MetroMessageBox.Show(this, "Modelo Já cadastrado", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    //INSERI NOVO USUARIO
                    SqlConnection con1 = new SqlConnection(Conexao.ROTA);
                    SqlCommand comande1 = new SqlCommand("insert into [FONTE].[dbo].[MODELO_FONTE] ([nome],[codigo],[qty_caixa],[teste1]) values (@USUARIO,@SENHA,@qtycaixa,@Test1)", con1);

                    comande1.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = tbModelo.Text;
                    comande1.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = tbCodPa.Text;
                    comande1.Parameters.Add("@qtycaixa", SqlDbType.VarChar).Value = txtCaixa.Text;
                    comande1.Parameters.Add("@Test1", SqlDbType.VarChar).Value = PRO;

                    con1.Open();
                    comande1.ExecuteScalar();
                    con1.Close();

                    MetroMessageBox.Show(this, "modelo cadastrado com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbModelo.Clear();
                    tbCodPa.Clear();
                    txtCaixa.Clear();
                    tbModelo.Focus();


                }

            }
        }

        private void tbModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbCodPa.Focus();
            }
        }

        private void tbCodPa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cadastroInsert();
            }
        }
        private void Consulta()
        {
            //CARREGA DATAGRID
            SqlConnection conecta = new SqlConnection(Conexao.ROTA);
            SqlCommand comande = new SqlCommand("SELECT * FROM [FONTE].[dbo].[MODELO_FONTE]", conecta);

            conecta.Open();
            SqlDataReader dr = comande.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            dgvcadastromodelo.DataSource = dt;

            conecta.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void dgvcadastromodelo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string usuario;
            usuario = dgvcadastromodelo.CurrentRow.Cells[1].Value.ToString();
            MetroMessageBox.Show(this, "modelo selecionado foi : " + usuario, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SqlConnection con = new SqlConnection(Conexao.ROTA);
            SqlCommand comande = new SqlCommand("select * from [FONTE].[dbo].[MODELO_FONTE] where codigo = @user", con);

            comande.Parameters.Add("@user", SqlDbType.VarChar).Value = usuario;

            con.Open();
            SqlDataReader dr1 = comande.ExecuteReader();
            while (dr1.Read())
            {
                string nome = dr1["codigo"].ToString();
                tbCodPa.Text = nome;

                string senha = dr1["nome"].ToString();
                tbModelo.Text = senha;

                string qty = dr1["qty_caixa"].ToString();
                txtCaixa.Text = qty;

                // NOME
                //rota - medicao
                string PRODUCAO = dr1["teste1"].ToString();
                if (PRODUCAO == "SIM")
                {
                    ckbpPRO.Checked = true;
                }
                else
                {
                    ckbpPRO.Checked = false;
                }

            }
            con.Close();
        }

        private void dgvcadastromodelo_MouseHover(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            dgvcadastromodelo.ForeColor = Color.Red;
        }

        private void dgvcadastromodelo_MouseLeave(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            dgvcadastromodelo.ForeColor = Color.Black;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string PRO = string.Empty;
            if (ckbpPRO.Checked)
            {
                PRO = "SIM";
            }
            else
            {
                PRO = "NAO";
            }

            //VERIFICA SE O USUARIO JA EXISTE
            SqlConnection con = new SqlConnection(Conexao.ROTA);
            SqlCommand comande = new SqlCommand("IF EXISTS(select * from [FONTE].[dbo].[MODELO_FONTE] where codigo = @codigo)SELECT 1 ELSE SELECT 0", con);

            comande.Parameters.Add("@codigo", SqlDbType.VarChar).Value = tbCodPa.Text;

            con.Open();
            int x1 = Convert.ToInt32(comande.ExecuteScalar());
            con.Close();

            if (x1 == 1)
            {

                //INSERI NOVO USUARIO
                SqlConnection con1 = new SqlConnection(Conexao.ROTA);
                SqlCommand comande1 = new SqlCommand("UPDATE [FONTE].[dbo].[MODELO_FONTE] SET [nome]= @USUARIO,[qty_caixa]= @qtycaixa,[teste1]= @test1 where codigo= @SENHA ", con1);

                comande1.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = tbModelo.Text;
                comande1.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = tbCodPa.Text;
                comande1.Parameters.Add("@qtycaixa", SqlDbType.VarChar).Value = txtCaixa.Text;
                comande1.Parameters.Add("@test1", SqlDbType.VarChar).Value = PRO;


                con1.Open();
                comande1.ExecuteScalar();
                con1.Close();

                MetroMessageBox.Show(this, "Nome do modelo alterado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbModelo.Text = "";
                tbCodPa.Text = "";
                Consulta();

            }
            else
            {
                MetroMessageBox.Show(this, "Modelo Não cadastrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            //VERIFICA SE O USUARIO JA EXISTE
            SqlConnection con = new SqlConnection(Conexao.ROTA);
            SqlCommand comande = new SqlCommand("IF EXISTS(select * from [FONTE].[dbo].[MODELO_FONTE] where codigo = @USUARIO)SELECT 1 ELSE SELECT 0", con);

            comande.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = tbCodPa.Text;

            con.Open();
            int x1 = Convert.ToInt32(comande.ExecuteScalar());
            con.Close();

            if (x1 == 1)
            {

                DialogResult resultado = MetroMessageBox.Show(this, "Deseja Realmente Deletar esse Modelo", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.No) { }
                else
                {

                    //deletar NOVO USUARIO
                    SqlConnection con1 = new SqlConnection(Conexao.ROTA);
                    SqlCommand comande1 = new SqlCommand("DELETE FROM [FONTE].[dbo].[MODELO_FONTE] where codigo= @USUARIO ", con1);
                    comande1.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = tbCodPa.Text;
                    con1.Open();
                    comande1.ExecuteScalar();
                    con1.Close();
                    MetroMessageBox.Show(this, "Deletado com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbCodPa.Text = "";
                    tbModelo.Text = "";
                    Consulta();
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Modelos Não cadastrado", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;
            }
        }
    }
}
