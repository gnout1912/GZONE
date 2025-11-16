using GZone.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GZone.QuanLyLamViec
{
    public partial class frmXepLichNhanVien : Form
    {
        private NhanVien _nhanVienHienTai;
        private DateTime _ngayDauTuan;
        private string _maChiNhanh;
        private DangKiLichLamDAL _dangKiDAL;
        private CaDAL _caDAL;
        private List<Ca> _danhSachCa;
        private List<DangKiLichLam> _lichLamTuanNay;

        public frmXepLichNhanVien(NhanVien nhanVien)
        {
            InitializeComponent();
            _nhanVienHienTai = nhanVien;
            _maChiNhanh = _nhanVienHienTai.MaChiNhanh;
            _dangKiDAL = new DangKiLichLamDAL();
            _caDAL = new CaDAL();
        }

        private void frmXepLichNhanVien_Load(object sender, EventArgs e)
        {
            lblNhanVien.Text = $"{_nhanVienHienTai.Ten} ({_nhanVienHienTai.Ma.Trim()})";
            _danhSachCa = _caDAL.GetAllCa();
            TinhNgayDauTuan(DateTime.Today);
            LoadDuLieuLich();
        }

        private void TinhNgayDauTuan(DateTime selectedDate)
        {
            int diff = DayOfWeek.Monday - selectedDate.DayOfWeek;
            if (diff > 0) diff -= 7;

            _ngayDauTuan = selectedDate.AddDays(diff).Date;

            lblTuan.Text = $"Tuần từ: {_ngayDauTuan:dd/MM} đến {_ngayDauTuan.AddDays(6):dd/MM/yyyy}";
            dtpChonNgay.Value = _ngayDauTuan; 
        }

        private void LoadDuLieuLich()
        {
            _lichLamTuanNay = _dangKiDAL.GetLichLamTheoTuanCuaChiNhanh(_ngayDauTuan, _maChiNhanh);
            VeLaiGrid();
        }
        private void VeLaiGrid()
        {
            dgvLichTuan.Rows.Clear();
            dgvLichTuan.Columns.Clear();
            dgvLichTuan.RowHeadersVisible = true;
            for (int i = 0; i < 7; i++)
            {
                DateTime ngay = _ngayDauTuan.AddDays(i);
                string tenThu = CultureInfo.GetCultureInfo("vi-VN").DateTimeFormat.GetDayName(ngay.DayOfWeek);
                string tenCot = $"{tenThu}\n({ngay:dd/MM})";

                dgvLichTuan.Columns.Add($"col{i}", tenCot);
                dgvLichTuan.Columns[i].Tag = ngay;
                dgvLichTuan.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (Ca ca in _danhSachCa)
            {
                int rowIndex = dgvLichTuan.Rows.Add();
                dgvLichTuan.Rows[rowIndex].Tag = ca; 
                dgvLichTuan.Rows[rowIndex].HeaderCell.Value = $"{ca.TenCa}\n({ca.ThoiGianBD:hh\\:mm}-{ca.ThoiGianKT:hh\\:mm})";
            }
            dgvLichTuan.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            foreach (DangKiLichLam lich in _lichLamTuanNay)
            {
                int rowIdx = _danhSachCa.FindIndex(c => c.MaCa == lich.CaMa);

                int colIdx = (lich.NgayDangKy.Date - _ngayDauTuan.Date).Days;

                if (rowIdx >= 0 && colIdx >= 0 && colIdx < 7)
                {
                    DataGridViewCell cell = dgvLichTuan.Rows[rowIdx].Cells[colIdx];
                    cell.Value = lich.TenNhanVien; 

                    if (lich.NvMa == _nhanVienHienTai.Ma)
                    {
                        cell.Style.BackColor = Color.LightGreen;
                        cell.ToolTipText = "Click để Hủy ca này";
                    }
                    else
                    {
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.DarkGray;
                        cell.ReadOnly = true; 
                        cell.ToolTipText = $"Đã được {lich.TenNhanVien} đăng ký.";
                    }
                }
            }
            dgvLichTuan.ClearSelection();
        }

        private void dgvLichTuan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewCell cell = dgvLichTuan.Rows[e.RowIndex].Cells[e.ColumnIndex];
            Ca ca = (Ca)dgvLichTuan.Rows[e.RowIndex].Tag;
            DateTime ngay = (DateTime)dgvLichTuan.Columns[e.ColumnIndex].Tag;
            string tenNVTrongO = cell.Value?.ToString();

            if (cell.ReadOnly)
            {
                MessageBox.Show($"{ca.TenCa} ngày {ngay:dd/MM} đã được {tenNVTrongO} đăng ký.", "Ô đã bị khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(tenNVTrongO)) 
            {
                var confirm = MessageBox.Show($"Đăng ký {ca.TenCa} ({ngay:dd/MM}) cho {_nhanVienHienTai.Ten}?", "Xác nhận đăng ký", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    bool success = _dangKiDAL.AddDangKy(_nhanVienHienTai.Ma, ca.MaCa, ngay);
                    if (success)
                    {
                        LoadDuLieuLich();
                    }
                }
            }
            else if (tenNVTrongO == _nhanVienHienTai.Ten)
            {
                var confirm = MessageBox.Show($"Hủy {ca.TenCa} ({ngay:dd/MM}) của {_nhanVienHienTai.Ten}?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    bool success = _dangKiDAL.DeleteDangKy(_nhanVienHienTai.Ma, ca.MaCa, ngay);
                    if (success)
                    {
                        LoadDuLieuLich();
                    }
                }
            }
        }

        private void btnTuanTruoc_Click(object sender, EventArgs e)
        {
            TinhNgayDauTuan(_ngayDauTuan.AddDays(-7));
            LoadDuLieuLich();
        }

        private void btnTuanSau_Click(object sender, EventArgs e)
        {
            TinhNgayDauTuan(_ngayDauTuan.AddDays(7));
            LoadDuLieuLich();
        }

        private void dtpChonNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpChonNgay.Value.Date != _ngayDauTuan.Date)
            {
                TinhNgayDauTuan(dtpChonNgay.Value);
                LoadDuLieuLich();
            }
        }
    }
}