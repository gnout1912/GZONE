using GZone.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GZone;

namespace GZone.QuanLyDoanhThuHeThong
{
    public partial class QuanLyDoanhThuHeThong : Form
    {
        ThongKeDAL thongKeDAL;
        ChiNhanhDAL chiNhanhDAL;

        private DataTable _fullData;
        private int _currentPage = 1;
        private int _pageSize = 15;
        private int _totalPages = 0;

        private int _currentRowIndexToPrint = 0;

        public QuanLyDoanhThuHeThong()
        {
            InitializeComponent();
            thongKeDAL = new ThongKeDAL();
            chiNhanhDAL = new ChiNhanhDAL();
        }

        private void QuanLyDoanhThuHeThong_Load(object sender, EventArgs e)
        {
            cbTongHopTheo.Items.Add("Ngày");
            cbTongHopTheo.Items.Add("Tháng");
            cbTongHopTheo.Items.Add("Năm");
            cbTongHopTheo.SelectedIndex = 1;

            cbSapXepTheo.Items.Add("Ngày mới nhất");
            cbSapXepTheo.Items.Add("Doanh thu cao nhất");
            cbSapXepTheo.SelectedIndex = 0;

            cbTangGiam.Items.Add("Giảm dần");
            cbTangGiam.Items.Add("Tăng dần");
            cbTangGiam.SelectedIndex = 0;

            LoadComboBoxChiNhanh();
            SetupDataGridView();

            btnPrevious.Click += new EventHandler(btnPrevious_Click);
            btnNext.Click += new EventHandler(btnNext_Click);

            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnInDoanhThu.Enabled = false;
            lblPageInfo.Text = "";
        }

        private void SetupDataGridView()
        {
            dgvThongKe.AutoGenerateColumns = false;
            dgvThongKe.Dock = DockStyle.Bottom;
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKe.AllowUserToAddRows = false;

            dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThoiGian", HeaderText = "Thời Gian", DataPropertyName = "ThoiGian" });
            dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenChiNhanh", HeaderText = "Tên Chi Nhánh", DataPropertyName = "Tên Chi Nhánh" });
            dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn { Name = "TongDoanhThu", HeaderText = "Tổng Doanh Thu", DataPropertyName = "Tổng Doanh Thu", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvThongKe.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuongGiaoDich", HeaderText = "Số Lượng Giao Dịch", DataPropertyName = "Số Lượng Giao Dịch" });

            dgvThongKe.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgvThongKe_RowPostPaint);
            dgvThongKe.RowHeadersWidth = 65;
        }

        private void LoadComboBoxChiNhanh()
        {
            try
            {
                List<ChiNhanh> dsChiNhanh = chiNhanhDAL.GetAllChiNhanh();
                dsChiNhanh.Insert(0, new ChiNhanh { Ma = "TatCa", Ten = "Tất cả chi nhánh" });
                cbChiNhanh.DataSource = dsChiNhanh;
                cbChiNhanh.DisplayMember = "Ten";
                cbChiNhanh.ValueMember = "Ma";
                cbChiNhanh.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chi nhánh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            try
            {
                string tongHopTheo = cbTongHopTheo.SelectedItem.ToString();
                string sapXepTheo = cbSapXepTheo.SelectedItem.ToString();
                string maChiNhanh = cbChiNhanh.SelectedValue.ToString();
                string sapXepHuong = cbTangGiam.SelectedItem.ToString();

                _fullData = thongKeDAL.GetThongKeDoanhThu(tongHopTheo, maChiNhanh, sapXepTheo, sapXepHuong);

                _currentPage = 1;
                _totalPages = (int)Math.Ceiling(_fullData.Rows.Count / (double)_pageSize);

                BindPageData();
                UpdatePaginationControls();

                btnInDoanhThu.Enabled = (_fullData.Rows.Count > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chạy thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInDoanhThu_Click(object sender, EventArgs e)
        {
            if (_fullData == null || _fullData.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _currentRowIndexToPrint = 0;

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();
        }

        private void dgvThongKe_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string soThuTu = ((_currentPage - 1) * _pageSize + e.RowIndex + 1).ToString();
            Font font = new Font("Segoe UI", 9, FontStyle.Regular);
            Brush brush = Brushes.Black;
            SizeF stringSize = e.Graphics.MeasureString(soThuTu, font);
            float x = e.RowBounds.Left + (dgvThongKe.RowHeadersWidth - stringSize.Width) / 2;
            float y = e.RowBounds.Top + (dgvThongKe.RowTemplate.Height - stringSize.Height) / 2;
            e.Graphics.DrawString(soThuTu, font, brush, x, y);
        }

        private void BindPageData()
        {
            var pageData = _fullData.AsEnumerable()
                                    .Skip((_currentPage - 1) * _pageSize)
                                    .Take(_pageSize);

            if (pageData.Any())
            {
                dgvThongKe.DataSource = pageData.CopyToDataTable();
            }
            else
            {
                dgvThongKe.DataSource = _fullData.Clone();
            }
        }

        private void UpdatePaginationControls()
        {
            if (_totalPages > 0)
            {
                lblPageInfo.Text = $"Trang {_currentPage} / {_totalPages}";
                btnPrevious.Enabled = (_currentPage > 1);
                btnNext.Enabled = (_currentPage < _totalPages);
            }
            else
            {
                lblPageInfo.Text = "Không có dữ liệu";
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                BindPageData();
                UpdatePaginationControls();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                BindPageData();
                UpdatePaginationControls();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font bodyFont = new Font("Segoe UI", 10, FontStyle.Regular);
            Brush brush = Brushes.Black;
            Pen pen = new Pen(Color.Black, 1);

            float y = e.MarginBounds.Top;
            float x = e.MarginBounds.Left;
            float rowHeight = bodyFont.GetHeight(e.Graphics) + 8;

            string title = "BÁO CÁO DOANH THU HỆ THỐNG";
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            e.Graphics.DrawString(title, titleFont, brush, e.MarginBounds.Left + (e.MarginBounds.Width - titleSize.Width) / 2, y);
            y += titleSize.Height + 20;

            string filterInfo = $"Tổng hợp: {cbTongHopTheo.Text} | Chi nhánh: {cbChiNhanh.Text} | Sắp xếp: {cbSapXepTheo.Text} ({cbTangGiam.Text})";
            e.Graphics.DrawString(filterInfo, bodyFont, brush, x, y);
            y += rowHeight + 10;

            float currentX = x;
            float colSttWidth = 50;
            float colThoiGianWidth = 100;
            float colChiNhanhWidth = 250;
            float colSoLuongWidth = 150;
            float colTongDoanhThuWidth = 150;

            e.Graphics.DrawString("STT", headerFont, brush, currentX, y);
            currentX += colSttWidth;
            e.Graphics.DrawString("Thời Gian", headerFont, brush, currentX, y);
            currentX += colThoiGianWidth;
            e.Graphics.DrawString("Tên Chi Nhánh", headerFont, brush, currentX, y);
            currentX += colChiNhanhWidth;
            e.Graphics.DrawString("Số Giao Dịch", headerFont, brush, currentX, y);
            currentX += colSoLuongWidth;
            e.Graphics.DrawString("Tổng Doanh Thu", headerFont, brush, currentX, y);
            y += rowHeight;

            e.Graphics.DrawLine(pen, x, y, e.MarginBounds.Right, y);
            y += 5;

            for (int i = _currentRowIndexToPrint; i < _fullData.Rows.Count; i++)
            {
                if (y + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    _currentRowIndexToPrint = i;
                    return;
                }

                DataRow row = _fullData.Rows[i];
                currentX = x;

                e.Graphics.DrawString((i + 1).ToString(), bodyFont, brush, currentX, y);
                currentX += colSttWidth;

                e.Graphics.DrawString(row["ThoiGian"].ToString(), bodyFont, brush, currentX, y);
                currentX += colThoiGianWidth;

                e.Graphics.DrawString(row["Tên Chi Nhánh"].ToString(), bodyFont, brush, currentX, y);
                currentX += colChiNhanhWidth;

                e.Graphics.DrawString(row["Số Lượng Giao Dịch"].ToString(), bodyFont, brush, currentX, y);
                currentX += colSoLuongWidth;

                string doanhThu = Convert.ToDecimal(row["Tổng Doanh Thu"]).ToString("N0");
                SizeF doanhThuSize = e.Graphics.MeasureString(doanhThu, bodyFont);
                e.Graphics.DrawString(doanhThu, bodyFont, brush, (currentX + colTongDoanhThuWidth - doanhThuSize.Width), y);

                y += rowHeight;
            }

            e.HasMorePages = false;
            _currentRowIndexToPrint = 0;
        }
    }
}