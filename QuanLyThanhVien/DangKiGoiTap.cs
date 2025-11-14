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
    public partial class DangKiGoiTap : Form
    {

        // === 1. KHAI BÁO BIẾN ===
        private GoiTapDAL goiTapDAL;
        private ThanhVienGoiTapDAL tvgtDAL;

        // Biến để nhận thông tin từ form chính
        private string _currentMaTV;
        private string _currentTenTV;
        public DangKiGoiTap(string maTV, string tenTV)
        {
            InitializeComponent();

            // Khởi tạo các DAL
            goiTapDAL = new GoiTapDAL();
            tvgtDAL = new ThanhVienGoiTapDAL();

            // Lưu thông tin hội viên
            this._currentMaTV = maTV;
            this._currentTenTV = tenTV;
        }

        private void DangKyGoiTap_Load(object sender, EventArgs e)
        {
            // 2. Tải danh sách gói tập lên ComboBox
            LoadGoiTapComboBox();

            // 3. Đặt ngày đăng ký mặc định là hôm nay
            dtpNgayDangKy.Value = DateTime.Now;
        }

        private void LoadGoiTapComboBox()
        {
            // Lấy danh sách từ CSDL
            List<GoiTap> dsGoiTap = goiTapDAL.GetAllGoiTap();

            cboGoiTap.DataSource = dsGoiTap;
            cboGoiTap.DisplayMember = "Ten"; // Hiển thị Tên gói
            cboGoiTap.ValueMember = "Ma";   // Lấy giá trị Mã gói

            // Xóa chọn mặc định để người dùng phải tự chọn
            cboGoiTap.SelectedIndex = -1;
        }

        private void cboGoiTap_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu chưa chọn gì (ví dụ lúc mới load) thì thoát
            if (cboGoiTap.SelectedItem == null)
            {
                // Xóa trắng các ô chi tiết
                txtThoiHan.Text = "";
                txtGiaTien.Text = "";
                txtNgayHetHan.Text = "";
                return;
            }

            // Lấy gói tập mà người dùng đã chọn
            GoiTap goiTapChon = (GoiTap)cboGoiTap.SelectedItem;

            // Hiển thị chi tiết gói
            txtGiaTien.Text = goiTapChon.Gia.ToString("N0") + " VNĐ"; // Định dạng 1.000.000
            txtThoiHan.Text = goiTapChon.ThoiHan.ToString() + " tháng";

            // Tự động tính ngày hết hạn
            TinhNgayHetHan();
        }

        private void dtpNgayDangKy_ValueChanged(object sender, EventArgs e)
        {
            TinhNgayHetHan();
        }

        private void TinhNgayHetHan()
        {
            if (cboGoiTap.SelectedItem == null)
            {
                txtNgayHetHan.Text = "";
                return;
            }

            // Lấy thời hạn của gói (số tháng)
            int soThang = ((GoiTap)cboGoiTap.SelectedItem).ThoiHan;

            // Lấy ngày bắt đầu
            DateTime ngayBatDau = dtpNgayDangKy.Value.Date;

            // Tính ngày hết hạn
            DateTime ngayHetHan = ngayBatDau.AddMonths(soThang);

            // Hiển thị lên TextBox
            txtNgayHetHan.Text = ngayHetHan.ToString("dd/MM/yyyy");
        }



        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu
            if (cboGoiTap.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một gói tập.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None; // Ngăn form đóng
                return;
            }

            // 2. Lấy thông tin từ Form
            GoiTap goiTapChon = (GoiTap)cboGoiTap.SelectedItem;
            DateTime ngayDangKy = dtpNgayDangKy.Value.Date;
            DateTime ngayHetHan = ngayDangKy.AddMonths(goiTapChon.ThoiHan);

            // 3. Tạo đối tượng ThanhVienGoiTap
            ThanhVienGoiTap tvgt = new ThanhVienGoiTap
            {
                TV_Ma = this._currentMaTV,
                GT_Ma = goiTapChon.Ma,
                NgayDangKy = ngayDangKy,
                NgayHetHan = ngayHetHan,
                TrangThai = "Còn hiệu lực", // Mới đăng ký luôn là "Còn hiệu lực"
                CN_Ma = Session.MaChiNhanh // Lấy chi nhánh của nhân viên
            };

            try
            {
                // 4. Gọi DAL để lưu vào CSDL
                int result = tvgtDAL.AddThanhVienGoiTap(tvgt);

                if (result > 0)
                {
                    // Lưu thành công
                    MessageBox.Show("Đăng ký gói tập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // DialogResult đã được set là OK trên nút, form sẽ tự đóng
                }
                else if (result == 0)
                {
                    // Lỗi logic (ví dụ: Gói đã tồn tại), DAL đã tự thông báo
                    this.DialogResult = DialogResult.None; // Ngăn form đóng
                }
                else
                {
                    // Lỗi CSDL (result = -1), DAL đã tự thông báo
                    this.DialogResult = DialogResult.None; // Ngăn form đóng
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nghiêm trọng khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None; // Ngăn form đóng
            }
        }
    }
}
