using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Sản_phẩm
{
    class Cxuly
    {
        public QuanLyKho[] nhapkho = new QuanLyKho[1000];
        int spt = 0;
        public void NhapKho(QuanLyKho K)
        {
            nhapkho[spt] = K;
            spt++;
            nhapkho[spt - 1].STT = spt;
        }
        public int LaySTT()
        {
            int STT;
            STT = spt;
            return STT;
        }
        public int LaySoPhanTu()
        {
            return spt;
        }
    }
}
