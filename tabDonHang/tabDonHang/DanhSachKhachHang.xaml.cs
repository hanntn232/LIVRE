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
using tabDonHang.Phân_Loại_Khách_Hàng;

namespace tabDonHang
{
    /// <summary>
    /// Interaction logic for DanhSachKhachHang.xaml
    /// </summary>
    public partial class DanhSachKhachHang : Window
    {
        MangKhachHang mangKH = new MangKhachHang();
        Load_DSKhachHang load_DSKH = new Load_DSKhachHang();

        public DanhSachKhachHang()
        {
            InitializeComponent();
            
            //LsvKhachHang.ItemsSource = load_DSKH.LoadDSKH_TraVeItemSource();
        }

        private void BtnXuatDS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHuyTimKiem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
