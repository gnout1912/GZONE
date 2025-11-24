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
    public partial class ThemChiNhanhForm : Form
    {
        public ThemChiNhanhForm()
        {
            InitializeComponent();
        }

        private void ThemChiNhanhForm_Load(object sender, EventArgs e)
        {
            TaoMaChiNhanhTuDongTang();
        }

        private void TaoMaChiNhanhTuDongTang()
        {
            string maMoi = "CN001";

            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT MAX(CN_Ma) FROM CHI_NHANH WHERE CN_Ma LIKE 'CN[0-9]%'";

                    using (SqlCommand cmd = new SqlCommand(query, clsDatabase.con))
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            string maLonNhat = result.ToString();

                            if (maLonNhat.Length > 2 && maLonNhat.StartsWith("CN"))
                            {
                                string phanSoStr = maLonNhat.Substring(2);
                                if (int.TryParse(phanSoStr, out int soHienTai))
                                {
                                    int soMoi = soHienTai + 1;
                                    maMoi = "CN" + soMoi.ToString("D3");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo mã chi nhánh tự động: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }

            txtMaChiNhanh.Text = maMoi;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaChiNhanh.Text.Trim();
            string ten = txtTenChiNhanh.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            DateTime ngayThanhLap = dtpNgayThanhLap.Value;

            if (string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên chi nhánh và Địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Lỗi: Không tìm thấy Mã chi nhánh. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"INSERT INTO CHI_NHANH (CN_Ma, CN_Ten, CN_DiaChi, CN_Sdt, CN_NgayThanhLap) 
                             VALUES (@Ma, @Ten, @DiaChi, @Sdt, @NgayThanhLap)";

                    using (SqlCommand cmd = new SqlCommand(query, clsDatabase.con))
                    {
                        cmd.Parameters.AddWithValue("@Ma", ma);
                        cmd.Parameters.AddWithValue("@Ten", ten);
                        cmd.Parameters.AddWithValue("@DiaChi", diaChi);

                        cmd.Parameters.AddWithValue("@Sdt", string.IsNullOrEmpty(sdt) ? (object)DBNull.Value : sdt);

                        cmd.Parameters.AddWithValue("@NgayThanhLap", ngayThanhLap);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Thêm chi nhánh mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thêm chi nhánh không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException sqlex)
                {
                    if (sqlex.Number == 2627)
                    {
                        MessageBox.Show($"Lỗi: Mã chi nhánh '{ma}' đã tồn tại. Vui lòng tạo mã mới hoặc thử lại.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        TaoMaChiNhanhTuDongTang();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi thêm chi nhánh: " + sqlex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}