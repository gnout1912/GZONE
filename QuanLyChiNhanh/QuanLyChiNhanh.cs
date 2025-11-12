using GZone.models; // Đảm bảo using models của bạn
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
            // MỚI: Gọi hàm để cài đặt giao diện "chỉ xem"
            SetupReadOnlyTextBoxes();

            LoadDanhSachChiNhanhLenList();
            SetupDgvYeuCauColumns(); // Cấu hình lưới yêu cầu
        }

        // MỚI: Thêm hàm helper này
        /// <summary>
        /// Cài đặt các TextBox thông tin chi tiết thành dạng chỉ xem (Read-Only)
        /// và chỉnh lại kiểu dáng cho đẹp (bỏ viền, đổi màu nền)
        /// </summary>
        private void SetupReadOnlyTextBoxes()
        {
            // Tạo một danh sách các TextBox cần chỉnh
            var textBoxes = new List<TextBox>
            {
                txtMaChiNhanh,
                txtTenChiNhanh,
                txtDiaChi,
                txtSoDienThoai,
                txtNgayThanhLap
            };

            // Duyệt qua từng TextBox và chỉnh thuộc tính
            foreach (var txt in textBoxes)
            {
                txt.ReadOnly = true;                 // Không cho phép gõ chữ
                txt.BorderStyle = BorderStyle.None;  // Bỏ viền
                txt.BackColor = Color.White;         // Đặt nền màu trắng (hoặc SystemColors.Control nếu nền form của bạn màu xám)
                txt.TabStop = false;                 // Bỏ qua khi nhấn phím Tab
            }
        }

        /// <summary>
        /// Tải danh sách chi nhánh lên ListBox bên trái
        /// </summary>
        private void LoadDanhSachChiNhanhLenList()
        {
            try
            {
                _danhSachChiNhanh = _chiNhanhDAL.GetAllChiNhanh();

                lstChiNhanh.DataSource = null;
                lstChiNhanh.DataSource = _danhSachChiNhanh;
                lstChiNhanh.DisplayMember = "Ten"; // Hiển thị tên
                lstChiNhanh.ValueMember = "Ma";   // Giữ giá trị là Mã

                lstChiNhanh.SelectedIndex = -1; // Bỏ chọn mặc định
                ClearDetails(); // Xóa trống thông tin bên phải
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chi nhánh: " + ex.Message);
            }
        }

        /// <summary>
        /// Sự kiện quan trọng: Xảy ra khi người dùng chọn một chi nhánh bên trái
        /// </summary>
        private void lstChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstChiNhanh.SelectedItem == null)
            {
                ClearDetails();
                return;
            }

            // Lấy chi nhánh được chọn
            var selectedChiNhanh = lstChiNhanh.SelectedItem as ChiNhanh;
            if (selectedChiNhanh == null) return;

            // 1. Tải thông tin chi tiết lên Tab 1
            LoadThongTinChiTiet(selectedChiNhanh);

            // 2. Tải danh sách yêu cầu lên Tab 2 (dùng hàm mới)
            LoadYeuCauChiNhanh(selectedChiNhanh.Ma);
        }

        /// <summary>
        /// Hiển thị thông tin chi tiết của chi nhánh lên các TextBox
        /// </summary>
        private void LoadThongTinChiTiet(ChiNhanh cn)
        {
            txtMaChiNhanh.Text = cn.Ma;
            txtTenChiNhanh.Text = cn.Ten;
            txtDiaChi.Text = cn.DiaChi;
            txtSoDienThoai.Text = cn.Sdt;
            txtNgayThanhLap.Text = cn.NgayThanhLap?.ToShortDateString() ?? "";
        }

        /// <summary>
        /// Lọc và hiển thị các yêu cầu của chi nhánh
        /// </summary>
        private void LoadYeuCauChiNhanh(string maChiNhanh)
        {
            try
            {
                // Gọi hàm DAL mới mà chúng ta vừa tạo
                List<YeuCau> yeuCauList = _yeuCauDAL.GetYeuCauTheoChiNhanh(maChiNhanh);

                dgvYeuCau.DataSource = null;
                dgvYeuCau.DataSource = yeuCauList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách yêu cầu: " + ex.Message);
            }
        }

        /// <summary>
        /// Cấu hình các cột cho lưới Yêu cầu (chỉ cần chạy 1 lần)
        /// </summary>
        private void SetupDgvYeuCauColumns()
        {
            dgvYeuCau.AutoGenerateColumns = false; // Rất quan trọng

            // Định nghĩa các cột
            dgvYeuCau.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ma", HeaderText = "Mã YC", Width = 60 });
            dgvYeuCau.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TieuDe", HeaderText = "Tiêu Đề", Width = 150, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvYeuCau.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThai", HeaderText = "Trạng Thái", Width = 100 });
            dgvYeuCau.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayGui", HeaderText = "Ngày Gửi", Width = 120 });
            dgvYeuCau.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PhanHoi", HeaderText = "Phản Hồi", Width = 150, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvYeuCau.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayXuLy", HeaderText = "Ngày Xử Lý", Width = 120 });

            // Ẩn các cột không cần thiết
            // (Nếu bạn dùng AutoGenerateColumns = false, bạn không cần ẩn gì cả)
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

        // >>> HÀM MỚI CHO BUTTON BẠN VỪA THÊM <<<
        private void btnThemChiNhanh_Click(object sender, EventArgs e)
        {
            // 1. Mở form thêm mới
            // (Giả sử Form của bạn tên là ThemChiNhanhForm)
            ThemChiNhanhForm frmThem = new ThemChiNhanhForm();
            DialogResult result = frmThem.ShowDialog();

            // 2. Nếu form báo OK (tức là đã thêm thành công)
            // (Form ThemChiNhanhForm của bạn nên trả về DialogResult.OK khi thành công)
            if (result == DialogResult.OK)
            {
                // 3. Tải lại danh sách chi nhánh để cập nhật list bên trái
                LoadDanhSachChiNhanhLenList();
            }
        }

        private void btnSuaChiTiet_Click(object sender, EventArgs e)
        {
            if (lstChiNhanh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một chi nhánh để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedChiNhanh = lstChiNhanh.SelectedItem as ChiNhanh;

            if (selectedChiNhanh.Ma == null)
            {
                MessageBox.Show("Vui lòng chọn một chi nhánh cụ thể để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChinhSuaChiNhanhForm frmSuaCN = new ChinhSuaChiNhanhForm(selectedChiNhanh);
            DialogResult result = frmSuaCN.ShowDialog();

            // MỚI: Thêm phần này để load lại danh sách nếu có chỉnh sửa
            // (Bạn chưa có phần này, mình thêm vào cho hoàn chỉnh)
            if (result == DialogResult.OK)
            {
                // Lưu lại index đang chọn
                int selectedIndex = lstChiNhanh.SelectedIndex;

                // Tải lại danh sách chi nhánh
                LoadDanhSachChiNhanhLenList();

                // Chọn lại đúng chi nhánh vừa sửa
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
                MessageBox.Show("Vui lòng chọn một yêu cầu để xử lý.", "Chưa chọn yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var yeuCau = dgvYeuCau.CurrentRow.DataBoundItem as YeuCau;
            if (yeuCau == null) return;

            if (yeuCau.TrangThai != "Chờ duyệt")
            {
                MessageBox.Show("Yêu cầu này đã được xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string phanHoi = isApproved ? "Đã duyệt" : "Đã từ chối";

            yeuCau.TrangThai = isApproved ? "Đã duyệt" : "Đã từ chối";
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