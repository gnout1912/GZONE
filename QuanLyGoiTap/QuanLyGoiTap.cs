using GZone.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GZone
{
    public partial class QuanLyGoiTap : Form
    {
        private GoiTapDAL _goiTapDAL;
        public QuanLyGoiTap()
        {
            InitializeComponent();
            _goiTapDAL = new GoiTapDAL();
            dgvDSGoiTap.AutoGenerateColumns = false;
        }
        private void QuanLyGoiTap_Load(object sender, EventArgs e)
        {
            LoadDataGoiTap();
        }
        private void LoadDataGoiTap()
        {
            List<GoiTap> danhSachGoiTap = _goiTapDAL.GetAllGoiTap();
            dgvDSGoiTap.DataSource = danhSachGoiTap;

            for (int i = 0; i < dgvDSGoiTap.Rows.Count; i++)
            {
                dgvDSGoiTap.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void btnThemGT_Click(object sender, EventArgs e)
        {
            frmThemGoiTap themGoiTapForm = new frmThemGoiTap();

           themGoiTapForm.ShowDialog();
            if (themGoiTapForm.DialogResult == DialogResult.OK)
            {
                LoadDataGoiTap();
            }
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc là muốn xóa tất cả gói tập không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _goiTapDAL.DeleteAllGoiTap();
                LoadDataGoiTap();
            }
            else
            {
                return;
            }
        }

        private void dgvDSGoiTap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            string colName = dgvDSGoiTap.Columns[e.ColumnIndex].Name;

            GoiTap selectedGoiTap = dgvDSGoiTap.Rows[e.RowIndex].DataBoundItem as GoiTap;

            if (selectedGoiTap != null)
            {
                if (colName == "colChinhSua")
                {
                   ChinhSuaGoiTapForm frmChinhSua = new ChinhSuaGoiTapForm(selectedGoiTap);
                    frmChinhSua.ShowDialog();
                    if (frmChinhSua.DialogResult == DialogResult.OK)
                    {
                        LoadDataGoiTap();
                    }
                }
                else if (colName == "colXoaGoiTap")
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc là muốn xóa gói tập này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        _goiTapDAL.DeleteGoiTapByMa(selectedGoiTap.Ma);
                        LoadDataGoiTap();
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}
