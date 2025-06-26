using System; // Mengimpor namespace dasar untuk aplikasi
using System.Net; // Mengimpor namespace untuk menangani alamat IP
using System.Net.Sockets; // Mengimpor namespace untuk menangani soket jaringan

namespace CRUDSederhana // Namespace untuk mengelompokkan kelas Koneksi
{
    internal class Koneksi // Kelas Koneksi untuk mengelola koneksi ke database
    {
        public string connectionString() //untuk membangundan mengembalikan string koneksi ke database
        {
            string connectStr = ""; //mendeklarasikan string koneksi ke database
            try //blok try untuk menangkap exception jika terjadi kesalahan saat mendapatkan IP Address
            {
                string localIP = GetLocalIPAddress(); //mendeklarasikan ipaddress
                connectStr = $"Server={localIP};Initial Catalog=OrganisasiMahasiswa;" + //membangun string koneksi ke database dengan IP Address lokal
                    $"Integrated Security=True;"; //membangun string koneksi ke database dengan IP Address lokal

                return connectStr; //mengembalikan string koneksi ke database

            }
            catch (Exception ex) //menangkap exception jika terjadi kesalahan saat mendapatkan IP Address
            {
                Console.WriteLine(ex.Message); //menangkap exception jika terjadi kesalahan saat mendapatkan IP Address
                return string.Empty; //mengembalikan string kosong jika terjadi kesalahan
            }
        }

        public static string GetLocalIPAddress() //untuk mengambil IP Address pada PC yang menjalankan aplikasi
        {
            //mengambil informasi tentang local host
            var host = Dns.GetHostEntry(Dns.GetHostName()); // mendapatkan nama host lokal
            foreach (var ip in host.AddressList) //melakukan iterasi pada daftar alamat IP yang terkait dengan host
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) //mengambil IPv4
                {
                    return ip.ToString(); //mengembalikan IP Address
                }
            }
            throw new Exception("Tidak dapat menemukan IP Address lokal yang valid."); // jika tidak ada IP Address yang valid ditemukan, lemparkan exception
        }
    }
}
