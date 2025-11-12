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

namespace GZone
{
    public partial class ChinhSuaTaiKhoanForm : Form
    {
        // Dùng 2 biến này để lưu trữ
        private TaiKhoan _taiKhoanCanSua;
        private List<ChiNhanh> _danhSachChiNhanh;
        private TaiKhoanDAL _taiKhoanDAL;

        // Quyền hạn - Định nghĩa ở một nơi để dễ quản lý
        private readonly List<string> _danhSachQuyen = new List<string> { "Admin", "Manager", "Staff" };

        public ChinhSuaTaiKhoanForm(TaiKhoan taiKhoan, List<ChiNhanh> danhSachChiNhanh)
        {
            InitializeComponent(); // <-- Lỗi null xảy ra nếu .Designer.cs không tạo control

            _taiKhoanCanSua = taiKhoan;
            // Lọc bỏ mục "Tất cả chi nhánh" (Ma == null)
            _danhSachChiNhanh = danhSachChiNhanh.Where(cn => cn.Ma != null).ToList();
            _taiKhoanDAL = new TaiKhoanDAL();
        }

        private void ChinhSuaTaiKhoanForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Nạp ComboBox Quyền
                cboQuyen.DataSource = _danhSachQuyen;

                // Nạp ComboBox Chi Nhánh
                cboChiNhanh.DataSource = _danhSachChiNhanh;
                cboChiNhanh.DisplayMember = "Ten";
                cboChiNhanh.ValueMember = "Ma";

                // Điền thông tin tài khoản hiện tại vào Form
                txtMaTaiKhoan.Text = _taiKhoanCanSua.Ma;
                txtTenDangNhap.Text = _taiKhoanCanSua.Ten;
                cboQuyen.SelectedItem = _taiKhoanCanSua.Quyen;
                chkTrangThai.Checked = _taiKhoanCanSua.TrangThai;

                // Xử lý chọn chi nhánh dựa trên quyền
                if (_taiKhoanCanSua.Quyen == "Admin")
                {
                    cboChiNhanh.Enabled = false;
                    cboChiNhanh.SelectedValue = -1; // Admin không có chi nhánh
                }
                else
                {
                    cboChiNhanh.Enabled = true;
                    // Phải kiểm tra MaChiNhanh có tồn tại không
                    if (_taiKhoanCanSua.MaChiNhanh != null)
                    {
                        cboChiNhanh.SelectedValue = _taiKhoanCanSua.MaChiNhanh;
                    }
                    else
                    {
                        cboChiNhanh.SelectedIndex = -1; // Không thuộc CN nào
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu là Admin, vô hiệu hóa chọn Chi nhánh
            if (cboQuyen.SelectedItem != null && cboQuyen.SelectedItem.ToString() == "Admin")
            {
                cboChiNhanh.Enabled = false;
                cboChiNhanh.SelectedIndex = -1; // Bỏ chọn
            }
            else
            {
                cboChiNhanh.Enabled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // === Xác thực (Validate) dữ liệu ===
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboQuyen.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string quyenDuocChon = cboQuyen.SelectedItem.ToString();

            // Chỉ bắt buộc chọn chi nhánh nếu không phải là Admin
            if (quyenDuocChon != "Admin" && cboChiNhanh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh cho Manager hoặc Staff.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // === Cập nhật dữ liệu vào đối tượng ===
            try
            {
                // Cập nhật các thuộc tính của đối tượng _taiKhoanCanSua
                _taiKhoanCanSua.Ten = txtTenDangNhap.Text.Trim();
                _taiKhoanCanSua.Quyen = quyenDuocChon;
                _taiKhoanCanSua.TrangThai = chkTrangThai.Checked;
                _taiKhoanCanSua.MaChiNhanh = (quyenDuocChon == "Admin") ? null : cboChiNhanh.SelectedValue.ToString();

                // Gọi DAL để cập nhật
                _taiKhoanDAL.UpdateTaiKhoan(_taiKhoanCanSua);

                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Báo cho form cha biết là đã thành công
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thất bại: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm này được gọi khi nhấn nút Hủy (đã được gán trong Designer)
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}