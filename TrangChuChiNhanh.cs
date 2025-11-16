using GZone.QuanLyLamViec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GZone
{
    public partial class TrangChuChiNhanh : Form
    {
        public TrangChuChiNhanh()
        {
            InitializeComponent();
        }

        private void btnQuanLyChamCong_Click(object sender, EventArgs e)
        {
            QuanLyChamCong frm = new QuanLyChamCong();
            frm.ShowDialog();
        }

        private void btnQuanLyCoSoVatChat_Click(object sender, EventArgs e)
        {
            QuanLyCoSoVatChat frm = new QuanLyCoSoVatChat();
            frm.ShowDialog();
        }

        private void btnQuanLyDoanhThuChiNhanh_Click(object sender, EventArgs e)
        {

            var manager = GZone.Session.LoggedInUser;
            if (manager == null || string.IsNullOrEmpty(manager.MaChiNhanh))
            {
                MessageBox.Show("Lỗi: Tài khoản của bạn không được gán vào chi nhánh nào.",
                                "Lỗi Phân Quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maChiNhanhCuaManager = manager.MaChiNhanh;

            GZone.QuanLyDoanhThuChiNhanh.QuanLyDoanhThuChiNhanh frm =
                new GZone.QuanLyDoanhThuChiNhanh.QuanLyDoanhThuChiNhanh(maChiNhanhCuaManager);

            frm.ShowDialog();
        }

        private void btnQuanLyGoiTap_Click(object sender, EventArgs e)
        {
            QuanLyGoiTap frm = new QuanLyGoiTap();
            frm.ShowDialog();
        }

        private void btnQuanLyLamViec_Click(object sender, EventArgs e)
        {
            var manager = GZone.Session.LoggedInUser;
            string maChiNhanhCuaManager = manager.MaChiNhanh;
            GZone.QuanLyLamViec.Quanlylamviec frm = new Quanlylamviec(maChiNhanhCuaManager);
            frm.ShowDialog();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            var manager = GZone.Session.LoggedInUser;
            if (manager == null || string.IsNullOrEmpty(manager.MaChiNhanh))
            {
                MessageBox.Show("Lỗi: Tài khoản của bạn không được gán vào chi nhánh nào.",
                                "Lỗi Phân Quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maChiNhanhCuaManager = manager.MaChiNhanh;

            QuanLyNhanVien frm = new QuanLyNhanVien(maChiNhanhCuaManager);
            frm.ShowDialog();
        }

        private void btnQuanLyThanhVien_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có Form tên là QuanLyThanhVien
            //QuanLyThanhVien frm = new QuanLyThanhVien();
            // frm.ShowDialog();
            MessageBox.Show("Chức năng 'Quản lý Thành viên' đang được phát triển.");
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
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