drop database OrganisasiMahasiswa
create database OrganisasiMahasiswa
use OrganisasiMahasiswa

-- Tabel Mahasiswa
CREATE TABLE Mahasiswa (
    NIM VARCHAR(11) PRIMARY KEY,
    Nama VARCHAR(100),
    Email VARCHAR(100),
    Telepon VARCHAR(13) CHECK (Telepon LIKE '08%' AND LEN(Telepon) BETWEEN 10 AND 13),
    Alamat TEXT
);

-- Tabel Organisasi
CREATE TABLE Organisasi (
    ID_Organisasi INT PRIMARY KEY,
    NamaOrganisasi VARCHAR(100),
    Deskripsi TEXT,
    TahunBerdiri INT
);

-- Tabel AnggotaOrganisasi
CREATE TABLE AnggotaOrganisasi (
    ID_Anggota INT PRIMARY KEY,
    NIM VARCHAR(11),
    ID_Organisasi INT,
    Jabatan VARCHAR(50),
    TahunMasuk INT,
    FOREIGN KEY (NIM) REFERENCES Mahasiswa(NIM) ON DELETE CASCADE,
    FOREIGN KEY (ID_Organisasi) REFERENCES Organisasi(ID_Organisasi) ON DELETE CASCADE
);

-- Tabel Kegiatan
CREATE TABLE Kegiatan (
    ID_Kegiatan INT PRIMARY KEY,
    ID_Organisasi INT,
    NamaKegiatan VARCHAR(100),
    Tanggal DATE,
    Deskripsi TEXT,
    FOREIGN KEY (ID_Organisasi) REFERENCES Organisasi(ID_Organisasi) ON DELETE CASCADE
);

-- Tabel Keuangan
CREATE TABLE Keuangan (
    ID_Keuangan INT PRIMARY KEY,
    ID_Organisasi INT,
    Jenis VARCHAR(20) NOT NULL, 
    Jumlah DECIMAL(15,2),
    Tanggal DATE,
    Keterangan TEXT,
    FOREIGN KEY (ID_Organisasi) REFERENCES Organisasi(ID_Organisasi) ON DELETE CASCADE,
    CONSTRAINT CHK_Jenis CHECK (Jenis IN ('Pemasukan', 'Pengeluaran')) 
);

select * from Mahasiswa

-- Stored Procedure untuk Menambah Data Mahasiswa
CREATE PROCEDURE AddMahasiswa
    @NIM CHAR(11),
    @Nama VARCHAR(50),
    @Email VARCHAR(100),
    @Telepon VARCHAR(13),
    @Alamat VARCHAR(255)
AS
BEGIN
    INSERT INTO Mahasiswa (NIM, Nama, Email, Telepon, Alamat)
    VALUES (@NIM, @Nama, @Email, @Telepon, @Alamat);
END;


-- Stored Procedure untuk Menghapus Data Mahasiswa berdasarkan NIM
CREATE PROCEDURE DeleteMahasiswa
    @NIM CHAR(11)
AS
BEGIN
    DELETE FROM Mahasiswa WHERE NIM = @NIM;
END;

-- Stored Procedure untuk Memperbarui Data Mahasiswa
CREATE PROCEDURE UpdateMahasiswa
    @NIM CHAR(11),
    @Nama VARCHAR(50),
    @Email VARCHAR(100),
    @Telepon VARCHAR(13),
    @Alamat VARCHAR(255)
AS
BEGIN
    UPDATE Mahasiswa
    SET
        Nama = COALESCE(NULLIF(@Nama, ''), Nama),
        Email = COALESCE(NULLIF(@Email, ''), Email),
        Telepon = COALESCE(NULLIF(@Telepon, ''), Telepon),
        Alamat = COALESCE(NULLIF(@Alamat, ''), Alamat)
    WHERE NIM = @NIM;
END;

-- 1. Indeks pada kolom Nama (untuk mempercepat pencarian berdasarkan nama)
IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'idx_Mahasiswa_Nama'
      AND object_id = OBJECT_ID('dbo.Mahasiswa')
)
BEGIN
    CREATE NONCLUSTERED INDEX idx_Mahasiswa_Nama
    ON dbo.Mahasiswa(Nama);
    PRINT 'Created idx_Mahasiswa_Nama';
END
ELSE
    PRINT 'idx_Mahasiswa_Nama sudah ada.';

-- 2. Indeks pada kolom Email (jika Anda sering mencari atau meng-JOIN berdasarkan email)
IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'idx_Mahasiswa_Email'
      AND object_id = OBJECT_ID('dbo.Mahasiswa')
)
BEGIN
    CREATE NONCLUSTERED INDEX idx_Mahasiswa_Email
    ON dbo.Mahasiswa(Email);
    PRINT 'Created idx_Mahasiswa_Email';
END
ELSE
    PRINT 'idx_Mahasiswa_Email sudah ada.';

-- 3. Indeks pada kolom Telepon (untuk lookup cepat berdasarkan nomor telepon)
IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'idx_Mahasiswa_Telepon'
      AND object_id = OBJECT_ID('dbo.Mahasiswa')
)
BEGIN
    CREATE NONCLUSTERED INDEX idx_Mahasiswa_Telepon
    ON dbo.Mahasiswa(Telepon);
    PRINT 'Created idx_Mahasiswa_Telepon';
END
ELSE
    PRINT 'idx_Mahasiswa_Telepon sudah ada.';
GO

ALTER TABLE Organisasi
ADD JumlahDana DECIMAL(15,2),
    Keterangan VARCHAR(255);

EXEC sp_help Organisasi;

-- cara menonaktifkan sementara constraint foreign key agar tidak terjadi error :
ALTER TABLE Enrollments NOCHECK CONSTRAINT ALL;

-- cara mengaktifkan kembali :
ALTER TABLE Enrollments CHECK CONSTRAINT ALL;

-- 1. Nonaktifkan semua FK sementara
ALTER TABLE Keuangan NOCHECK CONSTRAINT ALL;
ALTER TABLE AnggotaOrganisasi NOCHECK CONSTRAINT ALL;

-- 2. Hapus PK dan kolom ID_Organisasi dari tabel utama
ALTER TABLE Organisasi DROP CONSTRAINT PK_Organisasi; -- ganti nama sesuai hasil query
ALTER TABLE Organisasi DROP COLUMN ID_Organisasi;

-- 3. Tambah ulang ID_Organisasi sebagai auto increment
ALTER TABLE Organisasi ADD ID_Organisasi INT IDENTITY(1,1) PRIMARY KEY;

-- 4. Aktifkan kembali FK
ALTER TABLE Keuangan CHECK CONSTRAINT ALL;
ALTER TABLE AnggotaOrganisasi CHECK CONSTRAINT ALL;

-- Cek nama PK di tabel Organisasi
SELECT name 
FROM sys.key_constraints 
WHERE parent_object_id = OBJECT_ID('Organisasi');

-- Cek foreign key yang bergantung pada ID_Organisasi
SELECT f.name AS ForeignKeyName, OBJECT_NAME(f.parent_object_id) AS TableName
FROM sys.foreign_keys AS f
INNER JOIN sys.foreign_key_columns AS fc ON f.object_id = fc.constraint_object_id
WHERE OBJECT_NAME(fc.referenced_object_id) = 'Organisasi';

-- Hapus foreign key di tabel lain
ALTER TABLE Keuangan DROP CONSTRAINT FK__Keuangan__ID_Org__4316F928;
ALTER TABLE Kegiatan DROP CONSTRAINT FK__Kegiatan__ID_Org__403A8C7D;
ALTER TABLE AnggotaOrganisasi DROP CONSTRAINT FK__AnggotaOr__ID_Or__3D5E1FD2;

-- Hapus primary key di tabel Organisasi
ALTER TABLE Organisasi DROP CONSTRAINT PK__Organisa__1787A03B29A10016;

-- Hapus kolom ID_Organisasi
ALTER TABLE Organisasi DROP COLUMN ID_Organisasi;

ALTER TABLE Organisasi ADD ID_Organisasi INT IDENTITY(1,1) PRIMARY KEY;

--  Tambahkan kembali foreign key
ALTER TABLE Keuangan 
ADD CONSTRAINT FK_Keuangan_Organisasi FOREIGN KEY (ID_Organisasi) REFERENCES Organisasi(ID_Organisasi) ON DELETE CASCADE;

-- Menambahkan foreign key (relasi) dari tabel Kegiatan ke tabel Organisasi
-- Jika data di tabel Organisasi dihapus, maka data terkait di tabel Kegiatan juga akan ikut terhapus (ON DELETE CASCADE)
ALTER TABLE Kegiatan 
ADD CONSTRAINT FK_Kegiatan_Organisasi FOREIGN KEY (ID_Organisasi) REFERENCES Organisasi(ID_Organisasi) ON DELETE CASCADE;

-- Menambahkan foreign key dari tabel AnggotaOrganisasi ke tabel Organisasi
-- Sama seperti sebelumnya, jika Organisasi dihapus maka data anggota terkait juga ikut dihapus
ALTER TABLE AnggotaOrganisasi 
ADD CONSTRAINT FK_AnggotaOrganisasi_Organisasi FOREIGN KEY (ID_Organisasi) REFERENCES Organisasi(ID_Organisasi) ON DELETE CASCADE;

-- Menampilkan struktur tabel Organisasi (kolom, tipe data, constraint, dsb.)
EXEC sp_help Organisasi;

-- Menampilkan struktur tabel Keuangan
EXEC sp_help Keuangan;

-- Menghapus constraint primary key dari kolom ID_Keuangan
-- Langkah ini diperlukan sebelum menghapus kolom primary key
ALTER TABLE Keuangan DROP CONSTRAINT PK__Keuangan__ID_Keuangan;

-- Menghapus kolom ID_Keuangan dari tabel Keuangan
-- Karena akan diganti dengan kolom baru yang menggunakan auto increment
ALTER TABLE Keuangan DROP COLUMN ID_Keuangan;

-- Menambahkan kembali kolom ID_Keuangan sebagai auto increment (IDENTITY)
-- Sekaligus menjadikannya primary key
ALTER TABLE Keuangan ADD ID_Keuangan INT IDENTITY(1,1) PRIMARY KEY;

select * from Organisasi;
