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
            // MỚI: Lấy mã chi nhánh trực tiếp từ Session
            string maCN = GZone.Session.MaChiNhanh;

            // MỚI: Gán mã chi nhánh vào textbox và khóa lại
            txtCNMa.Text = maCN;
            txtCNMa.ReadOnly = true;

            LoadData(); // Tải dữ liệu theo mã chi nhánh đó
            cbTinhTrang.Items.AddRange(new string[] { "Hoạt động", "Hỏng", "Bảo trì" });
        }

        private void LoadData()
        {
            // MỚI: Lấy mã chi nhánh từ Session
            string maCN = GZone.Session.MaChiNhanh;

            // MỚI: Thay vì gọi GetAllCSVC(),
            // chúng ta sẽ gọi hàm lọc theo mã chi nhánh (bạn sẽ cần tạo hàm này trong DAL)
            dgvCSVC.DataSource = _dal.GetCSVCByMaChiNhanh(maCN);
        }

        private void ClearInputs()
        {
            // txtCNMa.Clear(); // MỚI: Không xóa mã chi nhánh
            txtTenMay.Clear();
            txtLoaiMay.Clear();
            txtSoLuong.Clear();
            txtGhiChu.Clear();
            cbTinhTrang.SelectedIndex = -1; // bỏ chọn combobox
            txtTenMay.Focus(); // MỚI: Trỏ lại ô Tên máy
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
                // MỚI: Lấy mã chi nhánh từ Session, không dùng textbox
                MaChiNhanh = GZone.Session.MaChiNhanh,
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
                // MỚI: Lấy mã chi nhánh từ Session, không dùng textbox
                MaChiNhanh = GZone.Session.MaChiNhanh,
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
                // MỚI: Không cần thiết gán txtCNMa nữa vì nó đã bị khóa,
                // nhưng giữ lại cũng không sao
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