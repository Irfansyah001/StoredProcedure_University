using System;

namespace CRUDSederhana
{
    partial class FormDashboard
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
            this.btnMahasiswa = new System.Windows.Forms.Button();
            this.btnOrganisasi = new System.Windows.Forms.Button();
            this.btnKeuangan = new System.Windows.Forms.Button();
            this.btnKegiatan = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnPengaturanIP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMahasiswa
            // 
            this.btnMahasiswa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMahasiswa.BackColor = System.Drawing.Color.DarkGreen;
            this.btnMahasiswa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMahasiswa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMahasiswa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMahasiswa.ForeColor = System.Drawing.Color.White;
            this.btnMahasiswa.Location = new System.Drawing.Point(269, 85);
            this.btnMahasiswa.Name = "btnMahasiswa";
            this.btnMahasiswa.Size = new System.Drawing.Size(220, 182);
            this.btnMahasiswa.TabIndex = 1;
            this.btnMahasiswa.Text = "📚 Mahasiswa";
            this.btnMahasiswa.UseVisualStyleBackColor = false;
            this.btnMahasiswa.Click += new System.EventHandler(this.btnMahasiswa_Click);
            // 
            // btnOrganisasi
            // 
            this.btnOrganisasi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrganisasi.BackColor = this.btnMahasiswa.BackColor;
            this.btnOrganisasi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrganisasi.FlatStyle = this.btnMahasiswa.FlatStyle;
            this.btnOrganisasi.Font = this.btnMahasiswa.Font;
            this.btnOrganisasi.ForeColor = this.btnMahasiswa.ForeColor;
            this.btnOrganisasi.Location = new System.Drawing.Point(533, 85);
            this.btnOrganisasi.Name = "btnOrganisasi";
            this.btnOrganisasi.Size = new System.Drawing.Size(220, 182);
            this.btnOrganisasi.TabIndex = 2;
            this.btnOrganisasi.Text = "🏢 Organisasi";
            this.btnOrganisasi.UseVisualStyleBackColor = false;
            this.btnOrganisasi.Click += new System.EventHandler(this.btnOrganisasi_Click);
            // 
            // btnKeuangan
            // 
            this.btnKeuangan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKeuangan.BackColor = this.btnMahasiswa.BackColor;
            this.btnKeuangan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKeuangan.FlatStyle = this.btnMahasiswa.FlatStyle;
            this.btnKeuangan.Font = this.btnMahasiswa.Font;
            this.btnKeuangan.ForeColor = this.btnMahasiswa.ForeColor;
            this.btnKeuangan.Location = new System.Drawing.Point(533, 306);
            this.btnKeuangan.Name = "btnKeuangan";
            this.btnKeuangan.Size = new System.Drawing.Size(220, 182);
            this.btnKeuangan.TabIndex = 3;
            this.btnKeuangan.Text = "📊 Keuangan";
            this.btnKeuangan.UseVisualStyleBackColor = false;
            this.btnKeuangan.Click += new System.EventHandler(this.btnKeuangan_Click);
            // 
            // btnKegiatan
            // 
            this.btnKegiatan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKegiatan.BackColor = this.btnMahasiswa.BackColor;
            this.btnKegiatan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKegiatan.FlatStyle = this.btnMahasiswa.FlatStyle;
            this.btnKegiatan.Font = this.btnMahasiswa.Font;
            this.btnKegiatan.ForeColor = this.btnMahasiswa.ForeColor;
            this.btnKegiatan.Location = new System.Drawing.Point(269, 306);
            this.btnKegiatan.Name = "btnKegiatan";
            this.btnKegiatan.Size = new System.Drawing.Size(220, 182);
            this.btnKegiatan.TabIndex = 4;
            this.btnKegiatan.Text = "📑 Kegiatan";
            this.btnKegiatan.UseVisualStyleBackColor = false;
            this.btnKegiatan.Click += new System.EventHandler(this.btnKegiatan_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = this.btnMahasiswa.BackColor;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = this.btnMahasiswa.FlatStyle;
            this.btnExit.Font = this.btnMahasiswa.Font;
            this.btnExit.ForeColor = this.btnMahasiswa.ForeColor;
            this.btnExit.Location = new System.Drawing.Point(933, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 31);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Quit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(299, 23);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(426, 48);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "DASHBOARD UTAMA";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPengaturanIP
            // 
            this.btnPengaturanIP.Location = new System.Drawing.Point(12, 12);
            this.btnPengaturanIP.Name = "btnPengaturanIP";
            this.btnPengaturanIP.Size = new System.Drawing.Size(56, 23);
            this.btnPengaturanIP.TabIndex = 6;
            this.btnPengaturanIP.Text = "setting";
            this.btnPengaturanIP.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPengaturanIP.UseVisualStyleBackColor = true;
            this.btnPengaturanIP.Click += new System.EventHandler(this.btnPengaturanIP_Click);
            // 
            // FormDashboard
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1006, 553);
            this.Controls.Add(this.btnPengaturanIP);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnMahasiswa);
            this.Controls.Add(this.btnOrganisasi);
            this.Controls.Add(this.btnKeuangan);
            this.Controls.Add(this.btnKegiatan);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDashboard";
            this.Text = "Dashboard Utama";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMahasiswa;
        private System.Windows.Forms.Button btnOrganisasi;
        private System.Windows.Forms.Button btnKeuangan;
        private System.Windows.Forms.Button btnKegiatan;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnPengaturanIP;
    }
}