using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZone.models
{
    public class CoSoVatChat
    {
        public int Ma { get; set; }            // CSVC_Ma (tự tăng)
        public string MaChiNhanh { get; set; }    // CN_Ma
        public string TenMay { get; set; }        // CSVC_TenMay
        public string LoaiMay { get; set; }       // CSVC_LoaiMay
        public int SoLuong { get; set; }        // CSVC_SoLuong
        public string TinhTrang { get; set; }     // CSVC_TinhTrang
        public string GhiChu { get; set; }        // CSVC_GhiChu
    }

    public class CoSoVatChatDAL
    {
        // 📋 SỬA LẠI HÀM NÀY
        // Lấy danh sách cơ sở vật chất THEO MÃ CHI NHÁNH
        public List<CoSoVatChat> GetCSVCByMaChiNhanh(string maCN)
        {
            List<CoSoVatChat> list = new List<CoSoVatChat>();

            if (clsDatabase.OpenConnection())
            {
                try
                {
                    // 🟢 Dùng alias để DataGridView hiểu đúng property trong class
                    string query = @"
                        SELECT 
                            CSVC_Ma AS Ma, 
                            CN_Ma AS MaChiNhanh, 
                            TenMay, 
                            LoaiMay, 
                            SoLuong, 
                            TinhTrang, 
                            GhiChu
                        FROM CO_SO_VAT_CHAT
                        WHERE CN_Ma = @MaChiNhanh -- THÊM DÒNG NÀY ĐỂ LỌC
                        ORDER BY CSVC_Ma DESC";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    // THÊM THAM SỐ CHO CÂU LỆNH WHERE
                    cmd.Parameters.AddWithValue("@MaChiNhanh", maCN);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CoSoVatChat c = new CoSoVatChat
                        {
                            Ma = Convert.ToInt32(reader["Ma"]),
                            MaChiNhanh = reader["MaChiNhanh"].ToString(),
                            TenMay = reader["TenMay"].ToString(),
                            LoaiMay = reader["LoaiMay"].ToString(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            TinhTrang = reader["TinhTrang"].ToString(),
                            GhiChu = reader["GhiChu"]?.ToString()
                        };
                        list.Add(c);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách cơ sở vật chất: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }

            return list;
        }

        // ➕ Thêm cơ sở vật chất (Giữ nguyên)
        public void AddCSVC(CoSoVatChat c)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"
                        INSERT INTO CO_SO_VAT_CHAT (CN_Ma, TenMay, LoaiMay, SoLuong, TinhTrang, GhiChu)
                        VALUES (@CN_Ma, @TenMay, @LoaiMay, @SoLuong, @TinhTrang, @GhiChu)";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@CN_Ma", c.MaChiNhanh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenMay", c.TenMay);
                    cmd.Parameters.AddWithValue("@LoaiMay", c.LoaiMay ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoLuong", c.SoLuong);
                    cmd.Parameters.AddWithValue("@TinhTrang", c.TinhTrang ?? "Hoạt động");
                    cmd.Parameters.AddWithValue("@GhiChu", c.GhiChu ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Thêm cơ sở vật chất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm cơ sở vật chất: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        // 🗑️ Xóa cơ sở vật chất (Giữ nguyên)
        public void DeleteCSVC(int ma)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "DELETE FROM CO_SO_VAT_CHAT WHERE CSVC_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", ma);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("🗑️ Xóa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        // ✏️ Cập nhật cơ sở vật chất (Giữ nguyên)
        public void UpdateCSVC(CoSoVatChat c)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"
                        UPDATE CO_SO_VAT_CHAT 
                        SET 
                            CN_Ma = @CN_Ma, 
                            TenMay = @TenMay, 
                            LoaiMay = @LoaiMay, 
                            SoLuong = @SoLuong, 
                            TinhTrang = @TinhTrang, 
                            GhiChu = @GhiChu
                        WHERE CSVC_Ma = @Ma";

                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@CN_Ma", c.MaChiNhanh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenMay", c.TenMay);
                    cmd.Parameters.AddWithValue("@LoaiMay", c.LoaiMay ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoLuong", c.SoLuong);
                    cmd.Parameters.AddWithValue("@TinhTrang", c.TinhTrang ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GhiChu", c.GhiChu ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ma", c.Ma);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("✏️ Cập nhật thành công!");
                    else
                        MessageBox.Show("⚠️ Không tìm thấy bản ghi để cập nhật!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }
    }
}