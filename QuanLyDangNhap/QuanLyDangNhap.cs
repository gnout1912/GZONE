using GZone.models; 
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
    public partial class QuanLyDangNhap : Form
    {
        private QuanLyDangNhapDAL _dangNhapDAL;

        public QuanLyDangNhap() 
        {
            InitializeComponent();
            _dangNhapDAL = new QuanLyDangNhapDAL();
        }

        private void QuanLyDangNhap_Load(object sender, EventArgs e) 
        {
            txtMatKhau.PasswordChar = '*';
            this.AcceptButton = btnDangNhap; 
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
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
                    GZone.Session.MaTaiKhoan = taiKhoan.Ma; // Ví dụ: taiKhoan.MaTaiKhoan
                    GZone.Session.TenTaiKhoan = taiKhoan.Ten; // Ví dụ: taiKhoan.TenHienThi
                    GZone.Session.MaChiNhanh = taiKhoan.MaChiNhanh; // << QUAN TRỌNG NHẤT
                    GZone.Session.Quyen = taiKhoan.Quyen;


                    if (taiKhoan.Quyen == "Admin") 
                    {
      
                        TrangChuAdmin frmTrangChuAdmin = new TrangChuAdmin(); 
                        this.Hide();
                        frmTrangChuAdmin.ShowDialog(); 
                        this.Close(); 
                    }
                    else if (taiKhoan.Quyen == "Manager") 
                    {
                        TrangChuChiNhanh frmTrangChuChiNhanh = new TrangChuChiNhanh();
                        this.Hide();
                        frmTrangChuChiNhanh.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã đăng nhập thành công với quyền hạn thấp hơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; 
                        this.Close(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}