using LayoutFonte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonte
{
    public partial class frmTeste : Form
    {
        delegate void serialCalback(string val);
        private string ResultLogic = string.Empty;
        private string DATA = string.Empty;
        public frmTeste()
        {
            InitializeComponent();

            DataServer();

            LoadCbBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void DataServer()
        {

            SqlConnection cona = new SqlConnection(Conexao.ROTA);
            SqlCommand comandea = new SqlCommand("Select getdate()", cona);

            cona.Open();
            DATA = Convert.ToString(comandea.ExecuteScalar());
            cona.Close();
        }

        private void tbSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cbModelo.Text == "" || txtOP.Text == "" || cblinha.Text == "")
                {
                    lblAviso.Text = "PREENCHER TODOS OS CAMPOS";
                }
                else
                {


                    listBox1.Items.Insert(0, this.tbSN.Text);

                    //VERIFICA SE JA EXISTE
                    SqlConnection con = new SqlConnection(Conexao.ROTA);
                    SqlCommand comande = new SqlCommand("IF EXISTS(select * from [FONTE].[dbo].[TESTE_FONTE] where SN = @SN )SELECT 1 ELSE SELECT 0", con);

                    comande.Parameters.Add("@SN", SqlDbType.VarChar).Value = tbSN.Text;

                    con.Open();
                    int USUARIO = Convert.ToInt32(comande.ExecuteScalar());
                    con.Close();
                    if (USUARIO == 1)
                    {
                        string OP = "", datahora = "";

                        // total do bot
                        SqlConnection conecta34 = new SqlConnection(Conexao.ROTA);
                        SqlCommand comande34 = new SqlCommand("SELECT  [OP],[data_hora] FROM [FONTE].[dbo].[TESTE_FONTE] where SN=@sn  ", conecta34);

                        comande34.Parameters.Add("@sn", SqlDbType.VarChar).Value = tbSN.Text;

                        conecta34.Open();

                        SqlDataReader dr1 = comande34.ExecuteReader();
                        while (dr1.Read())
                        {
                            OP = dr1["OP"].ToString();
                            datahora = dr1["data_hora"].ToString();
                        }
                        conecta34.Close();

                        lblAviso.Text = "SN :( " + tbSN.Text + " ) já logado na OP : " + OP + "  Horario do log : " + datahora;

                        tbSN.Clear();
                        tbSN.Focus();
                    }
                    else
                    {

                        //insert DB
                        SqlConnection con1 = new SqlConnection(Conexao.ROTA);
                        SqlCommand comande1 = new SqlCommand("insert into [FONTE].[dbo].[TESTE_FONTE] ([sn],[modelo],[op],[data_hora],[usuario],[linha],[status]) values (@SN,@modelo,@OP,@DATA,@usuario,@cblinha,@S)", con1);

                        comande1.Parameters.Add("@SN", SqlDbType.VarChar).Value = tbSN.Text;
                        comande1.Parameters.Add("@modelo", SqlDbType.VarChar).Value = cbModelo.Text;
                        comande1.Parameters.Add("@OP", SqlDbType.VarChar).Value = txtOP.Text.Trim();
                        comande1.Parameters.Add("@DATA", SqlDbType.VarChar).Value = DATA;
                        comande1.Parameters.Add("@usuario", SqlDbType.VarChar).Value = global.usuario;
                        comande1.Parameters.Add("@S", SqlDbType.Int).Value = 1;
                        comande1.Parameters.Add("@cblinha", SqlDbType.VarChar).Value = cblinha.Text;

                        con1.Open();
                        comande1.ExecuteScalar();
                        con1.Close();


                        tbSN.Clear();
                        tbSN.Focus();
                        //=====================================================================================================
                        timerconsulta();//=====================================================================================
                        //=====================================================================================================

                        tbSN.Enabled = false;
                          
                        lblAviso.Text = "AGUARDANDO";

                        panelAviso.BackColor = Color.PaleGreen;

                    }
                }
            }
        }

        private void frmTeste_Load(object sender, EventArgs e)
        {
            modeloLoad();
        }
        private void LoadCbBox()
        {
            int i = 0;
            this.metroComboBox1.Items.Clear(); // Clear the serial port
            string[] gCOM = System.IO.Ports.SerialPort.GetPortNames(); // Get all available serial ports of the device
            int j = gCOM.Length; // Get the number of all available serial ports
            for (i = 0; i < j; i++)
            {
                this.metroComboBox1.Items.Add(gCOM[i]); // Add to the drop-down box in turn
            }

            ManagementObjectCollection mReturn;
            ManagementObjectSearcher mSearch;
            mSearch = new ManagementObjectSearcher("Select * from Win32_SerialPort");
            mReturn = mSearch.Get();

            foreach (ManagementObject mObj in mReturn)
            {
                Console.WriteLine(mObj["Name"].ToString());
            }

        }
        private void modeloLoad()
        {
            //carrega combobox cliente
            SqlConnection conecta2 = new SqlConnection(Conexao.ROTA);
            SqlCommand comande2 = new SqlCommand("select codigo, COUNT(*) from [FONTE].[dbo].[MODELO_FONTE] group by codigo", conecta2);

            conecta2.Open();

            SqlDataReader dr2 = comande2.ExecuteReader();

            DataTable dt2 = new DataTable();

            dt2.Load(dr2);
            cbModelo.DisplayMember = "codigo";
            cbModelo.DataSource = dt2;

            //ADICIONAR TODOS NO COMBOBOX
            //ORDENANDO O COMBOBOX
            dt2.DefaultView.Sort = "codigo";

            conecta2.Close();

            cbModelo.SelectedIndex = -1;
            cbModelo.DropDownHeight = cbModelo.ItemHeight * 15;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = metroComboBox1.Text;
                    serialPort1.Open();
                    metroButton1.Enabled = false;
                    metroButton2.Enabled = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            lblStatus.Text = "ONLINE";
            lblStatus.ForeColor = Color.ForestGreen;

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            lblStatus.Text = "OFFILINE";
            lblStatus.ForeColor = Color.DarkRed;

            metroButton1.Enabled = true;
            metroButton2.Enabled = false;
        }

        private void metroGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Font font = new Font("Itálico", 10.0f);
            DataGridViewRow row = metroGrid1.Rows[e.RowIndex];
            row.DefaultCellStyle.ForeColor = Color.Black;
            row.DefaultCellStyle.Font = font;
        }

        private void timerconsulta()
        {
            SqlConnection cn = new SqlConnection(Conexao.ROTA);
            SqlCommand comande2 = new SqlCommand("SELECT  [SN],[MODELO],[OP],[data_hora] FROM [FONTE].[dbo].[TESTE_FONTE] where op=@op order by id desc ", cn);

            cn.Open();
            comande2.Parameters.Add("@op", SqlDbType.VarChar).Value = txtOP.Text.Trim();

            SqlDataReader dr = comande2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            metroGrid1.DataSource = dt;
            cn.Close();
            int linhas = dt.Rows.Count;
            lblProd.Text = linhas.ToString();

            metroGrid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


        }

        private void setText(string val)
        {
            try
            {
                if (this.textBox1.InvokeRequired)
                {
                    serialCalback scb = new serialCalback(setText);
                    this.Invoke(scb, new object[] { val });
                }
                else
                {
                    textBox1.Text = "LOGIC SIGNAL :" + val;
                    if (Convert.ToInt64(val) == 2)
                    {
                        lblResposta.Text = "PASS";
                    }

                    else if (Convert.ToInt64(val) == 1)
                    {
                        lblResposta.Text = "FALHA";
                    }

                    else if (Convert.ToInt64(val) == 0)
                    {
                        lblResposta.Text = "AGUARDANDO";
                        button1.Focus();
                    }

                    if (lblResposta.Text == "PASS")
                    {
                        tbSN.Enabled = true;
                        tbSN.Focus();
                        lblAviso.Text = "LIBERADO PARA COLETA";
                        panelAviso.BackColor = Color.PaleGreen;
                    }
                    if (lblResposta.Text == "FALHA")
                    {
                        tbSN.Enabled = false;
                        tbSN.Focus();
                        lblAviso.Text = "FONTE COM DEFEITO";
                        panelAviso.BackColor = Color.Salmon;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string incomSting = serialPort1.ReadLine();
            setText(incomSting);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
