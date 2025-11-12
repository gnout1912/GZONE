using GZone.models;
using System;
using System.Windows.Forms;

namespace GZone
{
    public partial class QuanLyCoSoVatChat : Form
    {
        private readonly CoSoVatChatDAL _dal = new CoSoVatChatDAL();

        public QuanLyCoSoVatChat()
        {
            InitializeComponent();
        }

        private void QuanLyCoSoVatChat_Load(object sender, EventArgs e)
        {
            LoadData();
            cbTinhTrang.Items.AddRange(new string[] { "Hoạt động", "Hỏng", "Bảo trì" });
        }

        private void LoadData()
        {
            dgvCSVC.DataSource = _dal.GetAllCSVC();
        }

        private void ClearInputs()
        {
            txtCNMa.Clear();
            txtTenMay.Clear();
            txtLoaiMay.Clear();
            txtSoLuong.Clear();
            txtGhiChu.Clear();
            cbTinhTrang.SelectedIndex = -1; // bỏ chọn combobox
            txtCNMa.Focus(); // trỏ lại ô đầu tiên
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenMay.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập tên máy!");
                return;
            }

            var csvc = new CoSoVatChat
            {
                MaChiNhanh = txtCNMa.Text.Trim(),
                TenMay = txtTenMay.Text.Trim(),
                LoaiMay = txtLoaiMay.Text.Trim(),
                SoLuong = int.TryParse(txtSoLuong.Text, out int sl) ? sl : 1,
                TinhTrang = cbTinhTrang.SelectedItem?.ToString(),
                GhiChu = txtGhiChu.Text.Trim()
            };

            _dal.AddCSVC(csvc);
            LoadData();
            ClearInputs();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvCSVC.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Vui lòng chọn một hàng để sửa!");
                return;
            }

            var csvc = new CoSoVatChat
            {
                Ma = Convert.ToInt32(dgvCSVC.CurrentRow.Cells["colMa"].Value),
                MaChiNhanh = txtCNMa.Text.Trim(),
                TenMay = txtTenMay.Text.Trim(),
                LoaiMay = txtLoaiMay.Text.Trim(),
                SoLuong = int.TryParse(txtSoLuong.Text, out int sl) ? sl : 1,
                TinhTrang = cbTinhTrang.SelectedItem?.ToString(),
                GhiChu = txtGhiChu.Text.Trim()
            };

            _dal.UpdateCSVC(csvc);
            LoadData();
            ClearInputs();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvCSVC.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Vui lòng chọn hàng để xóa!");
                return;
            }

            int ma = Convert.ToInt32(dgvCSVC.CurrentRow.Cells["colMa"].Value);
            if (MessageBox.Show("Bạn có chắc muốn xóa máy này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _dal.DeleteCSVC(ma);
                LoadData();
                ClearInputs();
            }
        }

        private void dgvCSVC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCSVC.Rows[e.RowIndex];
                txtCNMa.Text = row.Cells["colCNMa"].Value?.ToString();
                txtTenMay.Text = row.Cells["colTenMay"].Value?.ToString();
                txtLoaiMay.Text = row.Cells["colLoaiMay"].Value?.ToString();
                txtSoLuong.Text = row.Cells["colSoLuong"].Value?.ToString();
                cbTinhTrang.Text = row.Cells["colTinhTrang"].Value?.ToString();
                txtGhiChu.Text = row.Cells["colGhiChu"].Value?.ToString();
            }
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
