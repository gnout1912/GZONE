using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZone.models
{
    public class NhanVien
    {
        public string Ma { get; set; }              // NV_Ma (tự tăng)
        public string Ten { get; set; }          // NV_Ten
        public string Sdt { get; set; }          // NV_Sdt
        public string GioiTinh { get; set; }     // NV_GioiTinh
        public string MaChiNhanh { get; set; }   // CN_Ma
    }

    public class NhanVienDAL
    {
        // Lấy toàn bộ danh sách nhân viên
        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT * FROM NHAN_VIEN";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        NhanVien nv = new NhanVien
                        {
                            Ma = reader["NV_Ma"].ToString(),
                            Ten = reader["NV_Ten"].ToString(),
                            Sdt = reader["NV_Sdt"].ToString(),
                            GioiTinh = reader["NV_GioiTinh"].ToString(),
                            MaChiNhanh = reader["CN_Ma"]?.ToString()
                        };
                        list.Add(nv);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return list;
        }

        // Thêm nhân viên
        // Thêm nhân viên (TỰ ĐỘNG TẠO MÃ)
        public void AddNhanVien(NhanVien nv)
        {
            // 1. Bắt buộc phải có mã chi nhánh
            if (string.IsNullOrWhiteSpace(nv.MaChiNhanh))
            {
                MessageBox.Show("⚠️ Lỗi: Không thể thêm nhân viên mà không có mã chi nhánh.");
                return;
            }

            if (clsDatabase.OpenConnection())
            {
                // Sử dụng transaction để đảm bảo an toàn dữ liệu khi 2 người cùng thêm
                SqlTransaction transaction = clsDatabase.con.BeginTransaction();
                SqlCommand cmd = clsDatabase.con.CreateCommand();
                cmd.Transaction = transaction;

                try
                {
                    // 2. Tìm mã NV lớn nhất của chi nhánh này
                    int nextId = 1; // Mặc định là 001 nếu chi nhánh chưa có ai
                    cmd.CommandText = "SELECT MAX(NV_Ma) FROM NHAN_VIEN WHERE CN_Ma = @CNMaFind AND NV_Ma LIKE @Pattern";
                    cmd.Parameters.AddWithValue("@CNMaFind", nv.MaChiNhanh);
                    cmd.Parameters.AddWithValue("@Pattern", nv.MaChiNhanh + "%");

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        string lastMa = result.ToString(); // VD: "CN01003"
                        // Lấy 3 ký tự cuối
                        string numericPart = lastMa.Substring(lastMa.Length - 3); // "003"
                        int lastId = int.Parse(numericPart); // 3
                        nextId = lastId + 1; // 4
                    }

                    // 3. Tạo mã NV mới
                    // Format số thành 3 chữ số (VD: 4 -> "004", 12 -> "012")
                    string newNumericPart = nextId.ToString("D3");
                    string newMaNV = nv.MaChiNhanh + newNumericPart; // VD: "CN01" + "004"

                    // (Tùy chọn) Kiểm tra xem mã mới có vượt quá 10 ký tự không
                    if (newMaNV.Length > 10)
                    {
                        throw new Exception($"Mã chi nhánh '{nv.MaChiNhanh}' quá dài, không thể tạo mã nhân viên.");
                    }

                         // 4. Thực hiện INSERT với mã mới

                    cmd.CommandText = "INSERT INTO NHAN_VIEN (NV_Ma, NV_Ten, NV_Sdt, NV_GioiTinh, CN_Ma) VALUES (@Ma, @Ten, @Sdt, @GioiTinh, @CNMa)";

                    // Xóa parameter cũ trước khi thêm parameter mới
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@Ma", newMaNV); // Dùng mã vừa tạo
                    cmd.Parameters.AddWithValue("@Ten", nv.Ten);
                    cmd.Parameters.AddWithValue("@Sdt", nv.Sdt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CNMa", nv.MaChiNhanh);

                    cmd.ExecuteNonQuery();

                    transaction.Commit(); // Hoàn tất
                    MessageBox.Show($"✅ Thêm nhân viên thành công! Mã NV: {newMaNV}");
                }
                catch (Exception ex){
                    transaction.Rollback(); // Hoàn tác nếu có lỗi
                    MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
                }

        finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        // Xóa nhân viên
        public void DeleteNhanVien(string maNV)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "DELETE FROM NHAN_VIEN WHERE NV_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", maNV);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("🗑️ Xóa nhân viên thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        // Cập nhật nhân viên
        public void UpdateNhanVien(NhanVien nv)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "UPDATE NHAN_VIEN SET NV_Ten = @Ten, NV_Sdt = @Sdt, NV_GioiTinh = @GioiTinh, CN_Ma = @CNMa WHERE NV_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ten", nv.Ten);
                    cmd.Parameters.AddWithValue("@Sdt", nv.Sdt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CNMa", nv.MaChiNhanh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ma", nv.Ma);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✏️ Cập nhật thông tin thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }
        public List<NhanVien> GetAllNhanVienWithChiNhanh()
        {
            List<NhanVien> list = new List<NhanVien>();
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"
                        SELECT 
                            N.NV_Ma, N.NV_Ten, N.NV_Sdt, N.NV_GioiTinh, N.CN_Ma, C.CN_Ten 
                        FROM NHAN_VIEN N
                        LEFT JOIN CHI_NHANH C ON N.CN_Ma = C.CN_Ma
                        ORDER BY C.CN_Ten, N.NV_Ten";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        NhanVien nv = new NhanVien
                        {
                            Ma = reader["NV_Ma"].ToString(),
                            Ten = reader["NV_Ten"].ToString(),
                            Sdt = reader["NV_Sdt"].ToString(),
                            GioiTinh = reader["NV_GioiTinh"].ToString(),
                            MaChiNhanh = reader["CN_Ma"]?.ToString(),
                        };
                        list.Add(nv);
                    }
                    reader.Close();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message); }
                finally { clsDatabase.CloseConnection(); }
            }
            return list;
        }
    }
}