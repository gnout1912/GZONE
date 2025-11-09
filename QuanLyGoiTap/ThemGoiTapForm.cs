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

namespace GZone
{
    public partial class frmThemGoiTap : Form
    {
        public frmThemGoiTap()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenGoiTap = txtGoiTap.Text.Trim();
            decimal gia = numGia.Value;
            int thoiHan = (int)numThoiHan.Value;
            string maGoiTap = "";
            if(string.IsNullOrEmpty(tenGoiTap))
            {
                MessageBox.Show("Vui lòng nhập tên gói tập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GoiTapDAL goiTapDAL = new GoiTapDAL();
            maGoiTap = goiTapDAL.getNewMaGoiTap();
            GoiTap goiTap = new GoiTap
            {   
                Ma = maGoiTap,
                Ten = tenGoiTap,
                Gia = gia,
                ThoiHan = thoiHan
            };

            int result = goiTapDAL.AddGoiTap(goiTap);
            if (result > 0)
            {
                MessageBox.Show("Thêm gói tập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm gói tập thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy thêm gói tập?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }

        }
    }
 }
