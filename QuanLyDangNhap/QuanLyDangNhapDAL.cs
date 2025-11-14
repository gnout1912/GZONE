using GZone.models; 
using GZone;
using System;
using System.Collections.Generic;
using System.Data.SqlClient; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography; 

namespace GZone.QuanLyDangNhap
{
    internal class QuanLyDangNhapDAL
    {
     
        private string HashPassword(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(""))).Replace("-", "").ToLower();
            }

            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(plainText);
                byte[] hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public TaiKhoan Login(string tenDangNhap, string matKhau)
        {
            TaiKhoan user = null;

            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string matKhauDaBamTuNhap = HashPassword(matKhau); 

  
                    string query = "SELECT TK_Ma, TK_Ten, TK_TrangThai, TK_Quyen, CN_Ma FROM TAI_KHOAN WHERE TK_Ten = @Ten AND TK_MatKhau = @MatKhau";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    cmd.Parameters.AddWithValue("@Ten", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhauDaBamTuNhap);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) 
                    {
                        user = new TaiKhoan
                        {
                            Ma = reader["TK_Ma"].ToString(),
                            Ten = reader["TK_Ten"]?.ToString(), 
                            TrangThai = Convert.ToBoolean(reader["TK_TrangThai"]),
                            Quyen = reader["TK_Quyen"]?.ToString(), 
                            MaChiNhanh = reader["CN_Ma"] == DBNull.Value ? null : reader["CN_Ma"].ToString() 
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra đăng nhập từ database: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return user;
        }
    }
}