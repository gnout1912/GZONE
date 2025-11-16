using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GZone
{
    public partial class TrangChuAdmin : Form
    {
        public TrangChuAdmin()
        {
            InitializeComponent();
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan frmQuanLyTaiKhoan = new QuanLyTaiKhoan();
            frmQuanLyTaiKhoan.ShowDialog();
        }

        private void btnQuanLyChiNhanh_Click(object sender, EventArgs e)
        {
            QuanLyChiNhanh frmQuanLyChiNhanh = new QuanLyChiNhanh();
            frmQuanLyChiNhanh.ShowDialog();
        }

        private void btnQuanDoanhThu_click(object sender, EventArgs e)
        {
            QuanLyDoanhThuHeThong.QuanLyDoanhThuHeThong frmQuanLyDoanhThuHeThong = new QuanLyDoanhThuHeThong.QuanLyDoanhThuHeThong();
            frmQuanLyDoanhThuHeThong.ShowDialog();

        }

        private void btnQuanLyGoiTap_Click(object sender, EventArgs e)
        {
            QuanLyGoiTap frmQuanLyGoiTap = new QuanLyGoiTap();
            frmQuanLyGoiTap.ShowDialog();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                                      "Xác nhận Đăng xuất",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                GZone.Session.LoggedInUser = null;
                this.Close();
            }
        }
    }
}
