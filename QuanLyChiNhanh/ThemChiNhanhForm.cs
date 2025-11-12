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
    public partial class ThemChiNhanhForm : Form
    {
        public ThemChiNhanhForm()
        {
            InitializeComponent();
        }

        private void ThemChiNhanhForm_Load(object sender, EventArgs e)
        {
            // Tự động tạo mã chi nhánh ngẫu nhiên khi form được tải
            TaoMaChiNhanhNgauNhien();
        }

        private void TaoMaChiNhanhNgauNhien()
        {
            // Tạo một mã ngẫu nhiên có dạng "CN" + 3 chữ số (ví dụ: CN123)
            // Bạn có thể thay đổi logic này nếu muốn mã phức tạp hơn
            // và nên kiểm tra CSDL xem mã này đã tồn tại chưa
            Random random = new Random();
            int soNgauNhien = random.Next(100, 1000); // Tạo số từ 100 đến 999
            txtMaChiNhanh.Text = "CN" + soNgauNhien.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Đóng form khi nhấn nút Hủy
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Bước tiếp theo:
            // Bạn sẽ viết code ở đây để lấy dữ liệu từ các textbox
            // và lưu vào CSDL bằng câu lệnh SQL INSERT.
            MessageBox.Show("Chức năng Thêm sẽ được lập trình ở đây!");

            // Ví dụ (chưa chạy):
            // string maCN = txtMaChiNhanh.Text;
            // string tenCN = txtTenChiNhanh.Text;
            // ...
            // clsDatabase.OpenConnection();
            // string query = "INSERT INTO CHI_NHANH(...) VALUES (...)";
            // ...
            // clsDatabase.CloseConnection();
            // this.Close();
        }
    }
}