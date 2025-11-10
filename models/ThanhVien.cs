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
    }

    public class ThanhVienDAL
    {
        public DataTable GetAllThanhVien()
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT TV_Ma, TV_HoTen, TV_NgaySinh, TV_GioiTinh, TV_Sdt FROM THANH_VIEN";
                    SqlDataAdapter da = new SqlDataAdapter(query, clsDatabase.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return null;
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo mã thành viên mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = @"INSERT INTO THANH_VIEN(TV_Ma, TV_HoTen, TV_NgaySinh, TV_GioiTinh, TV_Sdt)
                                     VALUES (@Ma, @HoTen, @NgaySinh, @GioiTinh, @Sdt)";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", tv.TV_Ma);
                    cmd.Parameters.AddWithValue("@HoTen", tv.TV_HoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", tv.TV_NgaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", tv.TV_GioiTinh);
                    cmd.Parameters.AddWithValue("@Sdt", tv.TV_Sdt);

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
                                     SET TV_HoTen=@HoTen, TV_NgaySinh=@NgaySinh, TV_GioiTinh=@GioiTinh, TV_Sdt=@Sdt
                                     WHERE TV_Ma=@Ma";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", tv.TV_Ma);
                    cmd.Parameters.AddWithValue("@HoTen", tv.TV_HoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", tv.TV_NgaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", tv.TV_GioiTinh);
                    cmd.Parameters.AddWithValue("@Sdt", tv.TV_Sdt);

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
