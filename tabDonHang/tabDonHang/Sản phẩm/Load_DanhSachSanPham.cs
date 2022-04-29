using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Sản_phẩm
{
    class Load_DanhSachSanPham
    {
        public List<QuanLyKho> LoadDSSP_TraVeItemSource(MangTenSP A1, MangHoaDon A2)
        {
            MangMSP mangMSP_SP = new MangMSP();
            mangMSP_SP.TaoMangMSP_TuMangTenSP(A1);
            MangMSP mangMSP_HD = new MangMSP();
            mangMSP_HD.TaoMangMSP_TuMangHoaDon(A2);


            QuanLyKho B1 = new QuanLyKho();
            QuanLyKho B2 = new QuanLyKho();

            List<QuanLyKho> listQLK = new List<QuanLyKho>();

            Cxuly mangQuanLyKho1 = new Cxuly();
            Cxuly mangQuanLyKho2 = new Cxuly();

            int i;
            for (i = 0; i < mangMSP_SP.spt; i++)
            {
                B1 = mangMSP_SP.TimSoLuongNhapVaoCuaMSP_TuMangTenSP(A1, mangMSP_SP.msp[i]);
                B1.STT = i + 1;
                mangQuanLyKho1.NhapKho(B1);
            }
            for (i = 0; i < mangMSP_HD.spt; i++)
            {
                B2 = mangMSP_HD.TimSoLuongBanRaCuaMSP_TuMangHoaDon(A2, mangMSP_HD.msp[i]);
                mangQuanLyKho2.NhapKho(B2);
            }
            int a,b,count;
            for(a=0;a<mangQuanLyKho1.LaySoPhanTu();a++)
            {
                count = 0;
                for(b=0;b<mangQuanLyKho2.LaySoPhanTu();b++)
                {
                    if(mangQuanLyKho1.nhapkho[a].MaSanPham == mangQuanLyKho2.nhapkho[b].MaSanPham)
                    {
                        mangQuanLyKho1.nhapkho[a].SoLuongBan = mangQuanLyKho2.nhapkho[b].SoLuongBan;
                        mangQuanLyKho1.nhapkho[a].SoLuongTon = mangQuanLyKho1.nhapkho[a].SoLuongNhap - mangQuanLyKho2.nhapkho[b].SoLuongBan;
                        count++;
                        break;
                    }
                }
                if(count==0)
                {
                    mangQuanLyKho1.nhapkho[a].SoLuongTon = mangQuanLyKho1.nhapkho[a].SoLuongNhap;
                    listQLK.Add(mangQuanLyKho1.nhapkho[a]);
                }
                else
                {
                    listQLK.Add(mangQuanLyKho1.nhapkho[a]);
                }
            }
            return listQLK;
        }
        public Cxuly LoadDSSP_TraVeMangSP(MangTenSP A1, MangHoaDon A2)
        {
            MangMSP mangMSP_SP = new MangMSP();
            mangMSP_SP.TaoMangMSP_TuMangTenSP(A1);
            MangMSP mangMSP_HD = new MangMSP();
            mangMSP_HD.TaoMangMSP_TuMangHoaDon(A2);


            QuanLyKho B1 = new QuanLyKho();
            QuanLyKho B2 = new QuanLyKho();


            Cxuly mangQuanLyKho1 = new Cxuly();
            Cxuly mangQuanLyKho2 = new Cxuly();

            int i;
            for (i = 0; i < mangMSP_SP.spt; i++)
            {
                B1 = mangMSP_SP.TimSoLuongNhapVaoCuaMSP_TuMangTenSP(A1, mangMSP_SP.msp[i]);
                B1.STT = i + 1;
                mangQuanLyKho1.NhapKho(B1);
            }
            for (i = 0; i < mangMSP_HD.spt; i++)
            {
                B2 = mangMSP_HD.TimSoLuongBanRaCuaMSP_TuMangHoaDon(A2, mangMSP_HD.msp[i]);
                mangQuanLyKho2.NhapKho(B2);
            }
            int a, b, count;
            for (a = 0; a < mangQuanLyKho1.LaySoPhanTu(); a++)
            {
                count = 0;
                for (b = 0; b < mangQuanLyKho2.LaySoPhanTu(); b++)
                {
                    if (mangQuanLyKho1.nhapkho[a].MaSanPham == mangQuanLyKho2.nhapkho[b].MaSanPham)
                    {
                        mangQuanLyKho1.nhapkho[a].SoLuongBan = mangQuanLyKho2.nhapkho[b].SoLuongBan;
                        mangQuanLyKho1.nhapkho[a].SoLuongTon = mangQuanLyKho1.nhapkho[a].SoLuongNhap - mangQuanLyKho2.nhapkho[b].SoLuongBan;
                        count++;
                        break;
                    }
                }
                if (count == 0)
                {
                    mangQuanLyKho1.nhapkho[a].SoLuongTon = mangQuanLyKho1.nhapkho[a].SoLuongNhap;
                }
               
            }
            return mangQuanLyKho1;
        }



        //---------------------

        








    }
}
