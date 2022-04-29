using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang
{
    class HoaDon
    {
        public int STT { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string TenSanPham { get; set; }
        public string MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public long Gia { get; set; }
        public int ChietKhau { get; set; }
       
        public long ThanhTien { get; set; }
        public string NgayMua { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string ChietKhauHien { get; set; }

        public void NhapHoaDon(string tenKhachHang, string soDienThoai, string diaChi, string tenSanPham, string maSanPham,int soLuong, long giatemp, string ngayMua, string phuongThucThanhToan, MangKhachHang mangKhachHang)
        {
            int i, count = 0; ;
            for(i=0;i<mangKhachHang.spt;i++)
            {
                if(soDienThoai == mangKhachHang.khachHang[i].SoDienThoai)
                {
                    if(mangKhachHang.khachHang[i].PhanLoaiKH=="Gold")
                    {
                        ChietKhau = 30;
                    }
                    else if (mangKhachHang.khachHang[i].PhanLoaiKH == "Silver")
                    {
                        ChietKhau = 20;
                    }
                    else
                    {
                        ChietKhau = 0;
                    }
                    count++;
                    break;
                }
            }
            if (count == 0)
                ChietKhau = 0;

            TenKhachHang = tenKhachHang;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            TenSanPham = tenSanPham;
            MaSanPham = maSanPham;
            SoLuong = soLuong;
            Gia = giatemp;
            ThanhTien = SoLuong*Gia*(100-ChietKhau)/100;
            NgayMua = ngayMua;
            PhuongThucThanhToan = phuongThucThanhToan;
            ChietKhauHien = ChietKhau + "%";
        }
       
    }
}
