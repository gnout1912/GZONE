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
            // Giả sử bạn có Form tên là QuanLyChamCong
            QuanLyChamCong frm = new QuanLyChamCong();
            frm.ShowDialog();
        }

        private void btnQuanLyCoSoVatChat_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có Form tên là QuanLyCoSoVatChat
            QuanLyCoSoVatChat frm = new QuanLyCoSoVatChat();
            frm.ShowDialog();
        }

        private void btnQuanLyDoanhThuChiNhanh_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có Form tên là QuanLyDoanhThuChiNhanh
            GZone.QuanLyDoanhThuChiNhanh.QuanLyDoanhThuChiNhanh frm = new GZone.QuanLyDoanhThuChiNhanh.QuanLyDoanhThuChiNhanh();
            frm.ShowDialog();

        }

        private void btnQuanLyGoiTap_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có Form tên là QuanLyGoiTap
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
            // 1. Lấy thông tin manager từ session
            var manager = GZone.Session.LoggedInUser;

            // 2. Kiểm tra xem manager có được gán chi nhánh không
            if (manager == null || string.IsNullOrEmpty(manager.MaChiNhanh))
            {
                MessageBox.Show("Lỗi: Tài khoản của bạn không được gán vào chi nhánh nào.",
                                "Lỗi Phân Quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Lấy mã chi nhánh
            string maChiNhanhCuaManager = manager.MaChiNhanh;

            // 4. Mở form QuanLyNhanVien và "truyền" mã chi nhánh này vào
            // (Chúng ta sẽ tạo constructor mới này ở Bước 2)
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
    }
}