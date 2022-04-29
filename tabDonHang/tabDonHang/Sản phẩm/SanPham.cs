using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Sản_phẩm
{
    class SanPham
    {
        public string TenSanPham { get; set; }
        public string MaSanPham { get; set; }
        public long SoLuong { get; set; }
        public long GiaGoc { get; set; }
        public long GiaBan { get; set; }
        public string MaNCC { get; set; }
        public int STT { get; set; }

        //tab Nhap Hang
        public long SLNhap { get; set; }
        public long GiaNhap { get; set; }
        public long ThanhTien { get; set; }

        public void NhapSanPham(string tenSanPham, string maSanPham, string soLuong, string giaGoc, string giaBan, string Mancc)
        {
            TenSanPham = tenSanPham;
            MaSanPham = maSanPham;
            SoLuong = long.Parse(soLuong);
            GiaBan = long.Parse(giaBan);
            GiaGoc = long.Parse(giaGoc);
            MaNCC = Mancc ;
        }

    }
}
