using System; // Mengimpor namespace dasar untuk aplikasi
using System.IO; // Mengimpor namespace untuk membaca dan menulis file konfigurasi
using System.Net; // Mengimpor namespace untuk validasi IP Address

namespace CRUDSederhana // Namespace untuk mengelompokkan kelas Koneksi
{
    internal class Koneksi // Kelas Koneksi untuk mengelola koneksi ke database
    {
        public string connectionString() // untuk membangun dan mengembalikan string koneksi ke database
        {
            string connectStr = ""; // mendeklarasikan string koneksi ke database
            try // blok try untuk menangkap exception jika terjadi kesalahan saat membaca konfigurasi IP
            {
                string serverIP = GetServerIPFromConfig(); // mendapatkan IP server dari file konfigurasi
                connectStr = $"Server={serverIP};Initial Catalog=OrganisasiMahasiswa;" +
                             $"User ID=sa;Password=12345678910;"; // ubah 'yourpassword' sesuai password login SQL Server Anda

                return connectStr; // mengembalikan string koneksi ke database
            }
            catch (Exception ex) // menangkap exception jika terjadi kesalahan
            {
                Console.WriteLine("Gagal membaca IP dari konfigurasi: " + ex.Message); // tampilkan pesan kesalahan di konsol
                return string.Empty; // mengembalikan string kosong jika gagal
            }
        }

        private string GetServerIPFromConfig() // metode untuk membaca IP server dari file server_config.txt
        {
            string configPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), // mendapatkan path ke folder AppData
                "OrganisasiMahasiswa", "server_config.txt"); // menggabungkan path dengan nama file konfigurasi
            if (!File.Exists(configPath)) // jika file tidak ditemukan
            {
                throw new FileNotFoundException("File konfigurasi 'server_config.txt' tidak ditemukan.");
            }

            string ip = File.ReadAllText(configPath).Trim(); // membaca isi file dan menghapus spasi

            if (string.IsNullOrEmpty(ip))
            {
                throw new Exception("Isi file konfigurasi 'server_config.txt' kosong.");
            }

            if (!IsValidIPv4(ip))
            {
                throw new Exception("Format IP tidak valid. Harap masukkan IP Address dengan format IPv4 (contoh: 192.168.100.32).");
            }

            return ip; // mengembalikan IP yang valid
        }

        private bool IsValidIPv4(string ipString) // fungsi untuk validasi format IP v4
        {
            if (IPAddress.TryParse(ipString, out IPAddress ip))
            {
                return ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork;
            }
            return false;
        }

        // Fungsi ini tidak digunakan tetapi bisa diaktifkan jika ingin kembali ke IP lokal
        public static string GetLocalIPAddress() // untuk mengambil IP Address pada PC yang menjalankan aplikasi
        {
            var host = Dns.GetHostEntry(Dns.GetHostName()); // mendapatkan nama host lokal
            foreach (var ip in host.AddressList) // melakukan iterasi pada daftar alamat IP yang terkait dengan host
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // mengambil IPv4
                {
                    return ip.ToString(); // mengembalikan IP Address
                }
            }
            throw new Exception("Tidak dapat menemukan IP Address lokal yang valid."); // jika tidak ada IP Address yang valid ditemukan, lemparkan exception
        }
    }
}
