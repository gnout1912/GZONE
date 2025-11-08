using GZone.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            if (clsDatabase.OpenConnection())
            {
                MessageBox.Show("✅ Kết nối đến SQL Server thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsDatabase.CloseConnection();
            }
            else
            {
                MessageBox.Show("❌ Không thể kết nối đến SQL Server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Ngừng thực hiện nếu không kết nối được
            }

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
    }
}
