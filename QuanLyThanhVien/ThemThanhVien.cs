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
    public partial class ThemThanhVien : Form
    {
        // === 1. KHAI BÁO BIẾN ===
        private ThanhVienDAL tvDAL;
        private ChiNhanhDAL cnDAL;

        // Biến này sẽ lưu mã TV (nếu là Sửa) hoặc null (nếu là Thêm)
        private string maThanhVien_HienTai;
        private bool isAddMode = false; // Cờ kiểm tra chế độ

        public ThemThanhVien(string maTV)
        {
            InitializeComponent();
            this.Load += ThemThanhVien_Load;

            // Khởi tạo các DAL
            tvDAL = new ThanhVienDAL();
            cnDAL = new ChiNhanhDAL();

            // Nhận mã HV từ form chính
            this.maThanhVien_HienTai = maTV;

            // Kiểm tra xem đây là chế độ Thêm hay Sửa
            if (string.IsNullOrEmpty(maThanhVien_HienTai))
            {
                isAddMode = true; // Là chế độ THÊM
            }
        }

        private void LoadChiNhanhComboBox()
        {
            var list = cnDAL.GetAllChiNhanh();

            if (list != null && list.Count > 0)
            {
                cboChiNhanh.DataSource = list;
                cboChiNhanh.DisplayMember = "Ten";
                cboChiNhanh.ValueMember = "Ma";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu chi nhánh.");
            }
        }

        private void ThemThanhVien_Load(object sender, EventArgs e)
        {
            // === SỬA LỖI 1: GỌI HÀM NÀY ĐẦU TIÊN ===
            // Phải tải dữ liệu vào ComboBox TRƯỚC KHI cố gắng chọn nó
            LoadChiNhanhComboBox();

            if (isAddMode)
            {
                this.Text = "Thêm Hội viên mới";

                // Dòng này để lấy Mã TV mới
                txtMaHV.Text = tvDAL.GetNewMaThanhVien();
                txtMaHV.ReadOnly = true; // Không cho sửa Mã

                // Dòng này GÁN chi nhánh (giờ sẽ hoạt động
                // vì ComboBox đã có dữ liệu)
                cboChiNhanh.SelectedValue = Session.MaChiNhanh;
                cboChiNhanh.Enabled = false;
            }
            else
            {
                // === CHẾ ĐỘ SỬA ===
                this.Text = "Cập nhật thông tin Hội viên";
                txtMaHV.ReadOnly = true; // Không cho sửa Mã
                LoadThongTinThanhVien();
            }
        }

        

        private void LoadThongTinThanhVien()
        {
            // Dùng hàm GetThanhVienByMa (đã thêm ở câu trả lời trước)
            ThanhVien tv = tvDAL.GetThanhVienByMa(this.maThanhVien_HienTai);

            if (tv != null)
            {
                txtMaHV.Text = tv.TV_Ma;
                txtHoTen.Text = tv.TV_HoTen;
                dtpNgaySinh.Value = tv.TV_NgaySinh;
                cbGioiTinh.SelectedItem = tv.TV_GioiTinh;
                txtSdt.Text = tv.TV_Sdt;
                cboChiNhanh.SelectedValue = tv.CN_Ma;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin hội viên để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu không tìm thấy
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // === 1. THÊM KIỂM TRA DỮ LIỆU ===

            // Kiểm tra Họ Tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên hội viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return; // Dừng lại
            }

            // Kiểm tra Giới tính (SỬA LỖI 1)
            if (cbGioiTinh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Giới tính.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbGioiTinh.Focus();
                return; // Dừng lại
            }

            // Kiểm tra Chi nhánh (SỬA LỖI 2)
            if (cboChiNhanh.SelectedValue == null)
            {
                MessageBox.Show("Không thể lấy được mã chi nhánh. Vui lòng kiểm tra lại.", "Lỗi Chi Nhánh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboChiNhanh.Focus();
                return; // Dừng lại
            }

            // === 2. TẠO ĐỐI TƯỢNG THANH VIEN ===
            // Nếu code chạy đến đây, nghĩa là cbGioiTinh và cboChiNhanh ĐÃ CÓ giá trị

            ThanhVien tv = new ThanhVien
            {
                TV_Ma = txtMaHV.Text,
                TV_HoTen = txtHoTen.Text.Trim(),
                TV_NgaySinh = dtpNgaySinh.Value.Date,
                TV_GioiTinh = cbGioiTinh.SelectedItem.ToString(), // Giờ đã an toàn
                TV_Sdt = txtSdt.Text.Trim(),
                CN_Ma = cboChiNhanh.SelectedValue.ToString() // Giờ đã an toàn
            };

            // === 3. LƯU VÀO CSDL (Giữ nguyên code của bạn) ===
            try
            {
                if (isAddMode)
                {
                    tvDAL.AddThanhVien(tv);
                    MessageBox.Show("Thêm hội viên mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tvDAL.UpdateThanhVien(tv);
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
