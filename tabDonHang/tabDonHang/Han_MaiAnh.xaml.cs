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
using tabDonHang.Phân_Loại_Khách_Hàng;
using tabDonHang.Sản_phẩm;
using tabDonHang.Đọc__Ghi_File;
using System.Data;
using System.ComponentModel;
using tabDonHang.Nhà_Cung_Cấp.Thông_tin_chi_tiết;

namespace tabDonHang
{
    /// <summary>
    /// Interaction logic for Han_MaiAnh.xaml
    /// </summary>
    //Hân + Mai Anh

    public partial class Han_MaiAnh : Window
    {

        //Hân
        MangHoaDon mangHoaDon = new MangHoaDon();
        MangKhachHang mangKhachHang = new MangKhachHang();
        Load_DSKhachHang load_dsKH = new Load_DSKhachHang();
        List<HoaDon> ListHoaDon = new List<HoaDon>();
        List<KhachHang> ListKhachHang = new List<KhachHang>();


        //Nữ
        MangTenSP mangSp = new MangTenSP();
        List<SanPham> ListSP = new List<SanPham>();
        Cxuly mangnhapkho = new Cxuly();
        List<QuanLyKho> listQLK = new List<QuanLyKho>();
        Load_DanhSachSanPham load_DSSP = new Load_DanhSachSanPham();
        //Nữ - Bổ sung 
        public List<ComboBoxItem> listcbo = new List<ComboBoxItem>();
        int sptCBO = 0;
        public List<ListBoxItem> List_lboSP = new List<ListBoxItem>();
        int sptcboSP = 0;
        public MangLichSuNhapHang mangLichSu = new MangLichSuNhapHang();


        //Trang
        public CmangNCC mangNCC = new CmangNCC();
        List<CNhacungcap> listtab2 = new List<CNhacungcap>();

        //Hạnh
        CmangBCDT tapBCDT = new CmangBCDT();
        List<CbaocaoDT> Listbaocao = new List<CbaocaoDT>();


        public Han_MaiAnh()
        {
            InitializeComponent();
            //Hân

            DocFile docFileDonHang = new DocFile();
            ListHoaDon = docFileDonHang.DocFile_TraVeListHoaDon("DonHang.txt");
            LsvHoaDon.ItemsSource = ListHoaDon;
            mangHoaDon = docFileDonHang.DocFile_TraVeMangHoaDon("DonHang.txt");
            lblSoDonHang.Content = "Có " + mangHoaDon.LaySoPhanTu().ToString() + " đơn hàng";
            ListKhachHang = load_dsKH.LoadDSKH_TraVeItemSource(mangHoaDon);
            LsvKhachHang.ItemsSource = ListKhachHang;
            mangKhachHang = load_dsKH.LoadDSKH_TraVeMangKH(mangHoaDon);

            //Nữ
            DocFile docFileSanPham = new DocFile();
            ListSP = docFileSanPham.DocFile_TraVeListSP("DSSP.txt");
            mangSp = docFileSanPham.DocFile_TraVeMangTenSP("DSSP.txt");
            LsvSanPham.ItemsSource = ListSP;
            //DocFile docFileNhapKho = new DocFile();
            //mangnhapkho = docFileNhapKho.DocFile_TraVeMangNhapKho("NhapKho.txt");

            listQLK = load_DSSP.LoadDSSP_TraVeItemSource(mangSp, mangHoaDon);
            lsvQuanLyKho.ItemsSource = listQLK;
            mangnhapkho = load_DSSP.LoadDSSP_TraVeMangSP(mangSp, mangHoaDon);
            //listQLK = docFileNhapKho.DocFile_TraVeListNhapKho("bbb.txt");
            //lsvQuanLyKho.ItemsSource = listQLK;

            

            //Trang
            mangNCC.docfile("dataNCC.txt");
            LsvDSNCC.ItemsSource = null;
            LsvDSNCC.ItemsSource = mangNCC.ListNCC;
            lblSLKhac.Content = mangNCC.demSLNCC("Khác");
            lblSLNS.Content = mangNCC.demSLNCC("Nhà sách");
            lblSLNXB.Content = mangNCC.demSLNCC("NXB");

            //Nữ - Bổ sung nhập hàng
            int i;
            for (i = 0; i < mangNCC.spt; i++)
            {
                ComboBoxItem cbo1 = new ComboBoxItem();
                cbo1.Content = mangNCC.ListNCC[i].TenNCC;
                nhapCBO(cbo1);
            }
            cboChonNCC.ItemsSource = listcbo;

            int m;
            for (m = 0; m < mangSp.spt; m++)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = ListSP[m].TenSanPham;
                nhaplistboxSP(itm);
            }
            listboxSP.ItemsSource = List_lboSP;

            //Hạnh
            DocFile docFileBaocao = new DocFile();
            docFileBaocao.docfilebaocao("BCDT.txt", Listbaocao, tapBCDT);
            lsvBCDT.ItemsSource = Listbaocao;
            long a = 0, b = 0, c = 0;
            foreach (var item in Listbaocao)
            {
                a += item.SL;
                b += item.DT;
                c += item.LN;
            }
            tbkSL.Text += "\n" + a.ToString();
            tbkDT.Text += "\n" + b.ToString();
            tbkLN.Text += "\n" + c.ToString();
        }

        //Hân
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
          


        //Hân
        private void btntaoDonHang_Click(object sender, RoutedEventArgs e)
        {
            HoaDon AB = new HoaDon();
            string phuongThucThanhToan = null;
            if (radtienMat.IsChecked == true)
                phuongThucThanhToan = "Tiền mặt";
            if (radchuyenKhoan.IsChecked == true)
                phuongThucThanhToan = "Chuyển khoản";

            
            MangSanPhamKhacNhau_LienKetVoiTabHoaDon mangSP_KhacNhau = new MangSanPhamKhacNhau_LienKetVoiTabHoaDon();
            if (KiemTraDuLieu(txttenKhachHang.Text) == 0 && KiemTraDuLieu(txtsoDienThoai.Text) == 0 && KiemTraDuLieu(txtdiaChi.Text) == 0 && KiemTraDuLieu(txtmaSanPham.Text) == 0 && KiemTraDuLieu(txtngayMua.Text) == 0 && phuongThucThanhToan != null)
            {
                string tensp = mangSP_KhacNhau.XetMSP_TraVeTen(mangSp, txtmaSanPham.Text);
                long giaBan = mangSP_KhacNhau.XetMSP_TraVeGia(mangSp, txtmaSanPham.Text);
                if (tensp != "-1" && giaBan != -1)
                {
                    try
                    {
                        AB.NhapHoaDon(txttenKhachHang.Text, txtsoDienThoai.Text, txtdiaChi.Text, tensp, txtmaSanPham.Text, int.Parse(txtSoLuong.Text), giaBan, txtngayMua.Text, phuongThucThanhToan, mangKhachHang);
                        mangHoaDon.NhapMangHoaDon(AB);
                        lsvQuanLyKho.ItemsSource = null;
                        listQLK = load_DSSP.LoadDSSP_TraVeItemSource(mangSp, mangHoaDon);
                        lsvQuanLyKho.ItemsSource = listQLK;
                        mangnhapkho = load_DSSP.LoadDSSP_TraVeMangSP(mangSp, mangHoaDon);

                        ListHoaDon.Add(AB);
                        LsvHoaDon.ItemsSource = null;
                        LsvHoaDon.ItemsSource = ListHoaDon;
                        DocFile ghiFile = new DocFile();
                        ghiFile.ghiVaoFileHoaDon("DonHang.txt", mangHoaDon);
                        mangKhachHang = load_dsKH.LoadDSKH_TraVeMangKH(mangHoaDon);
                        ListKhachHang = load_dsKH.LoadDSKH_TraVeItemSource(mangHoaDon);
                        LsvKhachHang.ItemsSource = ListKhachHang;
                        MessageBox.Show("Nhập đơn hàng thành công", "", MessageBoxButton.OK);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                    lblSoDonHang.Content = "Có " + mangHoaDon.LaySoPhanTu().ToString() + " đơn hàng";
                    txttenKhachHang.Text = "";
                    txtsoDienThoai.Text = "";
                    txtsoDienThoai.Text = "";
                    txtdiaChi.Text = "";
                    txtmaSanPham.Text = "";
                    txtSoLuong.Text = "";
                    txtngayMua.Text = "";
                    radtienMat.IsChecked = false;
                    radchuyenKhoan.IsChecked = false;

                }
                else
                    MessageBox.Show("Không tồn tại mã sản phẩm này!", "", MessageBoxButton.OK);
            }
            else
                MessageBox.Show("Bạn chưa nhập dủ thông tin");

           
        }
         

        //Hân
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

        //Hân
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

        private void BtnXuatDS_Click(object sender, RoutedEventArgs e)
        {
            XuatExcelDanhSachKhachHang xuat = new XuatExcelDanhSachKhachHang();
            xuat.xuatExcelDSKH(ListKhachHang);
        }


        //Nữ
        private void btnTao_Click(object sender, RoutedEventArgs e)
        {
            SanPham S = new SanPham();
            DocFile docFile = new DocFile();

            if (KiemTraDuLieu(txtTenSanPham.Text) == 0 && KiemTraDuLieu(txtSoLuongSP.Text) == 0 && KiemTraDuLieu(txtMaSp.Text) == 0 && KiemTraDuLieu(txtGiaBan.Text) == 0 && KiemTraDuLieu(txtGiaGoc.Text) == 0 && KiemTraDuLieu(txtMaNCC.Text) == 0)
            {
                if (mangNCC.KiemtraMaNCC(txtMaNCC.Text) == true)
                {
                    try
                    {
                        S.NhapSanPham(txtTenSanPham.Text, txtMaSp.Text, txtSoLuongSP.Text, txtGiaGoc.Text, txtGiaBan.Text, txtMaNCC.Text);
                        mangSp.NhapMangSP(S);
                        ListSP.Add(S);



                        LsvSanPham.ItemsSource = null;
                        LsvSanPham.ItemsSource = ListSP;

                        docFile.ghiVaoFileSanPham("DSSP.txt", mangSp);


                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }

                    txtTenSanPham.Text = "";
                    txtSoLuongSP.Text = "";
                    txtMaSp.Text = "";
                    txtGiaGoc.Text = "";
                    txtGiaBan.Text = "";
                    txtMaNCC.Text = "";


                    lsvQuanLyKho.ItemsSource = null;
                    listQLK = load_DSSP.LoadDSSP_TraVeItemSource(mangSp, mangHoaDon);
                    lsvQuanLyKho.ItemsSource = listQLK;
                    mangnhapkho = load_DSSP.LoadDSSP_TraVeMangSP(mangSp, mangHoaDon);
                    DocFile doc = new DocFile();
                    doc.ghiVaoFileKhoHang("bbb.txt", mangnhapkho);

                    MessageBox.Show("Nhập thông tin thành công", "", MessageBoxButton.OK);
                }
                else
                    MessageBox.Show("Không tồn tại mã nhà cung cấp này!", "", MessageBoxButton.OK);
            }
            else
                MessageBox.Show("Bạn chưa nhập dủ thông tin");
        }

        


        //Nữ
        private void btnXuat_Click(object sender, RoutedEventArgs e)
        {
            XuatExcelDanhSachSanPham xuat = new XuatExcelDanhSachSanPham();
            xuat.xuatExcelDSSP_Nhap(ListSP);
        }


        //Nữ
        private void btnTimKiemKH_Click(object sender, RoutedEventArgs e)
        {
            int i, count = 0;
            List<KhachHang> khachHangSearch = new List<KhachHang>();
            if (txtTimKiem.Text.Trim() != "")
            {
                if (mangKhachHang.spt != 0)
                {
                    for (i = 0; i < mangKhachHang.spt; i++)
                    {
                        if (mangKhachHang.khachHang[i].SoDienThoai == txtTimKiem.Text)
                        {
                            khachHangSearch.Add(mangKhachHang.khachHang[i]);
                            count++;
                        }

                    }
                    if (count == 0)
                        MessageBox.Show("Không tìm thấy khách hàng này");
                    else
                        LsvKhachHang.ItemsSource = khachHangSearch;
                }
                else
                    MessageBox.Show("Không tìm thấy khách hàng này");
            }
        }


        //Nữ
        private void btnHuyTimKiemKH_Click(object sender, RoutedEventArgs e)
        {
            LsvKhachHang.ItemsSource = null;
            LsvKhachHang.ItemsSource = ListKhachHang;
            txtTimKiem.Text = "";
        }

        //Nữ
        private void btnXuatDuLieu_Click(object sender, RoutedEventArgs e)
        {
            XuatExcelDanhSachSanPham xuat = new XuatExcelDanhSachSanPham();
            xuat.xuatExcelDSKhoHang(listQLK);
        }


        //THÙY TRANG - NHÀ CUNG CẤP
        private void btnLuuNCC_Click(object sender, RoutedEventArgs e)
        {
            CNhacungcap NCC = new CNhacungcap();
            if (KiemTraDuLieu(txtNhapTen.Text) == 0 && KiemTraDuLieu(txtNhapEmail.Text) == 0 && KiemTraDuLieu(txtNhapEmail.Text) == 0 && KiemTraDuLieu(txtNhapDiaChi.Text) == 0 && KiemTraDuLieu(txtNhapSDT.Text) == 0 && KiemTraDuLieu(txtNhapNV.Text) == 0 && KiemTraDuLieu(txtNhapWeb.Text) == 0 && cboNhomNCC.Text != "Chọn nhóm" && cboGiaMacDinh.Text != "Chọn giá mặc định" && cboHTTT.Text != "Chọn hình thức" && cboThue.Text != "Chọn thuế mặc định")
            {
                if (mangNCC.KiemtraMaNCC(txtNhapMa.Text) == false)
                {
                    NCC.NhapNCC(txtNhapMa.Text, txtNhapTen.Text, cboNhomNCC.Text, txtNhapEmail.Text, txtNhapSDT.Text, "Đang giao dịch");
                    NCC.DiaChi = txtNhapDiaChi.Text;
                    NCC.NhanVien = txtNhapNV.Text;
                    NCC.Website = txtNhapWeb.Text;
                    NCC.ThueMD = cboThue.Text;
                    NCC.GiaMD = cboGiaMacDinh.Text;
                    NCC.HTTT = cboHTTT.Text;
                    NCC.NhomNCC = cboNhomNCC.Text;
                    mangNCC.nhapmangncc(NCC);
                    LsvDSNCC.ItemsSource = null;
                    LsvDSNCC.ItemsSource = mangNCC.ListNCC;
                    MessageBox.Show("Nhập thông tin thành công", "", MessageBoxButton.OK);

                    ComboBoxItem cbo = new ComboBoxItem();
                    cbo.Content = txtNhapTen.Text;
                    nhapCBO(cbo);
                    cboChonNCC.ItemsSource = null;
                    cboChonNCC.ItemsSource = listcbo;

                    mangNCC.capnhatfile("dataNCC.txt");

                    txtNhapTen.Clear();
                    txtNhapMa.Clear();
                    txtNhapEmail.Clear();
                    txtNhapDiaChi.Clear();
                    txtNhapNV.Clear();
                    txtNhapWeb.Clear();
                    txtNhapSDT.Clear();

                    cboNhomNCC.Text = "Chọn nhóm";
                    cboHTTT.Text = "Chọn hình thức";
                    cboGiaMacDinh.Text = "Chọn giá mặc định";
                    cboThue.Text = "Chọn thuế mặc định";

                    lblSLKhac.Content = mangNCC.demSLNCC("Khác");
                    lblSLNS.Content = mangNCC.demSLNCC("Nhà sách");
                    lblSLNXB.Content = mangNCC.demSLNCC("NXB");
                }
                else
                    MessageBox.Show("Nhà cung cấp này đã tồn tại", "", MessageBoxButton.OK);
            }
            else
                MessageBox.Show("Bạn chưa nhập dủ thông tin");
        }


        private void btnHuyNCC_Click(object sender, RoutedEventArgs e)
        {
            txtNhapTen.Clear();
            txtNhapMa.Clear();
            txtNhapEmail.Clear();
            txtNhapDiaChi.Clear();
            txtNhapNV.Clear();
            txtNhapWeb.Clear();
            txtNhapSDT.Clear();
        }

        private void LsvDSNCC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CNhacungcap NCC = e.AddedItems[0] as CNhacungcap;
            DetailInfo.IsSelected = true;
            lblTenNCC.Content = NCC.TenNCC;
            txt_TTNCC_Nhom.Text = NCC.NhomNCC;
            txt_TTNCC_Ma.Text = NCC.MaNCC;
            txt_TTNCC_sdt.Text = NCC.SDTNCC;
            txt_TTNCC_Email1.Text = NCC.EmailNCC;
            txt_TTNCC_DiaChi.Text = NCC.DiaChi;
            txt_TTNCC_NVien1.Text = NCC.NhanVien;
            txt_TTNCC_Website.Text = NCC.Website;
            txt_TTNCC_ThueMacDinh.Text = NCC.ThueMD;
            txt_TTNCC_GiaMD.Text = NCC.GiaMD;
            txt_TTNCC_HTTT.Text = NCC.HTTT;
        }

        private void btnSearch_TT_Click(object sender, RoutedEventArgs e)
        {
            mangNCC.spt = listtab2.Count;
            mangNCC.nhapmang(listtab2);
            if (mangNCC.timkiemtheoMa(txtSearch_TT.Text) == true)
                LsvDSNCC.ItemsSource = mangNCC.ListNCC;
            else if (mangNCC.timkiemtheoMa(txtSearch_TT.Text) == false)
                MessageBox.Show("Không tìm thấy nhà cung cấp", "", MessageBoxButton.OK);
            txtSearch_TT.Clear();
        }

        private void btnhuytim_Click(object sender, RoutedEventArgs e)
        {
            mangNCC.spt = listtab2.Count;
            mangNCC.nhapmang(listtab2);
            LsvDSNCC.ItemsSource = null;
            LsvDSNCC.ItemsSource = mangNCC.ListNCC;
            cboThaotac.Text = "Lọc theo nhóm";
        }

        private void cboThaotac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mangNCC.spt = listtab2.Count;
            mangNCC.nhapmang(listtab2);
            switch (cboThaotac.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    mangNCC.Loc("NXB");
                    LsvDSNCC.ItemsSource = mangNCC.ListNCC;
                    break;
                case 2:
                    mangNCC.Loc("Nhà sách");
                    LsvDSNCC.ItemsSource = mangNCC.ListNCC;
                    break;
                case 3:
                    mangNCC.Loc("Khác");
                    LsvDSNCC.ItemsSource = mangNCC.ListNCC;
                    break;
            }
        }

        private void btnXuatFile_Click(object sender, RoutedEventArgs e)
        {
            mangNCC.xuatfile();

        }


        //Hạnh
        private void btnXuaBCDT_Click(object sender, RoutedEventArgs e)
        {
            XuatExcelBaocaoDT xuatbaocao = new XuatExcelBaocaoDT();
            xuatbaocao.luuexcel(Listbaocao);
        }
        private void gvchSL_Click(object sender, RoutedEventArgs e)
        {
            lsvBCDT.ItemsSource = tapBCDT.sxBCDTtheoSL();
        }

        private void gvchDT_Click(object sender, RoutedEventArgs e)
        {
            lsvBCDT.ItemsSource = tapBCDT.sxBCDTtheoDT();
        }

        private void gvcgLN_Click(object sender, RoutedEventArgs e)
        {
            lsvBCDT.ItemsSource = tapBCDT.sxBCDTtheoLN();
        }
        private void btnTimKiemBC_Click(object sender, RoutedEventArgs e)
        {
            List<CbaocaoDT> BCDTSearch = new List<CbaocaoDT>();
            foreach (var item in Listbaocao)
            {
                if (txtSKU.Text == item.SKU)
                    BCDTSearch.Add(item);
            }
            if (BCDTSearch.Count == 0)
                MessageBox.Show("Không tìm thấy");
            else lsvBCDT.ItemsSource = BCDTSearch;
        }

        private void btnHuyTimKiemBC_Click(object sender, RoutedEventArgs e)
        {
            txtSKU.Text = "";
            lsvBCDT.ItemsSource = null;
            lsvBCDT.ItemsSource = Listbaocao;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            tapBCDT.luuBCDT("BCDT.txt");
        }

        //Trang
        

        public void nhapCBO(ComboBoxItem cbo)
        {
            sptCBO++;
            listcbo.Add(cbo);
        }
        public void nhaplistboxSP(ListBoxItem lbo)
        {
            sptcboSP++;
            List_lboSP.Add(lbo);
        }


        private void listboxSP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ListBox)?.SelectedItem as ListBoxItem)?.Content.ToString();
            for (int i = 0; i < mangSp.spt; i++)
            {
                if (mangSp.ListSPham[i].TenSanPham == text)
                    LsvDSNhapKho.Items.Add(mangSp.ListSPham[i]);
            }

        }


        private void btntabNhapHang_Click(object sender, RoutedEventArgs e)
        {
            //click đây thì Lịch sử nhập hàng của Tab Nhà cung cấp cập nhật
            Trang_ThongTinChiTietNCC tab2 = new Trang_ThongTinChiTietNCC();
            LichSuNhapHang lsu = new LichSuNhapHang();
            lsu.CapNhatLichSu(txtMaDon.Text, "10000000", DateTime.Now);
            mangLichSu.ListHistory.Add(lsu);
            tab2.LsvLichsu.ItemsSource = mangLichSu.ListHistory;
            MessageBox.Show("Nhập kho thành công", "", MessageBoxButton.OK);

        }

        private void LsvDSNhapKho_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboChonNCC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox)?.SelectedItem as ComboBoxItem)?.Content.ToString();
            int i;
            for (i = 0; i < mangNCC.spt; i++)
            {
                if (text == mangNCC.ListNCC[i].TenNCC)
                {
                    if (mangNCC.ListNCC[i].HTTT == "Chuyển khoản")
                        radCK.IsChecked = true;
                    else if (mangNCC.ListNCC[i].HTTT == "Tiền mặt")
                        radTM.IsChecked = true;
                    else break;
                }
            }
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

        private void BtnXoaNhom_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (CNhacungcap it in mangNCC.ListNCC)
            {
                if (it.TenNCC == lblTenNCC.Content.ToString())
                {
                    mangNCC.ListNCC.Remove(it);
                    LsvDSNCC.ItemsSource = mangNCC.ListNCC;
                    MessageBox.Show("Xóa thành công");

                    tabNCC.IsSelected = true;
                    break;
                }
            }
            mangNCC.spt = mangNCC.ListNCC.Count();
            mangNCC.capnhatfile("dataNCC.txt");
        }

        public void LayList(List<CNhacungcap> a)
        {
            mangNCC.ListNCC = a;
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int i;
            for (i = 0; i < mangNCC.spt; i ++)
            {
                if (mangNCC.ListNCC[i].TenNCC == lblTenNCC.Content.ToString())
                {
                    mangNCC.ListNCC[i].NhomNCC = txt_TTNCC_Nhom.Text;
                    mangNCC.ListNCC[i].MaNCC = txt_TTNCC_Ma.Text;
                    mangNCC.ListNCC[i].SDTNCC = txt_TTNCC_sdt.Text;
                    mangNCC.ListNCC[i].EmailNCC = txt_TTNCC_Email1.Text;
                    mangNCC.ListNCC[i].Website = txt_TTNCC_Website.Text;
                    mangNCC.ListNCC[i].ThueMD = txt_TTNCC_ThueMacDinh.Text;
                    mangNCC.ListNCC[i].GiaMD = txt_TTNCC_GiaMD.Text;
                    mangNCC.ListNCC[i].HTTT = txt_TTNCC_HTTT.Text;
                    mangNCC.ListNCC[i].NhanVien = txt_TTNCC_NVien1.Text;
                    mangNCC.ListNCC[i].DiaChi = txt_TTNCC_DiaChi.Text;
                }
            }
            MessageBox.Show("Cập nhật thành thành công");
            mangNCC.capnhatfile("dataNCC.txt");
            LsvDSNCC.ItemsSource = mangNCC.ListNCC;
        }

    }
}

