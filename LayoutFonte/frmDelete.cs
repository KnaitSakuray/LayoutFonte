using LayoutFonte;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonte
{
    public partial class frmDelete : Form
    {
        public frmDelete()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            LoadOP();
        }

        private void frmDelete_Load(object sender, EventArgs e)
        {

        }

        private void LoadOP()
        {
            SqlConnection cn = new SqlConnection(Conexao.ROTA);
            SqlCommand comande2 = new SqlCommand("SELECT  [SN],[MODELO],[OP],[data_hora] FROM [FONTE].[dbo].[MODELO_INTEGRACAOO] where op=@op order by id desc ", cn);

            cn.Open();
            comande2.Parameters.Add("@op", SqlDbType.VarChar).Value = cbOP.Text.Trim();

            SqlDataReader dr = comande2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            metroGrid1.DataSource = dt;
            cn.Close();
            int linhas = dt.Rows.Count;

            metroGrid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void metroGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Font font = new Font("Itálico", 10.0f);
            DataGridViewRow row = metroGrid1.Rows[e.RowIndex];
            row.DefaultCellStyle.ForeColor = Color.Black;
            row.DefaultCellStyle.Font = font;
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string SN;
            SN = metroGrid1.CurrentRow.Cells[0].Value.ToString();

            //VERIFICA SE O USUARIO JA EXISTE
            SqlConnection con = new SqlConnection(Conexao.ROTA);
            SqlCommand comande = new SqlCommand("IF EXISTS(select * from [FONTE].[dbo].[MODELO_INTEGRACAOO] where sn = @sn)SELECT 1 ELSE SELECT 0", con);

            comande.Parameters.Add("@sn", SqlDbType.VarChar).Value = SN;

            con.Open();

            int x1 = Convert.ToInt32(comande.ExecuteScalar());

            con.Close();

            if (x1 == 1)
            {

                DialogResult resultado = MetroMessageBox.Show(this, "Deseja Realmente Deletar esse SN : (" + SN + ")", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.No) { }
                else
                {
                    //deletar NOVO USUARIO
                    SqlConnection con1 = new SqlConnection(Conexao.ROTA);
                    SqlCommand comande1 = new SqlCommand("DELETE FROM [FONTE].[dbo].[MODELO_INTEGRACAOO] where sn= @sn ", con1);

                    comande1.Parameters.Add("@sn", SqlDbType.VarChar).Value = SN;

                    con1.Open();
                    comande1.ExecuteScalar();
                    con1.Close();

                    tbSN.Clear();

                    tbSN.Focus();
                }
            }
            else
            {
                MetroMessageBox.Show(this, "SN Não encontrado", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void tbSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {

                string SN;
                SN = tbSN.Text.Trim();

                //VERIFICA SE O USUARIO JA EXISTE
                SqlConnection con = new SqlConnection(Conexao.ROTA);
                SqlCommand comande = new SqlCommand("IF EXISTS(select * from [FONTE].[dbo].[MODELO_INTEGRACAOO] where sn = @sn)SELECT 1 ELSE SELECT 0", con);

                comande.Parameters.Add("@sn", SqlDbType.VarChar).Value = SN;

                con.Open();
                int x1 = Convert.ToInt32(comande.ExecuteScalar());
                con.Close();

                if (x1 == 1)
                {

                    DialogResult resultado = MetroMessageBox.Show(this, "Deseja Realmente Deletar esse SN : (" + SN + ")", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.No) { }
                    else
                    {
                        //deletar NOVO USUARIO
                        SqlConnection con1 = new SqlConnection(Conexao.ROTA);
                        SqlCommand comande1 = new SqlCommand("DELETE FROM [FONTE].[dbo].[MODELO_INTEGRACAOO] where sn= @sn ", con1);

                        comande1.Parameters.Add("@sn", SqlDbType.VarChar).Value = SN;

                        con1.Open();
                        comande1.ExecuteScalar();
                        con1.Close();

                        tbSN.Clear();

                        tbSN.Focus();

                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "SN Não encontrado", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }

        }
    }
}
