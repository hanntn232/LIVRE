using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Sản_phẩm
{
    class MangMSP
    {
        //Hân + Nữ 

        public string[] msp = new string[1000];
        public int spt;
        public void TaoMangMSP_TuMangTenSP(MangTenSP A)
        {
            spt = 0;
            int i, j, count;
            for (i = 0; i < A.LaySoPhanTu(); i++)
            {
                count = 0;
                if (spt == 0)
                {
                    msp[0] = A.spham[i].MaSanPham;
                    spt++;
                }
                else
                {
                    for (j = 0; j < spt; j++)
                    {
                        if (A.spham[i].MaSanPham == msp[j])
                            count++;
                    }
                    if (count == 0)
                    {
                        msp[spt] = A.spham[i].MaSanPham;
                        spt++;
                    }
                }
            }
        }
        public QuanLyKho TimSoLuongNhapVaoCuaMSP_TuMangTenSP(MangTenSP A, string MSP)
        {
            QuanLyKho B = new QuanLyKho();
            int i;
            for (i = 0; i < A.LaySoPhanTu(); i++)
            {
                if (MSP.Trim() == A.spham[i].MaSanPham.Trim())
                {
                    B.TenSanPham = A.spham[i].TenSanPham;
                    B.MaSanPham = A.spham[i].MaSanPham.Trim();
                    B.MaNcc = A.spham[i].MaNCC;
                    B.SoLuongNhap += A.spham[i].SoLuong;
                }
            }
           
            return B;
        }






        //---------------------
        public void TaoMangMSP_TuMangHoaDon(MangHoaDon A)
        {
            spt = 0;
            int i, j, count;
            for (i = 0; i < A.LaySoPhanTu(); i++)
            {
                count = 0;
                if (spt == 0)
                {
                    msp[0] = A.HDon[i].MaSanPham;
                    spt++;
                }
                else
                {
                    for (j = 0; j < spt; j++)
                    {
                        if (A.HDon[i].MaSanPham == msp[j])
                            count++;
                    }
                    if (count == 0)
                    {
                        msp[spt] = A.HDon[i].MaSanPham;
                        spt++;
                    }
                }
            }
        }

        public QuanLyKho TimSoLuongBanRaCuaMSP_TuMangHoaDon(MangHoaDon A, string MSP)
        {
            QuanLyKho B = new QuanLyKho();
            int i;
            for (i = 0; i < A.LaySoPhanTu(); i++)
            {
                if (MSP.Trim() == A.HDon[i].MaSanPham.Trim())
                {
                    B.MaSanPham = A.HDon[i].MaSanPham;
                    B.SoLuongBan += A.HDon[i].SoLuong;
                }
            }
            return B;
        }


        //-----------------------------------------

        


    }
}
