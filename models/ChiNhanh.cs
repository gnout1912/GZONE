using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data; // Thêm using này để dùng DBNull.Value

// (Tôi giả sử class clsDatabase của bạn nằm trong GZone)
using GZone;

namespace GZone.models
{
    public class ChiNhanh
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public DateTime? NgayThanhLap { get; set; }
    }

    public class ChiNhanhDAL
    {
        public List<ChiNhanh> GetAllChiNhanh()
        {
            List<ChiNhanh> list = new List<ChiNhanh>();
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT * FROM CHI_NHANH";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ChiNhanh cn = new ChiNhanh
                        {
                            Ma = reader["CN_Ma"].ToString(),
                            Ten = reader["CN_Ten"]?.ToString(),

                            // === ĐÃ SỬA LỖI TYPO (Diachi -> DiaChi) ===
                            DiaChi = reader["CN_DiaChi"]?.ToString(),

                            Sdt = reader["CN_Sdt"]?.ToString(),
                            NgayThanhLap = reader["CN_NgayThanhLap"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["CN_NgayThanhLap"])
                        };
                        list.Add(cn);
                    }
                    reader.Close(); // Đóng reader sau khi dùng xong
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu chi nhánh: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return list;
        }

        public void AddChiNhanh(ChiNhanh cn)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    // === ĐÃ SỬA LỖI TYPO (Diachi -> DiaChi) ===
                    string query = "INSERT INTO CHI_NHANH (CN_Ma, CN_Ten, CN_DiaChi, CN_Sdt, CN_NgayThanhLap) VALUES (@Ma, @Ten, @DiaChi, @Sdt, @NgayThanhLap)";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    cmd.Parameters.AddWithValue("@Ma", cn.Ma);
                    cmd.Parameters.AddWithValue("@Ten", cn.Ten ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", cn.DiaChi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sdt", cn.Sdt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayThanhLap", cn.NgayThanhLap ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm chi nhánh thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm chi nhánh: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }
        public void DeleteChiNhanh(string maCN)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "DELETE FROM CHI_NHANH WHERE CN_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", maCN);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa chi nhánh thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa chi nhánh: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        public void UpdateChiNhanh(ChiNhanh cn)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    // === ĐÃ SỬA LỖI TYPO (Diachi -> DiaChi) ===
                    string query = "UPDATE CHI_NHANH SET CN_Ten = @Ten, CN_DiaChi = @DiaChi, CN_Sdt = @Sdt, CN_NgayThanhLap = @NgayThanhLap WHERE CN_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    cmd.Parameters.AddWithValue("@Ten", cn.Ten ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", cn.DiaChi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sdt", cn.Sdt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayThanhLap", cn.NgayThanhLap ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ma", cn.Ma);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật chi nhánh: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }
    }
}