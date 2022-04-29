using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tabDonHang.Sản_phẩm;

namespace tabDonHang
{
    public partial class FormBanHang : Form
    {
        public long SLBan { get; set; }
        long SLTK { get; set; }
        public FormBanHang()
        {
            InitializeComponent();
        }

        private void btnOKBan_Click(object sender, EventArgs e)
        {
                SLBan = long.Parse(txtSLBan.Text);
   
        }

        public void LaySLTonKho(long sltonkho)
        {
            lblSLtonkho.Text = sltonkho.ToString();
            SLTK = sltonkho;
        }

        private void txtSLBan_TextChanged(object sender, EventArgs e)
        {

                if (txtSLBan.Text == "")
                {
                    return;
                }
                if (long.TryParse(txtSLBan.Text, out long SLBan) == false)
                {

                    MessageBox.Show("Kiểm tra lại dữ liệu nhập\n Chú ý: \n- Số lượng là số nguyên");
                    txtSLBan.Text = "";
                }
                
        }

        private void txtSLBan_Leave(object sender, EventArgs e)
        {
            SLBan = long.Parse(txtSLBan.Text);
            if (SLBan > SLTK || SLBan < 0 )
            {
                MessageBox.Show("Số lượng bán phải nhỏ hơn lượng tồn kho");
                txtSLBan.Text = "";
            }
        }
    }
}
