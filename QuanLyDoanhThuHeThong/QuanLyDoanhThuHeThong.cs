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

using GZone;

namespace GZone.QuanLyDoanhThuHeThong
{
    public partial class QuanLyDoanhThuHeThong : Form
    {
        ThongKeDAL thongKeDAL;
        ChiNhanhDAL chiNhanhDAL;

        public QuanLyDoanhThuHeThong()
        {
            InitializeComponent();
            thongKeDAL = new ThongKeDAL();
            chiNhanhDAL = new ChiNhanhDAL();
        }

        private void QuanLyDoanhThuHeThong_Load(object sender, EventArgs e)
        {
            // 1. Tải ComboBox "Tổng hợp theo:" 
            cbTongHopTheo.Items.Add("Ngày");
            cbTongHopTheo.Items.Add("Tháng");
            cbTongHopTheo.Items.Add("Năm");
            cbTongHopTheo.SelectedIndex = 1; // Chọn "Tháng"

            // 2. Tải ComboBox "Sắp xếp theo:"
            cbSapXepTheo.Items.Add("Ngày mới nhất");
            cbSapXepTheo.Items.Add("Doanh thu cao nhất");
            cbSapXepTheo.SelectedIndex = 0;

            // 3. Tải ComboBox "Tăng/Giảm"
            cbTangGiam.Items.Add("Giảm dần");
            cbTangGiam.Items.Add("Tăng dần");
            cbTangGiam.SelectedIndex = 0;

            // 4. Tải ComboBox Chi Nhánh
            LoadComboBoxChiNhanh();
        }

        private void LoadComboBoxChiNhanh()
        {
            try
            {
                // Gọi hàm DAL để lấy danh sách
                List<ChiNhanh> dsChiNhanh = chiNhanhDAL.GetAllChiNhanh();

                // Thêm mục "Tất cả" vào đầu danh sách
                dsChiNhanh.Insert(0, new ChiNhanh { Ma = "TatCa", Ten = "Tất cả chi nhánh" });

                // Gán DataSource bằng code
                cbChiNhanh.DataSource = dsChiNhanh;
                cbChiNhanh.DisplayMember = "Ten"; // Hiển thị tên
                cbChiNhanh.ValueMember = "Ma";   // Lấy giá trị là Mã

                cbChiNhanh.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chi nhánh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === ĐÂY LÀ NÚT ĐỂ XEM THỐNG KÊ (TỔNG HỢP) ===
        private void btnTongHop_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy giá trị từ các ComboBox
                string tongHopTheo = cbTongHopTheo.SelectedItem.ToString();
                string sapXepTheo = cbSapXepTheo.SelectedItem.ToString();
                string maChiNhanh = cbChiNhanh.SelectedValue.ToString();
                string sapXepHuong = cbTangGiam.SelectedItem.ToString();

                // 2. Gọi hàm DAL với 4 tham số
                DataTable dtThongKe = thongKeDAL.GetThongKeDoanhThu(tongHopTheo, maChiNhanh, sapXepTheo, sapXepHuong);

                // 3. Hiển thị lên DataGridView
                dgvThongKe.DataSource = dtThongKe;

                // 4. (Tùy chọn) Định dạng cột tiền tệ
                if (dgvThongKe.Columns.Contains("Tổng Doanh Thu"))
                {
                    dgvThongKe.Columns["Tổng Doanh Thu"].DefaultCellStyle.Format = "N0";
                    dgvThongKe.Columns["Tổng Doanh Thu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chạy thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === NÚT NÀY DÙNG ĐỂ IN ẤN (SẼ LÀM SAU) ===
        private void btnInDoanhThu_Click(object sender, EventArgs e)
        {
            // (Code xử lý in ấn từ dgvThongKe sẽ được thêm vào đây sau)
            MessageBox.Show("Chức năng in báo cáo chưa được implement.", "Thông báo");
        }
    }
}