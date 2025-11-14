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

namespace GZone.QuanLyThanhVien
{
    public partial class QuanLyThanhVien : Form
    {
        ThanhVienDAL tvDAL;
        ThanhVienGoiTapDAL tvgtDAL;

        // Lưu mã hội viên đang được chọn
        private string currentMaTV = null;

        public QuanLyThanhVien()
        {
            InitializeComponent();
            tvDAL = new ThanhVienDAL();
            tvgtDAL = new ThanhVienGoiTapDAL();

        }

        private void LoadDanhSachThanhVien()
        {
            // Lấy mã chi nhánh của nhân viên từ Session
            string maCN = Session.MaChiNhanh;
            string searchTerm = txtTimKiem.Text.Trim();
            dgvHoiVien.AutoGenerateColumns = true;


            // Gọi hàm DAL đã được nâng cấp (ở Bước 1)
            dgvHoiVien.DataSource = tvDAL.GetAllThanhVien(maCN, searchTerm);
        }

        private void QuanLyThanhVien_Load(object sender, EventArgs e)
        {
            SetupGoiTapColumns();
            LoadDanhSachThanhVien();
        }

        // === Tải danh sách Master (DataGridView chính) ===

        #region Tải Dữ Liệu (Hàm Helper
        

        // === Tải Tab 1: Thông tin chi tiết ===
        private void LoadThongTinChiTiet(string maHV)
        {
            // Gọi hàm DAL mới (ở Bước 1)
            ThanhVien tv = tvDAL.GetThanhVienByMa(maHV);
            if (tv != null)
            {
                // Binding dữ liệu lên các TextBox (đang ở chế độ ReadOnly)
                txtMaHV.Text = tv.TV_Ma;
                txtHoTen.Text = tv.TV_HoTen;
                txtNgaySinh.Text = tv.TV_NgaySinh.ToString("dd/MM/yyyy");
                txtGioiTinh.Text = tv.TV_GioiTinh;
                txtSdt.Text = tv.TV_Sdt;
                txtChiNhanh.Text = tv.CN_Ma; // (Có thể đổi thành Tên Chi Nhánh nếu JOIN)
            }
        }

        private void SetupGoiTapColumns()
        {
            // Tắt tự động tạo cột
            dgvGoiTap.AutoGenerateColumns = false;
            dgvGoiTap.Columns.Clear(); // Xóa các cột cũ (nếu có)

            // Thêm cột ID (ẩn đi, nhưng cần cho logic)
            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TVGT_ID",
                DataPropertyName = "TVGT_ID", // Tên cột từ CSDL
                HeaderText = "ID",
                Visible = false // Ẩn cột này
            });

            // Thêm cột Mã Gói (ẩn nếu muốn)
            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GT_Ma",
                DataPropertyName = "GT_Ma", // Tên cột từ CSDL
                HeaderText = "Mã Gói",
                Width = 80
            });

            // Thêm cột Tên Gói
            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GT_Ten",
                DataPropertyName = "GT_Ten", // Tên cột từ CSDL
                HeaderText = "Tên Gói Tập", // Tên "đẹp"
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Tự co giãn
            });

            // Thêm cột Thời Hạn (từ CSDL)
            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GT_ThoiHan",
                DataPropertyName = "GT_ThoiHan", // Tên cột từ CSDL
                HeaderText = "Thời Hạn (Tháng)", // Tên "đẹp"
                Width = 80
            });

            // Thêm cột Ngày Đăng Ký
            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayDangKy",
                DataPropertyName = "NgayDangKy", // Tên cột từ CSDL
                HeaderText = "Ngày Đăng Ký", // Tên "đẹp"
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 110
            });

            // Thêm cột Ngày Hết Hạn
            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayHetHan",
                DataPropertyName = "NgayHetHan", // Tên cột từ CSDL
                HeaderText = "Ngày Hết Hạn", // Tên "đẹp"
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 110
            });

            // Thêm cột Trạng Thái
            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TrangThai",
                DataPropertyName = "TrangThai", // Tên cột từ CSDL
                HeaderText = "Trạng Thái", // Tên "đẹp"
                Width = 110
            });
        }

        // === Tải Tab 2: Thông tin dịch vụ (Gói tập) ===
        private void LoadThongTinDichVu(string maTV)
        {
            // Hàm này của bạn đã có và trả về DataTable, rất tốt
            dgvGoiTap.DataSource = tvgtDAL.GetGoiTapByThanhVien(maTV);
        }

        // === Xóa trắng các Tab chi tiết ===
        private void ClearDetailTabs()
        {
            // Tab 1
            txtMaHV.Text = "";
            txtHoTen.Text = "";
            txtNgaySinh.Text = "";
            txtGioiTinh.Text = "";
            txtSdt.Text = "";
            txtChiNhanh.Text = "";

            // Tab 2
            dgvGoiTap.DataSource = null;

            currentMaTV = null;
        }

        #endregion

        #region Sự kiện Click (Nút bấm)

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMaHV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtChiNhanh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGioiTinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSdt_Click(object sender, EventArgs e)
        {

        }

        private void lblNgaySinh_Click(object sender, EventArgs e)
        {

        }

        private void lblMaHV_Click(object sender, EventArgs e)
        {

        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDanhSachThanhVien();
            ClearDetailTabs();
        }

        // (UX: Cho phép nhấn Enter để tìm kiếm)
        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
                e.Handled = true; // Ngăn tiếng "bíp"
            }
        }

        private void btnThemHoiVien_Click(object sender, EventArgs e)
        {
            ThemThanhVien fThem = new ThemThanhVien(null);

            if (fThem.ShowDialog() == DialogResult.OK)
            {
                // Nếu thêm thành công, tải lại danh sách
                LoadDanhSachThanhVien();
            }
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaTV))
            {
                MessageBox.Show("Vui lòng chọn hội viên từ danh sách.");
                return;
            }

            // Mở form modal ở chế độ "Sửa" (truyền Mã HV)
            ThemThanhVien fSua = new ThemThanhVien(currentMaTV);

            if (fSua.ShowDialog() == DialogResult.OK)
            {
                // Nếu sửa thành công, tải lại cả danh sách và chi tiết
                LoadDanhSachThanhVien();
                LoadThongTinChiTiet(currentMaTV);
            }
        }

        private void btnDangKyGoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaTV))
            {
                MessageBox.Show("Vui lòng chọn hội viên từ danh sách.");
                return;
            }

            // Lấy Tên hội viên từ tab 1
            string tenHV = txtHoTen.Text;

            // Mở form modal Đăng Ký Gói (bạn tự tạo form này)
            DangKiGoiTap fDK = new DangKiGoiTap(currentMaTV, tenHV);

            if (fDK.ShowDialog() == DialogResult.OK)
            {
                // Nếu đăng ký thành công, chỉ cần tải lại Tab 2
                LoadThongTinDichVu(currentMaTV);
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (dgvGoiTap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một gói tập từ danh sách để gia hạn.",
                                "Chưa chọn gói", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy thông tin từ dòng được chọn
            DataGridViewRow row = dgvGoiTap.SelectedRows[0];
            string tenGoi = row.Cells["GT_Ten"].Value.ToString();
            DateTime ngayHetHanCu = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);

            // 3. Hỏi xác nhận
            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn gia hạn cho gói '{tenGoi}' không?\n" +
                                              $"Ngày hết hạn cũ: {ngayHetHanCu.ToString("dd/MM/yyyy")}",
                                              "Xác nhận gia hạn",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (dr == DialogResult.No)
            {
                return; // Người dùng không đồng ý
            }

            try
            {
                // 4. Lấy các thông số cần thiết để tính toán
                int tvgtID = Convert.ToInt32(row.Cells["TVGT_ID"].Value);

                // Lấy thời hạn gốc của gói (ví dụ: 3 tháng, 12 tháng)
                // (Hàm GetGoiTapByThanhVien của bạn đã JOIN và lấy được GT_ThoiHan)
                int thoiHanGoi_TheoThang = Convert.ToInt32(row.Cells["GT_ThoiHan"].Value);

                // 5. === Logic Tính Ngày Hết Hạn Mới (Quan trọng) ===

                DateTime today = DateTime.Now.Date;
                DateTime startDate;

                // Nếu gói đã hết hạn (ngày hết hạn < hôm nay),
                // thì ngày bắt đầu mới là TỪ HÔM NAY.
                if (ngayHetHanCu < today)
                {
                    startDate = today;
                }
                else
                {
                    // Nếu gói vẫn còn hạn,
                    // thì gia hạn tiếp TỪ NGÀY HẾT HẠN CŨ (cộng dồn).
                    startDate = ngayHetHanCu;
                }

                // Tính ngày hết hạn mới
                DateTime ngayHetHanMoi = startDate.AddMonths(thoiHanGoi_TheoThang);

                // 6. Tạo đối tượng để cập nhật CSDL
                ThanhVienGoiTap tvgt_Update = new ThanhVienGoiTap
                {
                    TVGT_ID = tvgtID,
                    NgayHetHan = ngayHetHanMoi,
                    TrangThai = "Còn hiệu lực" // Khi gia hạn, chắc chắn là "Còn hiệu lực"
                };

                // 7. Gọi DAL để cập nhật
                int result = tvgtDAL.UpdateThanhVienGoiTap(tvgt_Update);

                if (result > 0)
                {
                    MessageBox.Show($"Gia hạn thành công!\nNgày hết hạn mới: {ngayHetHanMoi.ToString("dd/MM/yyyy")}",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 8. Tải lại danh sách gói tập trong Tab 2
                    // (currentMaHV là biến lưu mã hội viên đang được chọn)
                    LoadThongTinDichVu(this.currentMaTV);
                }
                else
                {
                    MessageBox.Show("Gia hạn thất bại do lỗi CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình gia hạn: " + ex.Message,
                                "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Sự kiện DataGridView

        private void dgvHoiVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoiVien.SelectedRows.Count > 0)
            {
                // Lỗi là ở đây: Bạn phải dùng Alias "Mã TV"
                // mà bạn đã đặt trong file ThanhVien.cs
                string maTV = dgvHoiVien.SelectedRows[0].Cells["Mã TV"].Value.ToString();

                if (maTV != currentMaTV)
                {
                    currentMaTV = maTV;

                    // 2. Tải dữ liệu chi tiết
                    LoadThongTinChiTiet(currentMaTV);
                    LoadThongTinDichVu(currentMaTV);

                    // 3. Mặc định active tab 1
                    // (Bạn nên có 1 TabControl tên là tabChiTiet
                    // và TabPage tên là tabThongTin)
                    // tabChiTiet.SelectedTab = tabThongTin; 
                }
            }
        }

        #endregion
    }
}
