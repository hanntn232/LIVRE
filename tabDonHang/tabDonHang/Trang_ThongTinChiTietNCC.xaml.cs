using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace tabDonHang
{
    /// <summary>
    /// Interaction logic for Trang_ThongTinChiTietNCC.xaml
    /// </summary>
    public partial class Trang_ThongTinChiTietNCC : Window
    {
        List<CNhacungcap> m = new List<CNhacungcap>();
        Han_MaiAnh tab1 = new Han_MaiAnh();
        public Trang_ThongTinChiTietNCC()
        {
            InitializeComponent();

        }

        private void BtnThemMoiLH_Click(object sender, RoutedEventArgs e)
        {
            LienHe LH = new LienHe();
            LH.ThemLH(txtTenLienHe.Text, txtSDTLienHe.Text, txtEmailLienHe.Text, txtChucVuLienHe.Text, txtBoPhanLienHe.Text);
            LsvLienhe.Items.Add(LH);
            txtTenLienHe.Clear();
            txtEmailLienHe.Clear();
            txtChucVuLienHe.Clear();
            txtBoPhanLienHe.Clear();
            txtSDTLienHe.Clear();
        }

        private void BtnThemGhiChu_Click(object sender, RoutedEventArgs e)
        {
            GhiChu Note = new GhiChu();
            Note.ThemGhiChu(txtGhiChu.Text, txtNguoiThem.Text, DateTime.Now);
            LsvGhichu.Items.Add(Note);
            txtGhiChu.Clear();
            txtNguoiThem.Clear();
        }

        public void LayList1(List<CNhacungcap> a)
        {
            m = a;
        }
        private void BtnXoaNhom_Click_1(object sender, RoutedEventArgs e)
        {

            foreach (CNhacungcap it in m)
            {
                if (it.TenNCC == lblTenNCC.Content.ToString())
                {
                    m.Remove(it);
                    tab1.LsvDSNCC.ItemsSource = m;
                    MessageBox.Show("Xóa thành công");
                    tab1.mangNCC.ListNCC = m;

                    tab1.mangNCC.spt = m.Count;
                    tab1.lblSLNXB.Content = tab1.mangNCC.demSLNCC("NXB");
                    tab1.lblSLNS.Content = tab1.mangNCC.demSLNCC("Nhà sách");
                    tab1.lblSLKhac.Content = tab1.mangNCC.demSLNCC("Khác");

                    tab1.tabNCC.IsSelected = true;
                    tab1.mangNCC.capnhatfile("dataNCC.txt");
                    tab1.Show();
                    this.Close();
                    return;
                }
            }
        }


        
        //{
        //    tab1.LsvDSNCC.ItemsSource = m;
        //    tab1.mangNCC.ListNCC = m;
        //    tab1.LayList2(m);

        //    tab1.mangNCC.spt = m.Count;
        //    tab1.lblSLNXB.Content = tab1.mangNCC.demSLNCC("NXB");
        //    tab1.lblSLNS.Content = tab1.mangNCC.demSLNCC("Nhà sách");
        //    tab1.lblSLKhac.Content = tab1.mangNCC.demSLNCC("Khác");

        //    tab1.tabNCC.IsSelected = true;
        //    tab1.Show();
        //    this.Close();
        }

        
        
            //foreach (CNhacungcap it in m)
            //{
            //    if (it.TenNCC == lblTenNCC.Content.ToString())
            //    {
            //        it.NhomNCC = txt_TTNCC_Nhom.Text;
            //        it.MaNCC = txt_TTNCC_Ma.Text;
            //        it.SDTNCC = txt_TTNCC_sdt.Text;
            //        it.EmailNCC = txt_TTNCC_Email1.Text;
            //        it.Website = txt_TTNCC_Website.Text;
            //        it.ThueMD = txt_TTNCC_ThueMacDinh.Text;
            //        it.GiaMD = txt_TTNCC_GiaMD.Text;
            //        it.HTTT = txt_TTNCC_HTTT.Text;
            //        it.NhanVien = txt_TTNCC_NVien1.Text;
            //        it.DiaChi = txt_TTNCC_DiaChi.Text;
            //        tab1.mangNCC.nhapmangncc(it);
            //        tab1.LsvDSNCC.ItemsSource = m;
            //        MessageBox.Show("Cập nhật thành thành công");
            //        tab1.mangNCC.ListNCC = m;
            //        tab1.LayList2(m);

            //        tab1.tabNCC.IsSelected = true;
            //        tab1.mangNCC.spt = m.Count;
            //        tab1.lblSLNXB.Content = tab1.mangNCC.demSLNCC("NXB");
            //        tab1.lblSLNS.Content = tab1.mangNCC.demSLNCC("Nhà sách");
            //        tab1.lblSLKhac.Content = tab1.mangNCC.demSLNCC("Khác");
            //        tab1.mangNCC.capnhatfile("dataNCC.txt");
            //        return;
            //    }
            //}
        }
    

