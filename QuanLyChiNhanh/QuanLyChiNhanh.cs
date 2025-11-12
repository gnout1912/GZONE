using GZone.models; // Sử dụng namespace models của bạn
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GZone.QuanLyChiNhanh
{
    // Đây là class logic tương ứng với file Designer.cs của bạn
    public partial class QuanLyChiNhanh : Form
    {
        private TaiKhoanDAL _taiKhoanDAL;
        private ChiNhanhDAL _chiNhanhDAL;
        private List<TaiKhoan> _toanBoTaiKhoan; // Danh sách cache
        private List<ChiNhanh> _danhSachChiNhanh; // Danh sách cache

        public QuanLyChiNhanh()
        {
            InitializeComponent(); // Hàm này nằm trong file Designer.cs
            _taiKhoanDAL = new TaiKhoanDAL();
            _chiNhanhDAL = new ChiNhanhDAL();
        }

        private void QuanLyChiNhanh_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadData();
        }

        private void SetupDataGridView()
        {
            // Cấu hình các cột cho DataGridView
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.Columns.Clear();

            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMa",
                HeaderText = "ID (Mã TK)",
                DataPropertyName = "Ma", // Phải trùng với tên thuộc tính của class TaiKhoan
                Width = 120
            });

            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTen",
                HeaderText = "Tên đăng nhập",
                DataPropertyName = "Ten", // Phải trùng với tên thuộc tính của class TaiKhoan
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuyen",
                HeaderText = "Quyền hạn",
                DataPropertyName = "Quyen", // Phải trùng với tên thuộc tính của class TaiKhoan
                Width = 150
            });

            dgvTaiKhoan.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colTrangThai",
                HeaderText = "Trạng thái",
                DataPropertyName = "TrangThai", // Phải trùng với tên thuộc tính của class TaiKhoan
                Width = 100
            });
        }

        private void LoadData()
        {
            // Load danh sách chi nhánh
            _danhSachChiNhanh = _chiNhanhDAL.GetAllChiNhanh();
            // Thêm mục "Tất cả" vào đầu danh sách
            _danhSachChiNhanh.Insert(0, new ChiNhanh { Ma = 0, Ten = "--- Tất cả chi nhánh ---" });

            lstChiNhanh.DataSource = null; // Xóa datasource cũ
            lstChiNhanh.DataSource = _danhSachChiNhanh;
            lstChiNhanh.DisplayMember = "Ten";
            lstChiNhanh.ValueMember = "Ma";

            // Load toàn bộ tài khoản
            _toanBoTaiKhoan = _taiKhoanDAL.GetAllTaiKhoan();

            // Lọc danh sách tài khoản theo lựa chọn
            FilterTaiKhoanGrid();
        }

        private void FilterTaiKhoanGrid()
        {
            if (lstChiNhanh.SelectedItem == null || _toanBoTaiKhoan == null)
                return;

            var selectedChiNhanh = lstChiNhanh.SelectedItem as ChiNhanh;

            List<TaiKhoan> filteredList;

            if (selectedChiNhanh.Ma == 0) // "Tất cả chi nhánh"
            {
                filteredList = _toanBoTaiKhoan;
                lblTieuDeTaiKhoan.Text = "TÀI KHOẢN TẤT CẢ CHI NHÁNH";
            }
            else
            {
                // Lọc tài khoản theo MaChiNhanh
                filteredList = _toanBoTaiKhoan
                    .Where(tk => tk.MaChiNhanh == selectedChiNhanh.Ma)
                    .ToList();
                lblTieuDeTaiKhoan.Text = $"TÀI KHOẢN CHI NHÁNH {selectedChiNhanh.Ten.ToUpper()}";
            }

            dgvTaiKhoan.DataSource = null;
            // Sử dụng BindingList để DataGridView tự động cập nhật khi có thay đổi
            dgvTaiKhoan.DataSource = new BindingList<TaiKhoan>(filteredList);
        }

        private void lstChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi chọn chi nhánh khác, lọc lại Grid
            FilterTaiKhoanGrid();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Chức năng này cần một Form/Dialog mới để nhập thông tin
            // Ví dụ:
            // frmChiTietTaiKhoan frmThem = new frmChiTietTaiKhoan(_danhSachChiNhanh);
            // if (frmThem.ShowDialog() == DialogResult.OK)
            // {
            //    LoadData(); // Tải lại dữ liệu nếu thêm thành công
            // }
            MessageBox.Show("Chức năng 'Thêm mới' cần một Form chi tiết (chưa được cài đặt).");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTK = dgvTaiKhoan.CurrentRow.DataBoundItem as TaiKhoan;
            if (selectedTK == null) return;

            // Chức năng này cần một Form/Dialog mới để sửa thông tin
            // Ví dụ:
            // frmChiTietTaiKhoan frmSua = new frmChiTietTaiKhoan(selectedTK, _danhSachChiNhanh);
            // if (frmSua.ShowDialog() == DialogResult.OK)
            // {
            //    LoadData(); // Tải lại dữ liệu nếu sửa thành công
            // }
            MessageBox.Show($"Chức năng 'Sửa' tài khoản: {selectedTK.Ma} (chưa được cài đặt).");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTK = dgvTaiKhoan.CurrentRow.DataBoundItem as TaiKhoan;
            if (selectedTK == null) return;

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản '{selectedTK.Ten}' (Mã: {selectedTK.Ma})?",
                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _taiKhoanDAL.DeleteTaiKhoan(selectedTK.Ma);
                // Lớp DAL của bạn đã tự hiển thị MessageBox
                LoadData(); // Tải lại dữ liệu sau khi xóa
            }
        }

        private void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để reset mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTK = dgvTaiKhoan.CurrentRow.DataBoundItem as TaiKhoan;
            if (selectedTK == null) return;

            // Trong thực tế, bạn nên dùng InputBox hoặc 1 form nhỏ để nhập mật khẩu mới
            // Ở đây, ta reset về một mật khẩu mặc định, ví dụ "123456"
            string matKhauMoi = "123456";

            var confirm = MessageBox.Show($"Bạn có chắc muốn reset mật khẩu cho tài khoản '{selectedTK.Ma}' về '{matKhauMoi}'?",
                                          "Xác nhận Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Giả sử bạn có hàm mã hóa mật khẩu, hãy mã hóa 'matKhauMoi' trước khi gọi DAL
                // Ví dụ: string hashedMk = MaHoaMatKhau(matKhauMoi);
                // _taiKhoanDAL.ResetMatKhau(selectedTK.Ma, hashedMk);

                _taiKhoanDAL.ResetMatKhau(selectedTK.Ma, matKhauMoi);
                // Lớp DAL của bạn đã tự hiển thị MessageBox
            }
        }
    }
}