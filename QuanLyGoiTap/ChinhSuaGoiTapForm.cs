using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GZone.models;

namespace GZone
{
    public partial class ChinhSuaGoiTapForm : Form
    {
        private GoiTap _goiTapCanSua;
        private GoiTapDAL _goiTapDAL;
        public ChinhSuaGoiTapForm(GoiTap goiTap)
        {
            InitializeComponent();
            _goiTapCanSua = goiTap;
            _goiTapDAL = new GoiTapDAL();
        }

        private void ChinhSuaGoiTapForm_Load(object sender, EventArgs e)
        {
            txtTenGoiTap.Text = _goiTapCanSua.Ten;
            numGia.Value = _goiTapCanSua.Gia;
            numThoiHan.Value = _goiTapCanSua.ThoiHan;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenMoi = txtTenGoiTap.Text.Trim();
            decimal giaMoi = numGia.Value;
            int thoiHanMoi = (int)numThoiHan.Value;

            if (string.IsNullOrEmpty(tenMoi))
            {
                MessageBox.Show("Tên gói tập không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _goiTapCanSua.Ten = tenMoi;
            _goiTapCanSua.Gia = giaMoi;
            _goiTapCanSua.ThoiHan = thoiHanMoi;

            bool result = _goiTapDAL.UpdateGoiTap(_goiTapCanSua);  
            if (result)
            {
                MessageBox.Show("Cập nhật gói tập thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật gói tập thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy chỉnh sửa gói tập?","Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                {
                    this.Close();
                }
        }
    }
}
