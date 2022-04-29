using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using tabDonHang.Sản_phẩm;

namespace tabDonHang.Đọc__Ghi_File
{
    class DocFile
    {
        //Hân
        public List<HoaDon> DocFile_TraVeListHoaDon(string tenFile)
        {
            List<HoaDon> list = new List<HoaDon>();
            string line;
            string[] chuoiTrongLine;
            FileStream FileDonHang = File.Open(tenFile, FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(FileDonHang);
            try
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    chuoiTrongLine = TachChuoi(line);
                    HoaDon hoaDon = new HoaDon();
                    hoaDon.STT = int.Parse(chuoiTrongLine[0]);
                    hoaDon.TenKhachHang = chuoiTrongLine[1];
                    hoaDon.SoDienThoai = chuoiTrongLine[2];
                    hoaDon.DiaChi = chuoiTrongLine[3];
                    hoaDon.TenSanPham = chuoiTrongLine[4];
                    hoaDon.MaSanPham = chuoiTrongLine[5];
                    hoaDon.SoLuong = int.Parse(chuoiTrongLine[6]);
                    hoaDon.Gia = long.Parse(chuoiTrongLine[7]);
                    hoaDon.ChietKhau = int.Parse(chuoiTrongLine[8]);
                    hoaDon.ChietKhauHien = hoaDon.ChietKhau + "%";
                    hoaDon.ThanhTien = long.Parse(chuoiTrongLine[9]);
                    hoaDon.NgayMua = chuoiTrongLine[10];
                    hoaDon.PhuongThucThanhToan = chuoiTrongLine[11];
                    list.Add(hoaDon);
                }
                reader.Close();
                FileDonHang.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            return list;
        }


        public static string[] TachChuoi(string A)
        {
            string[] B = A.Split('_');
            return B;
        }


        public MangHoaDon DocFile_TraVeMangHoaDon(string tenFile)
        {
            MangHoaDon mangHD = new MangHoaDon();
            string line;
            string[] chuoiTrongLine;
            FileStream FileDonHang = File.Open(tenFile, FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(FileDonHang);
            try
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    chuoiTrongLine = TachChuoi(line);
                    HoaDon hoaDon = new HoaDon();
                    hoaDon.STT = int.Parse(chuoiTrongLine[0]);
                    hoaDon.TenKhachHang = chuoiTrongLine[1];
                    hoaDon.SoDienThoai = chuoiTrongLine[2];
                    hoaDon.DiaChi = chuoiTrongLine[3];
                    hoaDon.TenSanPham = chuoiTrongLine[4];
                    hoaDon.MaSanPham = chuoiTrongLine[5];
                    hoaDon.SoLuong = int.Parse(chuoiTrongLine[6]);
                    hoaDon.Gia = long.Parse(chuoiTrongLine[7]);
                    hoaDon.ChietKhau = int.Parse(chuoiTrongLine[8]);
                    hoaDon.ChietKhauHien = hoaDon.ChietKhau + "%";
                    hoaDon.ThanhTien = long.Parse(chuoiTrongLine[9]);
                    hoaDon.NgayMua = chuoiTrongLine[10];
                    hoaDon.PhuongThucThanhToan = chuoiTrongLine[11];
                    mangHD.NhapMangHoaDon(hoaDon);
                }
                reader.Close();
                FileDonHang.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            return mangHD;
        }

        //Nữ
        public MangTenSP DocFile_TraVeMangTenSP(string tenFile)
        {
            MangTenSP mangSP = new MangTenSP();
            string line;
            string[] chuoiTrongLine;
            FileStream FileSP = File.Open(tenFile, FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(FileSP);
            try
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    chuoiTrongLine = TachChuoi(line);
                    SanPham sanpham = new SanPham();
                    sanpham.STT = int.Parse(chuoiTrongLine[0]);
                    sanpham.TenSanPham = chuoiTrongLine[1];
                    sanpham.MaSanPham = chuoiTrongLine[2];
                    sanpham.SoLuong = long.Parse(chuoiTrongLine[3]);
                    sanpham.MaNCC = chuoiTrongLine[4];
                    sanpham.GiaGoc = long.Parse(chuoiTrongLine[5]);
                    sanpham.GiaBan = long.Parse(chuoiTrongLine[6]);
                    mangSP.NhapMangSP(sanpham);
                }
                reader.Close();
                FileSP.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            return mangSP;
        }
        public List<SanPham> DocFile_TraVeListSP(string tenFile)
        {
            List<SanPham> list = new List<SanPham>();
            string line;
            string[] chuoiTrongLine;
            FileStream FileSP = File.Open(tenFile, FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(FileSP);
            try
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    chuoiTrongLine = TachChuoi(line);
                    SanPham sanpham = new SanPham();

                    sanpham.STT = int.Parse(chuoiTrongLine[0]);
                    sanpham.TenSanPham = chuoiTrongLine[1];
                    sanpham.MaSanPham = chuoiTrongLine[2];
                    sanpham.SoLuong = long.Parse(chuoiTrongLine[3]);
                    sanpham.MaNCC = chuoiTrongLine[4];
                    sanpham.GiaGoc = long.Parse(chuoiTrongLine[5]);
                    sanpham.GiaBan = long.Parse(chuoiTrongLine[6]);
                    list.Add(sanpham);
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            reader.Close();
            FileSP.Close();
            return list;
        }


        public Cxuly DocFile_TraVeMangNhapKho(string tenFile)
        {
            Cxuly mangNhapKho = new Cxuly();
            string s;
            string[] chuoi;
            FileStream FileNhapKho = File.Open(tenFile, FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(FileNhapKho);
            try
            {
                while (!reader.EndOfStream)
                {
                    s = reader.ReadLine();
                    chuoi = TachChuoi(s);
                    QuanLyKho quanly = new QuanLyKho();
                    quanly.STT = int.Parse(chuoi[0]);
                    quanly.TenSanPham = chuoi[1];
                    quanly.MaSanPham = chuoi[2];
                    quanly.MaNcc = chuoi[3];
                    quanly.SoLuongNhap = long.Parse(chuoi[4]);
                    quanly.SoLuongBan = long.Parse(chuoi[5]);
                    quanly.SoLuongTon = long.Parse(chuoi[6]);
                    mangNhapKho.NhapKho(quanly);
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            reader.Close();
            FileNhapKho.Close();
            return mangNhapKho;

        }

        public List<QuanLyKho> DocFile_TraVeListNhapKho(string tenFile)
        {
            List<QuanLyKho> list = new List<QuanLyKho>();
            string s;
            string[] chuoi;
            FileStream FileNhapKho = File.Open(tenFile, FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(FileNhapKho);
            try
            {
                while (!reader.EndOfStream)
                {
                    s = reader.ReadLine();
                    chuoi = TachChuoi(s);
                    QuanLyKho quanly = new QuanLyKho();
                    quanly.STT = int.Parse(chuoi[0]);
                    quanly.TenSanPham = chuoi[1];
                    quanly.MaSanPham = chuoi[2];
                    quanly.MaNcc = chuoi[3];
                    list.Add(quanly);
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            reader.Close();
            FileNhapKho.Close();
            return list;
        }


        //Hân
        public void ghiVaoFileHoaDon(string file, MangHoaDon mangHoaDon)
        {
            FileStream FileGhi = File.Create(file);
            StreamWriter writer = new StreamWriter(FileGhi, Encoding.Unicode);
            int i;
            for (i = 0; i < mangHoaDon.LaySoPhanTu(); i++)
            {
                writer.WriteLine
                    (mangHoaDon.HDon[i].STT + "_"
                    + mangHoaDon.HDon[i].TenKhachHang
                    + "_" + mangHoaDon.HDon[i].SoDienThoai
                    + "_" + mangHoaDon.HDon[i].DiaChi
                    + "_" + mangHoaDon.HDon[i].TenSanPham
                    + "_" + mangHoaDon.HDon[i].MaSanPham
                    + "_" + mangHoaDon.HDon[i].SoLuong
                    + "_" + mangHoaDon.HDon[i].Gia
                    + "_" + mangHoaDon.HDon[i].ChietKhau
                    + "_" + mangHoaDon.HDon[i].ThanhTien
                    + "_" + mangHoaDon.HDon[i].NgayMua
                    + "_" + mangHoaDon.HDon[i].PhuongThucThanhToan);
            }
            writer.Flush();
            writer.Close();

        }



        //Nữ 
        public void ghiVaoFileKhoHang(string fileLuu, Cxuly mangnhapkho)
        {
            FileStream FileGhi = File.Create(fileLuu);
            StreamWriter writer = new StreamWriter(FileGhi, Encoding.Unicode);
            int i;
            for (i = 0; i < mangnhapkho.LaySoPhanTu(); i++)
            {
                writer.WriteLine(
                               mangnhapkho.nhapkho[i].STT
                              + "_" + mangnhapkho.nhapkho[i].TenSanPham
                              + "_" + mangnhapkho.nhapkho[i].MaSanPham
                              + "_" + mangnhapkho.nhapkho[i].MaSanPham
                              + "_" + mangnhapkho.nhapkho[i].SoLuongNhap
                              + "_" + mangnhapkho.nhapkho[i].SoLuongBan
                              + "_" + mangnhapkho.nhapkho[i].SoLuongTon);

            }
            writer.Flush();
            writer.Close();

        }

        public void ghiVaoFileSanPham(string file, MangTenSP mangsp)
        {
            FileStream FileGhi = File.Create(file);
            StreamWriter writer = new StreamWriter(FileGhi, Encoding.Unicode);
            int i;
            for (i = 0; i < mangsp.LaySoPhanTu(); i++)
            {
                writer.WriteLine
                    (mangsp.spham[i].STT + "_"
                            + mangsp.spham[i].TenSanPham
                            + "_" + mangsp.spham[i].MaSanPham

                            + "_" + mangsp.spham[i].SoLuong
                            + "_" + mangsp.spham[i].MaNCC
                            + "_" + mangsp.spham[i].GiaGoc
                            + "_" + mangsp.spham[i].GiaBan);
            }
            writer.Flush();
            writer.Close();

        }

        //Hạnh
        public void docfilebaocao(string file, List<CbaocaoDT> a, CmangBCDT b)
        {
            FileStream filebaocao = new FileStream(file, FileMode.Open, FileAccess.Read);

            StreamReader sr = new StreamReader(file);

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                CbaocaoDT BCDT = new CbaocaoDT();
                BCDT.SKU = s.Split('/')[0];
                BCDT.Tensp = s.Split('/')[1];
                BCDT.SL = int.Parse(s.Split('/')[2]);
                BCDT.DT = long.Parse(s.Split('/')[3]);
                BCDT.TV = long.Parse(s.Split('/')[4]);
                BCDT.GT = int.Parse(s.Split('/')[5]);
                BCDT.LN = long.Parse(s.Split('/')[6]);
                b.them1dongBCDT(BCDT);
                a.Add(BCDT);
            }
            sr.Close();
            filebaocao.Close();


        }
    }
}
