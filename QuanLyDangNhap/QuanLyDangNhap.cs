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
                    GZone.Session.MaTaiKhoan = taiKhoan.Ma;
                    GZone.Session.TenTaiKhoan = taiKhoan.Ten; 
                    GZone.Session.MaChiNhanh = taiKhoan.MaChiNhanh; 
                    GZone.Session.Quyen = taiKhoan.Quyen;

                    this.Hide();

                    if (taiKhoan.Quyen == "Admin") 
                    {
      
                        TrangChuAdmin frmTrangChuAdmin = new TrangChuAdmin(); 

                        frmTrangChuAdmin.ShowDialog();
                    }
                    else if (taiKhoan.Quyen == "Manager") 
                    {
                        TrangChuManager frmTrangChuChiNhanh = new TrangChuManager();
                        frmTrangChuChiNhanh.ShowDialog();
                    }
                    else
                    {
                        QuanLyThanhVien.QuanLyThanhVien frmQuanLyThanhVien = new QuanLyThanhVien.QuanLyThanhVien();
                        frmQuanLyThanhVien.ShowDialog();

                    }
                    txtMatKhau.Text = "";
                    txtTenDangNhap.Text = "";
                    this.Show();
                    txtTenDangNhap.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}