using GZone.models; // Để dùng TaiKhoan
using GZone; // Để dùng clsDatabase (đảm bảo namespace này đúng với vị trí của clsDatabase)
using System;
using System.Collections.Generic;
using System.Data.SqlClient; // Cần thiết để làm việc với SQL Server
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Cần cho MessageBox

namespace GZone.QuanLyDangNhap
{
    internal class QuanLyDangNhapDAL
    {
        public TaiKhoan Login(string tenDangNhap, string matKhau)
        {
            TaiKhoan user = null; 
            if (clsDatabase.OpenConnection())
            {
                try
                {

                    string query = "SELECT TK_Ma, TK_Ten, TK_TrangThai, TK_Quyen, CN_Ma FROM TAI_KHOAN WHERE TK_Ten = @Ten AND TK_MatKhau = @MatKhau";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    // Sử dụng SqlParameter để tránh SQL Injection
                    cmd.Parameters.AddWithValue("@Ten", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) 
                    {
                        user = new TaiKhoan
                        {
                            Ma = reader["TK_Ma"].ToString(),
                            Ten = reader["TK_Ten"].ToString(),
                            TrangThai = Convert.ToBoolean(reader["TK_TrangThai"]), 
                            Quyen = reader["TK_Quyen"].ToString(),
                            MaChiNhanh = reader["CN_Ma"].ToString() 
                        };
                    }
                    reader.Close(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra đăng nhập từ database: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally

                    clsDatabase.CloseConnection();
                }
            }
            return user; 
        }
    }
}