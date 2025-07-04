using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDSederhana
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void btnMahasiswa_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.FormClosed += (s, args) => this.Show(); // Show dashboard when Form1 is closed
            form.Show();
            this.Hide(); // Sembunyikan dashboard setelah membuka form mahasiswa
        }

        private void btnOrganisasi_Click(object sender, EventArgs e)
        {
            FormOrganisasi form = new FormOrganisasi();
            form.FormClosed += (s, args) => this.Show(); // Show dashboard when Form1 is closed
            form.Show();
            this.Hide(); // Sembunyikan dashboard setelah membuka form organisasi
        }

        private void btnKeuangan_Click(object sender, EventArgs e)
        {
            FormKeuangan form = new FormKeuangan();
            form.FormClosed += (s, args) => this.Show(); // Show dashboard when Form1 is closed
            form.Show();
            this.Hide(); // Sembunyikan dashboard setelah membuka form keuangan
        }

        private void btnKegiatan_Click(object sender, EventArgs e)
        {
            FormKegiatan form = new FormKegiatan();
            form.FormClosed += (s, args) => this.Show(); // Show dashboard when Form1 is closed
            form.Show();
            this.Hide(); // Sembunyikan dashboard setelah membuka form kegiatan
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Keluar dari aplikasi jika pengguna memilih Ya
            }
        }

        private void btnPengaturanIP_Click(object sender, EventArgs e)
        {
            FormPengaturanIP form = new FormPengaturanIP();
            form.ShowDialog();
        }
    }
}
