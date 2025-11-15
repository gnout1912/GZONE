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
    public class ThanhVienGoiTap
    {
        public int TVGT_ID { get; set; }
        public string TV_Ma { get; set; }
        public string GT_Ma { get; set; }
        public DateTime NgayDangKy { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string TrangThai { get; set; }

        public string CN_Ma { get; set; }
    }

    public class ThanhVienGoiTapDAL
    {
        public int AddThanhVienGoiTap(ThanhVienGoiTap tvgt)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string checkQuery = @"SELECT COUNT(*) 
                                  FROM THANH_VIEN_GOI_TAP 
                                  WHERE TV_Ma = @TV AND GT_Ma = @GT AND TrangThai = N'Còn hiệu lực'";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, clsDatabase.con);
                    checkCmd.Parameters.AddWithValue("@TV", tvgt.TV_Ma);
                    checkCmd.Parameters.AddWithValue("@GT", tvgt.GT_Ma);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Thành viên này đã đăng ký gói tập này và đang còn hiệu lực.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return 0; 
                    }

                    string query = @"INSERT INTO THANH_VIEN_GOI_TAP(TV_Ma, GT_Ma, NgayDangKy, NgayHetHan, TrangThai, CN_Ma)
                             VALUES (@TV, @GT, @NgayDK, @NgayHH, @TrangThai, @CNMa)";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@TV", tvgt.TV_Ma);
                    cmd.Parameters.AddWithValue("@GT", tvgt.GT_Ma);
                    cmd.Parameters.AddWithValue("@NgayDK", tvgt.NgayDangKy);
                    cmd.Parameters.AddWithValue("@NgayHH", tvgt.NgayHetHan);
                    cmd.Parameters.AddWithValue("@TrangThai", tvgt.TrangThai);
                    cmd.Parameters.AddWithValue("@CNMa", tvgt.CN_Ma);

                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm gói tập cho thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return -1;
        }


        public int UpdateThanhVienGoiTap(ThanhVienGoiTap tvgt)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"UPDATE THANH_VIEN_GOI_TAP 
                                     SET NgayHetHan=@NgayHH, TrangThai=@TrangThai
                                     WHERE TVGT_ID=@ID";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@NgayHH", tvgt.NgayHetHan);
                    cmd.Parameters.AddWithValue("@TrangThai", tvgt.TrangThai);
                    cmd.Parameters.AddWithValue("@ID", tvgt.TVGT_ID);

                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật gói tập cho thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return -1;
        }

        public int DeleteThanhVienGoiTap(int tvgtID)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "DELETE FROM THANH_VIEN_GOI_TAP WHERE TVGT_ID=@ID";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@ID", tvgtID);

                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa gói tập của thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return -1;
        }

        public DataTable GetAllThanhVienGoiTap()
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"SELECT TVGT.TVGT_ID, TV.TV_Ma, TV.TV_HoTen, GT.GT_Ten, 
                                     GT.GT_Ma, GT.GT_ThoiHan,
                                     TVGT.NgayDangKy, TVGT.NgayHetHan, TVGT.TrangThai
                                     FROM THANH_VIEN_GOI_TAP TVGT
                                     INNER JOIN THANH_VIEN TV ON TVGT.TV_Ma = TV.TV_Ma
                                     INNER JOIN GOI_TAP GT ON TVGT.GT_Ma = GT.GT_Ma";

                    SqlDataAdapter da = new SqlDataAdapter(query, clsDatabase.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy danh sách gói tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return null;
        }

        public DataTable GetGoiTapByThanhVien(string maTV)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"SELECT TVGT.TVGT_ID, GT.GT_Ten, GT.GT_Ma, GT.GT_ThoiHan,
                                     TVGT.NgayDangKy, TVGT.NgayHetHan, TVGT.TrangThai
                                     FROM THANH_VIEN_GOI_TAP TVGT
                                     INNER JOIN GOI_TAP GT ON TVGT.GT_Ma = GT.GT_Ma
                                     WHERE TVGT.TV_Ma = @MaTV";

                    SqlDataAdapter da = new SqlDataAdapter(query, clsDatabase.con);
                    da.SelectCommand.Parameters.AddWithValue("@MaTV", maTV);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy gói tập của thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return null;
        }
    }
}