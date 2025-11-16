using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZone.models
{
    // Model: Lưu 1 bản ghi đăng ký
    public class DangKiLichLam
    {
        public int DkMa { get; set; }
        public string NvMa { get; set; }
        public string CaMa { get; set; }
        public DateTime NgayDangKy { get; set; }
        public bool DaChamCong { get; set; }

        // Thuộc tính phụ để hiển thị
        public string TenNhanVien { get; set; }
    }

    // DAL: Xử lý logic CSDL
    public class DangKiLichLamDAL
    {
        // Lấy tất cả lịch đăng ký trong 1 tuần (7 ngày)
        public List<DangKiLichLam> GetLichLamTheoTuan(DateTime startOfWeek)
        {
            List<DangKiLichLam> list = new List<DangKiLichLam>();
            DateTime endOfWeek = startOfWeek.AddDays(6);

            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"
                        SELECT D.*, N.NV_Ten 
                        FROM DANG_KI_LICH_LAM D
                        JOIN NHAN_VIEN N ON D.NV_Ma = N.NV_Ma
                        WHERE D.DK_NgayDangKy BETWEEN @start AND @end";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@start", startOfWeek.Date);
                    cmd.Parameters.AddWithValue("@end", endOfWeek.Date);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new DangKiLichLam
                        {
                            DkMa = (int)reader["DK_Ma"],
                            NvMa = reader["NV_Ma"].ToString(),
                            CaMa = reader["CA_Ma"].ToString(),
                            NgayDangKy = (DateTime)reader["DK_NgayDangKy"],
                            DaChamCong = (bool)reader["DK_DaChamCong"],
                            TenNhanVien = reader["NV_Ten"].ToString()
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải lịch làm việc tuần: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return list;
        }

        // Đăng ký 1 ca mới
        public bool AddDangKy(string nvMa, string caMa, DateTime ngay)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO DANG_KI_LICH_LAM (NV_Ma, CA_Ma, DK_NgayDangKy, DK_DaChamCong) VALUES (@NvMa, @CaMa, @Ngay, 0)";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@NvMa", nvMa);
                    cmd.Parameters.AddWithValue("@CaMa", caMa);
                    cmd.Parameters.AddWithValue("@Ngay", ngay.Date);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    // Lỗi này xảy ra nếu vi phạm ràng buộc UNIQUE (UK_NHAN_VIEN_CA_NGAY)
                    MessageBox.Show("Lỗi khi đăng ký ca: Ca này đã có người đăng ký hoặc nhân viên này đã đăng ký ca khác cùng ngày.\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return false;
        }

        // Hủy 1 ca đã đăng ký
        public bool DeleteDangKy(string nvMa, string caMa, DateTime ngay)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    // Chỉ xóa nếu chưa chấm công
                    string query = "DELETE FROM DANG_KI_LICH_LAM WHERE NV_Ma = @NvMa AND CA_Ma = @CaMa AND DK_NgayDangKy = @Ngay AND DK_DaChamCong = 0";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@NvMa", nvMa);
                    cmd.Parameters.AddWithValue("@CaMa", caMa);
                    cmd.Parameters.AddWithValue("@Ngay", ngay.Date);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Không thể hủy ca. Lịch này đã được chấm công hoặc không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy ca: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return false;
        }
        public List<DangKiLichLam> GetLichLamTheoTuanCuaChiNhanh(DateTime startOfWeek, string maChiNhanh)
        {
            List<DangKiLichLam> list = new List<DangKiLichLam>();
            DateTime endOfWeek = startOfWeek.AddDays(6);

            if (clsDatabase.OpenConnection())
            {
                try
                {
                    // 1. Thêm điều kiện 'AND N.CN_Ma = @maChiNhanh' vào query
                    string query = @"
                SELECT D.*, N.NV_Ten 
                FROM DANG_KI_LICH_LAM D
                JOIN NHAN_VIEN N ON D.NV_Ma = N.NV_Ma
                WHERE D.DK_NgayDangKy BETWEEN @start AND @end
                  AND N.CN_Ma = @maChiNhanh"; // <-- THAY ĐỔI QUAN TRỌNG Ở ĐÂY

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@start", startOfWeek.Date);
                    cmd.Parameters.AddWithValue("@end", endOfWeek.Date);

                    // 2. Thêm tham số @maChiNhanh
                    cmd.Parameters.AddWithValue("@maChiNhanh", maChiNhanh);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new DangKiLichLam
                        {
                            DkMa = (int)reader["DK_Ma"],
                            NvMa = reader["NV_Ma"].ToString(),
                            CaMa = reader["CA_Ma"].ToString(),
                            NgayDangKy = (DateTime)reader["DK_NgayDangKy"],
                            DaChamCong = (bool)reader["DK_DaChamCong"],
                            TenNhanVien = reader["NV_Ten"].ToString()
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // 3. Cập nhật thông báo lỗi
                    MessageBox.Show("Lỗi khi tải lịch làm việc của chi nhánh: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return list;
        }
    }
}