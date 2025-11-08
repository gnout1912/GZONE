using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GZone.models
{
    public class ChamCong
    {
        public int CC_ID { get; set; }
        public string NV_Ma { get; set; }
        public DateTime? GioVao { get; set; }
        public DateTime? GioRa { get; set; }
        public DateTime Ngay { get; set; }
    }

    public class ChamCongDAL
    {
        public void CheckIn(string maNV)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"
                        IF NOT EXISTS (SELECT * FROM CHAM_CONG WHERE NV_Ma = @Ma AND Ngay = CAST(GETDATE() AS DATE))
                        BEGIN
                            INSERT INTO CHAM_CONG (NV_Ma, GioVao, Ngay)
                            VALUES (@Ma, GETDATE(), CAST(GETDATE() AS DATE))
                        END";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", maNV);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Check-in thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi check-in: " + ex.Message);
                }
                finally { clsDatabase.CloseConnection(); }
            }
        }

        public void CheckOut(string maNV)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = @"
                        UPDATE CHAM_CONG
                        SET GioRa = GETDATE()
                        WHERE NV_Ma = @Ma AND Ngay = CAST(GETDATE() AS DATE) AND GioRa IS NULL";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", maNV);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("✅ Check-out thành công!");
                    else
                        MessageBox.Show("⚠️ Bạn chưa check-in hoặc đã check-out rồi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi check-out: " + ex.Message);
                }
                finally { clsDatabase.CloseConnection(); }
            }
        }

        public List<ChamCong> GetAllChamCong()
        {
            List<ChamCong> list = new List<ChamCong>();
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT * FROM CHAM_CONG ORDER BY Ngay DESC";
                    SqlCommand cmd = new SqlCommand(query, clsDatabase.con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ChamCong cc = new ChamCong
                        {
                            CC_ID = Convert.ToInt32(reader["CC_ID"]),
                            NV_Ma = reader["NV_Ma"].ToString(),
                            GioVao = reader["GioVao"] == DBNull.Value ? null : (DateTime?)reader["GioVao"],
                            GioRa = reader["GioRa"] == DBNull.Value ? null : (DateTime?)reader["GioRa"],
                            Ngay = Convert.ToDateTime(reader["Ngay"])
                        };
                        list.Add(cc);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách chấm công: " + ex.Message);
                }
                finally { clsDatabase.CloseConnection(); }
            }
            return list;
        }
    }
}
