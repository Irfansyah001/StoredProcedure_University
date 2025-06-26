using Microsoft.Reporting.WinForms;
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
using System.IO;

namespace CRUDSederhana
{
    public partial class FormKegiatan : Form
    {
        Koneksi kn = new Koneksi(); // Instance of Koneksi class to manage database connection
        string connect = ""; // Variable to hold the connection string

        public FormKegiatan()
        {
            InitializeComponent();
            connect = kn.connectionString(); // Initialize the connection string using the Koneksi class
        }

        private void FormKegiatan_Load(object sender, EventArgs e)
        {
            // Setup ReportViewer data
            SetupReportViewer();
            // Refresh report to display data
            this.reportViewer1.RefreshReport();
        }

        private void SetupReportViewer()
        {
            // Connection string to your database
            // string connectionString = "Data Source=LAPTOPGW1;Initial Catalog=OrganisasiMahasiswa;Integrated Security=True";

            connect = kn.connectionString(); // Get the connection string from Koneksi class

            // SQL query to retrieve the required data from the database
            string query = @"
                SELECT
                    o.ID_Organisasi,
                    o.NamaOrganisasi,
                    k.Jenis,
                    k.Jumlah,
                    k.Tanggal
                FROM
                    Organisasi o
                JOIN
                    Keuangan k ON o.ID_Organisasi = k.ID_Organisasi";

            // Create a DataTable to store the data
            DataTable dt = new DataTable();

            // Use SqlDataAdapter to fill the DataTable with data from the database
            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            // Create a ReportDataSource
            ReportDataSource rds = new ReportDataSource("DataSet1", dt); // Make sure "DataSet1" matches your RDLC dataset name

            // Clear any existing data sources and add the new data source
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Set the path to the report (.rdlc file)
            // Change this to the actual path of your RDLC file
            // reportViewer1.LocalReport.ReportPath = @"C:\Users\syahi\source\repos\CRUDSEDERHANA\CRUDSederhana\OrganisasiReport.rdlc";

            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OrganisasiReport.rdlc");
            reportViewer1.LocalReport.ReportPath = reportPath; // Set the report path dynamically

            // Refresh the ReportViewer to show the updated report
            reportViewer1.RefreshReport();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboard dashboard = new FormDashboard();
            dashboard.Show();
        }
    }
}

