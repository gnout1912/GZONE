using GZone.models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GZone.QuanLyThanhVien
{
    public partial class QuanLyThanhVien : Form
    {
        ThanhVienDAL tvDAL;
        ThanhVienGoiTapDAL tvgtDAL;

        private string currentMaTV = null;

        public QuanLyThanhVien()
        {
            InitializeComponent();
            tvDAL = new ThanhVienDAL();
            tvgtDAL = new ThanhVienGoiTapDAL();

        }

        private void LoadDanhSachThanhVien()
        {
            string maCN = Session.MaChiNhanh;
            string searchTerm = txtTimKiem.Text.Trim();
            dgvHoiVien.AutoGenerateColumns = true;
            
            dgvHoiVien.DataSource = tvDAL.GetAllThanhVien(maCN, searchTerm);
        }

        private void QuanLyThanhVien_Load(object sender, EventArgs e)
        {
            SetupGoiTapColumns();
            LoadDanhSachThanhVien();
        }

        #region Tải Dữ Liệu (Hàm Helper

        private void LoadThongTinChiTiet(string maHV)
        {
            ThanhVien tv = tvDAL.GetThanhVienByMa(maHV);

            if (tv != null)
            {
                txtMaHV.Text = tv.TV_Ma;
                txtHoTen.Text = tv.TV_HoTen;
                txtNgaySinh.Text = tv.TV_NgaySinh.ToString("dd/MM/yyyy");
                txtGioiTinh.Text = tv.TV_GioiTinh;
                txtSdt.Text = tv.TV_Sdt;

                txtChiNhanh.Text = tv.TenChiNhanh; 
            }
        }

        private void SetupGoiTapColumns()
        {
            dgvGoiTap.AutoGenerateColumns = false;
            dgvGoiTap.Columns.Clear();
            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TVGT_ID",
                DataPropertyName = "TVGT_ID",
                HeaderText = "ID",
                Visible = false 
            });
            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GT_Ma",
                DataPropertyName = "GT_Ma", 
                HeaderText = "Mã Gói",
                Width = 80
            });

            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GT_Ten",
                DataPropertyName = "GT_Ten",
                HeaderText = "Tên Gói Tập",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            });

            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GT_ThoiHan",
                DataPropertyName = "GT_ThoiHan", 
                HeaderText = "Thời Hạn (Tháng)", 
                Width = 80
            });

            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayDangKy",
                DataPropertyName = "NgayDangKy", 
                HeaderText = "Ngày Đăng Ký", 
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 110
            });

            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayHetHan",
                DataPropertyName = "NgayHetHan", 
                HeaderText = "Ngày Hết Hạn", 
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 110
            });

            dgvGoiTap.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TrangThai",
                DataPropertyName = "TrangThai", 
                HeaderText = "Trạng Thái", 
                Width = 110
            });
        }

        private void LoadThongTinDichVu(string maTV)
        {
            dgvGoiTap.DataSource = tvgtDAL.GetGoiTapByThanhVien(maTV);
        }

        private void ClearDetailTabs()
        {
            txtMaHV.Text = "";
            txtHoTen.Text = "";
            txtNgaySinh.Text = "";
            txtGioiTinh.Text = "";
            txtSdt.Text = "";
            txtChiNhanh.Text = "";

            dgvGoiTap.DataSource = null;

            currentMaTV = null;
        }

        #endregion

        #region Sự kiện Click (Nút bấm)

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMaHV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtChiNhanh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGioiTinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSdt_Click(object sender, EventArgs e)
        {

        }

        private void lblNgaySinh_Click(object sender, EventArgs e)
        {

        }

        private void lblMaHV_Click(object sender, EventArgs e)
        {

        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDanhSachThanhVien();
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
                e.Handled = true;
            }
        }

        private void btnThemHoiVien_Click(object sender, EventArgs e)
        {
            ThemThanhVien fThem = new ThemThanhVien(null);

            if (fThem.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachThanhVien();
            }
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaTV))
            {
                MessageBox.Show("Vui lòng chọn hội viên từ danh sách.");
                return;
            }

            ThemThanhVien fSua = new ThemThanhVien(currentMaTV);

            if (fSua.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachThanhVien();
                LoadThongTinChiTiet(currentMaTV);
            }
        }

        private void btnDangKyGoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaTV))
            {
                MessageBox.Show("Vui lòng chọn hội viên từ danh sách.");
                return;
            }

            string tenHV = txtHoTen.Text;

            DangKiGoiTap fDK = new DangKiGoiTap(currentMaTV, tenHV);

            if (fDK.ShowDialog() == DialogResult.OK)
            {
                LoadThongTinDichVu(currentMaTV);
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (dgvGoiTap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một gói tập từ danh sách để gia hạn.",
                                "Chưa chọn gói", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvGoiTap.SelectedRows[0];
            string tenGoi = row.Cells["GT_Ten"].Value.ToString();
            DateTime ngayHetHanCu = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn gia hạn cho gói '{tenGoi}' không?\n" +
                                              $"Ngày hết hạn cũ: {ngayHetHanCu.ToString("dd/MM/yyyy")}",
                                              "Xác nhận gia hạn",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                int tvgtID = Convert.ToInt32(row.Cells["TVGT_ID"].Value);

                int thoiHanGoi_TheoThang = Convert.ToInt32(row.Cells["GT_ThoiHan"].Value);


                DateTime today = DateTime.Now.Date;
                DateTime startDate;

                if (ngayHetHanCu < today)
                {
                    startDate = today;
                }
                else
                {
                    startDate = ngayHetHanCu;
                }

                DateTime ngayHetHanMoi = startDate.AddMonths(thoiHanGoi_TheoThang);

                ThanhVienGoiTap tvgt_Update = new ThanhVienGoiTap
                {
                    TVGT_ID = tvgtID,
                    NgayHetHan = ngayHetHanMoi,
                    TrangThai = "Còn hiệu lực"
                };

                int result = tvgtDAL.UpdateThanhVienGoiTap(tvgt_Update);

                if (result > 0)
                {
                    MessageBox.Show($"Gia hạn thành công!\nNgày hết hạn mới: {ngayHetHanMoi.ToString("dd/MM/yyyy")}",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadThongTinDichVu(this.currentMaTV);
                }
                else
                {
                    MessageBox.Show("Gia hạn thất bại do lỗi CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình gia hạn: " + ex.Message,
                                "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Sự kiện DataGridView

        private void dgvHoiVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoiVien.SelectedRows.Count > 0)
            {
                string maTV = dgvHoiVien.SelectedRows[0].Cells["Mã TV"].Value.ToString();

                if (maTV != currentMaTV)
                {
                    currentMaTV = maTV;

                    LoadThongTinChiTiet(currentMaTV);
                    LoadThongTinDichVu(currentMaTV);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoiVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thành viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maTV = dgvHoiVien.SelectedRows[0].Cells["Mã TV"].Value.ToString();
            string tenTV = dgvHoiVien.SelectedRows[0].Cells["Họ Tên"].Value.ToString(); 

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa thành viên '{tenTV}' ({maTV})?",
                                                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int result = tvDAL.DeleteThanhVien(maTV);

                    if (result > 0)
                    {
                        MessageBox.Show("Xóa thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachThanhVien();
                        ClearDetailTabs(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearDetailTabs();
            dgvHoiVien.ClearSelection();
            txtTimKiem.Text = "";
        }

        private void printCardDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                string maTV = txtMaHV.Text;
                string hoTen = txtHoTen.Text;
                string ngaySinh = txtNgaySinh.Text;
                string gioiTinh = txtGioiTinh.Text;
                string sdt = txtSdt.Text;
                string chiNhanh = txtChiNhanh.Text;

                StringBuilder qrDataBuilder = new StringBuilder();
                qrDataBuilder.AppendLine($"Chi Nhánh: {chiNhanh}");
                qrDataBuilder.AppendLine("--- GÓI TẬP HIỆN CÓ ---");

                DataTable dtGoiTap = tvgtDAL.GetGoiTapByThanhVien(maTV);
                int soGoiConHan = 0;

                if (dtGoiTap != null)
                {
                    foreach (DataRow row in dtGoiTap.Rows)
                    {
                        if (row["TrangThai"].ToString() == "Còn hiệu lực")
                        {
                            string tenGoi = row["GT_Ten"].ToString();
                            DateTime ngayHH = Convert.ToDateTime(row["NgayHetHan"]);
                            qrDataBuilder.AppendLine($"- {tenGoi} (HSD: {ngayHH:dd/MM/yyyy})");
                            soGoiConHan++;
                        }
                    }
                }
                if (soGoiConHan == 0)
                {
                    qrDataBuilder.AppendLine("Không có gói tập nào còn hiệu lực.");
                }

                string qrData = qrDataBuilder.ToString();

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = new Bitmap(qrCode.GetGraphic(3), new Size(150, 150));

                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font labelFont = new Font("Arial", 10, FontStyle.Bold);
                Font infoFont = new Font("Arial", 10);
                SolidBrush brush = new SolidBrush(Color.Black);
                Pen blackPen = new Pen(Color.Black, 2);
                int startX = 100, startY = 100, cardWidth = 400, cardHeight = 250;

                e.Graphics.DrawRectangle(blackPen, startX, startY, cardWidth, cardHeight);
                e.Graphics.DrawString("THẺ THÀNH VIÊN", titleFont, brush, startX + 75, startY + 15);
                e.Graphics.DrawImage(qrCodeImage, startX + 20, startY + 60);

                float infoX_Label = startX + qrCodeImage.Width + 30;
                float infoX_Text = infoX_Label + 80;
                float infoY = startY + 60;

                e.Graphics.DrawString("Mã TV:", labelFont, brush, infoX_Label, infoY);
                e.Graphics.DrawString(maTV, infoFont, brush, infoX_Text, infoY);
                infoY += 30;
                e.Graphics.DrawString("Họ tên:", labelFont, brush, infoX_Label, infoY);
                e.Graphics.DrawString(hoTen, infoFont, brush, new RectangleF(infoX_Text, infoY, 150, 40));
                infoY += 30;
                e.Graphics.DrawString("Ngày sinh:", labelFont, brush, infoX_Label, infoY);
                e.Graphics.DrawString(ngaySinh, infoFont, brush, infoX_Text, infoY);
                infoY += 30;
                e.Graphics.DrawString("Giới tính:", labelFont, brush, infoX_Label, infoY);
                e.Graphics.DrawString(gioiTinh, infoFont, brush, infoX_Text, infoY);
                infoY += 30;
                e.Graphics.DrawString("SĐT:", labelFont, brush, infoX_Label, infoY);
                e.Graphics.DrawString(sdt, infoFont, brush, infoX_Text, infoY);
                infoY += 30;
                e.Graphics.DrawString("Chi Nhánh:", labelFont, brush, infoX_Label, infoY);
                e.Graphics.DrawString(chiNhanh, infoFont, brush, infoX_Text, infoY);

                qrCodeImage.Dispose();
                titleFont.Dispose();
                labelFont.Dispose();
                infoFont.Dispose();
                brush.Dispose();
                blackPen.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vẽ thẻ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnInThe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHV.Text))
            {
                MessageBox.Show("Vui lòng chọn một thành viên để in thẻ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            printCardPreviewDialog.Document = printCardDocument;

            printCardPreviewDialog.ShowDialog();

        }
    }
}
