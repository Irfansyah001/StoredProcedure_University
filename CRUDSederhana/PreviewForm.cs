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
    public partial class PreviewForm: Form
    {
        private string connectionString = "Data Source=LAPTOPGW1;Initial Catalog=OrganisasiMahasiswa;Integrated Security=True";

        // Konstruktor menerima DataTable dan menampilkan data di DataGridView
        public PreviewForm(DataTable data)
        {
            InitializeComponent();
            // Menetapkan data source DataGridView ke DataTable yang diterima
            dgvPreview.DataSource = data;
        }

        private void dgvPreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Event ketika form dimuat
        private void PreviewForm_Load(object sender, EventArgs e)
        {
            // Optional: Sesuaikan DataGridView jika perlu
            dgvPreview.AutoResizeColumns(); // Menyesuaikan ukuran kolom
        }

        private bool ValidateRow(DataRow row)
        {
            string nim = row["NIM"].ToString();

            // Validasi NIM (misalnya, harus berjumlah 11 karakter)
            if (nim.Length != 11)
            {
                MessageBox.Show("NIM harus terdiri dari 11 karakter.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Jika perlu, tambahkan validasi lain sesuai dengan kebutuhan (misalnya, pola tertentu untuk NIM)

            return true;
        }

        private void ImportDataToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPreview.DataSource;

                foreach (DataRow row in dt.Rows)
                {
                    // Validasi setiap baris sebelum diimpor
                    if (!ValidateRow(row))
                    {
                        // Jika validasi gagal, lanjutkan ke baris berikutnya
                        continue; // Lewati baris ini jika tidak valid
                    }

                    string query = "INSERT INTO Mahasiswa (NIM, Nama, Email, Telepon, Alamat) VALUES (@NIM, @Nama, @Email, @Telepon, @Alamat)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@NIM", row["NIM"]);
                            cmd.Parameters.AddWithValue("@Nama", row["Nama"]);
                            cmd.Parameters.AddWithValue("@Email", row["Email"]);
                            cmd.Parameters.AddWithValue("@Telepon", row["Telepon"]);
                            cmd.Parameters.AddWithValue("@Alamat", row["Alamat"]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Data berhasil diimpor ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Tutup PreviewForm setelah data diimpor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengimpor data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Event ketika tombol OK diklik
        private void button1_Click(object sender, EventArgs e)
        {
            // Menanyakan kepada pengguna jika mereka ingin mengimpor data
            DialogResult result = MessageBox.Show("Apakah Anda ingin mengimpor data ini ke database?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Mengimpor data dari DataGridView ke database
                ImportDataToDatabase();
            }
        }
    }
}
