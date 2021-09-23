
namespace Fonte
{
    partial class frmDelete
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
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.tbSN = new MetroFramework.Controls.MetroTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cbOP = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(572, 69);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(110, 25);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "DELETAR SN";
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
            this.tbSN.Location = new System.Drawing.Point(572, 97);
            this.tbSN.MaxLength = 32767;
            this.tbSN.Name = "tbSN";
            this.tbSN.PasswordChar = '\0';
            this.tbSN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbSN.SelectedText = "";
            this.tbSN.SelectionLength = 0;
            this.tbSN.SelectionStart = 0;
            this.tbSN.ShortcutsEnabled = true;
            this.tbSN.Size = new System.Drawing.Size(372, 40);
            this.tbSN.TabIndex = 9;
            this.tbSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSN.UseCustomBackColor = true;
            this.tbSN.UseCustomForeColor = true;
            this.tbSN.UseSelectable = true;
            this.tbSN.UseStyleColors = true;
            this.tbSN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbSN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 66.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSN_KeyPress);
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 30;
            this.listBox1.Location = new System.Drawing.Point(572, 180);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(372, 302);
            this.listBox1.TabIndex = 13;
            // 
            // cbOP
            // 
            // 
            // 
            // 
            this.cbOP.CustomButton.Image = null;
            this.cbOP.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.cbOP.CustomButton.Name = "";
            this.cbOP.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.cbOP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.cbOP.CustomButton.TabIndex = 1;
            this.cbOP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cbOP.CustomButton.UseSelectable = true;
            this.cbOP.CustomButton.Visible = false;
            this.cbOP.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.cbOP.Lines = new string[0];
            this.cbOP.Location = new System.Drawing.Point(12, 41);
            this.cbOP.MaxLength = 5;
            this.cbOP.Name = "cbOP";
            this.cbOP.PasswordChar = '\0';
            this.cbOP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cbOP.SelectedText = "";
            this.cbOP.SelectionLength = 0;
            this.cbOP.SelectionStart = 0;
            this.cbOP.ShortcutsEnabled = true;
            this.cbOP.Size = new System.Drawing.Size(154, 29);
            this.cbOP.TabIndex = 46;
            this.cbOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cbOP.UseSelectable = true;
            this.cbOP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cbOP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(12, 9);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(131, 25);
            this.metroLabel2.TabIndex = 45;
            this.metroLabel2.Text = "LOCALIZAR OP";
            // 
            // metroButton1
            // 
            this.metroButton1.BackgroundImage = global::Fonte.Properties.Resources.searchzoomflat_106031;
            this.metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton1.Location = new System.Drawing.Point(172, 36);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(42, 37);
            this.metroButton1.TabIndex = 54;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
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
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(12, 97);
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
            this.metroGrid1.Size = new System.Drawing.Size(532, 385);
            this.metroGrid1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroGrid1.TabIndex = 55;
            this.metroGrid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellContentClick);
            this.metroGrid1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.metroGrid1_CellFormatting);
            // 
            // frmDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1025, 530);
            this.Controls.Add(this.metroGrid1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.cbOP);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.tbSN);
            this.Name = "frmDelete";
            this.Text = "frmDelete";
            this.Load += new System.EventHandler(this.frmDelete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox tbSN;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroTextBox cbOP;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroGrid metroGrid1;
    }
}