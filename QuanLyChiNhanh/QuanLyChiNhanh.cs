using GZone.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GZone
{
    public partial class QuanLyChiNhanh : Form
    {
        private ChiNhanhDAL _chiNhanhDAL;
        private YeuCauDAL _yeuCauDAL;
        private List<ChiNhanh> _danhSachChiNhanh;

        public QuanLyChiNhanh()
        {
            InitializeComponent();
            _chiNhanhDAL = new ChiNhanhDAL();
            _yeuCauDAL = new YeuCauDAL();
        }

        private void QuanLyChiNhanh_Load(object sender, EventArgs e)
        {
            SetupReadOnlyTextBoxes();
            LoadDanhSachChiNhanhLenList();
            SetupDgvYeuCauColumns();
        }

        private void SetupReadOnlyTextBoxes()
        {
            var textBoxes = new List<TextBox>
            {
                txtMaChiNhanh,
                txtTenChiNhanh,
                txtDiaChi,
                txtSoDienThoai,
                txtNgayThanhLap
            };

            foreach (var txt in textBoxes)
            {
                txt.ReadOnly = true;
                txt.BorderStyle = BorderStyle.None;
                txt.BackColor = Color.White;
                txt.TabStop = false;
            }
        }

        private void LoadDanhSachChiNhanhLenList()
        {
            try
            {
                _danhSachChiNhanh = _chiNhanhDAL.GetAllChiNhanh();
                lstChiNhanh.DataSource = null;
                lstChiNhanh.DataSource = _danhSachChiNhanh;
                lstChiNhanh.DisplayMember = "Ten";
                lstChiNhanh.ValueMember = "Ma";
                lstChiNhanh.SelectedIndex = -1;
                ClearDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chi nhánh: " + ex.Message);
            }
        }

        private void lstChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstChiNhanh.SelectedItem == null)
            {
                ClearDetails();
                return;
            }

            var selectedChiNhanh = lstChiNhanh.SelectedItem as ChiNhanh;
            if (selectedChiNhanh == null) return;

            LoadThongTinChiTiet(selectedChiNhanh);
            LoadYeuCauChiNhanh(selectedChiNhanh.Ma);
        }

        private void LoadThongTinChiTiet(ChiNhanh cn)
        {
            txtMaChiNhanh.Text = cn.Ma;
            txtTenChiNhanh.Text = cn.Ten;
            txtDiaChi.Text = cn.DiaChi;
            txtSoDienThoai.Text = cn.Sdt;
            txtNgayThanhLap.Text = cn.NgayThanhLap?.ToShortDateString() ?? "";
        }

        private void LoadYeuCauChiNhanh(string maChiNhanh)
        {
            try
            {
                List<YeuCau> yeuCauList = _yeuCauDAL.GetYeuCauTheoChiNhanh(maChiNhanh);
                dgvYeuCau.DataSource = null;
                dgvYeuCau.DataSource = yeuCauList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách yêu cầu: " + ex.Message);
            }
        }

        private void SetupDgvYeuCauColumns()
        {
            dgvYeuCau.AutoGenerateColumns = false;

            dgvYeuCau.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ma", HeaderText = "Mã YC", Width = 60 });
            dgvYeuCau.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TieuDe", HeaderText = "Tiêu Đề", Width = 150, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvYeuCau.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThai", HeaderText = "Trạng Thái", Width = 100 });
            dgvYeuCau.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayGui", HeaderText = "Ngày Gửi", Width = 120 });
            dgvYeuCau.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PhanHoi", HeaderText = "Phản Hồi", Width = 150, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvYeuCau.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayXuLy", HeaderText = "Ngày Xử Lý", Width = 120 });
        }

        private void ClearDetails()
        {
            txtMaChiNhanh.Text = "";
            txtTenChiNhanh.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtNgayThanhLap.Text = "";
            dgvYeuCau.DataSource = null;
        }

        private void btnThemChiNhanh_Click(object sender, EventArgs e)
        {
            ThemChiNhanhForm frmThem = new ThemChiNhanhForm();
            DialogResult result = frmThem.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadDanhSachChiNhanhLenList();
            }
        }

        private void btnSuaChiTiet_Click(object sender, EventArgs e)
        {
            if (lstChiNhanh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một chi nhánh để sửa.");
                return;
            }

            var selectedChiNhanh = lstChiNhanh.SelectedItem as ChiNhanh;
            if (selectedChiNhanh.Ma == null)
            {
                MessageBox.Show("Vui lòng chọn một chi nhánh cụ thể để sửa.");
                return;
            }

            ChinhSuaChiNhanhForm frmSuaCN = new ChinhSuaChiNhanhForm(selectedChiNhanh);
            DialogResult result = frmSuaCN.ShowDialog();

            if (result == DialogResult.OK)
            {
                int selectedIndex = lstChiNhanh.SelectedIndex;
                LoadDanhSachChiNhanhLenList();
                if (selectedIndex >= 0 && selectedIndex < lstChiNhanh.Items.Count)
                {
                    lstChiNhanh.SelectedIndex = selectedIndex;
                }
            }
        }

        private void btnPheDuyet_Click(object sender, EventArgs e)
        {
            XuLyYeuCau(true);
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            XuLyYeuCau(false);
        }

        private void XuLyYeuCau(bool isApproved)
        {
            if (dgvYeuCau.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu để xử lý.");
                return;
            }

            var yeuCau = dgvYeuCau.CurrentRow.DataBoundItem as YeuCau;
            if (yeuCau == null) return;

            if (yeuCau.TrangThai != "Chờ duyệt")
            {
                MessageBox.Show("Yêu cầu này đã được xử lý.");
                return;
            }

            string phanHoi = isApproved ? "Đã duyệt" : "Đã từ chối";

            yeuCau.TrangThai = phanHoi;
            yeuCau.PhanHoi = phanHoi;
            yeuCau.NgayXuLy = DateTime.Now;

            try
            {
                _yeuCauDAL.UpdateYeuCau(yeuCau);
                LoadYeuCauChiNhanh(yeuCau.MaChiNhanh);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật yêu cầu: " + ex.Message);
            }
        }
        private void dgvYeuCau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
