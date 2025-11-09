using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace GZone.models
{
    public class GoiTap
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public decimal Gia { get; set; }
        public int ThoiHan { get; set; }

        public GoiTap()
        {
            Ma = "";
            Ten = "";
            Gia = 0;
            ThoiHan = 0;
        }
        public GoiTap(string ma, string ten, decimal gia, int thoiHan) { 
            Ma = ma;
            Ten = ten;
            Gia = gia;
            ThoiHan = thoiHan;
        }
    }

    public class GoiTapDAL
    {
        public List<GoiTap> GetAllGoiTap()
        {
            List<GoiTap> danhSachGoiTap = new List<GoiTap>();
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    string query = "SELECT GT_Ma, GT_Ten, GT_Gia, GT_ThoiHan FROM Goi_Tap";

                    SqlCommand com = new SqlCommand(query, clsDatabase.con);

                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        GoiTap goitap = new GoiTap
                        {
                            Ma = reader["GT_Ma"].ToString(),
                            Ten = reader["GT_Ten"].ToString(),
                            Gia = Convert.ToDecimal(reader["GT_Gia"]),
                            ThoiHan = Convert.ToInt32(reader["GT_ThoiHan"])
                        };
                        danhSachGoiTap.Add(goitap);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu gói tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return danhSachGoiTap;
        }
        public int AddGoiTap(GoiTap goiTap)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Goi_Tap (GT_Ma, GT_Ten, GT_Gia, GT_ThoiHan) VALUES (@Ma, @Ten, @Gia, @ThoiHan)", clsDatabase.con);

                    cmd.Parameters.AddWithValue("@Ma", goiTap.Ma);
                    cmd.Parameters.AddWithValue("@Ten", goiTap.Ten);
                    cmd.Parameters.AddWithValue("@Gia", goiTap.Gia);
                    cmd.Parameters.AddWithValue("@ThoiHan", goiTap.ThoiHan);    

                    int result = cmd.ExecuteNonQuery();

                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm gói tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }   
            }
            return -1;
        }
        public string getNewMaGoiTap ()
        {
            string MaGoiTap = "";

            if (clsDatabase.OpenConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 GT_Ma FROM Goi_Tap ORDER BY GT_Ma DESC", clsDatabase.con);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string maCuoi = reader["GT_Ma"].ToString().Substring(2);
                    int soMoi = int.Parse(maCuoi) + 1;
                    MaGoiTap = "GT" + soMoi.ToString("D3");
                }
                else
                {
                    MaGoiTap = "GT001";  
                }
            }
            return MaGoiTap;
        }
        public void DeleteAllGoiTap()
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    SqlCommand com = new SqlCommand("DELETE FROM Goi_Tap", clsDatabase.con);

                    com.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa gói tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }
        public void DeleteGoiTapByMa(string MaGoiTap)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    SqlCommand com = new SqlCommand("DELETE FROM Goi_Tap WHERE GT_Ma = @MaGoiTap", clsDatabase.con);
                    com.Parameters.AddWithValue("@MaGoiTap", MaGoiTap);
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa gói tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
        }
        public bool UpdateGoiTap(GoiTap goiTap)
        {
            if (clsDatabase.OpenConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Goi_Tap SET GT_Ten = @Ten, GT_Gia = @Gia, GT_ThoiHan = @ThoiHan WHERE GT_Ma = @Ma", clsDatabase.con);
                    cmd.Parameters.AddWithValue("@Ma", goiTap.Ma);
                    cmd.Parameters.AddWithValue("@Ten", goiTap.Ten);
                    cmd.Parameters.AddWithValue("@Gia", goiTap.Gia);
                    cmd.Parameters.AddWithValue("@ThoiHan", goiTap.ThoiHan);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật gói tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return true;
        }
    }
}
