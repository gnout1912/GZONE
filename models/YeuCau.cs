using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZone.models
{
    public class YeuCau
    {
        public int Ma { get; set; }           
        public string MaChiNhanh { get; set; }  
        public string TieuDe { get; set; }     
        public string NoiDung { get; set; }     
        public DateTime NgayGui { get; set; }  
        public string TrangThai { get; set; }   
        public string PhanHoi { get; set; }     
        public DateTime? NgayXuLy { get; set; }
    }

    public class YeuCauDAL
    {

        public List<YeuCau> GetAllYeuCau()
        {
            List<YeuCau> list = new List<YeuCau>();
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT * FROM YEU_CAU ORDER BY YC_NgayGui DESC";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        YeuCau yc = new YeuCau
                        {
                            Ma = Convert.ToInt32(reader["YC_Ma"]),
                            MaChiNhanh = reader["CN_Ma"].ToString(),
                            TieuDe = reader["YC_TieuDe"].ToString(),
                            NoiDung = reader["YC_NoiDung"]?.ToString(),
                            NgayGui = Convert.ToDateTime(reader["YC_NgayGui"]),
                            TrangThai = reader["YC_TrangThai"].ToString(),
                            PhanHoi = reader["YC_PhanHoi"]?.ToString(),
                            NgayXuLy = reader["YC_NgayXuLy"] == DBNull.Value
                                         ? (DateTime?)null
                                         : Convert.ToDateTime(reader["YC_NgayXuLy"])
                        };
                        list.Add(yc);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu Yêu Cầu: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return list;
        }

        public List<YeuCau> GetYeuCauTheoChiNhanh(string maChiNhanh)
        {
            List<YeuCau> list = new List<YeuCau>();
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT * FROM YEU_CAU WHERE CN_Ma = @CNMa ORDER BY YC_NgayGui DESC";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    cmd.Parameters.AddWithValue("@CNMa", maChiNhanh);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        YeuCau yc = new YeuCau
                        {
                            Ma = Convert.ToInt32(reader["YC_Ma"]),
                            MaChiNhanh = reader["CN_Ma"].ToString(),
                            TieuDe = reader["YC_TieuDe"].ToString(),
                            NoiDung = reader["YC_NoiDung"]?.ToString(),
                            NgayGui = Convert.ToDateTime(reader["YC_NgayGui"]),
                            TrangThai = reader["YC_TrangThai"].ToString(),
                            PhanHoi = reader["YC_PhanHoi"]?.ToString(),
                            NgayXuLy = reader["YC_NgayXuLy"] == DBNull.Value
                                         ? (DateTime?)null
                                         : Convert.ToDateTime(reader["YC_NgayXuLy"])
                        };
                        list.Add(yc);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải Yêu Cầu theo Chi Nhánh: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return list;
        }

        public void AddYeuCau(YeuCau yc)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO YEU_CAU (CN_Ma, YC_TieuDe, YC_NoiDung) " +
                                   "VALUES (@CNMa, @TieuDe, @NoiDung)";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@CNMa", yc.MaChiNhanh);
                    cmd.Parameters.AddWithValue("@TieuDe", yc.TieuDe);
                    cmd.Parameters.AddWithValue("@NoiDung", yc.NoiDung ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Gửi yêu cầu thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gửi yêu cầu: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        public void UpdateYeuCau(YeuCau yc)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "UPDATE YEU_CAU SET " +
                                   "YC_TrangThai = @TrangThai, " +
                                   "YC_PhanHoi = @PhanHoi, " +
                                   "YC_NgayXuLy = @NgayXuLy " +
                                   "WHERE YC_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);

                    cmd.Parameters.AddWithValue("@TrangThai", yc.TrangThai);
                    cmd.Parameters.AddWithValue("@PhanHoi", yc.PhanHoi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayXuLy", (object)yc.NgayXuLy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ma", yc.Ma);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✏️ Đã xử lý yêu cầu!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật yêu cầu: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }

        public void DeleteYeuCau(int maYC)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "DELETE FROM YEU_CAU WHERE YC_Ma = @Ma";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", maYC);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("🗑️ Xóa yêu cầu thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa yêu cầu: " + ex.Message);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }
    }
}