using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZone.models
{
    public class ChiNhanh
    {
        public int Ma { get; set; }           // CN_Ma
        public string Ten { get; set; }          // CN_Ten
        public string DiaChi { get; set; }       // CN_Diachi
        public string Sdt { get; set; }          // CN_Sdt
        public DateTime? NgayThanhLap { get; set; } // CN_NgayThanhLap
    }

    public class ChiNhanhDAL
    {
        // L?y toàn b? danh sách chi nhánh
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
                            Ma = Convert.ToInt32(reader["CN_Ma"]),
                            Ten = reader["CN_Ten"]?.ToString(),
                            DiaChi = reader["CN_Diachi"]?.ToString(),
                            Sdt = reader["CN_Sdt"]?.ToString(),
                            NgayThanhLap = reader["CN_NgayThanhLap"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["CN_NgayThanhLap"])
                        };
                        list.Add(cn);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i khi t?i d? li?u chi nhánh: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return list;
        }

        // Thêm chi nhánh
        public void AddChiNhanh(ChiNhanh cn)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO CHI_NHANH (CN_Ten, CN_Diachi, CN_Sdt, CN_NgayThanhLap) VALUES (@Ten, @DiaChi, @Sdt, @NgayThanhLap)";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    cmd.Parameters.AddWithValue("@Ten", cn.Ten ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", cn.DiaChi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sdt", cn.Sdt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayThanhLap", cn.NgayThanhLap ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm chi nhánh thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i khi thêm chi nhánh: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        // Xóa chi nhánh
        public void DeleteChiNhanh(int maCN)
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
                    MessageBox.Show("L?i khi xóa chi nhánh: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        // C?p nh?t chi nhánh
        public void UpdateChiNhanh(ChiNhanh cn)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "UPDATE CHI_NHANH SET CN_Ten = @Ten, CN_Diachi = @DiaChi, CN_Sdt = @Sdt, CN_NgayThanhLap = @NgayThanhLap WHERE CN_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    cmd.Parameters.AddWithValue("@Ten", cn.Ten ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", cn.DiaChi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sdt", cn.Sdt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayThanhLap", cn.NgayThanhLap ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ma", cn.Ma);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("C?p nh?t thông tin thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i khi c?p nh?t chi nhánh: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }
    }
}