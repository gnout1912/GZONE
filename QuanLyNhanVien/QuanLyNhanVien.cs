    using GZone.models;
    using System;
    using System.Windows.Forms;

    namespace GZone
    {
        public partial class QuanLyNhanVien : Form
        {
            private NhanVienDAL _dal = new NhanVienDAL();

            public QuanLyNhanVien()
            {
                InitializeComponent();
            }

            private void QuanLyNhanVien_Load(object sender, EventArgs e)
            {
                LoadNhanVien();
                cbGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            }

            private void LoadNhanVien()
            {
                dgvNhanVien.DataSource = _dal.GetAllNhanVien();
            }

            private void ClearInputs()
            {
                txtTen.Clear();
                txtSdt.Clear();
                txtCNMa.Clear();
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

                NhanVien nv = new NhanVien
                {
                    Ten = txtTen.Text.Trim(),
                    Sdt = txtSdt.Text.Trim(),
                    GioiTinh = cbGioiTinh.SelectedItem?.ToString(),
                    MaChiNhanh = txtCNMa.Text.Trim()
                };

                _dal.AddNhanVien(nv);
                LoadNhanVien();
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
                    Ma = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["colMaNV"].Value),
                    Ten = txtTen.Text.Trim(),
                    Sdt = txtSdt.Text.Trim(),
                    GioiTinh = cbGioiTinh.SelectedItem?.ToString(),
                    MaChiNhanh = txtCNMa.Text.Trim()
                };

                _dal.UpdateNhanVien(nv);
                LoadNhanVien();
                ClearInputs(); 
            }

            private void btnXoa_Click(object sender, EventArgs e)
            {
                if (dgvNhanVien.CurrentRow == null)
                {
                    MessageBox.Show("⚠️ Vui lòng chọn nhân viên để xóa!");
                    return;
                }

                int maNV = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["colMaNV"].Value);
                if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _dal.DeleteNhanVien(maNV);
                    LoadNhanVien();
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

        }
    }
    }
