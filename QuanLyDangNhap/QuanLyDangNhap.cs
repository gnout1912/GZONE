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

                    // =========================================================================
                    // PHẦN PHÂN QUYỀN MỚI THÊM VÀO Ở ĐÂY
                    if (taiKhoan.Quyen == "Admin") // Giả sử "Admin" là chuỗi đại diện cho quyền quản trị
                    {
                        // Hiển thị form quản lý chi nhánh
                        // Bạn cần đảm bảo đã tạo form QuanLyChiNhanh và có thể truy cập nó
                        // Cần thêm using GZone.Forms.QuanLyChiNhanh; hoặc namespace tương ứng nếu cần
                        QuanLyChiNhanh frmQuanLyChiNhanh = new QuanLyChiNhanh(); // <== Thay thế bằng tên form quản lý chi nhánh của bạn
                        this.Hide(); // Ẩn form đăng nhập
                        frmQuanLyChiNhanh.ShowDialog(); // Hiển thị form quản lý chi nhánh dưới dạng dialog
                        this.Close(); // Đóng form đăng nhập khi form quản lý chi nhánh đóng
                    }
                    else if (taiKhoan.Quyen == "Manager") // Ví dụ: Nếu là Manager
                    {
                        // Hiển thị form quản lý tài khoản hoặc form Dashboard cho Manager
                        // Ví dụ: QuanLyTaiKhoan frmQuanLyTaiKhoan = new QuanLyTaiKhoan();
                        // this.Hide();
                        // frmQuanLyTaiKhoan.ShowDialog();
                        // this.Close();
                        MessageBox.Show("Bạn đã đăng nhập với quyền Manager. Chức năng quản lý chi nhánh không khả dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Vẫn đóng form đăng nhập và báo thành công
                        this.Close(); // Đóng form đăng nhập sau khi thông báo
                    }
                    else
                    {
                        // Các quyền hạn khác hoặc form mặc định
                        MessageBox.Show("Bạn đã đăng nhập thành công với quyền hạn thấp hơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Vẫn đóng form đăng nhập và báo thành công
                        this.Close(); // Đóng form đăng nhập sau khi thông báo
                    }
                    // =========================================================================
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}