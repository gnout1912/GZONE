using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZone.models
{
    // Model cho bảng CA
    public class Ca
    {
        public string MaCa { get; set; }
        public string TenCa { get; set; }
        public TimeSpan ThoiGianBD { get; set; }
        public TimeSpan ThoiGianKT { get; set; }
    }

    // DAL để truy vấn bảng CA
    public class CaDAL
    {
        public List<Ca> GetAllCa()
        {
            List<Ca> list = new List<Ca>();
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    // Sắp xếp theo giờ bắt đầu để "Sáng -> Chiều -> Tối"
                    string query = "SELECT * FROM dbo.CA_LAM_VIEC ORDER BY CA_ThoiGianBD";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Ca
                        {
                            MaCa = reader["CA_Ma"].ToString(),
                            TenCa = reader["CA_Ten"].ToString(),
                            ThoiGianBD = (TimeSpan)reader["CA_ThoiGianBD"],
                            ThoiGianKT = (TimeSpan)reader["CA_ThoiGianKT"]
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi khi tải danh sách ca: " + ex.Message); }
                finally { clsDatabase.CloseConnection(); }
            }
            return list;
        }
    }
}