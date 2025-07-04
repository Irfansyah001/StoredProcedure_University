using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CRUDSederhana
{
    public partial class FormPengaturanIP : Form
    {
        string configPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), // mendapatkan path ke folder AppData
            "OrganisasiMahasiswa", "server_config.txt" // menggabungkan path dengan nama file konfigurasi
        );
        public FormPengaturanIP()
        {
            InitializeComponent();
            LoadIP(); // Load IP saat form dibuka
        }

        private void LoadIP()
        {
            try
            {
                if (File.Exists(configPath))
                {
                    txtIP.Text = File.ReadAllText(configPath).Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membaca file konfigurasi: " + ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();

            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("IP tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidIPv4(ip))
            {
                MessageBox.Show("Format IP tidak valid. Gunakan format IPv4 seperti 192.168.1.1", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string folderPath = Path.GetDirectoryName(configPath);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            try
            {
                File.WriteAllText(configPath, ip);
                MessageBox.Show("IP berhasil disimpan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan file konfigurasi: " + ex.Message);
            }
        }

        private bool IsValidIPv4(string ipString)
        {
            if (IPAddress.TryParse(ipString, out IPAddress ip))
            {
                return ip.AddressFamily == AddressFamily.InterNetwork;
            }
            return false;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close(); // Tutup form tanpa menyimpan
        }
    }
}
