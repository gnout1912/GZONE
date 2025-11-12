using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZone.models
{
    public class TaiKhoan
    {
        public string Ma { get; set; }        // TK_Ma
        public string Ten { get; set; }       // TK_Ten
        public string MatKhau { get; set; }   // TK_MatKhau
        public bool TrangThai { get; set; }   // TK_TrangThai
        public string Quyen { get; set; }     // TK_Quyen

        // Khóa ngo?i liên k?t ??n ChiNhanh
        public int? MaChiNhanh { get; set; }
    }

    public class TaiKhoanDAL
    {
        // L?y toàn b? danh sách tài kho?n
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
                            MaChiNhanh = reader["CN_Ma"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CN_Ma"])
                        };
                        list.Add(tk);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i khi t?i d? li?u tài kho?n: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return list;
        }

        // Thêm tài kho?n
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
                    cmd.Parameters.AddWithValue("@CNMa", tk.MaChiNhanh ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm tài kho?n thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i khi thêm tài kho?n: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        // Xóa tài kho?n
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

                    MessageBox.Show("Xóa tài kho?n thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i khi xóa tài kho?n: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        // C?p nh?t tài kho?n
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
                    cmd.Parameters.AddWithValue("@CNMa", tk.MaChiNhanh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ma", tk.Ma);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("C?p nh?t thông tin thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i khi c?p nh?t tài kho?n: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        // C?p nh?t/Reset m?t kh?u
        public void ResetMatKhau(string maTK, string matKhauMoi)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "UPDATE TAI_KHOAN SET TK_MatKhau = @MatKhau WHERE TK_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    cmd.Parameters.AddWithValue("@MatKhau", matKhauMoi);
                    cmd.Parameters.AddWithValue("@Ma", maTK);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Reset m?t kh?u thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i khi reset m?t kh?u: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }
    }
        // ??m s? tài kho?n theo quy?n
    public int GetCountByQuyen(string quyen)
        {
            int count = 0;
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM TAI_KHOAN WHERE TK_Quyen = @Quyen";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Quyen", quyen);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        count = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i khi ??m tài kho?n: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return count;
        }

        // Ki?m tra mã tài kho?n t?n t?i
        public bool CheckMaExists(string maTK)
        {
            bool exists = false;
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT COUNT(1) FROM TAI_KHOAN WHERE TK_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", maTK);

                    int resultCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (resultCount > 0)
                    {
                        exists = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i khi ki?m tra mã TK: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return exists;
        }
    }