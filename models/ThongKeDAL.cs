using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GZone;

namespace GZone.models
{
    public class ThongKeDAL
    {
        public DataTable GetThongKeDoanhThu(string tongHopTheo, string maChiNhanh, string sapXepTheo, string sapXepHuong)
        {
            DataTable dt = new DataTable();

            if (clsDatabase.OpenConnection())
            {
                try
                {
                    StringBuilder queryBuilder = new StringBuilder();

                    string selectThoiGian = "";
                    string groupThoiGian = "";

                    if (tongHopTheo == "Ngày")
                    {
                        selectThoiGian = "CONVERT(nvarchar(10), T.NgayDangKy, 103) AS ThoiGian";
                        groupThoiGian = "CAST(T.NgayDangKy AS DATE)";
                    }
                    else if (tongHopTheo == "Tháng")
                    {
                        selectThoiGian = "FORMAT(T.NgayDangKy, 'MM-yyyy') AS ThoiGian";
                        groupThoiGian = "FORMAT(T.NgayDangKy, 'MM-yyyy')";
                    }
                    else
                    {
                        selectThoiGian = "YEAR(T.NgayDangKy) AS ThoiGian";
                        groupThoiGian = "YEAR(T.NgayDangKy)";
                    }

                    queryBuilder.Append($"SELECT {selectThoiGian}, ");
                    queryBuilder.Append(" C.CN_Ten AS N'Tên Chi Nhánh', ");
                    queryBuilder.Append(" SUM(G.GT_Gia) AS N'Tổng Doanh Thu', ");
                    queryBuilder.Append(" COUNT(T.TVGT_ID) AS N'Số Lượng Giao Dịch' ");
                    queryBuilder.Append(" FROM THANH_VIEN_GOI_TAP AS T");
                    queryBuilder.Append(" JOIN GOI_TAP AS G ON T.GT_Ma = G.GT_Ma");
                    queryBuilder.Append(" JOIN CHI_NHANH AS C ON T.CN_Ma = C.CN_Ma ");

                    if (maChiNhanh != "TatCa")
                    {
                        queryBuilder.Append(" WHERE T.CN_Ma = @MaChiNhanh ");
                    }

                    queryBuilder.Append($" GROUP BY {groupThoiGian}, C.CN_Ten ");

                    string huong = (sapXepHuong == "Tăng dần") ? "ASC" : "DESC";

                    if (sapXepTheo == "Doanh thu cao nhất")
                    {
                        queryBuilder.Append($" ORDER BY N'Tổng Doanh Thu' {huong}");
                    }
                    else
                    {
                        queryBuilder.Append($" ORDER BY {groupThoiGian} {huong}");
                    }

                    SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), clsDatabase.con);

                    if (maChiNhanh != "TatCa")
                    {
                        cmd.Parameters.AddWithValue("@MaChiNhanh", maChiNhanh);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    clsDatabase.CloseConnection();
                }
            }
            return dt;
        }
    }
}