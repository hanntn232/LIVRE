using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang
{
    class LienHe
    {
        public string TenLienHe { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string ChucVu { get; set; }
        public string Bophan { get; set; }

        public void ThemLH(string tenlh, string sdt, string email, string chucvu, string bophan)
        {
            TenLienHe = tenlh;
            Email = email;
            SDT = sdt;
            ChucVu = chucvu;
            Bophan = bophan;
        }

    }
}
