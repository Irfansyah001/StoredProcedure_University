namespace CRUDSederhana
{
    partial class FormKeuangan
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

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label1 = new System.Windows.Forms.Label();
            this.chartKeuangan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbJenis = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGoOrganisasi = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartKeuangan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(160, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dashboard Keuangan ORMAWA";
            // 
            // chartKeuangan
            // 
            this.chartKeuangan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelStyle.Angle = -45;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            chartArea1.AxisX.Title = "Organisasi";
            chartArea1.AxisY.LabelStyle.Format = "Rp#,0";
            chartArea1.AxisY.Title = "Jumlah (Rp)";
            chartArea1.Name = "ChartArea1";
            this.chartKeuangan.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartKeuangan.Legends.Add(legend1);
            this.chartKeuangan.Location = new System.Drawing.Point(36, 125);
            this.chartKeuangan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartKeuangan.Name = "chartKeuangan";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.ForestGreen;
            series1.Legend = "Legend1";
            series1.Name = "Pemasukan";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Firebrick;
            series2.Legend = "Legend1";
            series2.Name = "Pengeluaran";
            this.chartKeuangan.Series.Add(series1);
            this.chartKeuangan.Series.Add(series2);
            this.chartKeuangan.Size = new System.Drawing.Size(786, 355);
            this.chartKeuangan.TabIndex = 2;
            this.chartKeuangan.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Grafik Keuangan Organisasi";
            this.chartKeuangan.Titles.Add(title1);
            // 
            // cmbJenis
            // 
            this.cmbJenis.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbJenis.FormattingEnabled = true;
            this.cmbJenis.Location = new System.Drawing.Point(249, 80);
            this.cmbJenis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbJenis.Name = "cmbJenis";
            this.cmbJenis.Size = new System.Drawing.Size(338, 24);
            this.cmbJenis.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(160, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filter Jenis :";
            // 
            // btnGoOrganisasi
            // 
            this.btnGoOrganisasi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGoOrganisasi.BackColor = System.Drawing.Color.Transparent;
            this.btnGoOrganisasi.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoOrganisasi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGoOrganisasi.Location = new System.Drawing.Point(36, 485);
            this.btnGoOrganisasi.Name = "btnGoOrganisasi";
            this.btnGoOrganisasi.Size = new System.Drawing.Size(177, 28);
            this.btnGoOrganisasi.TabIndex = 5;
            this.btnGoOrganisasi.Text = "Go to Form Organisasi";
            this.btnGoOrganisasi.UseVisualStyleBackColor = false;
            this.btnGoOrganisasi.Click += new System.EventHandler(this.btnGoOrganisasi_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.DarkGreen;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(791, 485);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(64, 28);
            this.btnBack.TabIndex = 21;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormKeuangan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(867, 515);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnGoOrganisasi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbJenis);
            this.Controls.Add(this.chartKeuangan);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormKeuangan";
            this.Text = "Dashboard Keuangan ORMAWA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormKeuangan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartKeuangan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartKeuangan;
        private System.Windows.Forms.ComboBox cmbJenis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGoOrganisasi;
        private System.Windows.Forms.Button btnBack;
    }
}