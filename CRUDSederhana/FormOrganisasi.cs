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

namespace CRUDSederhana
{
    public partial class FormOrganisasi : Form
    {
        // private readonly string connectionString = "Data Source=LAPTOPGW1;Initial Catalog=OrganisasiMahasiswa;Integrated Security=True";

        Koneksi kn = new Koneksi(); // Membuat instance dari kelas Koneksi
        string connectionString = ""; // Mendeklarasikan string koneksi ke database

        private int selectedIdOrganisasi = -1; // Variabel untuk menyimpan ID Organisasi yang dipilih

        public FormOrganisasi()
        {
            InitializeComponent();
            connectionString = kn.connectionString(); // Mendapatkan string koneksi dari kelas Koneksi
        }

        private void FormOrganisasi_Load(object sender, EventArgs e)
        {

        }

        private void LoadJoinedData()
        {
            using (SqlConnection conn = new SqlConnection(kn.connectionString()))
            {
                string query = @"
                SELECT 
                    Organisasi.ID_Organisasi,
                    Organisasi.NamaOrganisasi,
                    Organisasi.Deskripsi,
                    Organisasi.TahunBerdiri,
                    Keuangan.Jumlah,
                    Keuangan.Tanggal,
                    Keuangan.Keterangan
                FROM 
                    Organisasi
                LEFT JOIN 
                    Keuangan ON Organisasi.ID_Organisasi = Keuangan.ID_Organisasi";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);
                    dgvOrganisasi.DataSource = dataTable; // Menampilkan hasil gabungan di DataGridView

                    // Menyembunyikan kolom ID_Organisasi dari tampilan DataGridView
                    dgvOrganisasi.Columns["ID_Organisasi"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void dataGridViewOrganisasi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan indeks baris valid
            if (e.RowIndex >= 0 && dgvOrganisasi.Rows.Count > 0)
            {
                try
                {
                    // Ambil ID_Organisasi dari baris yang dipilih
                    var idOrganisasiCellValue = dgvOrganisasi.Rows[e.RowIndex].Cells["ID_Organisasi"].Value;
                    if (idOrganisasiCellValue != null && idOrganisasiCellValue != DBNull.Value)
                    {
                        // Simpan ID yang dipilih untuk digunakan nanti
                        selectedIdOrganisasi = Convert.ToInt32(idOrganisasiCellValue);

                        // Isi TextBox dengan data dari baris yang dipilih
                        txtNama.Text = dgvOrganisasi.Rows[e.RowIndex].Cells["NamaOrganisasi"].Value?.ToString() ?? "";
                        txtDeskripsi.Text = dgvOrganisasi.Rows[e.RowIndex].Cells["Deskripsi"].Value?.ToString() ?? "";
                        txtTahun.Text = dgvOrganisasi.Rows[e.RowIndex].Cells["TahunBerdiri"].Value?.ToString() ?? "";

                        // Mengambil nilai dari kolom "Jumlah"
                        var jumlahValue = dgvOrganisasi.Rows[e.RowIndex].Cells["Jumlah"].Value;

                        // Cek apakah jumlahValue tidak null dan bukan DBNull
                        if (jumlahValue != null && jumlahValue != DBNull.Value)
                        {
                            txtDana.Text = jumlahValue.ToString();
                        }
                        else
                        {
                            txtDana.Text = "";
                        }

                        // Cek dan isi Keterangan
                        txtKeterangan.Text = dgvOrganisasi.Rows[e.RowIndex].Cells["Keterangan"].Value?.ToString() ?? "";
                    }
                    else
                    {
                        lblMessage.Text = "ID organisasi tidak valid.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saat mengambil data: " + ex.Message);
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string namaOrganisasi = txtNama.Text;
            string deskripsi = txtDeskripsi.Text;
            int tahunBerdiri;
            decimal jumlah;
            string keterangan = txtKeterangan.Text;

            // Validasi input
            if (string.IsNullOrEmpty(namaOrganisasi) || string.IsNullOrEmpty(deskripsi) ||
                !int.TryParse(txtTahun.Text, out tahunBerdiri) ||
                !decimal.TryParse(txtDana.Text, out jumlah) || string.IsNullOrEmpty(keterangan))
            {
                lblMessage.Text = "Isi kolom dengan data yang sesuai";
                return;
            }

            using (SqlConnection conn = new SqlConnection(kn.connectionString()))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        Transaction = transaction
                    };

                    // Insert ke tabel Organisasi dan ambil ID_Organisasi secara otomatis
                    cmd.CommandText = "INSERT INTO Organisasi (NamaOrganisasi, Deskripsi, TahunBerdiri) " +
                                      "OUTPUT INSERTED.ID_Organisasi " +
                                      "VALUES (@NamaOrganisasi, @Deskripsi, @TahunBerdiri)";
                    cmd.Parameters.AddWithValue("@NamaOrganisasi", namaOrganisasi);
                    cmd.Parameters.AddWithValue("@Deskripsi", deskripsi);
                    cmd.Parameters.AddWithValue("@TahunBerdiri", tahunBerdiri);

                    object result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                    {
                        lblMessage.Text = "Gagal mengambil ID organisasi.";
                        return;
                    }

                    int idOrganisasi = Convert.ToInt32(result);

                    cmd.CommandText = "SELECT ISNULL(MAX(ID_Keuangan), 0) + 1 FROM Keuangan";
                    int idKeuangan = Convert.ToInt32(cmd.ExecuteScalar());

                    // Insert ke tabel Keuangan
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO Keuangan (ID_Keuangan, ID_Organisasi, Jenis, Jumlah, Tanggal, Keterangan) " +
                                      "VALUES (@ID_Keuangan, @ID_Organisasi, 'Pemasukan', @Jumlah, GETDATE(), @Keterangan)";
                    cmd.Parameters.AddWithValue("@ID_Keuangan", idKeuangan);             // ⬅ ini wajib
                    cmd.Parameters.AddWithValue("@ID_Organisasi", idOrganisasi);
                    cmd.Parameters.AddWithValue("@Jumlah", jumlah);
                    cmd.Parameters.AddWithValue("@Keterangan", keterangan);
                    cmd.ExecuteNonQuery();


                    transaction.Commit();
                    lblMessage.Text = "Data berhasil disimpan";
                    LoadJoinedData();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedIdOrganisasi == -1)
            {
                lblMessage.Text = "Pilih nama organisasi yang ingin dihapus";
                return;
            }

            using (SqlConnection conn = new SqlConnection(kn.connectionString()))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        Transaction = transaction
                    };

                    // Delete from Keuangan table
                    cmd.CommandText = "DELETE FROM Keuangan WHERE ID_Organisasi = @ID_Organisasi";
                    cmd.Parameters.AddWithValue("@ID_Organisasi", selectedIdOrganisasi);
                    cmd.ExecuteNonQuery();

                    // Delete from Organisasi table
                    cmd.CommandText = "DELETE FROM Organisasi WHERE ID_Organisasi = @ID_Organisasi";
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    lblMessage.Text = "Data berhasil dihapus.";
                    LoadJoinedData(); // Refresh DataGridView setelah delete
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedIdOrganisasi == -1)
            {
                lblMessage.Text = "Pilih nama organisasi yang ingin diubah";
                return;
            }

            string namaOrganisasi = txtNama.Text;
            string deskripsi = txtDeskripsi.Text;
            int tahunBerdiri;
            decimal jumlah;
            string keterangan = txtKeterangan.Text;

            if (string.IsNullOrEmpty(namaOrganisasi) || string.IsNullOrEmpty(deskripsi) ||
                !int.TryParse(txtTahun.Text, out tahunBerdiri) ||
                !decimal.TryParse(txtDana.Text, out jumlah) || string.IsNullOrEmpty(keterangan))
            {
                lblMessage.Text = "Isi kolom dengan data yang sesuai";
                return;
            }

            using (SqlConnection conn = new SqlConnection(kn.connectionString()))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        Transaction = transaction
                    };

                    // Update Organisasi
                    cmd.CommandText = "UPDATE Organisasi SET NamaOrganisasi = @NamaOrganisasi, Deskripsi = @Deskripsi, TahunBerdiri = @TahunBerdiri WHERE ID_Organisasi = @ID_Organisasi";
                    cmd.Parameters.AddWithValue("@NamaOrganisasi", namaOrganisasi);
                    cmd.Parameters.AddWithValue("@Deskripsi", deskripsi);
                    cmd.Parameters.AddWithValue("@TahunBerdiri", tahunBerdiri);
                    cmd.Parameters.AddWithValue("@ID_Organisasi", selectedIdOrganisasi);
                    cmd.ExecuteNonQuery();

                    // Update Keuangan
                    cmd.CommandText = "UPDATE Keuangan SET Jumlah = @Jumlah, Keterangan = @Keterangan WHERE ID_Organisasi = @ID_Organisasi";
                    cmd.Parameters.AddWithValue("@Jumlah", jumlah);
                    cmd.Parameters.AddWithValue("@Keterangan", keterangan);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    lblMessage.Text = "Data berhasil diubah.";
                    LoadJoinedData();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadJoinedData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboard dashboard = new FormDashboard();
            dashboard.Show();
        }
    }
}
