using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang
{
    class GhiChu
    {
        public string GhiChu1 { get; set; }
        public string NguoiThem { get; set; }
        public string ThoiGian { get; set; }

        public void ThemGhiChu(string ghichu, string nguoithem, DateTime thoigian)
        {
            GhiChu1 = ghichu;
            NguoiThem = nguoithem;
            ThoiGian = thoigian.ToString();
        }
    }
}
