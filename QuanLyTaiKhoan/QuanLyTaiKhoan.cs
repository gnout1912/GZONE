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
    public partial class QuanLyTaiKhoan : Form
    {
        private TaiKhoanDAL _taiKhoanDAL;
        private ChiNhanhDAL _chiNhanhDAL;
        private List<TaiKhoan> _toanBoTaiKhoan;
        private List<ChiNhanh> _danhSachChiNhanh;


        public QuanLyTaiKhoan()
        {
            InitializeComponent();
            _taiKhoanDAL = new TaiKhoanDAL();
            _chiNhanhDAL = new ChiNhanhDAL();
        }

        #region Form & Grid Setup

        private void QuanLyChiNhanh_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadData();
        }

        private void SetupDataGridView()
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.Columns.Clear();

            // Chỉ thêm các cột dữ liệu
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMa",
                HeaderText = "ID (Mã TK)",
                DataPropertyName = "Ma",
                Width = 120
            });

            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTen",
                HeaderText = "Tên đăng nhập",
                DataPropertyName = "Ten",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuyen",
                HeaderText = "Quyền hạn",
                DataPropertyName = "Quyen",
                Width = 150
            });

            dgvTaiKhoan.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colTrangThai",
                HeaderText = "Trạng thái",
                DataPropertyName = "TrangThai",
                Width = 100
            });

            // --- Đã xóa logic thêm các cột nút Sửa/Xóa vào lưới ---
        }

        #endregion

        #region Data Loading & Filtering

        private void LoadData()
        {
            var selectedValue = lstChiNhanh.SelectedValue;

            _danhSachChiNhanh = _chiNhanhDAL.GetAllChiNhanh();
            _danhSachChiNhanh.Insert(0, new ChiNhanh { Ma = null, Ten = "--- Tất cả chi nhánh ---" });

            lstChiNhanh.DataSource = null;
            lstChiNhanh.DataSource = _danhSachChiNhanh;
            lstChiNhanh.DisplayMember = "Ten";
            lstChiNhanh.ValueMember = "Ma";

            if (selectedValue != null)
            {
                lstChiNhanh.SelectedValue = selectedValue;
            }

            _toanBoTaiKhoan = _taiKhoanDAL.GetAllTaiKhoan();
            FilterTaiKhoanGrid();
        }

        private void FilterTaiKhoanGrid()
        {
            if (lstChiNhanh.SelectedItem == null || _toanBoTaiKhoan == null)
                return;

            var selectedChiNhanh = lstChiNhanh.SelectedItem as ChiNhanh;
            List<TaiKhoan> filteredList;

            if (selectedChiNhanh.Ma == null)
            {
                filteredList = _toanBoTaiKhoan;
                lblTieuDeTaiKhoan.Text = "TÀI KHOẢN TẤT CẢ CHI NHÁNH";
            }
            else
            {
                filteredList = _toanBoTaiKhoan
                    .Where(tk => tk.MaChiNhanh == selectedChiNhanh.Ma)
                    .ToList();
                lblTieuDeTaiKhoan.Text = $"TÀI KHOẢN CHI NHÁNH {selectedChiNhanh.Ten.ToUpper()}";
            }

            dgvTaiKhoan.DataSource = null;
            dgvTaiKhoan.DataSource = new BindingList<TaiKhoan>(filteredList);
        }

        #endregion

        #region Button Click Events (Top Panel)

        private void lstChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTaiKhoanGrid();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var danhSachChiNhanhThat = _danhSachChiNhanh.Where(cn => cn.Ma != null).ToList();

            ThemTaiKhoanForm frmThem = new ThemTaiKhoanForm(danhSachChiNhanhThat);
            DialogResult result = frmThem.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadData();
            }
        }

        // Sửa lại hàm btnSua_Click
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTK = dgvTaiKhoan.CurrentRow.DataBoundItem as TaiKhoan;
            if (selectedTK == null) return;

            // Gọi hàm helper
            SuaTaiKhoan(selectedTK);
        }

        // Giữ nguyên hàm btnXoa_Click
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTK = dgvTaiKhoan.CurrentRow.DataBoundItem as TaiKhoan;
            if (selectedTK == null) return;

            // Gọi hàm helper
            XoaTaiKhoan(selectedTK);
        }

        #endregion

        #region Helper Methods (Sửa, Xóa)

        // Hàm helper để Sửa
        private void SuaTaiKhoan(TaiKhoan taiKhoanCanSua)
        {
            if (taiKhoanCanSua == null)
            {
                MessageBox.Show("Không có tài khoản hợp lệ để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var danhSachChiNhanhThat = _danhSachChiNhanh.Where(cn => cn.Ma != null).ToList();

            // Giả sử bạn có Form 'ChinhSuaTaiKhoanForm'
            ChinhSuaTaiKhoanForm frmSuaTK = new ChinhSuaTaiKhoanForm(taiKhoanCanSua, danhSachChiNhanhThat);
            DialogResult result = frmSuaTK.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadData();
            }
        }

        // Hàm helper để Xóa
        private void XoaTaiKhoan(TaiKhoan taiKhoanCanXoa)
        {
            if (taiKhoanCanXoa == null)
            {
                MessageBox.Show("Không có tài khoản hợp lệ để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản '{taiKhoanCanXoa.Ten}' (Mã: {taiKhoanCanXoa.Ma})?",
                                            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _taiKhoanDAL.DeleteTaiKhoan(taiKhoanCanXoa.Ma);
                LoadData();
                MessageBox.Show("Xóa tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Stub Functions (for Designer)

        // Hàm này PHẢI TỒN TẠI vì tệp Designer.cs của bạn có liên kết đến nó
        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Để trống
        }

        private void splitMain_Panel2_Paint(object sender, PaintEventArgs e)
        {
            // Để trống
        }

        #endregion
    }
}