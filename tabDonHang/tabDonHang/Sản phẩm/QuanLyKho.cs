using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Sản_phẩm
{
    class QuanLyKho
    {
        public string TenSanPham { get; set; }
        public string MaSanPham { get; set; }
        public long SoLuongTon { get; set; }
        public long SoLuongBan { get; set; }
        public long SoLuongNhap { get; set; }
        public string MaNcc { get; set; }
        public int STT { get; set; }
        public void KhoHang(string tenSanPham, string maSanPham, string soLuongNhap,string maNCC)
        {
            TenSanPham = tenSanPham;
            MaSanPham = maSanPham;
            SoLuongNhap = long.Parse(soLuongNhap);
            MaNcc = maNCC;
        }
    }
}
