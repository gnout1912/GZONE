using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZone.models
{
    public class NhanVien
    {
        public string Ma { get; set; }           // SỬA: NV_Ma CHAR(10)
        public string Ten { get; set; }          // NV_Ten
        public string Sdt { get; set; }          // NV_Sdt
        public string GioiTinh { get; set; }     // NV_GioiTinh
        public string MaChiNhanh { get; set; }   // CN_Ma CHAR(10)
    }

    public class NhanVienDAL
    {
        // Lấy toàn bộ danh sách nhân viên
        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT * FROM NHAN_VIEN";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        NhanVien nv = new NhanVien
                        {
                            Ma = reader["NV_Ma"].ToString(), // SỬA: Đọc Ma là string
                            Ten = reader["NV_Ten"].ToString(),
                            Sdt = reader["NV_Sdt"].ToString(),
                            GioiTinh = reader["NV_GioiTinh"].ToString(),
                            MaChiNhanh = reader["CN_Ma"]?.ToString()
                        };
                        list.Add(nv);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return list;
        }

        // Thêm nhân viên
        public void AddNhanVien(NhanVien nv)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO NHAN_VIEN (NV_Ma, NV_Ten, NV_Sdt, NV_GioiTinh, CN_Ma) VALUES (@Ma, @Ten, @Sdt, @GioiTinh, @CNMa)"; // SỬA
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", nv.Ma); // SỬA
                    cmd.Parameters.AddWithValue("@Ten", nv.Ten);
                    cmd.Parameters.AddWithValue("@Sdt", nv.Sdt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CNMa", nv.MaChiNhanh ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Thêm nhân viên thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        // Xóa nhân viên
        public void DeleteNhanVien(string maNV) // SỬA: maNV là string
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "DELETE FROM NHAN_VIEN WHERE NV_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", maNV);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("🗑️ Xóa nhân viên thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        // Cập nhật nhân viên
        public void UpdateNhanVien(NhanVien nv)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "UPDATE NHAN_VIEN SET NV_Ten = @Ten, NV_Sdt = @Sdt, NV_GioiTinh = @GioiTinh, CN_Ma = @CNMa WHERE NV_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ten", nv.Ten);
                    cmd.Parameters.AddWithValue("@Sdt", nv.Sdt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CNMa", nv.MaChiNhanh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ma", nv.Ma);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✏️ Cập nhật thông tin thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }
    }
}