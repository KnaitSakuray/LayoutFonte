using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Runtime.InteropServices;
using System.Threading;

namespace LayoutFonte
{
    public partial class principal : Form
    {
        Bitmap barcodeBitmap, barcodeBitmap1;
        Point barcodePoint, barcodePoint1;
        Thread threadPrincipal;
        int impressaoQTY;

        public principal()
        {
            InitializeComponent();
        }

        private void principal_Load(object sender, EventArgs e)
        {

            lblRE.Text = "Responsavel : " + global.usuario;
            modeloLoad();
            OpLoad();
            tbSN.Focus();
            tbSN.BackColor = Color.LightGreen;

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

            // ORDENANDO O COMBOBOX
            dt2.DefaultView.Sort = "codigo";

            conecta2.Close();

            cbModelo.SelectedIndex = -1;
            cbModelo.DropDownHeight = cbModelo.ItemHeight * 15;

        }

        private void OpLoad()
        {/*
            SqlConnection cn = new SqlConnection(Conexao.ROTA);
            SqlCommand cmd = new SqlCommand("select CKD, COUNT(*) from CKD  WHERE STATUS = 'PENDENTE' group by CKD", cn);

            cn.Open();

            SqlDataReader dr1 = cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            cbOP.DisplayMember = "CKD";
            cbOP.DataSource = dt1;
            cn.Close();*/
        }

        private void metroGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Font font = new Font("Itálico", 10.0f);
            DataGridViewRow row = metroGrid1.Rows[e.RowIndex];
            row.DefaultCellStyle.ForeColor = Color.Black;
            row.DefaultCellStyle.Font = font;
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void snenter() 
        {
            if (cbModelo.Text == "" || cbOP.Text == "" || tbSN.Text == "" || cblinha.Text=="" || txttotalOP.Text=="")
            { MetroMessageBox.Show(this, "Preencher os campos acima", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop); ; }
            else
            {
                SqlConnection cona = new SqlConnection(Conexao.ROTA);
                SqlCommand comandea = new SqlCommand("Select getdate()", cona);

                cona.Open();
                string DATA = Convert.ToString(comandea.ExecuteScalar());
                cona.Close();


                //VERIFICA SE JA EXISTE
                SqlConnection con = new SqlConnection(Conexao.ROTA);
                SqlCommand comande = new SqlCommand("IF EXISTS(select * from [FONTE].[dbo].[MODELO_INTEGRACAOO] where SN = @SN )SELECT 1 ELSE SELECT 0", con);

                comande.Parameters.Add("@SN", SqlDbType.VarChar).Value = tbSN.Text;

                con.Open();
                int USUARIO = Convert.ToInt32(comande.ExecuteScalar());
                con.Close();

                if (USUARIO == 1)
                {
                    string OP = "", datahora = "";

                    // total do bot
                    SqlConnection conecta34 = new SqlConnection(Conexao.ROTA);
                    SqlCommand comande34 = new SqlCommand("SELECT  [OP],[data_hora] FROM [FONTE].[dbo].[MODELO_INTEGRACAOO] where SN=@sn  ", conecta34);

                    comande34.Parameters.Add("@sn", SqlDbType.VarChar).Value = tbSN.Text;

                    conecta34.Open();

                    SqlDataReader dr1 = comande34.ExecuteReader();
                    while (dr1.Read())
                    {
                        OP = dr1["OP"].ToString();
                        datahora = dr1["data_hora"].ToString();


                    }
                    conecta34.Close();

                    MetroMessageBox.Show(this, "SN :( " + tbSN.Text + " ) já logado na OP : " + OP + "  Horario do log : " + datahora, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    tbSN.Clear();
                    tbSN.Focus();
                }
                else
                {
                    listBox1.Items.Insert(0, this.tbSN.Text);
                    //INSERI NOVO USUARIO
                    SqlConnection con1 = new SqlConnection(Conexao.ROTA);
                    SqlCommand comande1 = new SqlCommand("insert into [FONTE].[dbo].[MODELO_INTEGRACAOO] ([sn],[modelo],[op],[data_hora],[usuario],[linha]) values (@SN,@modelo,@OP,@DATA,@usuario,@cblinha)", con1);

                    comande1.Parameters.Add("@SN", SqlDbType.VarChar).Value = tbSN.Text;
                    comande1.Parameters.Add("@modelo", SqlDbType.VarChar).Value = cbModelo.Text;
                    comande1.Parameters.Add("@OP", SqlDbType.VarChar).Value = cbOP.Text.Trim();
                    comande1.Parameters.Add("@DATA", SqlDbType.VarChar).Value = DATA;
                    comande1.Parameters.Add("@usuario", SqlDbType.VarChar).Value = global.usuario;
                    comande1.Parameters.Add("@cblinha", SqlDbType.VarChar).Value = cblinha.Text;

                    con1.Open();
                    comande1.ExecuteScalar();
                    con1.Close();

                    tbSN.Clear();
                    tbSN.Focus();
                    timerconsulta();
                 
                   lblTotalCaixa.Text = Convert.ToString(Convert.ToInt32(lblTotalCaixa.Text) + 1);

                    if (Convert.ToInt32(lblQtyCaixa.Text) <= Convert.ToInt32(lblTotalCaixa.Text) || Convert.ToInt32(txttotalOP.Text) <= Convert.ToInt32(lblcont.Text))
                    {
                        if (threadPrincipal != null && threadPrincipal.ThreadState != System.Threading.ThreadState.Stopped)
                        {

                            threadPrincipal = null;


                        }

                        // comandoimpressaoX4();
                        threadPrincipal = new Thread(new ThreadStart(comandoimpressao));
                        CheckForIllegalCrossThreadCalls = false;
                        threadPrincipal.Start();

                        impressaoQTY = Convert.ToInt32(lblTotalCaixa.Text);

                        lblTotalCaixa.Text = "0"; 
                    }

                    if (txttotalOP.Text == "") { }
                    else
                    {
                        if (Convert.ToInt32(lblcont.Text.Trim()) == Convert.ToInt32(txttotalOP.Text) || Convert.ToInt32(txttotalOP.Text) <= Convert.ToInt32(lblcont.Text.Trim())) { tbSN.Enabled = false; txttotalOP.BackColor = Color.LightGreen; }
                        else
                        {
                            txttotalOP.BackColor = Color.Red; tbSN.Enabled = true;
                        }
                    }
                }
            }
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                snenter();
                timerconsulta();
            }
        }

        private void timerconsulta()
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
            lblcont.Text = linhas.ToString();

            metroGrid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //carrega combobox cliente
            SqlConnection con12 = new SqlConnection(Conexao.ROTA);
            SqlCommand comande15 = new SqlCommand("select nome from [FONTE].[dbo].[MODELO_FONTE] where codigo=@cod", con12);
            con12.Open();
            comande15.Parameters.Add("@cod", SqlDbType.VarChar).Value = cbModelo.Text;

            string nome = Convert.ToString(comande15.ExecuteScalar());
            con12.Close();

            lblNomeModelo.Text = nome;
           
            HoraAhora();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timerconsulta();


        }

        private void metroGrid1_MouseHover(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            metroGrid1.ForeColor = Color.Red;
        }

        private void metroGrid1_MouseLeave(object sender, EventArgs e)
        {
           // timer1.Enabled = true;
            metroGrid1.ForeColor = Color.Black;
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

                    MetroMessageBox.Show(this, "Deletado com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    timerconsulta();
                     if (Convert.ToInt32(lblTotalCaixa.Text) <= 0) { }
                     else
                     {
                         lblTotalCaixa.Text = Convert.ToString(Convert.ToInt32(lblTotalCaixa.Text) - 1);
                     }
                    
                    if (txttotalOP.Text == "") { }
                    else
                    {
                        if (Convert.ToInt32(lblcont.Text.Trim()) == Convert.ToInt32(txttotalOP.Text) || Convert.ToInt32(txttotalOP.Text) <= Convert.ToInt32(lblcont.Text.Trim())) { tbSN.Enabled = false; txttotalOP.BackColor = Color.LightGreen; }
                        else
                        {
                            txttotalOP.BackColor = Color.Red; tbSN.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "SN Não encontrado", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void metroGrid1_AutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {

        }

        private void cbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSN.Enabled = true;
            tbSN.Focus();
            //carrega combobox cliente
            SqlConnection con12 = new SqlConnection(Conexao.ROTA);
            SqlCommand comande15 = new SqlCommand("select [qty_caixa] from [FONTE].[dbo].[MODELO_FONTE] where codigo=@cod", con12);
            con12.Open();
            comande15.Parameters.Add("@cod", SqlDbType.VarChar).Value = cbModelo.Text;
            int qtycaixa = Convert.ToInt32(comande15.ExecuteScalar());
            con12.Close();
            if(qtycaixa <= 1)
            {
                qtycaixa = 1;
            }
            int Gramas = 15000;
            string Total = (Gramas / qtycaixa).ToString();
            lblQtyCaixa.Text = Total;
        }

        private void cbhInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            HoraAhora();
        }
        private void HoraAhora()
        {
            if (cbhInicio.Text == "") { }
            else
            {
                string Data;
                Data = Convert.ToString(DateTime.Now.Date);

                SqlConnection cn = new SqlConnection(Conexao.ROTA);
                SqlCommand comande2 = new SqlCommand("SELECT  COUNT(*)  FROM [FONTE].[dbo].[MODELO_INTEGRACAOO] where data_hora >= @datainicio and data_hora <= @datatermino ", cn);

                comande2.Parameters.Add("@datainicio", SqlDbType.VarChar).Value = Data.Substring(0, 10) + " " + cbhInicio.Text + ":" + "00" + ":" + "00";
                comande2.Parameters.Add("@datatermino", SqlDbType.VarChar).Value = Data.Substring(0, 10) + " " + cbhInicio.Text + ":" + "59" + ":" + "00";


                cn.Open();
                lblhorahora.Text = Convert.ToString(comande2.ExecuteScalar());
                cn.Close();
            }


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tbSN.Focus();
            tbSN.BackColor = Color.LightGreen;

        }

        private void txttotalOP_Enter(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            tbSN.BackColor = Color.LightSalmon;
        }

        private void txttotalOP_Leave(object sender, EventArgs e)
        {
            if (txttotalOP.Text == "") { }
            else
            {
                if (Convert.ToInt32(lblcont.Text.Trim()) == Convert.ToInt32(txttotalOP.Text) || Convert.ToInt32(txttotalOP.Text) <= Convert.ToInt32(lblcont.Text.Trim())) { tbSN.Enabled = false; txttotalOP.BackColor = Color.LightGreen; }
                else
                {
                    txttotalOP.BackColor = Color.Red; tbSN.Enabled = true;
                }
            }

            tbSN.BackColor = Color.LightGreen;
            tbSN.Focus();
            tbSN.Select();

        }

        private void cbModelo_Enter(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            tbSN.BackColor = Color.LightSalmon;
        }

        private void cbModelo_Leave(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            tbSN.BackColor = Color.LightGreen;
        }

        private void cbOP_MouseHover(object sender, EventArgs e)
        {

        }

        private void cbOP_MouseLeave(object sender, EventArgs e)
        {

        }

        private void cbOP_Leave(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            tbSN.BackColor = Color.LightGreen;
        }

        private void txttotalOP_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void cbOP_Enter(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            tbSN.BackColor = Color.LightSalmon;
        }

        private void cbOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            tbSN.BackColor = Color.LightGreen;
        }

        private void txttotalOP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {

                e.Handled = true;
            }
        }

        private void cbOP_Enter_1(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            tbSN.BackColor = Color.LightSalmon;
        }

        private void cbOP_Leave_1(object sender, EventArgs e)
        {
            timerconsulta();
        }

        private void cbOP_MouseLeave_1(object sender, EventArgs e)
        {
            
        }

        private void metroComboBox1_Enter(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            tbSN.BackColor = Color.LightSalmon;
        }

        private void metroComboBox1_Leave(object sender, EventArgs e)
        {
       
        }

        //metodo de impressão
        private void comandoimpressao()
        {
            PrintController standart = new StandardPrintController();
            PrintDocument doc = new PrintDocument();
            
            doc.PrintPage += Doc_PrintPage;
            //doc.DocumentName = "ETIQUETA";
            //if (pd.ShowDialog() == DialogResult.OK) doc.Print();
            // Specify the printer to use.
            doc.PrinterSettings.PrinterName = "\\\\ext-av-01\\FONTE"+cblinha.Text.Trim();//*/"Microsoft Print to PDF";//

            if (doc.PrinterSettings.IsValid)
            {

                doc.PrintController = new StandardPrintController();
                doc.Print();
               
                tbSN.Focus();
                impressaoQTY = 0;
            }
            else
            {
                MessageBox.Show("IMPRESSORA INVALIDA");
            }
        }
        
        private void barcodeop()
        { //op----------------------------------------------------------
            BarcodeReader barcodeReader = new BarcodeReader();
            BarcodeWriter barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128
            };
            barcodeWriter.Options.Height = 30;
            barcodeWriter.Options.Width = 200;
            barcodeWriter.Options.PureBarcode = true;

            barcodeReader.Options.PossibleFormats = new List<BarcodeFormat>();
            barcodeReader.Options.PossibleFormats.Add(BarcodeFormat.CODE_128);
            barcodeReader.Options.TryHarder = true;

            var teste = cbOP.Text;

            string content = teste;
            barcodeBitmap = barcodeWriter.Write(content);
            barcodePoint = new Point(1, 90);
        }
        private void barcodeqty()
        { //op----------------------------------------------------------
            BarcodeReader barcodeReader = new BarcodeReader();
            BarcodeWriter barcodeWriter = new BarcodeWriter


            {
                Format = BarcodeFormat.CODE_128
            };

            barcodeWriter.Options.Height = 20;
            barcodeWriter.Options.Width = 150;
            barcodeWriter.Options.PureBarcode = true;

            barcodeReader.Options.PossibleFormats = new List<BarcodeFormat>();
            barcodeReader.Options.PossibleFormats.Add(BarcodeFormat.CODE_128);
            barcodeReader.Options.TryHarder = true;

            var teste = lblTotalCaixa.Text.Trim();

            string content = teste;
            barcodeBitmap1 = barcodeWriter.Write(content);
            barcodePoint1 = new Point(200, 93);
        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            SqlConnection cona = new SqlConnection(Conexao.ROTA);
            SqlCommand comandea = new SqlCommand("Select getdate()", cona);

            cona.Open();
            string DATA = Convert.ToString(comandea.ExecuteScalar());
            cona.Close();


            //dimencionando a etiqueta
            Bitmap bm = new Bitmap(PicEtiqueta.Width, PicEtiqueta.Height);
            PicEtiqueta.DrawToBitmap(bm, new Rectangle(0, 0, PicEtiqueta.Width, PicEtiqueta.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();

            barcodeop();
            barcodeqty();

            //strings da etiqueta
            //nome
            string nomeModelo = "Nome: "+ lblNomeModelo.Text;
            Font letranome = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush cornome = new SolidBrush(Color.Black);
            Point pontonome = new Point(12, 10);
            //modelo
            string modelo = "Código: "+cbModelo.Text;
            Font letramodelo = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush cormodelo = new SolidBrush(Color.Black);
            Point pontomodelo = new Point(12, 36);
            //op
            string op = "OP: "+cbOP.Text;
            Font letraop = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush corop = new SolidBrush(Color.Black);
            Point pontoop = new Point(12, 71);
            //linha
            string linha = "Linha: "+cblinha.Text;
            Font letralinha = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush corlinha = new SolidBrush(Color.Black);
            Point pontolinha = new Point(230, 36);
            //total op--------------
            string totalOp = "QTY OP: "+txttotalOP.Text;
            Font letraTO = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush corTO = new SolidBrush(Color.Black);
            Point pontoTO = new Point(100, 71);
            //total caixa+++++++++++++++++
            string totalCaixa = "QTY CAIXA: " + impressaoQTY.ToString();
            Font letraTC = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush corTC = new SolidBrush(Color.Black);
            Point pontoTC = new Point(220, 71);
            //responsavel
            string responsavel = lblRE.Text;
            Font letraR = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush corR = new SolidBrush(Color.Black);
            Point pontoR = new Point(12, 130);
            //responsavel
 
            Font letraData = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush corData = new SolidBrush(Color.Black);
            Point pontoData = new Point(220, 115);

            //mapeamento da impressão
            e.Graphics.DrawImage(barcodeBitmap, barcodePoint);
            e.Graphics.DrawImage(barcodeBitmap1, barcodePoint1);
            e.Graphics.DrawString(nomeModelo, letranome, cornome, pontonome);
            e.Graphics.DrawString(modelo, letramodelo, cormodelo, pontomodelo);
            e.Graphics.DrawString(op, letraop, corop, pontoop);
            e.Graphics.DrawString(linha, letralinha, corlinha, pontolinha);
            e.Graphics.DrawString(totalOp, letraTO, corTO, pontoTO);
            e.Graphics.DrawString(totalCaixa, letraTC, corTC, pontoTC);
            e.Graphics.DrawString(responsavel, letraR, corR, pontoR);
            e.Graphics.DrawString(DATA, letraData, corData, pontoData);



        }

        private void tbSN_MouseHover(object sender, EventArgs e)
        {          
            metroGrid1.ForeColor = Color.Black;
        }

        private void tbSN_Enter(object sender, EventArgs e)
        {
            tbSN.BackColor = Color.LightGreen;
        }

        private void tbSN_Leave(object sender, EventArgs e)
        {
            tbSN.BackColor = Color.LightSalmon;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void cblinha_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerconsulta();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MetroMessageBox.Show(this, "Deseja realmente zera a caixa?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.No) { }
            else { lblTotalCaixa.Text = "0"; }

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
            if (threadPrincipal != null && threadPrincipal.ThreadState != System.Threading.ThreadState.Stopped)
            {

                threadPrincipal = null;


            }

            // comandoimpressaoX4();
            threadPrincipal = new Thread(new ThreadStart(comandoimpressao));
            CheckForIllegalCrossThreadCalls = false;
            threadPrincipal.Start();

            impressaoQTY = Convert.ToInt32(lblTotalCaixa.Text);

            lblTotalCaixa.Text = "0";
        }
    }
}
