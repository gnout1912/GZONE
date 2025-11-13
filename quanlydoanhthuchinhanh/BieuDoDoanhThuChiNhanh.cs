using GZone.models;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace GZone.QuanLyDoanhThuChiNhanh
{
    public partial class BieuDoDoanhThuChiNhanh : Form
    {
        private string _maChiNhanh;
        private int _namXem;
        private ThongKeDAL _dal;
        public BieuDoDoanhThuChiNhanh(string maChiNhanh, int? thang, int nam) 
        {
            InitializeComponent();
            _maChiNhanh = maChiNhanh;
            _namXem = nam;
            _dal = new ThongKeDAL();
        }

        private void BieuDoDoanhThuChiNhanh_Load(object sender, EventArgs e)
        {
            lblTieuDe.Text = $"BIỂU ĐỒ DOANH THU NĂM {_namXem}";
            VeBieuDo();
        }

        private void VeBieuDo()
        {
            try
            {
                chartDoanhThu.Series.Clear();
                chartDoanhThu.Titles.Clear();

                Series series = new Series("DoanhThu");
                series.ChartType = SeriesChartType.Column;
                series.Color = System.Drawing.Color.Teal;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "N2";

                DataTable dt = _dal.GetThongKeDoanhThu("Tháng", _maChiNhanh, "Ngày mới nhất", "Không sắp xếp");

                decimal[] doanhThuThang = new decimal[13]; 

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int rThang = 0;
                        int rNam = 0;
                        decimal rTien = 0;

                        if (dt.Columns.Contains("ThoiGian"))
                        {
                            string[] parts = row["ThoiGian"].ToString().Split('-');
                            if (parts.Length == 2)
                            {
                                rThang = int.Parse(parts[0]);
                                rNam = int.Parse(parts[1]);
                            }
                        }
                        else if (dt.Columns.Contains("Ngày"))
                        {
                            DateTime d = Convert.ToDateTime(row["Ngày"]);
                            rThang = d.Month;
                            rNam = d.Year;
                        }

                        if (rNam == _namXem)
                        {
                            if (dt.Columns.Contains("Tổng Doanh Thu") && row["Tổng Doanh Thu"] != DBNull.Value)
                            {
                                rTien = Convert.ToDecimal(row["Tổng Doanh Thu"]);
                                doanhThuThang[rThang] += rTien;
                            }
                        }
                    }
                }

                for (int i = 1; i <= 12; i++)
                {
                    decimal giaTriTrieuDong = doanhThuThang[i] / 1000000m; 
                    DataPoint point = new DataPoint();
                    point.SetValueXY(i, giaTriTrieuDong);

                    point.ToolTip = $"{i}/{_namXem}\nDoanh thu: {doanhThuThang[i]:N0} VNĐ";
                    series.Points.Add(point);
                }

                chartDoanhThu.Series.Add(series);
                chartDoanhThu.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartDoanhThu.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                chartDoanhThu.ChartAreas[0].AxisX.Maximum = 12;

                chartDoanhThu.ChartAreas[0].AxisX.Title = "Tháng";
                chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;

                chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (Triệu VNĐ)";
                chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi vẽ biểu đồ: " + ex.Message);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}