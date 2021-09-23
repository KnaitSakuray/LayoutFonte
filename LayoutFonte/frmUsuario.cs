using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework;
using System.Deployment.Application;

namespace LayoutFonte
{
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
      
            consulta();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {

        }
        private void UpdateData()
        {

            UpdateCheckInfo info;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    // System.Windows.MessageBox.Show("uma nova versão do aplicativo não pode ser baixada \n verifique a conexão : " + dde.Message, "Aviso", MessageBoxButton.OK);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MetroMessageBox.Show(this,"Falha na verificação para atualização, Tente novamente : " + ide.Message, "Aviso", MessageBoxButtons.OK);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MetroMessageBox.Show(this,"essa aplicação não pode ser atualizada : " + ioe.Message, "Aviso", MessageBoxButtons.OK);

                    MetroMessageBox.Show(this, "Usuario com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                    ;

                }
                if (info.UpdateAvailable)
                {

                    try
                    {

                        MetroMessageBox.Show(this, "Sua versão esta desatualizada , Sistema sera atualizado !!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ad.Update();
                        System.Windows.Forms.Application.Restart();
                    }
                    catch (Exception ex)
                    {
                        MetroMessageBox.Show(this,ex.Message, "Aviso", MessageBoxButtons.OK);
                    }
                }
            }
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            string PRO = "";
            string ADM = "";
            string DLT = "";
            if (ckbpPRO.Checked)
            {
                PRO = "SIM";
            }
            else
            {
                PRO = "NAO";
            }

            if (ckdADM.Checked)
            {
                ADM = "SIM";
            }
            else
            {
                ADM = "NAO";
            }

            if (ckbDelete.Checked)
            {
                DLT = "SIM";
            }
            else
            {
                DLT = "NAO";
            }

            //VERIFICA SE O USUARIO JA EXISTE
            SqlConnection con = new SqlConnection(Conexao.ROTA);
            SqlCommand comande = new SqlCommand("IF EXISTS(select * from [FONTE].[dbo].[USUARIO_FONTE] where usuario = @USUARIO)SELECT 1 ELSE SELECT 0", con);

            comande.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = tbUsuario.Text;

            con.Open();
            int USUARIO = Convert.ToInt32(comande.ExecuteScalar());
            con.Close();

            if (USUARIO == 1)
            {
                MetroMessageBox.Show(this,"Usuario Já cadastrado", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                //INSERI NOVO USUARIO
                SqlConnection con1 = new SqlConnection(Conexao.ROTA);
                SqlCommand comande1 = new SqlCommand("insert into [FONTE].[dbo].[USUARIO_FONTE] ([usuario],[senha],[cadastro_log],[adm_log],[delete_log]) values (@USUARIO,@SENHA,@pro,@adm,@dlt)", con1);

                comande1.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = tbUsuario.Text;
                comande1.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = tbSenha.Text;
                comande1.Parameters.Add("@pro", SqlDbType.VarChar).Value = PRO;
                comande1.Parameters.Add("@adm", SqlDbType.VarChar).Value = ADM;
                comande1.Parameters.Add("@dlt", SqlDbType.VarChar).Value = DLT;

                con1.Open();
                comande1.ExecuteScalar();
                con1.Close();

                MetroMessageBox.Show(this, "Usuario com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbUsuario.Text = "";
                tbSenha.Text = "";
                ckbpPRO.Checked = false;
                ckdADM.Checked = false;
                consulta();
            }






        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        private void consulta()
        {

            //CARREGA DATAGRID
            SqlConnection conecta = new SqlConnection(Conexao.ROTA);
            SqlCommand comande = new SqlCommand("SELECT [id],[usuario],[cadastro_log],[adm_log] FROM [FONTE].[dbo].[USUARIO_FONTE]", conecta);

            conecta.Open();
            SqlDataReader dr = comande.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            DGVusuario.DataSource = dt;

            conecta.Close();
        }

        private void DGVusuario_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void DGVusuario_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void DGVusuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string usuario;
            usuario = DGVusuario.CurrentRow.Cells[1].Value.ToString();
            MetroMessageBox.Show(this,"Usuario selecionado foi : "+usuario,"Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);

            SqlConnection con = new SqlConnection(Conexao.ROTA);
            SqlCommand comande = new SqlCommand("select * from [FONTE].[dbo].[USUARIO_FONTE] where usuario = @user", con);

            comande.Parameters.Add("@user", SqlDbType.VarChar).Value = usuario;

            con.Open();
            SqlDataReader dr1 = comande.ExecuteReader();
            while (dr1.Read())
            {
                string nome = dr1["usuario"].ToString();
                tbUsuario.Text = nome;

                string senha = dr1["senha"].ToString();
                tbSenha.Text = senha;

                //rota - medicao
                string PRODUCAO = dr1["cadastro_log"].ToString();
                if (PRODUCAO == "SIM")
                {
                    ckbpPRO.Checked = true;
                }
                else
                {
                    ckbpPRO.Checked = false;
                }

                //rota - preprinter
                string ADM = dr1["adm_log"].ToString();
                if (ADM == "SIM")
                {
                    ckdADM.Checked = true;
                }
                else
                {
                    ckdADM.Checked = false;
                }

                //rota - preprinter
                string DLT = dr1["delete_log"].ToString();
                if (DLT == "SIM")
                {
                    ckbDelete.Checked = true;
                }
                else
                {
                    ckbDelete.Checked = false;
                }

                // NOME

            }

            con.Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string PRO = "";
            string ADM = "";
            string DLT = "";
            if (ckbpPRO.Checked)
            {
                PRO = "SIM";
            }
            else
            {
                PRO = "NAO";
            }

            if (ckdADM.Checked)
            {
                ADM = "SIM";
            }
            else
            {
                ADM = "NAO";
            }
            if (ckbDelete.Checked)
            {
                DLT = "SIM";
            }
            else
            {
                DLT = "NAO";
            }

            //VERIFICA SE O USUARIO JA EXISTE
            SqlConnection con = new SqlConnection(Conexao.ROTA);
            SqlCommand comande = new SqlCommand("IF EXISTS(select * from [FONTE].[dbo].[USUARIO_FONTE] where usuario = @USUARIO)SELECT 1 ELSE SELECT 0", con);

            comande.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = tbUsuario.Text;

            con.Open();
            int x1 = Convert.ToInt32(comande.ExecuteScalar());
            con.Close();

            if (x1 == 1)
            {
                
                //INSERI NOVO USUARIO
                SqlConnection con1 = new SqlConnection(Conexao.ROTA);
                SqlCommand comande1 = new SqlCommand("UPDATE [FONTE].[dbo].[USUARIO_FONTE] SET [senha]= @SENHA, [cadastro_log]= @pro, [adm_log]= @adm, [delete_log]= @dlt where usuario= @USUARIO ", con1);

                comande1.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = tbUsuario.Text;
                comande1.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = tbSenha.Text;
                comande1.Parameters.Add("@pro", SqlDbType.VarChar).Value = PRO;
                comande1.Parameters.Add("@adm", SqlDbType.VarChar).Value = ADM;
                comande1.Parameters.Add("@dlt", SqlDbType.VarChar).Value = DLT;

                con1.Open();
                comande1.ExecuteScalar();
                con1.Close();

                MetroMessageBox.Show(this, "Alterado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbUsuario.Text = "";
                tbSenha.Text = "";
                ckbpPRO.Checked = false;
                ckdADM.Checked = false;
                consulta();
            }
            else
            {
                MetroMessageBox.Show(this, "Usuario Não cadastrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            //VERIFICA SE O USUARIO JA EXISTE
            SqlConnection con = new SqlConnection(Conexao.ROTA);
            SqlCommand comande = new SqlCommand("IF EXISTS(select * from [FONTE].[dbo].[USUARIO_FONTE] where usuario = @USUARIO)SELECT 1 ELSE SELECT 0", con);

            comande.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = tbUsuario.Text;

            con.Open();
            int x1 = Convert.ToInt32(comande.ExecuteScalar());
            con.Close();

            if (x1 == 1)
            {

                DialogResult resultado = MetroMessageBox.Show(this, "Deseja Realmente Deletar esse usuario","Aviso", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (resultado == DialogResult.No) { }
                else
                {

                    //deletar NOVO USUARIO
                    SqlConnection con1 = new SqlConnection(Conexao.ROTA);
                    SqlCommand comande1 = new SqlCommand("DELETE FROM [FONTE].[dbo].[USUARIO_FONTE] where usuario= @USUARIO ", con1);

                    comande1.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = tbUsuario.Text;

                    con1.Open();
                    comande1.ExecuteScalar();
                    con1.Close();

                    MetroMessageBox.Show(this, "Deletado com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbUsuario.Text = "";
                    tbSenha.Text = "";
                    ckbpPRO.Checked = false;
                    ckdADM.Checked = false;

                    consulta();
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Usuario Não cadastrado", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
