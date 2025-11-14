using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GZone.models
{
    public class TaiKhoan
    {
        public string Ma { get; set; }      
        public string Ten { get; set; }      
        public string MatKhau { get; set; }   
        public bool TrangThai { get; set; }   
        public string Quyen { get; set; }     
        public string MaChiNhanh { get; set; } 
    }

    public class TaiKhoanDAL
    {
        private string HashPassword(string plainText)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(plainText);
                byte[] hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public TaiKhoan GetAccountLogin(string tenDangNhap, string matKhau)
        {
            TaiKhoan tk = null;
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string matKhauDaBam = HashPassword(matKhau);
                    string query = @"SELECT TK_Ma, TK_Ten, TK_TrangThai, TK_Quyen, CN_Ma 
                             FROM TAI_KHOAN 
                             WHERE TK_Ten = @Ten AND TK_MatKhau = @MatKhau AND TK_TrangThai = 1";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ten", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhauDaBam);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tk = new TaiKhoan
                        {
                            Ma = reader["TK_Ma"].ToString(),
                            Ten = reader["TK_Ten"].ToString(),
                            TrangThai = Convert.ToBoolean(reader["TK_TrangThai"]),
                            Quyen = reader["TK_Quyen"].ToString(),
                            MaChiNhanh = reader["CN_Ma"] == DBNull.Value ? null : reader["CN_Ma"].ToString()
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy tài khoản: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return tk;
        }

        public string GenerateNewMaTaiKhoan()
        {
            string newMa = "TK001";

            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT TOP 1 TK_Ma FROM TAI_KHOAN ORDER BY TK_Ma DESC";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string lastMa = result.ToString();
                        int number = int.Parse(lastMa.Substring(2));
                        newMa = "TK" + (number + 1).ToString("D3");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo mã tài khoản mới: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }

            return newMa;
        }
        public List<TaiKhoan> GetAllTaiKhoan()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT * FROM TAI_KHOAN";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TaiKhoan tk = new TaiKhoan
                        {
                            Ma = reader["TK_Ma"].ToString(),
                            Ten = reader["TK_Ten"]?.ToString(),
                            MatKhau = reader["TK_MatKhau"]?.ToString(),
                            TrangThai = Convert.ToBoolean(reader["TK_TrangThai"]),
                            Quyen = reader["TK_Quyen"]?.ToString(),
                            MaChiNhanh = reader["CN_Ma"] == DBNull.Value ? null : reader["CN_Ma"].ToString()
                        };
                        list.Add(tk);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu tài khoản: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return list;
        }

        public void AddTaiKhoan(TaiKhoan tk)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string matKhauMaHoa = HashPassword(tk.MatKhau);

                    string query = "INSERT INTO TAI_KHOAN (TK_Ma, TK_Ten, TK_MatKhau, TK_TrangThai, TK_Quyen, CN_Ma) " +
                                   "VALUES (@Ma, @Ten, @MatKhau, @TrangThai, @Quyen, @CNMa)";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    cmd.Parameters.AddWithValue("@Ma", tk.Ma);
                    cmd.Parameters.AddWithValue("@Ten", tk.Ten ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhauMaHoa);
                    cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);
                    cmd.Parameters.AddWithValue("@Quyen", tk.Quyen ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CNMa", (object)tk.MaChiNhanh ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm tài khoản thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        public void UpdateTaiKhoan(TaiKhoan tk)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "UPDATE TAI_KHOAN SET TK_Ten = @Ten, TK_TrangThai = @TrangThai, " +
                                   "TK_Quyen = @Quyen, CN_Ma = @CNMa WHERE TK_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    cmd.Parameters.AddWithValue("@Ten", tk.Ten ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);
                    cmd.Parameters.AddWithValue("@Quyen", tk.Quyen ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CNMa", (object)tk.MaChiNhanh ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ma", tk.Ma);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin tài khoản thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        public void DeleteTaiKhoan(string maTK)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "DELETE FROM TAI_KHOAN WHERE TK_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", maTK);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa tài khoản thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        public void ResetMatKhau(string maTaiKhoan, string matKhauMoi)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string matKhauMaHoa = HashPassword(matKhauMoi);

                    string query = "UPDATE TAI_KHOAN SET TK_MatKhau = @MatKhau WHERE TK_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhauMaHoa);
                    cmd.Parameters.AddWithValue("@Ma", maTaiKhoan);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Reset mật khẩu thành công!");
                    else
                        MessageBox.Show("Không tìm thấy tài khoản để reset mật khẩu!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi reset mật khẩu: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        public bool CheckLogin(string tenDangNhap, string matKhauNhap)
        {
            bool isValid = false;

            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT TK_MatKhau FROM TAI_KHOAN WHERE TK_Ten = @Ten";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ten", tenDangNhap);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string matKhauDaBam = result.ToString();
                        string matKhauNhapBam = HashPassword(matKhauNhap);

                        if (matKhauDaBam == matKhauNhapBam)
                            isValid = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }

            return isValid;
        }
    }
}
