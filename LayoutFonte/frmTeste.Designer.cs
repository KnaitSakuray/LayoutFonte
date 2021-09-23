
namespace Fonte
{
    partial class frmTeste
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

        private void InitializeComponent()
        {
            {
                this.components = new System.ComponentModel.Container();
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
                this.txtOP = new System.Windows.Forms.TextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.cbModelo = new MetroFramework.Controls.MetroComboBox();
                this.label2 = new System.Windows.Forms.Label();
                this.cblinha = new MetroFramework.Controls.MetroComboBox();
                this.label3 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.lblProd = new System.Windows.Forms.Label();
                this.panel1 = new System.Windows.Forms.Panel();
                this.panel2 = new System.Windows.Forms.Panel();
                this.tbSN = new MetroFramework.Controls.MetroTextBox();
                this.label6 = new System.Windows.Forms.Label();
                this.panel3 = new System.Windows.Forms.Panel();
                this.panel6 = new System.Windows.Forms.Panel();
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.panel8 = new System.Windows.Forms.Panel();
                this.lblResposta = new System.Windows.Forms.Label();
                this.label8 = new System.Windows.Forms.Label();
                this.panel5 = new System.Windows.Forms.Panel();
                this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
                this.lblStatus = new System.Windows.Forms.Label();
                this.metroButton2 = new MetroFramework.Controls.MetroButton();
                this.metroButton1 = new MetroFramework.Controls.MetroButton();
                this.label9 = new System.Windows.Forms.Label();
                this.panelAviso = new System.Windows.Forms.Panel();
                this.lblAviso = new System.Windows.Forms.Label();
                this.panel7 = new System.Windows.Forms.Panel();
                this.listBox1 = new System.Windows.Forms.ListBox();
                this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
                this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
                this.button1 = new System.Windows.Forms.Button();
                this.panel1.SuspendLayout();
                this.panel3.SuspendLayout();
                this.panel6.SuspendLayout();
                this.panel5.SuspendLayout();
                this.panelAviso.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
                this.SuspendLayout();
                // 
                // txtOP
                // 
                this.txtOP.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtOP.Location = new System.Drawing.Point(464, 22);
                this.txtOP.Name = "txtOP";
                this.txtOP.Size = new System.Drawing.Size(165, 33);
                this.txtOP.TabIndex = 0;
                this.txtOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                this.txtOP.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                this.txtOP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label1.Location = new System.Drawing.Point(412, 25);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(46, 25);
                this.label1.TabIndex = 1;
                this.label1.Text = "OP :";
                // 
                // cbModelo
                // 
                this.cbModelo.FontSize = MetroFramework.MetroComboBoxSize.Tall;
                this.cbModelo.FormattingEnabled = true;
                this.cbModelo.ItemHeight = 29;
                this.cbModelo.Location = new System.Drawing.Point(146, 21);
                this.cbModelo.Name = "cbModelo";
                this.cbModelo.Size = new System.Drawing.Size(241, 35);
                this.cbModelo.TabIndex = 3;
                this.cbModelo.UseSelectable = true;
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label2.Location = new System.Drawing.Point(43, 25);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(97, 25);
                this.label2.TabIndex = 4;
                this.label2.Text = "MODELO :";
                // 
                // cblinha
                // 
                this.cblinha.FontSize = MetroFramework.MetroComboBoxSize.Tall;
                this.cblinha.FormattingEnabled = true;
                this.cblinha.ItemHeight = 29;
                this.cblinha.Items.AddRange(new object[] {
            "ASB1",
            "ASB2"});
                this.cblinha.Location = new System.Drawing.Point(736, 21);
                this.cblinha.Name = "cblinha";
                this.cblinha.Size = new System.Drawing.Size(87, 35);
                this.cblinha.TabIndex = 48;
                this.cblinha.UseSelectable = true;
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label3.Location = new System.Drawing.Point(656, 25);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(74, 25);
                this.label3.TabIndex = 49;
                this.label3.Text = "LINHA :";
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label4.Location = new System.Drawing.Point(863, 25);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(126, 25);
                this.label4.TabIndex = 50;
                this.label4.Text = "PRODUZIDO :";
                // 
                // lblProd
                // 
                this.lblProd.AutoSize = true;
                this.lblProd.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblProd.Location = new System.Drawing.Point(995, 25);
                this.lblProd.Name = "lblProd";
                this.lblProd.Size = new System.Drawing.Size(24, 25);
                this.lblProd.TabIndex = 51;
                this.lblProd.Text = "...";
                // 
                // panel1
                // 
                this.panel1.BackColor = System.Drawing.Color.White;
                this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.panel1.Controls.Add(this.panel2);
                this.panel1.Controls.Add(this.lblProd);
                this.panel1.Controls.Add(this.label4);
                this.panel1.Controls.Add(this.label3);
                this.panel1.Controls.Add(this.cblinha);
                this.panel1.Controls.Add(this.label2);
                this.panel1.Controls.Add(this.cbModelo);
                this.panel1.Controls.Add(this.label1);
                this.panel1.Controls.Add(this.txtOP);
                this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
                this.panel1.Location = new System.Drawing.Point(0, 0);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(1155, 78);
                this.panel1.TabIndex = 52;
                // 
                // panel2
                // 
                this.panel2.BackgroundImage = global::Fonte.Properties.Resources.iconfinder_weather_weather_forecast_lightning_storm_energy_3859139_121230;
                this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
                this.panel2.Location = new System.Drawing.Point(1074, 0);
                this.panel2.Name = "panel2";
                this.panel2.Size = new System.Drawing.Size(79, 76);
                this.panel2.TabIndex = 52;
                // 
                // tbSN
                // 
                // 
                // 
                // 
                this.tbSN.CustomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.tbSN.CustomButton.Image = null;
                this.tbSN.CustomButton.Location = new System.Drawing.Point(334, 2);
                this.tbSN.CustomButton.Name = "";
                this.tbSN.CustomButton.Size = new System.Drawing.Size(35, 35);
                this.tbSN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
                this.tbSN.CustomButton.TabIndex = 1;
                this.tbSN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
                this.tbSN.CustomButton.UseSelectable = true;
                this.tbSN.CustomButton.Visible = false;
                this.tbSN.FontSize = MetroFramework.MetroTextBoxSize.Tall;
                this.tbSN.Lines = new string[0];
                this.tbSN.Location = new System.Drawing.Point(35, 62);
                this.tbSN.MaxLength = 32767;
                this.tbSN.Name = "tbSN";
                this.tbSN.PasswordChar = '\0';
                this.tbSN.ScrollBars = System.Windows.Forms.ScrollBars.None;
                this.tbSN.SelectedText = "";
                this.tbSN.SelectionLength = 0;
                this.tbSN.SelectionStart = 0;
                this.tbSN.ShortcutsEnabled = true;
                this.tbSN.Size = new System.Drawing.Size(372, 40);
                this.tbSN.TabIndex = 53;
                this.tbSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                this.tbSN.UseCustomBackColor = true;
                this.tbSN.UseCustomForeColor = true;
                this.tbSN.UseSelectable = true;
                this.tbSN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
                this.tbSN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 66.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.tbSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSN_KeyPress);
                // 
                // label6
                // 
                this.label6.AutoSize = true;
                this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label6.Location = new System.Drawing.Point(30, 34);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(37, 25);
                this.label6.TabIndex = 54;
                this.label6.Text = "SN";
                // 
                // panel3
                // 
                this.panel3.Controls.Add(this.button1);
                this.panel3.Controls.Add(this.panel6);
                this.panel3.Controls.Add(this.panel5);
                this.panel3.Controls.Add(this.label6);
                this.panel3.Controls.Add(this.tbSN);
                this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
                this.panel3.Location = new System.Drawing.Point(0, 78);
                this.panel3.Name = "panel3";
                this.panel3.Size = new System.Drawing.Size(1155, 160);
                this.panel3.TabIndex = 55;
                // 
                // panel6
                // 
                this.panel6.Controls.Add(this.textBox1);
                this.panel6.Controls.Add(this.panel8);
                this.panel6.Controls.Add(this.lblResposta);
                this.panel6.Controls.Add(this.label8);
                this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
                this.panel6.Location = new System.Drawing.Point(418, 0);
                this.panel6.Name = "panel6";
                this.panel6.Size = new System.Drawing.Size(349, 160);
                this.panel6.TabIndex = 56;
                // 
                // textBox1
                // 
                this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.textBox1.Enabled = false;
                this.textBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.textBox1.Location = new System.Drawing.Point(0, 122);
                this.textBox1.Name = "textBox1";
                this.textBox1.ReadOnly = true;
                this.textBox1.Size = new System.Drawing.Size(349, 26);
                this.textBox1.TabIndex = 63;
                this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                // 
                // panel8
                // 
                this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.panel8.Location = new System.Drawing.Point(0, 148);
                this.panel8.Name = "panel8";
                this.panel8.Size = new System.Drawing.Size(349, 12);
                this.panel8.TabIndex = 7;
                // 
                // lblResposta
                // 
                this.lblResposta.AutoSize = true;
                this.lblResposta.BackColor = System.Drawing.Color.White;
                this.lblResposta.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblResposta.Location = new System.Drawing.Point(82, 74);
                this.lblResposta.MinimumSize = new System.Drawing.Size(179, 25);
                this.lblResposta.Name = "lblResposta";
                this.lblResposta.Size = new System.Drawing.Size(179, 25);
                this.lblResposta.TabIndex = 6;
                this.lblResposta.Text = "AGUARDANDO";
                this.lblResposta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // label8
                // 
                this.label8.AutoSize = true;
                this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label8.Location = new System.Drawing.Point(77, 3);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(199, 25);
                this.label8.TabIndex = 5;
                this.label8.Text = "RESULTADO DO TESTE";
                // 
                // panel5
                // 
                this.panel5.Controls.Add(this.metroComboBox1);
                this.panel5.Controls.Add(this.lblStatus);
                this.panel5.Controls.Add(this.metroButton2);
                this.panel5.Controls.Add(this.metroButton1);
                this.panel5.Controls.Add(this.label9);
                this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
                this.panel5.Location = new System.Drawing.Point(767, 0);
                this.panel5.Name = "panel5";
                this.panel5.Size = new System.Drawing.Size(388, 160);
                this.panel5.TabIndex = 55;
                // 
                // metroComboBox1
                // 
                this.metroComboBox1.FontSize = MetroFramework.MetroComboBoxSize.Tall;
                this.metroComboBox1.FormattingEnabled = true;
                this.metroComboBox1.ItemHeight = 29;
                this.metroComboBox1.Items.AddRange(new object[] {
            "ASB1",
            "ASB2"});
                this.metroComboBox1.Location = new System.Drawing.Point(145, 122);
                this.metroComboBox1.Name = "metroComboBox1";
                this.metroComboBox1.Size = new System.Drawing.Size(108, 35);
                this.metroComboBox1.TabIndex = 49;
                this.metroComboBox1.UseSelectable = true;
                // 
                // lblStatus
                // 
                this.lblStatus.AutoSize = true;
                this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblStatus.ForeColor = System.Drawing.Color.Green;
                this.lblStatus.Location = new System.Drawing.Point(157, 28);
                this.lblStatus.MinimumSize = new System.Drawing.Size(82, 25);
                this.lblStatus.Name = "lblStatus";
                this.lblStatus.Size = new System.Drawing.Size(82, 25);
                this.lblStatus.TabIndex = 9;
                this.lblStatus.Text = "ONLINE";
                this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // metroButton2
                // 
                this.metroButton2.BackColor = System.Drawing.Color.Salmon;
                this.metroButton2.Enabled = false;
                this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Medium;
                this.metroButton2.Location = new System.Drawing.Point(144, 93);
                this.metroButton2.Name = "metroButton2";
                this.metroButton2.Size = new System.Drawing.Size(109, 23);
                this.metroButton2.TabIndex = 8;
                this.metroButton2.Text = "DESCONECTAR";
                this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Light;
                this.metroButton2.UseCustomBackColor = true;
                this.metroButton2.UseCustomForeColor = true;
                this.metroButton2.UseSelectable = true;
                this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
                // 
                // metroButton1
                // 
                this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
                this.metroButton1.Location = new System.Drawing.Point(144, 64);
                this.metroButton1.Name = "metroButton1";
                this.metroButton1.Size = new System.Drawing.Size(109, 23);
                this.metroButton1.TabIndex = 7;
                this.metroButton1.Text = "CONECTAR";
                this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
                this.metroButton1.UseCustomBackColor = true;
                this.metroButton1.UseCustomForeColor = true;
                this.metroButton1.UseSelectable = true;
                this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
                // 
                // label9
                // 
                this.label9.AutoSize = true;
                this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label9.Location = new System.Drawing.Point(157, 3);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(75, 25);
                this.label9.TabIndex = 6;
                this.label9.Text = "STATUS";
                // 
                // panelAviso
                // 
                this.panelAviso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.panelAviso.Controls.Add(this.lblAviso);
                this.panelAviso.Dock = System.Windows.Forms.DockStyle.Top;
                this.panelAviso.Location = new System.Drawing.Point(0, 238);
                this.panelAviso.Name = "panelAviso";
                this.panelAviso.Size = new System.Drawing.Size(1155, 81);
                this.panelAviso.TabIndex = 56;
                // 
                // lblAviso
                // 
                this.lblAviso.AutoSize = true;
                this.lblAviso.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblAviso.Location = new System.Drawing.Point(54, 19);
                this.lblAviso.MinimumSize = new System.Drawing.Size(1043, 37);
                this.lblAviso.Name = "lblAviso";
                this.lblAviso.Size = new System.Drawing.Size(1043, 37);
                this.lblAviso.TabIndex = 5;
                this.lblAviso.Text = "AVISOS";
                this.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.lblAviso.UseMnemonic = false;
                // 
                // panel7
                // 
                this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
                this.panel7.Location = new System.Drawing.Point(0, 319);
                this.panel7.Name = "panel7";
                this.panel7.Size = new System.Drawing.Size(35, 314);
                this.panel7.TabIndex = 57;
                // 
                // listBox1
                // 
                this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
                this.listBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.listBox1.FormattingEnabled = true;
                this.listBox1.ItemHeight = 30;
                this.listBox1.Location = new System.Drawing.Point(35, 319);
                this.listBox1.Name = "listBox1";
                this.listBox1.Size = new System.Drawing.Size(374, 314);
                this.listBox1.TabIndex = 58;
                // 
                // metroGrid1
                // 
                this.metroGrid1.AllowUserToOrderColumns = true;
                this.metroGrid1.AllowUserToResizeRows = false;
                this.metroGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
                this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
                this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
                dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
                dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
                dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
                dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
                this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
                dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
                dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
                dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle5;
                this.metroGrid1.Dock = System.Windows.Forms.DockStyle.Right;
                this.metroGrid1.EnableHeadersVisualStyles = false;
                this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                this.metroGrid1.Location = new System.Drawing.Point(560, 319);
                this.metroGrid1.Name = "metroGrid1";
                this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
                dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
                dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
                dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
                dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
                this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                this.metroGrid1.Size = new System.Drawing.Size(595, 314);
                this.metroGrid1.Style = MetroFramework.MetroColorStyle.Orange;
                this.metroGrid1.TabIndex = 59;
                this.metroGrid1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.metroGrid1_CellFormatting);
                // 
                // serialPort1
                // 
                this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
                // 
                // button1
                // 
                this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.button1.Location = new System.Drawing.Point(390, 136);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(22, 21);
                this.button1.TabIndex = 57;
                this.button1.UseVisualStyleBackColor = true;
                // 
                // frmTeste
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.White;
                this.ClientSize = new System.Drawing.Size(1155, 633);
                this.Controls.Add(this.metroGrid1);
                this.Controls.Add(this.listBox1);
                this.Controls.Add(this.panel7);
                this.Controls.Add(this.panelAviso);
                this.Controls.Add(this.panel3);
                this.Controls.Add(this.panel1);
                this.Name = "frmTeste";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "frmTeste";
                this.Load += new System.EventHandler(this.frmTeste_Load);
                this.panel1.ResumeLayout(false);
                this.panel1.PerformLayout();
                this.panel3.ResumeLayout(false);
                this.panel3.PerformLayout();
                this.panel6.ResumeLayout(false);
                this.panel6.PerformLayout();
                this.panel5.ResumeLayout(false);
                this.panel5.PerformLayout();
                this.panelAviso.ResumeLayout(false);
                this.panelAviso.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
                this.ResumeLayout(false);

            }
        }

        #endregion

        private System.Windows.Forms.TextBox txtOP;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox cbModelo;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroComboBox cblinha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroTextBox tbSN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelAviso;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblResposta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStatus;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.Label label9;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel8;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private System.Windows.Forms.Button button1;
    }
}