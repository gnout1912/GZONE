using GZone.models; // Cần để dùng Session và TaiKhoan
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GZone.QuanLyDangNhap
{
    // Đổi tên class từ DangNhap thành QuanLyDangNhap
    public partial class QuanLyDangNhap : Form
    {
        private QuanLyDangNhapDAL _dangNhapDAL;

        public QuanLyDangNhap() // Cập nhật constructor theo tên class mới
        {
            InitializeComponent();
            _dangNhapDAL = new QuanLyDangNhapDAL();
        }

        private void QuanLyDangNhap_Load(object sender, EventArgs e) // Đổi tên sự kiện Load form nếu có
        {
            // (Giả sử tên TextBox là txtMatKhau)
            txtMatKhau.PasswordChar = '*';
            this.AcceptButton = btnDangNhap; // Cho phép nhấn Enter
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // (Giả sử tên TextBox là txtTenDangNhap và txtMatKhau)
            string ten = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập Tên Đăng Nhập và Mật Khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TaiKhoan taiKhoan = _dangNhapDAL.Login(ten, matKhau);

                if (taiKhoan == null)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (taiKhoan.TrangThai == false)
                {
                    MessageBox.Show("Tài khoản này đã bị khóa. Vui lòng liên hệ quản trị viên.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Chào mừng {taiKhoan.Quyen} {taiKhoan.Ten}!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GZone.Session.LoggedInUser = taiKhoan;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}