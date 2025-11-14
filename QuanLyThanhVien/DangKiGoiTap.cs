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

namespace GZone.QuanLyThanhVien
{
    public partial class DangKiGoiTap : Form
    {

        private GoiTapDAL goiTapDAL;
        private ThanhVienGoiTapDAL tvgtDAL;

        private string _currentMaTV;
        private string _currentTenTV;
        public DangKiGoiTap(string maTV, string tenTV)
        {
            InitializeComponent();

            goiTapDAL = new GoiTapDAL();
            tvgtDAL = new ThanhVienGoiTapDAL();

            this._currentMaTV = maTV;
            this._currentTenTV = tenTV;
        }

        private void DangKyGoiTap_Load(object sender, EventArgs e)
        {
            LoadGoiTapComboBox();

            dtpNgayDangKy.Value = DateTime.Now;
        }

        private void LoadGoiTapComboBox()
        {
            List<GoiTap> dsGoiTap = goiTapDAL.GetAllGoiTap();

            cboGoiTap.DataSource = dsGoiTap;
            cboGoiTap.DisplayMember = "Ten"; 
            cboGoiTap.ValueMember = "Ma";   

            cboGoiTap.SelectedIndex = -1;
        }

        private void cboGoiTap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGoiTap.SelectedItem == null)
            {
                txtThoiHan.Text = "";
                txtGiaTien.Text = "";
                txtNgayHetHan.Text = "";
                return;
            }

            GoiTap goiTapChon = (GoiTap)cboGoiTap.SelectedItem;

            txtGiaTien.Text = goiTapChon.Gia.ToString("N0") + " VNĐ";
            txtThoiHan.Text = goiTapChon.ThoiHan.ToString() + " tháng";

            TinhNgayHetHan();
        }

        private void dtpNgayDangKy_ValueChanged(object sender, EventArgs e)
        {
            TinhNgayHetHan();
        }

        private void TinhNgayHetHan()
        {
            if (cboGoiTap.SelectedItem == null)
            {
                txtNgayHetHan.Text = "";
                return;
            }

            int soThang = ((GoiTap)cboGoiTap.SelectedItem).ThoiHan;

            DateTime ngayBatDau = dtpNgayDangKy.Value.Date;

            DateTime ngayHetHan = ngayBatDau.AddMonths(soThang);

            txtNgayHetHan.Text = ngayHetHan.ToString("dd/MM/yyyy");
        }



        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboGoiTap.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một gói tập.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            GoiTap goiTapChon = (GoiTap)cboGoiTap.SelectedItem;
            DateTime ngayDangKy = dtpNgayDangKy.Value.Date;
            DateTime ngayHetHan = ngayDangKy.AddMonths(goiTapChon.ThoiHan);

            ThanhVienGoiTap tvgt = new ThanhVienGoiTap
            {
                TV_Ma = this._currentMaTV,
                GT_Ma = goiTapChon.Ma,
                NgayDangKy = ngayDangKy,
                NgayHetHan = ngayHetHan,
                TrangThai = "Còn hiệu lực",
                CN_Ma = Session.MaChiNhanh 
            };

            try
            {
                int result = tvgtDAL.AddThanhVienGoiTap(tvgt);

                if (result > 0)
                {
                    MessageBox.Show("Đăng ký gói tập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (result == 0)
                {
                    this.DialogResult = DialogResult.None; 
                }
                else
                {
                    this.DialogResult = DialogResult.None; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nghiêm trọng khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
