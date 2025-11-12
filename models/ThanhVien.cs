using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZone.models
{
    public class ThanhVien
    {
        public string Ma { get; set; } // TV_Ma CHAR(10)
        public string HoTen { get; set; } // TV_HoTen
        public DateTime? NgaySinh { get; set; } // TV_NgaySinh
        public string GioiTinh { get; set; } // TV_GioiTinh
        public string Sdt { get; set; } // TV_Sdt
    }

    public class ThanhVienDAL
    {
        // Lấy toàn bộ danh sách thành viên
        public List<ThanhVien> GetAllThanhVien()
        {
            List<ThanhVien> list = new List<ThanhVien>();
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT * FROM THANH_VIEN";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ThanhVien tv = new ThanhVien
                        {
                            Ma = reader["TV_Ma"].ToString(),
                            HoTen = reader["TV_HoTen"].ToString(),
                            NgaySinh = reader["TV_NgaySinh"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["TV_NgaySinh"]),
                            GioiTinh = reader["TV_GioiTinh"]?.ToString(),
                            Sdt = reader["TV_Sdt"]?.ToString()
                        };
                        list.Add(tv);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu thành viên: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return list;
        }

        // (Bạn có thể tự thêm các hàm Add, Update, Delete cho Thành Viên ở đây)
    }
}