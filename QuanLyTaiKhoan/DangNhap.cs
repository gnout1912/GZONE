using GZone.models;
using GZone.QuanLyThanhVien;
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
    public partial class DangNhap : Form
    {

        private TaiKhoanDAL tkDAL;
        public DangNhap()
        {
            InitializeComponent();
            tkDAL = new TaiKhoanDAL();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string ten = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // 1. Gọi hàm mới (ở Bước 2) để kiểm tra
            TaiKhoan taiKhoan = tkDAL.GetAccountLogin(ten, matKhau);

            // 2. Kiểm tra kết quả
            if (taiKhoan != null)
            {
                // === ĐĂNG NHẬP THÀNH CÔNG ===

                // 3. LƯU THÔNG TIN VÀO SESSION (Đây là lúc "lấy" chi nhánh)
                Session.MaTaiKhoan = taiKhoan.Ma;
                Session.TenTaiKhoan = taiKhoan.Ten;
                Session.Quyen = taiKhoan.Quyen;
                Session.MaChiNhanh = taiKhoan.MaChiNhanh; //

                // 4. Mở Form chính (ví dụ frmMain) và ẩn form login
                MessageBox.Show($"Đăng nhập thành công với quyền {Session.Quyen} tại chi nhánh {Session.MaChiNhanh}!");

                QuanLyThanhVien.QuanLyThanhVien qltv = new QuanLyThanhVien.QuanLyThanhVien(); // (Thay bằng tên Form chính của bạn)
                qltv.Show();
                this.Hide();
            }
            else
            {
                // === ĐĂNG NHẬP THẤT BẠI ===
                MessageBox.Show("Sai tên đăng nhập, mật khẩu hoặc tài khoản đã bị khóa.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
