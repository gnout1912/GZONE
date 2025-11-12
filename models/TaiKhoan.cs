using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZone.models
{
    public class TaiKhoan
    {
        public string Ma { get; set; }        // TK_Ma CHAR(10)
        public string Ten { get; set; }       // TK_Ten
        public string MatKhau { get; set; }   // TK_MatKhau
        public bool TrangThai { get; set; }   // TK_TrangThai
        public string Quyen { get; set; }     // TK_Quyen

        // Khóa ngoại liên kết đến ChiNhanh
        public string MaChiNhanh { get; set; } // SỬA: CN_Ma CHAR(10) NULL
    }

    public class TaiKhoanDAL
    {
        // Lấy toàn bộ danh sách tài khoản
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
                            MaChiNhanh = reader["CN_Ma"] == DBNull.Value ? null : reader["CN_Ma"].ToString() // SỬA
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

        // Thêm tài khoản
        public void AddTaiKhoan(TaiKhoan tk)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO TAI_KHOAN (TK_Ma, TK_Ten, TK_MatKhau, TK_TrangThai, TK_Quyen, CN_Ma) " +
                                   "VALUES (@Ma, @Ten, @MatKhau, @TrangThai, @Quyen, @CNMa)";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    cmd.Parameters.AddWithValue("@Ma", tk.Ma);
                    cmd.Parameters.AddWithValue("@Ten", tk.Ten ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);
                    cmd.Parameters.AddWithValue("@Quyen", tk.Quyen ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CNMa", (object)tk.MaChiNhanh ?? DBNull.Value); // SỬA

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

        // Xóa tài khoản
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

        // Cập nhật tài khoản
        public void UpdateTaiKhoan(TaiKhoan tk)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "UPDATE TAI_KHOAN SET TK_Ten = @Ten, TK_MatKhau = @MatKhau, " +
                                   "TK_TrangThai = @TrangThai, TK_Quyen = @Quyen, CN_Ma = @CNMa " +
                                   "WHERE TK_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    cmd.Parameters.AddWithValue("@Ten", tk.Ten ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TrangThai", tk.TrangThai);
                    cmd.Parameters.AddWithValue("@Quyen", tk.Quyen ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CNMa", (object)tk.MaChiNhanh ?? DBNull.Value); // SỬA
                    cmd.Parameters.AddWithValue("@Ma", tk.Ma);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin thành công!");
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

        // (Các hàm khác như ResetMatKhau, GetCountByQuyen... giữ nguyên)
        // ...
    }
}