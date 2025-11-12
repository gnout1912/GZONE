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
    public partial class ChinhSuaChiNhanhForm : Form
    {
        // Biến để lưu trữ chi nhánh đang được chỉnh sửa
        private ChiNhanh _chiNhanhHienTai;

        /// <summary>
        /// Constructor nhận vào đối tượng ChiNhanh cần sửa
        /// </summary>
        public ChinhSuaChiNhanhForm(ChiNhanh chiNhanhToEdit)
        {
            InitializeComponent();
            _chiNhanhHienTai = chiNhanhToEdit;
        }

        private void ChinhSuaChiNhanhForm_Load(object sender, EventArgs e)
        {
            // Điền thông tin của chi nhánh vào các controls
            if (_chiNhanhHienTai != null)
            {
                txtMaChiNhanh.Text = _chiNhanhHienTai.Ma;
                txtTenChiNhanh.Text = _chiNhanhHienTai.Ten;
                txtDiaChi.Text = _chiNhanhHienTai.DiaChi;
                txtSoDienThoai.Text = _chiNhanhHienTai.Sdt;
                dtpNgayThanhLap.Value = _chiNhanhHienTai.NgayThanhLap ?? DateTime.Now;
            }
            else
            {
                MessageBox.Show("Lỗi: Không có thông tin chi nhánh để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các controls
            string ten = txtTenChiNhanh.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            DateTime ngayThanhLap = dtpNgayThanhLap.Value;
            string ma = txtMaChiNhanh.Text; // Mã không đổi

            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên chi nhánh và Địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thực thi câu lệnh UPDATE
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"UPDATE CHI_NHANH 
                                     SET CN_Ten = @Ten, 
                                         CN_DiaChi = @DiaChi, 
                                         CN_Sdt = @Sdt, 
                                         CN_NgayThanhLap = @NgayThanhLap 
                                     WHERE CN_Ma = @Ma";

                    using (SqlCommand cmd = new SqlCommand(query, clsDatabase.con))
                    {
                        cmd.Parameters.AddWithValue("@Ten", ten);
                        cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                        cmd.Parameters.AddWithValue("@Sdt", sdt);
                        cmd.Parameters.AddWithValue("@NgayThanhLap", ngayThanhLap);
                        cmd.Parameters.AddWithValue("@Ma", ma);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin chi nhánh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK; // Đặt DialogResult để form gọi biết
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thành công. Không tìm thấy chi nhánh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật chi nhánh: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}