using GZone.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GZone
{
    public partial class QuanLyNhanVien : Form
    {
        private NhanVienDAL _dal = new NhanVienDAL();

        // BIẾN MỚI: Dùng để lưu mã chi nhánh của Manager
        private string _maChiNhanhCuaManager;

        // Constructor mặc định (dành cho Admin)
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        // CONSTRUCTOR MỚI: Dành cho Manager (nhận mã chi nhánh)
        public QuanLyNhanVien(string maChiNhanh) : this() // ": this()" gọi constructor mặc định ở trên
        {
            _maChiNhanhCuaManager = maChiNhanh;
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            cbGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });

            // CẢI TIẾN: Nếu là Manager, tự điền và khóa ô Mã Chi Nhánh
            if (!string.IsNullOrEmpty(_maChiNhanhCuaManager))
            {
                txtCNMa.Text = _maChiNhanhCuaManager;
                txtCNMa.ReadOnly = true; // Khóa không cho Manager sửa
            }

            // Tải danh sách nhân viên (hàm này đã được sửa ở dưới)
            LoadNhanVien();
        }

        private void LoadNhanVien()
        {
            // SỬA LẠI LOGIC:
            // Nếu _maChiNhanhCuaManager là null (Admin), tải tất cả.
            // Nếu có mã (Manager), chỉ tải theo mã đó.
            if (string.IsNullOrEmpty(_maChiNhanhCuaManager))
            {
                dgvNhanVien.DataSource = _dal.GetAllNhanVien();
            }
            else
            {
                // Gọi hàm mới ta vừa tạo ở Bước 1
                dgvNhanVien.DataSource = _dal.GetNhanVienByChiNhanh(_maChiNhanhCuaManager);
            }
        }

        private void ClearInputs()
        {
            txtTen.Clear();
            txtSdt.Clear();

            // Nếu không phải Manager thì mới xóa ô Chi Nhánh
            if (string.IsNullOrEmpty(_maChiNhanhCuaManager))
            {
                txtCNMa.Clear();
            }

            cbGioiTinh.SelectedIndex = -1;
            txtTen.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text) || string.IsNullOrWhiteSpace(txtSdt.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập đầy đủ thông tin nhân viên!");
                return;
            }

            // Logic này vẫn đúng vì txtCNMa đã được gán sẵn nếu là Manager
            NhanVien nv = new NhanVien
            {
                Ten = txtTen.Text.Trim(),
                Sdt = txtSdt.Text.Trim(),
                GioiTinh = cbGioiTinh.SelectedItem?.ToString(),
                MaChiNhanh = txtCNMa.Text.Trim()
            };

            _dal.AddNhanVien(nv);
            LoadNhanVien(); // Tải lại danh sách đã lọc
            ClearInputs();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Vui lòng chọn nhân viên để sửa!");
                return;
            }

            NhanVien nv = new NhanVien
            {
                Ma = dgvNhanVien.CurrentRow.Cells["colMaNV"].Value.ToString(),
                Ten = txtTen.Text.Trim(),
                Sdt = txtSdt.Text.Trim(),
                GioiTinh = cbGioiTinh.SelectedItem?.ToString(),
                MaChiNhanh = txtCNMa.Text.Trim() // Vẫn lấy từ textbox (đã bị khóa)
            };

            _dal.UpdateNhanVien(nv);
            LoadNhanVien(); // Tải lại
            ClearInputs();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Vui lòng chọn nhân viên để xóa!");
                return;
            }

            string maNV = dgvNhanVien.CurrentRow.Cells["colMaNV"].Value.ToString();
            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _dal.DeleteNhanVien(maNV);
                LoadNhanVien(); // Tải lại
                ClearInputs();
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtTen.Text = row.Cells["colTenNV"].Value?.ToString();
                txtSdt.Text = row.Cells["colSdt"].Value?.ToString();
                cbGioiTinh.Text = row.Cells["colGioiTinh"].Value?.ToString();
                txtCNMa.Text = row.Cells["colCNMa"].Value?.ToString();
            }
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Không cần code ở đây
        }
    }
}