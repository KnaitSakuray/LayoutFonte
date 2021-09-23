using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fonte;
using MetroFramework;
using MetroFramework.Forms;

namespace LayoutFonte
{
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
            UpdateData();

           

        }

        private void UpdateData()
        {
            if (Conexao.ROTA == "06") { label2.Text = " | EXTREMA MG | FILIAL 06"; }
            if (Conexao.ROTA == "49") { label2.Text = " | MANAUS AM | FILIAL 49"; }

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
                    MessageBox.Show("Falha na verificação para atualização, Tente novamente : " + ide.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("essa aplicação não pode ser atualizada : " + ioe.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (info.UpdateAvailable)
                {

                    try
                    {

                        System.Windows.Forms.MessageBox.Show(this, "Sua versão esta desatualizada , Sistema sera atualizado !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ad.Update();
                        Application.Restart();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
            txtsenha.UseSystemPasswordChar = false;
            
            txtuser.Clear();
            txtuser.Select();
            txtuser.Focus();
            this.txtuser.Enter += new EventHandler(txtuser_Enter);

           

        }

        private void loginAutentication()
        {
            SqlConnection conn = new SqlConnection(Conexao.ROTA);

            // comando sql + parametrização , que sera utilizado para consultar usuario e senha
            SqlCommand comande = new SqlCommand("select count(*) from [FONTE].[dbo].[USUARIO_FONTE] where usuario = @user and senha = @senha", conn);

            comande.Parameters.Add("@user", SqlDbType.VarChar).Value = txtuser.Text;
            comande.Parameters.Add("@senha", SqlDbType.VarChar).Value = txtsenha.Text;

            // abrindo conexao com o banco
            conn.Open();
            // confirmação de usuario e senha 
            int i = (int)comande.ExecuteScalar();

            conn.Close();

            if (txtuser.Text != "")
                if (i > 0)
                {


                    // preparando para conexao com o banco
                    SqlConnection conn2 = new SqlConnection(Conexao.ROTA);

                    // comando sql + parametrização , que sera utilizado para consultar usuario e senha
                    SqlCommand comande2 = new SqlCommand("select * from [FONTE].[dbo].[USUARIO_FONTE] where usuario = @user and senha = @senha", conn2);

                    comande2.Parameters.Add("@user", SqlDbType.VarChar).Value = txtuser.Text;
                    comande2.Parameters.Add("@senha", SqlDbType.VarChar).Value = txtsenha.Text;

                    // abrindo conexao com o banco
                    conn2.Open();

                    //criando tabela virtual
                    SqlDataReader dr1 = comande2.ExecuteReader();
                    while (dr1.Read())
                    {
                        // carregando as strings con os dados da tabela

                        string nome = dr1["usuario"].ToString();
                        txtuser.Text = nome;

                        string senha = dr1["senha"].ToString();
                        txtsenha.Text = senha;

                        //rota - medicao
                        string PRODUCAO = dr1["cadastro_log"].ToString();
                        if (PRODUCAO == "SIM")
                        {
                            btProducao.Enabled = true;
                            btProducao.Visible = true;

                            button2.Enabled = true;
                            button2.Visible = true;
                        }
                        else
                        {
                            btProducao.Enabled = false;
                            btProducao.Visible = false;

                            button2.Enabled = false;
                            button2.Visible = false;
                        }

                        //rota - preprinter
                        string ADM = dr1["adm_log"].ToString();
                        if (ADM == "SIM")
                        {
                            btAdm.Enabled = true;
                        
                            btCadastro.Enabled = true;
                        }
                        else
                        {
                            btAdm.Enabled = false;
                         
                            btCadastro.Enabled = false;
                        }

                        //rota - preprinter
                        string DLT = dr1["delete_log"].ToString();

                        if (DLT == "SIM")
                        {
                            btRefazer.Enabled = true;
                        }

                        else
                        {
                            btRefazer.Enabled = false;  
                        }

                        global.usuario = txtuser.Text;
                        conn.Close();

                    }
                    panel7.Visible = false;
                }

                else
                {
                    MetroMessageBox.Show(this, "Usuario ou senha incorretos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    conn.Close();
                }

          
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            loginAutentication();

        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            txtuser.Text = "";
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {

        }

        private void txtsenha_Enter(object sender, EventArgs e)
        {
            txtsenha.Text = "";
            txtsenha.UseSystemPasswordChar = true;
        }

        private void txtsenha_Leave(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void cADASTROUSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmUsuario f = new frmUsuario();
            f.Closed += (s, args) => this.Close();
            f.Show();

        }

        private void cADASTROMODELOToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmCadModeloFonte f = new frmCadModeloFonte();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void PRODUÇÃO_Click(object sender, EventArgs e)
        {
            this.Hide();
            principal f = new principal();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void cONSULTAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aDMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtsenha_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
        }

        private void txtsenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginAutentication();
            }
        }

        private void txtuser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtsenha.Focus();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            /*
            GraphicsUnit units = GraphicsUnit.Point;
            base.OnPaint(e);
            Rectangle Rect = new Rectangle(0, 0, button1.Width, button1.Height);
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, 20, 20, 180, 90);
            GraphPath.AddArc(Rect.X + 150 - 50, Rect.Y, 20, 20, 270, 90);
            GraphPath.AddArc(Rect.X + 150 - 50, Rect.Y + Rect.Height - 20, 20, 20, 0, 90);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - 20, 20, 20, 90, 90);
            */

           // button1.Region = new Region(GraphPath);
            

        }
        private void brconsulta_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            frmconsulta f = new frmconsulta();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginAutentication();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();

            lbltitle.Text = button5.Text;
            panelCon.BackColor = Color.PaleGreen;
            panelPro.BackColor = Color.FromArgb(255, 192, 128);
            panelADM.BackColor = Color.FromArgb(255, 192, 128);
            panelCAD.BackColor = Color.FromArgb(255, 192, 128);
            panelRT.BackColor = Color.FromArgb(255, 192, 128);
            panelTE.BackColor = Color.FromArgb(255, 192, 128);


            frmconsulta frm = new frmconsulta();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(frm);
            this.panelPrincipal.Tag = frm;
            frm.BringToFront();
            frm.Show();

        }

        private void btProducao_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();

            lbltitle.Text = btProducao.Text;
            panelCon.BackColor = Color.FromArgb(255, 192, 128);
            panelPro.BackColor = Color.PaleGreen;
            panelADM.BackColor = Color.FromArgb(255, 192, 128);
            panelCAD.BackColor = Color.FromArgb(255, 192, 128);
            panelRT.BackColor = Color.FromArgb(255, 192, 128);
            panelTE.BackColor = Color.FromArgb(255, 192, 128);

            principal frm = new principal();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(frm);
            this.panelPrincipal.Tag = frm;
            frm.BringToFront();
            frm.Show();
        }

        private void btAdm_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();

            lbltitle.Text = btAdm.Text;
            panelCon.BackColor = Color.FromArgb(255, 192, 128);
            panelPro.BackColor = Color.FromArgb(255, 192, 128);
            panelADM.BackColor = Color.PaleGreen;
            panelCAD.BackColor = Color.FromArgb(255, 192, 128);
            panelRT.BackColor = Color.FromArgb(255, 192, 128);
            panelTE.BackColor = Color.FromArgb(255, 192, 128);

            frmUsuario frm = new frmUsuario();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(frm);
            this.panelPrincipal.Tag = frm;
            frm.BringToFront();
            frm.Show();
        }

        private void btCadastro_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();

            lbltitle.Text = btCadastro.Text;
            panelCon.BackColor = Color.FromArgb(255, 192, 128);
            panelPro.BackColor = Color.FromArgb(255, 192, 128);
            panelADM.BackColor = Color.FromArgb(255, 192, 128);
            panelCAD.BackColor = Color.PaleGreen;
            panelRT.BackColor = Color.FromArgb(255, 192, 128);
            panelTE.BackColor = Color.FromArgb(255, 192, 128);

            frmCadModeloFonte frm = new frmCadModeloFonte();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(frm);
            this.panelPrincipal.Tag = frm;
            frm.BringToFront();
            frm.Show();
        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btRefazer_Click(object sender, EventArgs e)
        {

            panelPrincipal.Controls.Clear();

            lbltitle.Text = btCadastro.Text;
            panelCon.BackColor = Color.FromArgb(255, 192, 128);
            panelPro.BackColor = Color.FromArgb(255, 192, 128);
            panelADM.BackColor = Color.FromArgb(255, 192, 128);
            panelCAD.BackColor = Color.FromArgb(255, 192, 128);
            panelRT.BackColor = Color.PaleGreen;
            panelTE.BackColor = Color.FromArgb(255, 192, 128);

            frmDelete frm = new frmDelete();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(frm);
            this.panelPrincipal.Tag = frm;
            frm.BringToFront();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();

            lbltitle.Text = btProducao.Text;
            panelCon.BackColor = Color.FromArgb(255, 192, 128);
            panelPro.BackColor = Color.FromArgb(255, 192, 128);
            panelADM.BackColor = Color.FromArgb(255, 192, 128);
            panelCAD.BackColor = Color.FromArgb(255, 192, 128);
            panelRT.BackColor = Color.FromArgb(255, 192, 128);
            panelTE.BackColor = Color.PaleGreen;

            frmTeste frm = new frmTeste();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(frm);
            this.panelPrincipal.Tag = frm;
            frm.BringToFront();
            frm.Show();
        }
    }
    
}
