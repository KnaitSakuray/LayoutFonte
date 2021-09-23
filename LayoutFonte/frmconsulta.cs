using Fonte;
using LiveCharts;
using LiveCharts.Wpf;
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
using System.Threading;
using System.Windows.Forms;

namespace LayoutFonte
{
    public partial class frmconsulta : Form
    {
        Thread threadPrincipal;
        public frmconsulta()
        {
            InitializeComponent();
            graficoDiasASB1();
            graficoDiasASB2();
            graficoHoraASB1();
            graficoHoraASB2();
        }

        private void frmconsulta_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddDays(-1);

            graficoDias();
            graficoHora();
            dthInicio.Format = DateTimePickerFormat.Custom;
            dthInicio.CustomFormat = "dd/MM/yyyy";

            dthFinal.Format = DateTimePickerFormat.Custom;
            dthFinal.CustomFormat = "dd/MM/yyyy";

            dthInicio.Value = DateTime.Now.Date;
            dthFinal.Value = DateTime.Now.Date;
        }

        private void ckbSIM_CheckedChanged(object sender, EventArgs e)
        {
            ckdNAO.Checked = false;
            PainelData.Visible = true;
            if (ckbSIM.Checked == false) { PainelData.Visible = false; }
        }

        private void ckdNAO_CheckedChanged(object sender, EventArgs e)
        {
            ckbSIM.Checked = false;
            PainelData.Visible = false;
            if (ckbSIM.Checked == false) { PainelData.Visible = false; }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Relatorio();

            graficoDias();
            graficoHora();
        }

        private void Relatorio()
        {
            if (cbV1.Text == "") { MetroMessageBox.Show(this, "Por favor preencher a opção de pesquisa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            {
                if (PainelData.Visible == true)
                {
                 
                    if (cbV1.Text == "TODOS")
                    {
                        SqlConnection cn = new SqlConnection(Conexao.ROTA);
                        SqlCommand comande2 = new SqlCommand("SELECT  [SN],[MODELO],[OP],[data_hora],[usuario] FROM [FONTE].[dbo].[MODELO_INTEGRACAOO] where data_hora >= @datainicio and data_hora <= @datatermino ", cn);

                        comande2.Parameters.Add("@datainicio", SqlDbType.VarChar).Value = dthInicio.Value.ToShortDateString() + " " + cbhInicio.Text + ":" + cbMInicio.Text + ":" + "00";
                        comande2.Parameters.Add("@datatermino", SqlDbType.VarChar).Value = dthFinal.Value.ToShortDateString() + " " + cbhFinal.Text + ":" + cbMFinal.Text + ":" + "00";
                        lblDataInicio.Text= dthInicio.Value.ToShortDateString() + " " + cbhInicio.Text + ":" + cbMInicio.Text + ":" + "00";
                        lblDataFinal.Text= dthFinal.Value.ToShortDateString() + " " + cbhFinal.Text + ":" + cbMFinal.Text + ":" + "00";

                        cn.Open();

                        SqlDataReader dr = comande2.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        metroGrid1.DataSource = dt;

                        cn.Close();
                        int linhas = dt.Rows.Count;
                        lbltoralcont1.Text = linhas.ToString();
                    }
                    else
                    {

                        SqlConnection cn = new SqlConnection(Conexao.ROTA);
                        SqlCommand comande2 = new SqlCommand("SELECT  [SN],[MODELO],[OP],[data_hora],[usuario] FROM [FONTE].[dbo].[MODELO_INTEGRACAOO] where " + cbV1.Text + "=@v1 and data_hora >= @datainicio and data_hora <= @datatermino ", cn);

                        cn.Open();

                        comande2.Parameters.Add("@v1", SqlDbType.VarChar).Value = tbUsuario.Text;
                        comande2.Parameters.Add("@datainicio", SqlDbType.VarChar).Value = dthInicio.Value.ToShortDateString() + " " + cbhInicio.Text + ":" + cbMInicio.Text + ":" + "00";
                        comande2.Parameters.Add("@datatermino", SqlDbType.VarChar).Value = dthFinal.Value.ToShortDateString() + " " + cbhFinal.Text + ":" + cbMFinal.Text + ":" + "00";
                        lblDataInicio.Text = dthInicio.Value.ToShortDateString() + " " + cbhInicio.Text + ":" + cbMInicio.Text + ":" + "00";
                        lblDataFinal.Text = dthFinal.Value.ToShortDateString() + " " + cbhFinal.Text + ":" + cbMFinal.Text + ":" + "00";

                        SqlDataReader dr = comande2.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        metroGrid1.DataSource = dt;

                        cn.Close();
                        int linhas = dt.Rows.Count;
                        lbltoralcont1.Text = linhas.ToString();
                    }
                }
                else
                {

                    if (cbV1.Text == "TODOS")
                    {
                        SqlConnection cn = new SqlConnection(Conexao.ROTA);
                        SqlCommand comande2 = new SqlCommand("SELECT  [SN],[MODELO],[OP],[data_hora],[usuario] FROM [FONTE].[dbo].[MODELO_INTEGRACAOO] order by sn desc  ", cn);

                        cn.Open();



                        SqlDataReader dr = comande2.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        metroGrid1.DataSource = dt;

                        cn.Close();
                        int linhas = dt.Rows.Count;
                        lbltoralcont1.Text = linhas.ToString();
                    }
                    else
                    {

                        SqlConnection cn = new SqlConnection(Conexao.ROTA);
                        SqlCommand comande2 = new SqlCommand("SELECT  [SN],[MODELO],[OP],[data_hora],[usuario] FROM [FONTE].[dbo].[MODELO_INTEGRACAOO] where " + cbV1.Text + "=@v1  ", cn);

                        cn.Open();

                        comande2.Parameters.Add("@v1", SqlDbType.VarChar).Value = tbUsuario.Text;

                        SqlDataReader dr = comande2.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        metroGrid1.DataSource = dt;

                        cn.Close();
                        int linhas = dt.Rows.Count;
                        lbltoralcont1.Text = linhas.ToString();
                    }
                }
            }
        }

        private void cbV1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblopcao.Text = cbV1.Text;
        }

        private void dthInicio_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Font font = new Font("Itálico", 10.0f);
            DataGridViewRow row = metroGrid1.Rows[e.RowIndex];
            row.DefaultCellStyle.ForeColor = Color.Black;
            row.DefaultCellStyle.Font = font;
        }

        private void tbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Relatorio();
                graficoDias();
            }
        }
        private void graficoHora() 
        {
            cartesianChart2.Series.Clear();
            cartesianChart2.AxisX.Clear();
            cartesianChart2.AxisY.Clear();

            using (FONTEEntitiesHoras db = new FONTEEntitiesHoras())
            {

                var data = db.GetHoras();
                ColumnSeries col = new ColumnSeries()
                {
                    DataLabels = true,
                    Values = new ChartValues<int>(),
                    LabelPoint = Point => Point.Y.ToString(),
                    StrokeThickness = 30,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 128, 0)),

                    //Fill = System.Windows.Media.Brushes.LightSteelBlue,
                    //LineSmoothness = 10,
                    //PointGeometrySize = 12,
                    FontSize = 10,

                };
                Axis ax = new Axis()
                {
                    FontSize = 14,

                    Title = "HORARIOS",
                    Separator = new Separator()
                    {
                        Step = 1,
                        IsEnabled = false,
                    }
                };


                ax.Labels = new List<string>();

                foreach (var x in data)
                {

                    col.Values.Add(x.total.Value);
                    ax.Labels.Add(x.hora.ToString());

                }


                cartesianChart2.Series.Add(col);
                cartesianChart2.AxisX.Add(ax);
                cartesianChart2.AxisY.Add(new Axis
                {

                    FontSize = 14,

                    Title = "QUANTIDADE",
                    LabelFormatter = value => value.ToString(),
                    Separator = new Separator(),
                }

                );

            }
        }
        private void graficoHoraASB1()
        {
            cartesianChartHoraASB1.Series.Clear();
            cartesianChartHoraASB1.AxisX.Clear();
            cartesianChartHoraASB1.AxisY.Clear();

            using (FONTEEntitiesHorasASB db = new FONTEEntitiesHorasASB())
            {

                var data = db.GetHotasFonteASB1();
                ColumnSeries col = new ColumnSeries()
                {
                    DataLabels = true,
                    Values = new ChartValues<int>(),
                    LabelPoint = Point => Point.Y.ToString(),
                    StrokeThickness = 30,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 128, 0)),

                    //Fill = System.Windows.Media.Brushes.LightSteelBlue,
                    //LineSmoothness = 10,
                    //PointGeometrySize = 12,
                    FontSize = 10,

                };
                Axis ax = new Axis()
                {
                    FontSize = 14,

                    Title = "HORARIOS",
                    Separator = new Separator()
                    {
                        Step = 1,
                        IsEnabled = false,
                    }
                };


                ax.Labels = new List<string>();

                foreach (var x in data)
                {

                    col.Values.Add(x.total.Value);
                    ax.Labels.Add(x.hora.ToString());

                }


                cartesianChartHoraASB1.Series.Add(col);
                cartesianChartHoraASB1.AxisX.Add(ax);
                cartesianChartHoraASB1.AxisY.Add(new Axis
                {

                    FontSize = 14,

                    Title = "QUANTIDADE",
                    LabelFormatter = value => value.ToString(),
                    Separator = new Separator(),
                }

                );

            }
        }
        private void graficoHoraASB2()
        {
            cartesianChartHoraASB2.Series.Clear();
            cartesianChartHoraASB2.AxisX.Clear();
            cartesianChartHoraASB2.AxisY.Clear();

            using (FONTEEntitiesHorasASB db = new FONTEEntitiesHorasASB())
            {

                var data = db.GetHotasFonteASB2();
                ColumnSeries col = new ColumnSeries()
                {
                    DataLabels = true,
                    Values = new ChartValues<int>(),
                    LabelPoint = Point => Point.Y.ToString(),
                    StrokeThickness = 30,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 128, 0)),

                    //Fill = System.Windows.Media.Brushes.LightSteelBlue,
                    //LineSmoothness = 10,
                    //PointGeometrySize = 12,
                    FontSize = 10,

                };
                Axis ax = new Axis()
                {
                    FontSize = 14,

                    Title = "HORARIOS",
                    Separator = new Separator()
                    {
                        Step = 1,
                        IsEnabled = false,
                    }
                };


                ax.Labels = new List<string>();

                foreach (var x in data)
                {

                    col.Values.Add(x.total.Value);
                    ax.Labels.Add(x.hora.ToString());

                }


                cartesianChartHoraASB2.Series.Add(col);
                cartesianChartHoraASB2.AxisX.Add(ax);
                cartesianChartHoraASB2.AxisY.Add(new Axis
                {

                    FontSize = 14,

                    Title = "QUANTIDADE",
                    LabelFormatter = value => value.ToString(),
                    Separator = new Separator(),
                }

                );

            }
        }
        private void graficoDias() 
        {
            

            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            using (FONTEEntitiesDias db = new FONTEEntitiesDias())
            {

                var data = db.GetDiasFonte();
                ColumnSeries col = new ColumnSeries() { DataLabels = true, Values = new ChartValues<int>(), LabelPoint = Point => Point.Y.ToString(),

                    StrokeThickness = 30,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 128, 0)),
                    
                    //Fill = System.Windows.Media.Brushes.LightSteelBlue,
                    //LineSmoothness = 10,
                    //PointGeometrySize = 12,
                    FontSize = 10,

                };
                LineSeries col1 = new LineSeries()
                {
                    DataLabels = true,
                    Values = new ChartValues<int>(),
                    LabelPoint = Point => Point.Y.ToString(),

                    StrokeThickness = 30,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(200, 128, 0)),

                    //Fill = System.Windows.Media.Brushes.LightSteelBlue,
                    //LineSmoothness = 10,
                    //PointGeometrySize = 12,
                    FontSize = 10,

                };
                Axis ax = new Axis() {
                    FontSize = 14,
       
                    Title = "DIAS",
                    Separator = new Separator() { Step = 1, IsEnabled = false,
                    } };


                ax.Labels = new List<string>();

                foreach (var x in data)
                {

                    col.Values.Add(x.total.Value);
                    ax.Labels.Add(x.DIA.ToString());

                }


                cartesianChart1.Series.Add(col);
                cartesianChart1.Series.Add(col1);
                cartesianChart1.AxisX.Add(ax);
                cartesianChart1.AxisY.Add(new Axis
                {

                    FontSize = 14,
                   
                    Title = "QUANTIDADE",
                    LabelFormatter = value => value.ToString(),
                    Separator = new Separator(),
                }

                );

            }


        }
        private void graficoDiasASB1()
        {


            cartesianChartASB1.Series.Clear();
            cartesianChartASB1.AxisX.Clear();
            cartesianChartASB1.AxisY.Clear();

            using (FONTEEntities db = new FONTEEntities())
            {

                var data = db.GetDiasFonteAB1();

                ColumnSeries col = new ColumnSeries()
                {
                    DataLabels = true,
                    Values = new ChartValues<int>(),
                    LabelPoint = Point => Point.Y.ToString(),
                    StrokeThickness = 30,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 128, 0)),

                    //Fill = System.Windows.Media.Brushes.LightSteelBlue,
                    //LineSmoothness = 10,
                    //PointGeometrySize = 12,
                    FontSize = 10,

                };
                Axis ax = new Axis()
                {
                    FontSize = 14,

                    Title = "DIAS",
                    Separator = new Separator()
                    {
                        Step = 1,
                        IsEnabled = false,
                    }
                };


                ax.Labels = new List<string>();

                foreach (var x in data)
                {

                    col.Values.Add(x.total.Value);
                    ax.Labels.Add(x.DIA.ToString());

                }


                cartesianChartASB1.Series.Add(col);
                cartesianChartASB1.AxisX.Add(ax);
                cartesianChartASB1.AxisY.Add(new Axis
                {

                    FontSize = 14,

                    Title = "QUANTIDADE",
                    LabelFormatter = value => value.ToString(),
                    Separator = new Separator(),
                }

                );

            }


        }
        private void graficoDiasASB2()
        {


            cartesianChartASB2.Series.Clear();
            cartesianChartASB2.AxisX.Clear();
            cartesianChartASB2.AxisY.Clear();

            using (FONTEEntities db = new FONTEEntities())
            {

                var data = db.GetDiasFonteAB2();
                ColumnSeries col = new ColumnSeries()
                {
                    DataLabels = true,
                    Values = new ChartValues<int>(),
                    LabelPoint = Point => Point.Y.ToString(),

                    StrokeThickness = 30,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 128, 0)),

                    //Fill = System.Windows.Media.Brushes.LightSteelBlue,
                    //LineSmoothness = 10,
                    //PointGeometrySize = 12,
                    FontSize = 10,

                };
               
                Axis ax = new Axis()
                {
                    FontSize = 14,

                    Title = "DIAS",
                    Separator = new Separator()
                    {
                        Step = 1,
                        IsEnabled = false,
                    }
                };


                ax.Labels = new List<string>();

                foreach (var x in data)
                {

                    col.Values.Add(x.total.Value);
                    ax.Labels.Add(x.DIA.ToString());

                }


                cartesianChartASB2.Series.Add(col);
                cartesianChartASB2.AxisX.Add(ax);
                cartesianChartASB2.AxisY.Add(new Axis
                {

                    FontSize = 14,

                    Title = "QUANTIDADE",
                    LabelFormatter = value => value.ToString(),
                    Separator = new Separator(),
                }

                );

            }


        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(metroTabControl1.SelectedTab == metroTabPage3)  graficoDias(); 
            if (metroTabControl1.SelectedTab == metroTabPage5) graficoDiasASB1();
            if (metroTabControl1.SelectedTab == metroTabPage6) graficoDiasASB2();
            if (metroTabControl1.SelectedTab == metroTabPage7) graficoHoraASB1();
            if (metroTabControl1.SelectedTab == metroTabPage8) graficoHoraASB2();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graficoDias();
            graficoHora();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            graficoDiasASB2();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            graficoDiasASB1();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            graficoHoraASB1();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            graficoHoraASB2();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection conecta = new SqlConnection(Conexao.ROTA);
            SqlCommand comande = new SqlCommand(@"select distinct op as OP, count(sn) as [TOTAL PRODUZIDO]
FROM [FONTE].[dbo].MODELO_INTEGRACAOO
where data_hora>=@dhI and data_hora<=@dhF
group by op
order by op", conecta);
            comande.Parameters.Add("@dhI", SqlDbType.VarChar).Value = dateTimePicker2.Value.ToString().Substring(0, 10) + " 04:00:00";
            comande.Parameters.Add("@dhF", SqlDbType.VarChar).Value = dateTimePicker1.Value.ToString().Substring(0, 10) + " 04:00:00";

            conecta.Open();

            SqlDataReader dr = comande.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Font font = new Font("Segoe UI", 12.0f);
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            row.DefaultCellStyle.ForeColor = Color.Black;
            row.DefaultCellStyle.Font = font;
        }
    }
}
