using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Nhà_Cung_Cấp.Thông_tin_chi_tiết
{
    public class MangLichSuNhapHang
    {
        public int spt;
        public List<LichSuNhapHang> ListHistory = new List<LichSuNhapHang>();

        public void nhapmangLichSu(LichSuNhapHang lsu)
        {
            spt++;
            ListHistory.Add(lsu);
        }

        public void nhapmang(List<LichSuNhapHang> a)
        {
            ListHistory = a;
        }
    }
}
