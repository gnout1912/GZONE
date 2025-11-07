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
                catch (Exception e)
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
    }
}
