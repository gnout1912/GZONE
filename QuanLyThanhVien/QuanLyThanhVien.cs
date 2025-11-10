using GZone.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using System.Drawing.Printing;

namespace GZone.QuanLyThanhVien
{
    public partial class QuanLyThanhVien : Form
    {
        private ThanhVienDAL tvDAL = new ThanhVienDAL();
        private ThanhVienGoiTapDAL tvgtDAL = new ThanhVienGoiTapDAL();
        private GoiTapDAL gtDAL = new GoiTapDAL();
        public QuanLyThanhVien()
        {
            InitializeComponent();
        }

        private void LoadDanhSachThanhVien()
        {
            DataTable dt = tvDAL.GetAllThanhVien();
            dgvThanhVien.DataSource = dt;

            try
            {
                if (dgvThanhVien.Columns["TV_Ma"] != null)
                {
                    dgvThanhVien.Columns["TV_Ma"].HeaderText = "Mã Thành Viên";
                    dgvThanhVien.Columns["TV_Ma"].Width = 180; 
                }

                if (dgvThanhVien.Columns["TV_HoTen"] != null)
                {
                    dgvThanhVien.Columns["TV_HoTen"].HeaderText = "Họ và Tên";
                    dgvThanhVien.Columns["TV_HoTen"].Width = 120;
                }

                if (dgvThanhVien.Columns["TV_NgaySinh"] != null)
                {
                    dgvThanhVien.Columns["TV_NgaySinh"].HeaderText = "Ngày Sinh";
                    dgvThanhVien.Columns["TV_NgaySinh"].Width = 100;
                }

                if (dgvThanhVien.Columns["TV_GioiTinh"] != null)
                {
                    dgvThanhVien.Columns["TV_GioiTinh"].HeaderText = "Giới Tính";
                    dgvThanhVien.Columns["TV_Ma"].Width = 120;
                }

                if (dgvThanhVien.Columns["TV_Sdt"] != null)
                {
                    dgvThanhVien.Columns["TV_Sdt"].HeaderText = "Số Điện Thoại";
                    dgvThanhVien.Columns["TV_Sdt"].Width = 120;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tùy chỉnh cột: " + ex.Message);
            }
        }

        private void LoadGoiTapComboBox()
        {
            List<GoiTap> listGT = gtDAL.GetAllGoiTap();
            cboGoiTap.DataSource = listGT;
            cboGoiTap.DisplayMember = "Ten"; 
            cboGoiTap.ValueMember = "Ma";    
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void printCardDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                string maTV = txtMa.Text;
                string hoTen = txtHoTen.Text;

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(maTV, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(5);

                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font infoFont = new Font("Arial", 12);
                SolidBrush brush = new SolidBrush(Color.Black);
                Pen blackPen = new Pen(Color.Black, 2);

                int startX = 100;
                int startY = 100;
                int cardWidth = 350; 
                int cardHeight = 220; 

                e.Graphics.DrawRectangle(blackPen, startX, startY, cardWidth, cardHeight);

                e.Graphics.DrawString("THẺ THÀNH VIÊN", titleFont, brush, startX + 50, startY + 15);

                e.Graphics.DrawImage(qrCodeImage, startX + 20, startY + 50);

                float infoX = startX + qrCodeImage.Width + 30; 
                float infoY = startY + 60;
                e.Graphics.DrawString("Mã TV:", infoFont, brush, infoX, infoY);
                e.Graphics.DrawString(maTV, infoFont, brush, infoX, infoY + 25);

                e.Graphics.DrawString("Họ tên:", infoFont, brush, infoX, infoY + 60);

                e.Graphics.DrawString(hoTen, infoFont, brush, new RectangleF(infoX, infoY + 85, 150, 50));

                qrCodeImage.Dispose();
                titleFont.Dispose();
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
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn một thành viên để in thẻ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            printCardPreviewDialog.Document = printCardDocument;

            printCardPreviewDialog.ShowDialog();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gbThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void lblNgaySinh_Click(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuanLyThanhVien_Load(object sender, EventArgs e)
        {
            LoadDanhSachThanhVien();
            LoadGoiTapComboBox();
        }

        private void ClearMemberInputs()
        {
            txtMa.Text = "Mã (Tự động)";
            txtHoTen.Text = "Họ tên";
            txtSdt.Text = "Số điện thoại";
            dtpNgaySinh.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = -1;
            dgvGoiTap.DataSource = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maTV = tvDAL.GetNewMaThanhVien();

                ThanhVien tv = new ThanhVien
                {
                    TV_Ma = maTV,
                    TV_HoTen = txtHoTen.Text,
                    TV_NgaySinh = dtpNgaySinh.Value,
                    TV_GioiTinh = cboGioiTinh.Text,
                    TV_Sdt = txtSdt.Text
                };

                int result = tvDAL.AddThanhVien(tv);

                if (result > 0)
                {
                    MessageBox.Show("Thêm thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachThanhVien(); 
                    ClearMemberInputs();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (dgvGoiTap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một gói tập đã đăng ký (ở bảng dưới) để gia hạn.", "Chưa chọn gói tập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvGoiTap.SelectedRows[0];
            int tvgtID = Convert.ToInt32(row.Cells["TVGT_ID"].Value);
            DateTime ngayHienTai = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
            int thoiHan = Convert.ToInt32(row.Cells["GT_ThoiHan"].Value); 
            string maTV = txtMa.Text; 

            DateTime ngayHHMoi;
            if (ngayHienTai < DateTime.Now)
            {
                ngayHHMoi = DateTime.Now.AddMonths(thoiHan);
            }
            else 
            {
                ngayHHMoi = ngayHienTai.AddMonths(thoiHan);
            }

            ThanhVienGoiTap tvgt = new ThanhVienGoiTap
            {
                TVGT_ID = tvgtID,
                NgayHetHan = ngayHHMoi,
                TrangThai = "Còn hiệu lực"
            };

            int result = tvgtDAL.UpdateThanhVienGoiTap(tvgt);
            if (result > 0)
            {
                MessageBox.Show($"Gia hạn thành công.\nNgày hết hạn mới: {ngayHHMoi:dd/MM/yyyy}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGoiTapForMember(maTV);
            }
            else
            {
                MessageBox.Show("Gia hạn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void LoadGoiTapForMember(string maTV)
        {
            dgvGoiTap.DataSource = tvgtDAL.GetGoiTapByThanhVien(maTV);
            if (dgvGoiTap.Columns["TVGT_ID"] != null) dgvGoiTap.Columns["TVGT_ID"].HeaderText = "ID";
            if (dgvGoiTap.Columns["GT_Ten"] != null) dgvGoiTap.Columns["GT_Ten"].HeaderText = "Tên Gói Tập";
            if (dgvGoiTap.Columns["NgayDangKy"] != null) dgvGoiTap.Columns["NgayDangKy"].HeaderText = "Ngày ĐK";
            if (dgvGoiTap.Columns["NgayHetHan"] != null) dgvGoiTap.Columns["NgayHetHan"].HeaderText = "Ngày HH";
            if (dgvGoiTap.Columns["TrangThai"] != null) dgvGoiTap.Columns["TrangThai"].HeaderText = "Trạng Thái";
            if (dgvGoiTap.Columns["GT_Ma"] != null) dgvGoiTap.Columns["GT_Ma"].Visible = false;
            if (dgvGoiTap.Columns["GT_ThoiHan"] != null) dgvGoiTap.Columns["GT_ThoiHan"].Visible = false;

        }

        private void dgvThanhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThanhVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvThanhVien.SelectedRows[0];
                txtMa.Text = row.Cells["TV_Ma"].Value.ToString();
                txtHoTen.Text = row.Cells["TV_HoTen"].Value.ToString();
                txtSdt.Text = row.Cells["TV_Sdt"].Value.ToString();
                cboGioiTinh.SelectedItem = row.Cells["TV_GioiTinh"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["TV_NgaySinh"].Value);

                LoadGoiTapForMember(txtMa.Text);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                ThanhVien tv = new ThanhVien
                {
                    TV_Ma = txtMa.Text,
                    TV_HoTen = txtHoTen.Text,
                    TV_NgaySinh = dtpNgaySinh.Value,
                    TV_GioiTinh = cboGioiTinh.Text,
                    TV_Sdt = txtSdt.Text
                };

                int result = tvDAL.UpdateThanhVien(tv);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachThanhVien(); 
                    ClearMemberInputs(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maTV = txtMa.Text;
            if (string.IsNullOrEmpty(maTV))
            {
                MessageBox.Show("Vui lòng chọn thành viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa thành viên " + maTV + "?",
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
                        ClearMemberInputs(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                string maTV = txtMa.Text; 
                string maGT = cboGoiTap.SelectedValue.ToString();

                GoiTap selectedGT = gtDAL.GetGoiTapByMa(maGT);
                if (selectedGT == null)
                {
                    MessageBox.Show("Không tìm thấy gói tập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ThanhVienGoiTap tvgt = new ThanhVienGoiTap
                {
                    TV_Ma = maTV,
                    GT_Ma = maGT,
                    NgayDangKy = DateTime.Now,
                    NgayHetHan = DateTime.Now.AddMonths(selectedGT.ThoiHan),
                    TrangThai = "Còn hiệu lực"
                };

                int result = tvgtDAL.AddThanhVienGoiTap(tvgt);

                if (result > 0)
                {
                    MessageBox.Show("Thêm gói tập cho thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable dtGoiTap = tvgtDAL.GetGoiTapByThanhVien(maTV);
                    dgvGoiTap.DataSource = dtGoiTap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm gói tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
