using System.Collections.Generic;
using System.IO;
using tabDonHang.Sản_phẩm;

namespace tabDonHang
{
    class CmangBCDT
    {
        CbaocaoDT[] tapBCDT;
        public int sptBCDT;


        public CmangBCDT()
        {
            tapBCDT = new CbaocaoDT[200];
            sptBCDT = 0;


        }
        //cập nhật báo cáo khi có đơn hàng mới
        public void suaBCDT(HoaDon a, MangTenSP b, List<CbaocaoDT> c)
        {
            bool IsCompleted = false;
            for (int i = 0; i < sptBCDT; i++)
            {
                for (int j = 0; j < b.LaySoPhanTu(); j++)
                {
                    if (a.MaSanPham == tapBCDT[i].SKU && tapBCDT[i].SKU == b.spham[j].MaSanPham)
                    {
                        tapBCDT[i].SL += a.SoLuong;
                        tapBCDT[i].GT += (a.Gia * a.ChietKhau*a.SoLuong) / 100;
                        tapBCDT[i].DT += a.Gia * a.SoLuong;
                        tapBCDT[i].TV += b.spham[j].GiaGoc * a.SoLuong;
                        tapBCDT[i].LN = (tapBCDT[i].DT - tapBCDT[i].GT - tapBCDT[i].TV);
                        IsCompleted = true;
                    }
                }

            }
            if (IsCompleted == false)
            {
                    for (int j = 0; j < b.LaySoPhanTu(); j++)
                    {
                        if (a.MaSanPham == b.spham[j].MaSanPham)
                        {
                            CbaocaoDT tam = new CbaocaoDT();
                            tam.Tensp = a.TenSanPham;
                            tam.SKU = a.MaSanPham;
                            tam.SL = a.SoLuong;
                            tam.GT = (a.Gia * a.ChietKhau*a.SoLuong) / 100;
                            tam.DT = a.Gia * a.SoLuong;
                            tam.TV = b.spham[j].GiaGoc * a.SoLuong;
                            tam.LN = tam.DT - tam.GT - tam.TV;
                            them1dongBCDT(tam);
                        }
                    }
                
            }
            capnhatBCDT(c);
        }
        public void them1dongBCDT(CbaocaoDT a)
        {
            tapBCDT[sptBCDT] = a;
            sptBCDT++;
            tapBCDT[sptBCDT - 1].STT = sptBCDT;
        }
        public void capnhatBCDT(List<CbaocaoDT> a)
        {
            a.Clear();
            for (int i = 0; i < sptBCDT; i++)
            {
                a.Add(tapBCDT[i]);
            }
        }
        public void luuBCDT(string a)
        {
            int i, j;
            for (i = 0; i < sptBCDT - 1; i++)
            {
                for (j = i + 1; j < sptBCDT; j++)
                    if (tapBCDT[j].STT < tapBCDT[i].STT) // nếu có sự sai vị trí thì đổi chỗ
                        Hoanvi(i, j);
            }

            FileStream file = new FileStream(a, FileMode.Truncate, FileAccess.Write);
            // Create a new stream to read from a file
            StreamWriter sr = new StreamWriter(file);

            // Read contents of file into a string
            for (i = 0; i < sptBCDT; i++)
            {
                sr.WriteLine(tapBCDT[i].luuBCDT());
            }

            // Close StreamReader
            sr.Close();

            // Close file
            file.Close();
        }
        public void Hoanvi(int i, int j)
        {
            CbaocaoDT tam;
            tam = tapBCDT[i];
            tapBCDT[i] = tapBCDT[j];
            tapBCDT[j] = tam;

        }
        public List<CbaocaoDT> sxBCDTtheoSL()
        {
            List<CbaocaoDT> tam = new List<CbaocaoDT>();
            int i, j;
            for (i = 0; i < sptBCDT - 1; i++)
            {
                for (j = i + 1; j < sptBCDT; j++)
                    if (tapBCDT[j].SL > tapBCDT[i].SL) // nếu có sự sai vị trí thì đổi chỗ
                        Hoanvi(i, j);
            }
            for (i = 0; i < sptBCDT; i++)
            {
                tam.Add(tapBCDT[i]);
            }
            return tam;
        }
        public List<CbaocaoDT> sxBCDTtheoDT()
        {
            List<CbaocaoDT> tam = new List<CbaocaoDT>();
            int i, j;
            for (i = 0; i < sptBCDT - 1; i++)
            {
                for (j = i + 1; j < sptBCDT; j++)
                    if (tapBCDT[j].DT > tapBCDT[i].DT) // nếu có sự sai vị trí thì đổi chỗ
                        Hoanvi(i, j);
            }
            for (i = 0; i < sptBCDT; i++)
            {
                tam.Add(tapBCDT[i]);
            }
            return tam;
        }
        public List<CbaocaoDT> sxBCDTtheoLN()
        {
            List<CbaocaoDT> tam = new List<CbaocaoDT>();
            int i, j;
            for (i = 0; i < sptBCDT - 1; i++)
            {
                for (j = i + 1; j < sptBCDT; j++)
                    if (tapBCDT[j].LN > tapBCDT[i].LN) // nếu có sự sai vị trí thì đổi chỗ
                        Hoanvi(i, j);
            }
            for (i = 0; i < sptBCDT; i++)
            {
                tam.Add(tapBCDT[i]);
            }
            return tam;
        }

    }
}
