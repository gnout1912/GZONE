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
        // Nhân viên đang được xếp lịch
        private NhanVien _nhanVienHienTai;

        // Ngày đầu tuần (luôn là Thứ 2)
        private DateTime _ngayDauTuan;

        // Danh sách
        private DangKiLichLamDAL _dangKiDAL;
        private CaDAL _caDAL;
        private List<Ca> _danhSachCa;
        private List<DangKiLichLam> _lichLamTuanNay; // Lịch của tất cả NV

        public frmXepLichNhanVien(NhanVien nhanVien)
        {
            InitializeComponent();
            _nhanVienHienTai = nhanVien;
            _dangKiDAL = new DangKiLichLamDAL();
            _caDAL = new CaDAL();
        }

        private void frmXepLichNhanVien_Load(object sender, EventArgs e)
        {
            lblNhanVien.Text = $"{_nhanVienHienTai.Ten} ({_nhanVienHienTai.Ma.Trim()})";

            // Lấy danh sách 3 ca (Sáng, Chiều, Tối)
            _danhSachCa = _caDAL.GetAllCa();

            // Tính ngày đầu tuần (Thứ 2) từ ngày hôm nay
            TinhNgayDauTuan(DateTime.Today);

            // Tải dữ liệu lịch
            LoadDuLieuLich();
        }

        // Hàm này tính toán và lưu ngày Thứ 2 đầu tuần vào biến _ngayDauTuan
        private void TinhNgayDauTuan(DateTime selectedDate)
        {
            // DayOfWeek của C# Chủ Nhật = 0, Thứ Hai = 1, ...
            int diff = DayOfWeek.Monday - selectedDate.DayOfWeek;
            if (diff > 0) diff -= 7; // Nếu ngày chọn là T2->T7, diff sẽ âm. Nếu là CN (0), diff = 1, cần trừ 7.

            _ngayDauTuan = selectedDate.AddDays(diff).Date;

            // Cập nhật UI
            lblTuan.Text = $"Tuần từ: {_ngayDauTuan:dd/MM} đến {_ngayDauTuan.AddDays(6):dd/MM/yyyy}";
            dtpChonNgay.Value = _ngayDauTuan; // Đồng bộ DatePicker
        }

        // Tải lịch làm việc của CẢ TUẦN cho TẤT CẢ nhân viên
        private void LoadDuLieuLich()
        {
            _lichLamTuanNay = _dangKiDAL.GetLichLamTheoTuan(_ngayDauTuan);
            VeLaiGrid();
        }

        // Vẽ lại toàn bộ DataGridView
        private void VeLaiGrid()
        {
            dgvLichTuan.Rows.Clear();
            dgvLichTuan.Columns.Clear();
            dgvLichTuan.RowHeadersVisible = true;

            // --- 1. Tạo 7 CỘT (7 Ngày) ---
            for (int i = 0; i < 7; i++)
            {
                DateTime ngay = _ngayDauTuan.AddDays(i);
                string tenThu = CultureInfo.GetCultureInfo("vi-VN").DateTimeFormat.GetDayName(ngay.DayOfWeek);
                string tenCot = $"{tenThu}\n({ngay:dd/MM})";

                dgvLichTuan.Columns.Add($"col{i}", tenCot);
                dgvLichTuan.Columns[i].Tag = ngay; // Lưu trữ ngày trong Tag của cột
                dgvLichTuan.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // --- 2. Tạo 3 HÀNG (3 Ca) ---
            foreach (Ca ca in _danhSachCa)
            {
                int rowIndex = dgvLichTuan.Rows.Add();
                dgvLichTuan.Rows[rowIndex].Tag = ca; // Lưu trữ Ca trong Tag của hàng
                dgvLichTuan.Rows[rowIndex].HeaderCell.Value = $"{ca.TenCa}\n({ca.ThoiGianBD:hh\\:mm}-{ca.ThoiGianKT:hh\\:mm})";
            }
            dgvLichTuan.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);


            // --- 3. Đổ dữ liệu lịch đã đăng ký vào Grid ---
            foreach (DangKiLichLam lich in _lichLamTuanNay)
            {
                // Tìm hàng (Ca)
                int rowIdx = _danhSachCa.FindIndex(c => c.MaCa == lich.CaMa);

                // Tìm cột (Ngày)
                int colIdx = (lich.NgayDangKy.Date - _ngayDauTuan.Date).Days;

                if (rowIdx >= 0 && colIdx >= 0 && colIdx < 7)
                {
                    DataGridViewCell cell = dgvLichTuan.Rows[rowIdx].Cells[colIdx];
                    cell.Value = lich.TenNhanVien; // Hiển thị tên NV đã đăng ký

                    // Tô màu để phân biệt
                    if (lich.NvMa == _nhanVienHienTai.Ma)
                    {
                        // Ca của chính mình
                        cell.Style.BackColor = Color.LightGreen;
                        cell.ToolTipText = "Click để Hủy ca này";
                    }
                    else
                    {
                        // Ca của người khác
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.DarkGray;
                        cell.ReadOnly = true; // Đây là logic "không thể chọn ô người khác đã chọn"
                        cell.ToolTipText = $"Đã được {lich.TenNhanVien} đăng ký.";
                    }
                }
            }
            dgvLichTuan.ClearSelection();
        }


        // Xử lý khi click vào một ô trong lịch
        private void dgvLichTuan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Click vào header

            DataGridViewCell cell = dgvLichTuan.Rows[e.RowIndex].Cells[e.ColumnIndex];

            // 1. Lấy thông tin Ca và Ngày từ Tag
            Ca ca = (Ca)dgvLichTuan.Rows[e.RowIndex].Tag;
            DateTime ngay = (DateTime)dgvLichTuan.Columns[e.ColumnIndex].Tag;

            // 2. Kiểm tra ô (Cell)
            string tenNVTrongO = cell.Value?.ToString();

            if (cell.ReadOnly) // Case 1: Ô của người khác
            {
                MessageBox.Show($"{ca.TenCa} ngày {ngay:dd/MM} đã được {tenNVTrongO} đăng ký.", "Ô đã bị khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(tenNVTrongO)) // Case 2: Ô trống (Đăng ký mới)
            {
                var confirm = MessageBox.Show($"Đăng ký {ca.TenCa} ({ngay:dd/MM}) cho {_nhanVienHienTai.Ten}?", "Xác nhận đăng ký", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    bool success = _dangKiDAL.AddDangKy(_nhanVienHienTai.Ma, ca.MaCa, ngay);
                    if (success)
                    {
                        LoadDuLieuLich(); // Tải lại grid nếu thành công
                    }
                    // Nếu thất bại (AddDangKy trả về false), DAL đã tự hiển thị MessageBox lỗi
                }
            }
            else if (tenNVTrongO == _nhanVienHienTai.Ten) // Case 3: Ô của chính mình (Hủy ca)
            {
                var confirm = MessageBox.Show($"Hủy {ca.TenCa} ({ngay:dd/MM}) của {_nhanVienHienTai.Ten}?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    bool success = _dangKiDAL.DeleteDangKy(_nhanVienHienTai.Ma, ca.MaCa, ngay);
                    if (success)
                    {
                        LoadDuLieuLich(); // Tải lại grid nếu thành công
                    }
                    // Nếu thất bại (DeleteDangKy trả về false), DAL đã tự hiển thị MessageBox
                }
            }
        }

        // Chuyển tuần
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
            // Chỉ chạy khi giá trị thay đổi thực sự, tránh vòng lặp
            if (dtpChonNgay.Value.Date != _ngayDauTuan.Date)
            {
                TinhNgayDauTuan(dtpChonNgay.Value);
                LoadDuLieuLich();
            }
        }
    }
}