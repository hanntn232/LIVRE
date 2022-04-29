using System;
using System.Collections.Generic;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace tabDonHang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
     
    public partial class MainWindow : Window
    {
        MangHoaDon mangHoaDon = new MangHoaDon();
        
        List<HoaDon> ListHoaDon = new List<HoaDon>();
        public MainWindow()
        {

            InitializeComponent();
            string line;
            string[] chuoiTrongLine;
            FileStream FileDonHang = File.Open("DonHang.txt", FileMode.Open,FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(FileDonHang);
            try
            {
                  while (!reader.EndOfStream)
                  {
                    line = reader.ReadLine();
                    chuoiTrongLine = TachChuoi(line);
                    HoaDon hoaDon = new HoaDon();
                    hoaDon.STT = int.Parse(chuoiTrongLine[0]);
                    hoaDon.TenKhachHang = chuoiTrongLine[1];
                    hoaDon.SoDienThoai = chuoiTrongLine[2];
                    hoaDon.DiaChi = chuoiTrongLine[3];
                    hoaDon.TenSanPham = chuoiTrongLine[4];
                    hoaDon.MaSanPham = chuoiTrongLine[5];
                    hoaDon.SoLuong = int.Parse(chuoiTrongLine[6]);
                    hoaDon.Gia = long.Parse(chuoiTrongLine[7]);
                    hoaDon.ThanhTien = long.Parse(chuoiTrongLine[8]);
                    hoaDon.NgayMua = chuoiTrongLine[9];
                    hoaDon.PhuongThucThanhToan = chuoiTrongLine[10];
                    ListHoaDon.Add(hoaDon);
                    mangHoaDon.NhapMangHoaDon(hoaDon);
                  }
                reader.Close();
                FileDonHang.Close();
            }
            catch (Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }
            LsvHoaDon.ItemsSource = ListHoaDon;
            lblSoDonHang.Content = "Có " + mangHoaDon.LaySoPhanTu().ToString() + " đơn hàng";
        }
        static int KiemTraDuLieu(string A)
        {
            int count = 0;
            foreach (char c in A)
            {
                if (c != ' ')
                    count++;
            }
            if (count > 0)
                return 0;
            else
                return 1;
        }

        private void btntaoDonHang_Click(object sender, RoutedEventArgs e)
        {
            //HoaDon A = new HoaDon();
            //string phuongThucThanhToan = null;
            //if (radtienMat.IsChecked == true)
            //    phuongThucThanhToan = "Tiền mặt";
            //if(radchuyenKhoan.IsChecked == true)
            //    phuongThucThanhToan = "Chuyển khoản";
            //if (KiemTraDuLieu(txttenKhachHang.Text) == 0 && KiemTraDuLieu(txtsoDienThoai.Text) == 0 && KiemTraDuLieu(txtdiaChi.Text) == 0 && KiemTraDuLieu(txttenSanPham.Text) == 0 && KiemTraDuLieu(txtmaSanPham.Text) == 0 && KiemTraDuLieu(txtgia.Text) == 0 && KiemTraDuLieu(txtngayMua.Text) == 0 && phuongThucThanhToan != null)
            //{
            //    try
            //    {
            //        A.NhapHoaDon(txttenKhachHang.Text, txtsoDienThoai.Text, txtdiaChi.Text, txttenSanPham.Text, txtmaSanPham.Text, int.Parse(txtSoLuong.Text), long.Parse(txtgia.Text), txtngayMua.Text, phuongThucThanhToan);
            //        mangHoaDon.NhapMangHoaDon(A);
            //        ListHoaDon.Add(A);
            //        LsvHoaDon.ItemsSource = null;
            //        LsvHoaDon.ItemsSource = ListHoaDon;
            //        FileStream FileGhi = File.Create("DonHang.txt");
            //        StreamWriter writer = new StreamWriter(FileGhi, Encoding.Unicode);
            //        int i;
            //        for (i = 0; i < mangHoaDon.LaySoPhanTu(); i++)
            //        {
            //            writer.WriteLine
            //                (mangHoaDon.HDon[i].STT + "_"
            //                + mangHoaDon.HDon[i].TenKhachHang
            //                + "_" + mangHoaDon.HDon[i].SoDienThoai
            //                + "_" + mangHoaDon.HDon[i].DiaChi
            //                + "_" + mangHoaDon.HDon[i].TenSanPham
            //                + "_" + mangHoaDon.HDon[i].MaSanPham
            //                + "_" + mangHoaDon.HDon[i].SoLuong
            //                + "_" + mangHoaDon.HDon[i].Gia
            //                + "_" + mangHoaDon.HDon[i].ThanhTien
            //                + "_" + mangHoaDon.HDon[i].NgayMua
            //                + "_" + mangHoaDon.HDon[i].PhuongThucThanhToan);
            //        }
            //        writer.Flush();
            //        writer.Close();
            //        MessageBox.Show("Nhập đơn hàng thành công", "", MessageBoxButton.OK);
            //    }
            //    catch(Exception ee)
            //    {
            //        MessageBox.Show(ee.Message);
            //    }
            //    lblSoDonHang.Content = "Có " + mangHoaDon.LaySoPhanTu().ToString() + " đơn hàng";
            //    txttenKhachHang.Text = "";
            //    txtsoDienThoai.Text = "";
            //    txtsoDienThoai.Text = "";
            //    txtdiaChi.Text = "";
            //    txttenSanPham.Text = "";
            //    txtmaSanPham.Text = "";
            //    txtSoLuong.Text = "";
            //    txtgia.Text = "";
            //    txtngayMua.Text = "";
            //    radtienMat.IsChecked = false;
            //    radchuyenKhoan.IsChecked = false;

            //}
            //else
            //    MessageBox.Show("Bạn chưa nhập dủ thông tin");
        }

       
        static string[] TachChuoi(string A)
        {
            string[] B = A.Split('_');
            return B;
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            int i, count = 0;
            List<HoaDon> hoaDonSearch = new List<HoaDon>();
            if (txtSearch.Text.Trim() != "")
            {
                if (mangHoaDon.LaySoPhanTu() != 0)
                {
                    for (i = 0; i < mangHoaDon.LaySoPhanTu(); i++)
                    {
                        if (mangHoaDon.HDon[i].SoDienThoai == txtSearch.Text)
                        {
                            hoaDonSearch.Add(mangHoaDon.HDon[i]);
                            count++;
                        }

                    }
                    if (count == 0)
                        MessageBox.Show("Không tìm thấy đơn hàng");
                    else
                        LsvHoaDon.ItemsSource = hoaDonSearch;
                }
                else
                    MessageBox.Show("Không tìm thấy đơn hàng");
            }
        }

        private void btnHuyTimKiem_Click(object sender, RoutedEventArgs e)
        {
            LsvHoaDon.ItemsSource = null;
            LsvHoaDon.ItemsSource = ListHoaDon;
            txtSearch.Text = "";
        }



        private void btnXuatHoaDon_Click(object sender, RoutedEventArgs e)
        {
            XuatExcelHoaDon xuat = new XuatExcelHoaDon();
            xuat.xuatExcelHoaDon(ListHoaDon);
        }
    }

}
