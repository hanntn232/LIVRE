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
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        CmangUser mangU = new CmangUser();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Han_MaiAnh Maintab = new Han_MaiAnh();
            CUser user = new CUser(txtUsername.Text, txtPass.Password);
            mangU.docfile("Userdata.txt");
            if (mangU.tim(user) == true)
            {
                lblTbao.Content = "";
                MessageBox.Show(mangU.phanquyen(user), "", MessageBoxButton.OK);
                Maintab.Show();
                this.Close();
            }
            else if (mangU.tim(user) == false)
            {
                lblTbao.Content = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
        }
    }
}
