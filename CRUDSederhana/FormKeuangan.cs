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
using System.Windows.Forms.DataVisualization.Charting;

namespace CRUDSederhana
{
    public partial class FormKeuangan : Form
    {
        Koneksi kn = new Koneksi(); // Membuat instance dari kelas Koneksi untuk mengelola koneksi ke database
        string connect = ""; // Variabel untuk menyimpan string koneksi ke database

        public FormKeuangan()
        {
            InitializeComponent();
            connect = kn.connectionString(); // Menginisialisasi string koneksi dengan memanggil metode connectionString dari kelas Koneksi
        }

        private void FormKeuangan_Load(object sender, EventArgs e)
        {
            cmbJenis.Items.AddRange(new string[] { "Semua", "Pemasukan", "Pengeluaran" });
                cmbJenis.SelectedIndex = 0;

            LoadChartData("Semua");

            cmbJenis.SelectedIndexChanged += cmbJenis_SelectedIndexChanged;
        }

        private void cmbJenis_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbJenis.SelectedItem.ToString();
            LoadChartData(selected);
        }

        private void LoadChartData(string filter)
        {
            chartKeuangan.Series.Clear();
            chartKeuangan.Titles.Clear();
            chartKeuangan.Legends.Clear();
            chartKeuangan.ChartAreas.Clear();

            ChartArea ca = new ChartArea("MainArea");
            ca.AxisX.Title = "Organisasi";
            ca.AxisY.Title = "Jumlah (Rp)";
            ca.AxisX.LabelStyle.Angle = -45;
            ca.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            chartKeuangan.ChartAreas.Add(ca);

            // string connStr = "Data Source=LAPTOPGW1;Initial Catalog=OrganisasiMahasiswa;Integrated Security=True";
            string query = @"
                SELECT
                o.NamaOrganisasi,
                SUM(CASE WHEN k.Jenis = 'Pemasukan' THEN k.Jumlah ELSE 0 END) AS Pemasukan,
                SUM(CASE WHEN k.Jenis = 'Pengeluaran' THEN k.Jumlah ELSE 0 END) AS Pengeluaran
                FROM Organisasi o
                LEFT JOIN Keuangan k ON o.ID_Organisasi = k.ID_Organisasi
                GROUP BY o.NamaOrganisasi";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            if (filter == "Semua" || filter == "Pemasukan")
            {
                Series sPemasukan = new Series("Pemasukan")
                {
                    ChartType = SeriesChartType.Column,
                    Color = System.Drawing.Color.ForestGreen,
                    IsValueShownAsLabel = true
                };

                foreach (DataRow row in dt.Rows)
                {
                    decimal jumlah = Convert.ToDecimal(row["Pemasukan"]);
                    sPemasukan.Points.AddXY(row["NamaOrganisasi"].ToString(), jumlah);
                }

                chartKeuangan.Series.Add(sPemasukan);
            }

            if (filter == "Semua" || filter == "Pengeluaran")
            {
                Series sPengeluaran = new Series("Pengeluaran")
                {
                    ChartType = SeriesChartType.Column,
                    Color = System.Drawing.Color.Firebrick,
                    IsValueShownAsLabel = true
                };

                foreach (DataRow row in dt.Rows)
                {
                    decimal jumlah = Convert.ToDecimal(row["Pengeluaran"]);
                    sPengeluaran.Points.AddXY(row["NamaOrganisasi"].ToString(), jumlah);
                }

                chartKeuangan.Series.Add(sPengeluaran);
            }

            chartKeuangan.Titles.Add("Grafik Keuangan Organisasi");
            chartKeuangan.Legends.Add(new Legend("Legenda"));

        }

        private void btnGoOrganisasi_Click(object sender, EventArgs e)
        {
            FormOrganisasi formOrganisasi = new FormOrganisasi();
            formOrganisasi.FormClosed += (s, args) => this.Show();
            formOrganisasi.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboard dashboard = new FormDashboard();
            dashboard.Show();
        }
    }
}
