using GZone.models;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace GZone.QuanLyDoanhThuChiNhanh
{
    public partial class QuanLyDoanhThuChiNhanh : Form
    {
        private ThongKeDAL thongKeDAL;
        private string maChiNhanhHienTai = "CN01";
        private bool isLoading = true;

        public QuanLyDoanhThuChiNhanh()
        {
            InitializeComponent();
            thongKeDAL = new ThongKeDAL();

            cbThang.SelectedIndexChanged += new EventHandler(Filter_Changed);
            cbNam.SelectedIndexChanged += new EventHandler(Filter_Changed);
            cbSapXep.SelectedIndexChanged += new EventHandler(Filter_Changed);
        }

        private void QuanLyDoanhThuChiNhanh_Load(object sender, EventArgs e)
        {
            isLoading = true;
            SetupDefaultViews();
            isLoading = false; // Kết thúc khởi tạo

            // Gọi hàm load lần đầu
            LoadDuLieuDoanhThu();
        }

        private void SetupDefaultViews()
        {
            // 1. Cài đặt ComboBox "Tháng"
            cbThang.Items.Clear();
            cbThang.Items.Add("Tất cả");
            for (int i = 1; i <= 12; i++)
            {
                cbThang.Items.Add(i.ToString());
            }
            cbThang.SelectedIndex = 0;

            // 2. Cài đặt ComboBox "Năm"
            cbNam.Items.Clear();
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 2; i <= currentYear + 2; i++)
            {
                cbNam.Items.Add(i.ToString());
            }
            cbNam.SelectedItem = currentYear.ToString();

            // 3. Cài đặt ComboBox "Sắp xếp"
            cbSapXep.Items.Clear();
            cbSapXep.Items.Add("Giảm dần");
            cbSapXep.Items.Add("Tăng dần");
            cbSapXep.SelectedIndex = 0;
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            // Nếu đang khởi tạo hoặc chưa chọn đủ thông tin thì không chạy logic
            if (isLoading) return;
            if (cbThang.SelectedItem == null || cbNam.SelectedItem == null) return;

            LoadDuLieuDoanhThu();
        }

        private void LoadDuLieuDoanhThu()
        {
            try
            {
                if (cbThang.SelectedItem == null || cbNam.SelectedItem == null || cbSapXep.SelectedItem == null) return;

                string selectedMonth = cbThang.SelectedItem.ToString();
                string selectedYear = cbNam.SelectedItem.ToString();
                string sapXepHuong = cbSapXep.SelectedItem.ToString();

                // Biến cờ để kiểm tra xem user có chọn "Tất cả" không
                bool xemTatCa = (selectedMonth == "Tất cả");
                DataTable dt = thongKeDAL.GetThongKeDoanhThu("Tháng", maChiNhanhHienTai, "Ngày mới nhất", sapXepHuong);
                DataTable filteredDt = dt.Clone();
                string timeKey = "";
                if (!xemTatCa)
                {
                    string formattedMonth = selectedMonth.PadLeft(2, '0'); 
                    timeKey = $"{formattedMonth}-{selectedYear}"; 
                }

                foreach (DataRow row in dt.Rows)
                {
  
                    if (dt.Columns.Contains("ThoiGian"))
                    {
                        string rowTime = row["ThoiGian"].ToString(); 

                        if (xemTatCa)
                        {
                            if (rowTime.EndsWith("-" + selectedYear))
                            {
                                filteredDt.ImportRow(row);
                            }
                        }
                        else
                        {
                            if (rowTime == timeKey)
                            {
                                filteredDt.ImportRow(row);
                            }
                        }
                    }
   
                    else if (dt.Columns.Contains("Ngày"))
                    {
                        DateTime dateVal;
                        if (DateTime.TryParse(row["Ngày"].ToString(), out dateVal))
                        {
                            if (dateVal.Year == int.Parse(selectedYear))
                            {
                                if (xemTatCa)
                                {
                                    filteredDt.ImportRow(row);
                                }
                                else
                                {
    
                                    if (dateVal.Month == int.Parse(selectedMonth))
                                    {
                                        filteredDt.ImportRow(row);
                                    }
                                }
                            }
                        }
                    }
                }

                if (filteredDt.Columns.Contains("Tên Chi Nhánh")) filteredDt.Columns.Remove("Tên Chi Nhánh");
                if (filteredDt.Columns.Contains("TenChiNhanh")) filteredDt.Columns.Remove("TenChiNhanh");

                dgvThongKe.DataSource = filteredDt;

                if (dgvThongKe.Columns.Contains("Tổng Doanh Thu"))
                {
                    dgvThongKe.Columns["Tổng Doanh Thu"].DefaultCellStyle.Format = "N0";
                    dgvThongKe.Columns["Tổng Doanh Thu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                ThemHangTongCongVaoDataGridView(filteredDt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void ThemHangTongCongVaoDataGridView(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                DataTable emptyDt = new DataTable();
                if (dgvThongKe.DataSource is DataTable sourceDt) emptyDt = sourceDt.Clone();
                else if (dt != null) emptyDt = dt.Clone();

                if (emptyDt.Columns.Count == 0) return;

                DataRow row = emptyDt.NewRow();
                if (emptyDt.Columns.Contains("ThoiGian")) row["ThoiGian"] = "TỔNG CỘNG";
                else if (emptyDt.Columns.Contains("Ngày")) row["Ngày"] = "TỔNG CỘNG";

                if (emptyDt.Columns.Contains("Tổng Doanh Thu")) row["Tổng Doanh Thu"] = 0;

                emptyDt.Rows.Add(row);
                dgvThongKe.DataSource = emptyDt;
            }
            else
            {
                decimal tongDoanhThu = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("Tổng Doanh Thu") && row["Tổng Doanh Thu"] != DBNull.Value)
                    {
                        decimal val;
                        if (decimal.TryParse(row["Tổng Doanh Thu"].ToString(), out val)) tongDoanhThu += val;
                    }
                }

                DataTable displayDt = dt.Copy();
                DataRow tongRow = displayDt.NewRow();

                if (displayDt.Columns.Contains("ThoiGian")) tongRow["ThoiGian"] = "TỔNG CỘNG";
                else if (displayDt.Columns.Contains("Ngày")) tongRow["Ngày"] = "TỔNG CỘNG";
                else displayDt.Rows[0][0] = "TỔNG CỘNG"; 

                if (displayDt.Columns.Contains("Tổng Doanh Thu")) tongRow["Tổng Doanh Thu"] = tongDoanhThu;

                displayDt.Rows.Add(tongRow);
                dgvThongKe.DataSource = displayDt;
            }

            if (dgvThongKe.Rows.Count > 0)
            {
                DataGridViewRow lastRow = dgvThongKe.Rows[dgvThongKe.Rows.Count - 1];
                lastRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                lastRow.DefaultCellStyle.Font = new System.Drawing.Font(dgvThongKe.Font, System.Drawing.FontStyle.Bold);

                if (dgvThongKe.Columns.Contains("Tổng Doanh Thu"))
                {
                    dgvThongKe.Columns["Tổng Doanh Thu"].DefaultCellStyle.Format = "N0";
                    dgvThongKe.Columns["Tổng Doanh Thu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void btnXemBieuDo_Click(object sender, EventArgs e)
        {
            if (cbNam.SelectedItem == null) return;

            int selectedYear = Convert.ToInt32(cbNam.SelectedItem.ToString());
            int? selectedMonth = null;

            BieuDoDoanhThuChiNhanh frmBieuDo = new BieuDoDoanhThuChiNhanh(maChiNhanhHienTai, selectedMonth, selectedYear);
            this.Hide();
            frmBieuDo.ShowDialog();
            this.Show();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = $"DoanhThu_{DateTime.Now:yyyyMMdd}.csv"; 

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();

                        string[] columnHeaders = new string[dgvThongKe.Columns.Count];
                        for (int i = 0; i < dgvThongKe.Columns.Count; i++)
                        {
                            columnHeaders[i] = dgvThongKe.Columns[i].HeaderText;
                        }
                        sb.AppendLine(string.Join(",", columnHeaders));

                        foreach (DataGridViewRow row in dgvThongKe.Rows)
                        {
                            if (row.IsNewRow) continue; 

                            string[] cells = new string[dgvThongKe.Columns.Count];
                            for (int j = 0; j < dgvThongKe.Columns.Count; j++)
                            {
                                var val = row.Cells[j].Value?.ToString() ?? "";

                                if (val.Contains(","))
                                {
                                    val = "\"" + val + "\"";
                                }

                                cells[j] = val;
                            }
                            sb.AppendLine(string.Join(",", cells));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));

                        MessageBox.Show("Xuất file Excel (CSV) thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}