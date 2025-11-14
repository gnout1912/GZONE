using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GZone.models
{
    public class ThanhVien
    {
        public string TV_Ma { get; set; }
        public string TV_HoTen { get; set; }
        public DateTime TV_NgaySinh { get; set; }
        public string TV_GioiTinh { get; set; }
        public string TV_Sdt { get; set; }
        public string CN_Ma { get; set; }
        public string TenChiNhanh { get; set; }
    }

    public class ThanhVienDAL
    {
        public DataTable GetAllThanhVien(string maCN, string searchTerm)
        {
            DataTable dt = new DataTable();

            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"
        SELECT 
            TV_Ma AS [Mã TV],
            TV_HoTen AS [Họ Tên],
            CONVERT(VARCHAR(10), TV_NgaySinh, 103) AS [Ngày sinh],
            TV_GioiTinh AS [Giới tính],
            TV_Sdt AS [Số điện thoại],
            CN_Ma AS [Mã chi nhánh]
        FROM THANH_VIEN
        WHERE CN_Ma = @MaCN
    ";

                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        query += " AND (TV_HoTen LIKE @SearchPattern OR TV_Ma LIKE @SearchPattern)";
                    }

                    query += " ORDER BY TV_HoTen";

                    using (SqlCommand cmd = new SqlCommand(query, clsDatabase.con))
                    {
                        cmd.Parameters.AddWithValue("@MaCN", maCN);

                        if (!string.IsNullOrWhiteSpace(searchTerm))
                        {
                            cmd.Parameters.AddWithValue("@SearchPattern", "%" + searchTerm.Trim() + "%");
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách hội viên: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }

            return dt;
        }


        public ThanhVien GetThanhVienByMa(string maTV)
        {
            ThanhVien tv = null;
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"
                SELECT 
                    TV.*, 
                    CN.CN_Ten 
                FROM 
                    THANH_VIEN TV
                LEFT JOIN -- Dùng LEFT JOIN phòng trường hợp TV chưa có chi nhánh
                    CHI_NHANH CN ON TV.CN_Ma = CN.CN_Ma
                WHERE 
                    TV.TV_Ma = @Ma";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", maTV);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tv = new ThanhVien
                        {
                            TV_Ma = reader["TV_Ma"].ToString(),
                            TV_HoTen = reader["TV_HoTen"].ToString(),
                            TV_NgaySinh = Convert.ToDateTime(reader["TV_NgaySinh"]),
                            TV_GioiTinh = reader["TV_GioiTinh"].ToString(),
                            TV_Sdt = reader["TV_Sdt"].ToString(),
                            CN_Ma = reader["CN_Ma"].ToString(),

                            TenChiNhanh = reader["CN_Ten"] == DBNull.Value
                                           ? "Không có"
                                           : reader["CN_Ten"].ToString()
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return tv;
        }

        public string GetNewMaThanhVien()
        {
            string MaThanhVien = "TV001";

            if (clsDatabase.OpenConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 TV_Ma FROM THANH_VIEN ORDER BY TV_Ma DESC", clsDatabase.con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string maCuoi = reader["TV_Ma"].ToString().Substring(2);
                        int soMoi = int.Parse(maCuoi) + 1;
                        MaThanhVien = "TV" + soMoi.ToString("D3");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo mã thành viên mới: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }

            return MaThanhVien;
        }

        public int AddThanhVien(ThanhVien tv)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"INSERT INTO THANH_VIEN(TV_Ma, TV_HoTen, TV_NgaySinh, TV_GioiTinh, TV_Sdt, CN_Ma)
                                     VALUES (@Ma, @HoTen, @NgaySinh, @GioiTinh, @Sdt, @CNMa)";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", tv.TV_Ma);
                    cmd.Parameters.AddWithValue("@HoTen", tv.TV_HoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", tv.TV_NgaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", tv.TV_GioiTinh);
                    cmd.Parameters.AddWithValue("@Sdt", tv.TV_Sdt);
                    cmd.Parameters.AddWithValue("@CNMa", tv.CN_Ma);

                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return -1;
        }

        public int UpdateThanhVien(ThanhVien tv)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"UPDATE THANH_VIEN
                                     SET TV_HoTen=@HoTen, TV_NgaySinh=@NgaySinh, TV_GioiTinh=@GioiTinh, TV_Sdt=@Sdt, CN_Ma=@CNMa
                                     WHERE TV_Ma=@Ma";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", tv.TV_Ma);
                    cmd.Parameters.AddWithValue("@HoTen", tv.TV_HoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", tv.TV_NgaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", tv.TV_GioiTinh);
                    cmd.Parameters.AddWithValue("@Sdt", tv.TV_Sdt);
                    cmd.Parameters.AddWithValue("@CNMa", tv.CN_Ma);

                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return -1;
        }

        public int DeleteThanhVien(string ma)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string checkQuery = @"SELECT COUNT(*) 
                                  FROM THANH_VIEN_GOI_TAP 
                                  WHERE TV_Ma = @Ma AND TrangThai=N'Còn hiệu lực'";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, clsDatabase.con);
                    checkCmd.Parameters.AddWithValue("@Ma", ma);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa thành viên vì họ đang có gói tập còn hiệu lực.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return 0;
                    }

                    string query = "DELETE FROM THANH_VIEN WHERE TV_Ma=@Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", ma);

                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return -1;
        }
    }
}