using GZone.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GZone
{
    public partial class ThemTaiKhoanForm : Form
    {
        private List<ChiNhanh> _danhSachChiNhanh;
        private TaiKhoanDAL _taiKhoanDAL = new TaiKhoanDAL();

        /// <summary>
        /// Constructor nhận danh sách chi nhánh từ form cha
        /// </summary>
        public ThemTaiKhoanForm(List<ChiNhanh> danhSachChiNhanh)
        {
            InitializeComponent();
            // Lọc bỏ mục "Tất cả chi nhánh" nếu có
            _danhSachChiNhanh = danhSachChiNhanh
                                .Where(cn => cn.Ma != null)
                                .ToList();
        }

        private void ThemTaiKhoanForm_Load(object sender, EventArgs e)
        {
            // Tải ComboBox Quyền
            cmbQuyen.Items.Add("Admin");
            cmbQuyen.Items.Add("Manager");
            cmbQuyen.Items.Add("Staff");
            cmbQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbQuyen.SelectedIndex = 2; // Mặc định là Staff

            // Tải ComboBox Chi Nhánh
            // Thêm mục "Không (Admin)" lên đầu
            var dsHienThi = new List<ChiNhanh>();
            dsHienThi.Add(new ChiNhanh { Ma = null, Ten = "Không (Tài khoản Admin)" });
            dsHienThi.AddRange(_danhSachChiNhanh);

            cmbChiNhanh.DataSource = dsHienThi;
            cmbChiNhanh.DisplayMember = "Ten";
            cmbChiNhanh.ValueMember = "Ma";
            cmbChiNhanh.DropDownStyle = ComboBoxStyle.DropDownList;

            // Đặt trạng thái mặc định
            chkTrangThai.Checked = true;

            // Tạo mã tài khoản mới
            txtMaTK.Text = _taiKhoanDAL.GenerateNewMaTaiKhoan();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Xác thực dữ liệu
            if (string.IsNullOrWhiteSpace(txtTen.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text) ||
                cmbQuyen.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên, Mật khẩu và Quyền.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Tạo đối tượng TaiKhoan
            TaiKhoan tk = new TaiKhoan
            {
                Ma = txtMaTK.Text,
                Ten = txtTen.Text.Trim(),
                MatKhau = txtMatKhau.Text, // TRONG THỰC TẾ: BẠN PHẢI MÃ HÓA (HASH) MẬT KHẨU NÀY
                Quyen = cmbQuyen.SelectedItem.ToString(),
                TrangThai = chkTrangThai.Checked,
                MaChiNhanh = cmbChiNhanh.SelectedValue as string // Sẽ là NULL nếu chọn "Không"
            };

            // 3. Xử lý logic quyền
            if (tk.Quyen == "Admin" && tk.MaChiNhanh != null)
            {
                MessageBox.Show("Tài khoản 'Admin' không thể thuộc về một chi nhánh.", "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((tk.Quyen == "Manager" || tk.Quyen == "Staff") && tk.MaChiNhanh == null)
            {
                MessageBox.Show("Tài khoản 'Manager' hoặc 'Staff' phải thuộc về một chi nhánh.", "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Gọi DAL để thêm
            _taiKhoanDAL.AddTaiKhoan(tk);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}